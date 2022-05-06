using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelToArticuloParserV2.Utility
{
    internal class FormStateMachine
    {
        private Form1 form;
        private bool _isFileSelected = false;
        private bool _isCompanySelected = false;
        public bool isUploadingActive = false;

        public FormStateMachine(Form1 form)
        {
            this.form = form;
        }

        internal void fileStart()
        {
            form.fileSelectBtn.Enabled = false;
            form.fileSelectText.Text = "Cargando...";
            _isFileSelected = false;
            refreshState();
        }

        internal void fileEnd(string fileName)
        {
            form.fileSelectBtn.Enabled = true;
            form.fileSelectText.Text = fileName;
            _isFileSelected = true;
            refreshState();
        }

        private void refreshState()
        {
            form.startBtn.Enabled = _isFileSelected && _isCompanySelected;
        }

        public void companySelected(string enlaceEmpresaActiva)
        {
            form.empresaSelectText.Text = enlaceEmpresaActiva;
            _isCompanySelected = true;
            refreshState();
        }

        public void UploadingState(bool isActive)
        {
            isUploadingActive = isActive;
            form.fileSelectBtn.Enabled = !isActive;
            form.empresaSelectBtn.Enabled = !isActive;
            form.startBtn.Text = isActive ? "Actualización..." : "3. Iniciar la actualización";
            form.startBtn.Enabled = !isActive;
        }

        public void FinishReport(BindingSource articlesBinding)
        {
            var list = articlesBinding.List.OfType<ArticleDTO>().ToList();
            int created = list.FindAll(a => a.ArticleStatus.Equals(ArticleDTO.ArticleStatusEnum.CREATED)).Count;
            int updated = list.FindAll(a => a.ArticleStatus.Equals(ArticleDTO.ArticleStatusEnum.UPDATED)).Count;
            int waiting = list.FindAll(a => a.ArticleStatus.Equals(ArticleDTO.ArticleStatusEnum.WAITING)).Count;
            int formatError = list.FindAll(a => a.ArticleStatus.Equals(ArticleDTO.ArticleStatusEnum.FORMAT_ERROR)).Count;
            int uploadError = list.FindAll(a => a.ArticleStatus.Equals(ArticleDTO.ArticleStatusEnum.UPLOAD_ERROR)).Count;
            MessageBox.Show($"Fin:\nCreado: {created}\nActualizado: {updated}\nTotal: {created+updated}" +
                            $"\nErrores:\nFormat error: {formatError}\nActializacion error: {uploadError}\nOmitido: {waiting}" +
                            $"\nTotal errores: {waiting+uploadError+formatError} ");
        }
    }
}