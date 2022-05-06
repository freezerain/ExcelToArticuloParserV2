using ExcelToArticuloParserV2.BackgroundWorker;
using ExcelToArticuloParserV2.Utility;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using a3ERPActiveX;

namespace ExcelToArticuloParserV2
{
    public partial class Form1 : Form
    {
        private readonly BindingSource articlesBinding = new BindingSource();
        private readonly FormStateMachine _viewModel;
        private Enlace _enlace;

        public Form1()
        {
            InitializeComponent();
            _viewModel = new FormStateMachine(this);
        }

        private async void fileSelectBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _viewModel.fileStart();
                string fileName = fileDialog.FileName;
                CancellationToken token = new CancellationTokenSource().Token;
                articlesBinding.DataSource = await new ExcelParser(fileName).GetArticleListAsync(token);
                _viewModel.fileEnd(fileName);
            }
        }

        private async void empresaSelectBtn_Click(object sender, EventArgs e)
        {
            if (_enlace == null) _enlace = new Enlace();
            if (await Task.Run(()=>_enlace.SelecEmpresa())) 
                _viewModel.companySelected(_enlace.EmpresaActiva);
        }

        private async void startBtn_Click(object sender, EventArgs e)
        {
            _viewModel.UploadingState(true);
            IProgress<int> progress = new Progress<int>(
                i=> startStatusText.Text = $"Progreso: {i+1} / {articlesBinding.Count}");
            await Task.Run(()=>DBLoader.UploadToDB(articlesBinding, _enlace, progress));
            startStatusText.Text = "Actualizacion acabada";
            _viewModel.UploadingState(false);
            _viewModel.FinishReport(articlesBinding);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = articlesBinding;
        }
        
        //close connection on deconstruct
        ~Form1()
        {
            _enlace?.Acabar();
        }

    }
}