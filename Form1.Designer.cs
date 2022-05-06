using System.Windows.Forms;

namespace ExcelToArticuloParserV2
{
    partial class Form1 : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileSelectBtn = new System.Windows.Forms.Button();
            this.fileSelectText = new System.Windows.Forms.Label();
            this.empresaSelectBtn = new System.Windows.Forms.Button();
            this.empresaSelectText = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.startStatusText = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.helpBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSelectBtn
            // 
            this.fileSelectBtn.Location = new System.Drawing.Point(12, 10);
            this.fileSelectBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileSelectBtn.Name = "fileSelectBtn";
            this.fileSelectBtn.Size = new System.Drawing.Size(183, 26);
            this.fileSelectBtn.TabIndex = 0;
            this.fileSelectBtn.Text = "1. Elegir fichero...";
            this.fileSelectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fileSelectBtn.UseVisualStyleBackColor = true;
            this.fileSelectBtn.Click += new System.EventHandler(this.fileSelectBtn_Click);
            // 
            // fileSelectText
            // 
            this.fileSelectText.AutoSize = true;
            this.fileSelectText.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.fileSelectText.Location = new System.Drawing.Point(201, 13);
            this.fileSelectText.Name = "fileSelectText";
            this.fileSelectText.Size = new System.Drawing.Size(244, 23);
            this.fileSelectText.TabIndex = 1;
            this.fileSelectText.Text = "Por favor elige un fichero Excel";
            // 
            // empresaSelectBtn
            // 
            this.empresaSelectBtn.Location = new System.Drawing.Point(12, 41);
            this.empresaSelectBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.empresaSelectBtn.Name = "empresaSelectBtn";
            this.empresaSelectBtn.Size = new System.Drawing.Size(183, 26);
            this.empresaSelectBtn.TabIndex = 2;
            this.empresaSelectBtn.Text = "2. Elegir empresa...";
            this.empresaSelectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.empresaSelectBtn.UseVisualStyleBackColor = true;
            this.empresaSelectBtn.Click += new System.EventHandler(this.empresaSelectBtn_Click);
            // 
            // empresaSelectText
            // 
            this.empresaSelectText.AutoSize = true;
            this.empresaSelectText.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.empresaSelectText.Location = new System.Drawing.Point(201, 44);
            this.empresaSelectText.Name = "empresaSelectText";
            this.empresaSelectText.Size = new System.Drawing.Size(228, 23);
            this.empresaSelectText.TabIndex = 3;
            this.empresaSelectText.Text = "Por favor elige una empresa ";
            // 
            // startBtn
            // 
            this.startBtn.Enabled = false;
            this.startBtn.Location = new System.Drawing.Point(12, 72);
            this.startBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(183, 26);
            this.startBtn.TabIndex = 4;
            this.startBtn.Text = "3. Iniciar la actualización";
            this.startBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // startStatusText
            // 
            this.startStatusText.AutoSize = true;
            this.startStatusText.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.startStatusText.Location = new System.Drawing.Point(201, 75);
            this.startStatusText.Name = "startStatusText";
            this.startStatusText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startStatusText.Size = new System.Drawing.Size(239, 23);
            this.startStatusText.TabIndex = 5;
            this.startStatusText.Text = "Complete los pasos anteriores";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 103);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(959, 277);
            this.dataGridView1.TabIndex = 6;
            // 
            // helpBtn
            // 
            this.helpBtn.Location = new System.Drawing.Point(950, 10);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(21, 23);
            this.helpBtn.TabIndex = 7;
            this.helpBtn.Text = "?";
            this.helpBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 390);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.startStatusText);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.empresaSelectText);
            this.Controls.Add(this.empresaSelectBtn);
            this.Controls.Add(this.fileSelectText);
            this.Controls.Add(this.fileSelectBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Button fileSelectBtn;
        public Label fileSelectText;
        public Button empresaSelectBtn;
        public Label empresaSelectText;
        public Button startBtn;
        public Label startStatusText;
        public DataGridView dataGridView1;
        public Button helpBtn;
    }
}