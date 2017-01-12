namespace PowerBIExcel
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.projectLable = new System.Windows.Forms.Label();
            this.projectText = new System.Windows.Forms.TextBox();
            this.queryRootLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.queryFolder = new System.Windows.Forms.TextBox();
            this.queryName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileDestination = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // projectLable
            // 
            this.projectLable.AutoSize = true;
            this.projectLable.Location = new System.Drawing.Point(13, 29);
            this.projectLable.Name = "projectLable";
            this.projectLable.Size = new System.Drawing.Size(74, 13);
            this.projectLable.TabIndex = 0;
            this.projectLable.Text = "Project Name:";
            // 
            // projectText
            // 
            this.projectText.Location = new System.Drawing.Point(105, 26);
            this.projectText.Name = "projectText";
            this.projectText.Size = new System.Drawing.Size(135, 20);
            this.projectText.TabIndex = 1;
            this.projectText.Text = "Devdiv";
            // 
            // queryRootLabel
            // 
            this.queryRootLabel.AutoSize = true;
            this.queryRootLabel.Location = new System.Drawing.Point(13, 53);
            this.queryRootLabel.Name = "queryRootLabel";
            this.queryRootLabel.Size = new System.Drawing.Size(70, 13);
            this.queryRootLabel.TabIndex = 2;
            this.queryRootLabel.Text = "Query Folder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Query Definiton :";
            // 
            // queryFolder
            // 
            this.queryFolder.Location = new System.Drawing.Point(105, 53);
            this.queryFolder.Name = "queryFolder";
            this.queryFolder.Size = new System.Drawing.Size(135, 20);
            this.queryFolder.TabIndex = 4;
            this.queryFolder.Text = "eg: My Queries";
            // 
            // queryName
            // 
            this.queryName.Location = new System.Drawing.Point(105, 79);
            this.queryName.Name = "queryName";
            this.queryName.Size = new System.Drawing.Size(135, 20);
            this.queryName.TabIndex = 5;
            this.queryName.Text = "eg: CTI Active Product Bugs";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(458, 303);
            this.dataGridView1.TabIndex = 6;
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(272, 26);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(67, 73);
            this.SubmitBtn.TabIndex = 7;
            this.SubmitBtn.Text = "ConnectedToVSO";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(355, 26);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(91, 73);
            this.buttonExcel.TabIndex = 8;
            this.buttonExcel.Text = "ExportToExcel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(13, 109);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(92, 13);
            this.fileLabel.TabIndex = 9;
            this.fileLabel.Text = "FileSaveLocation:";
            // 
            // fileDestination
            // 
            this.fileDestination.Location = new System.Drawing.Point(105, 106);
            this.fileDestination.Name = "fileDestination";
            this.fileDestination.Size = new System.Drawing.Size(122, 20);
            this.fileDestination.TabIndex = 10;
            this.fileDestination.Text = "C:\\temp";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 452);
            this.Controls.Add(this.fileDestination);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.queryName);
            this.Controls.Add(this.queryFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queryRootLabel);
            this.Controls.Add(this.projectText);
            this.Controls.Add(this.projectLable);
            this.Name = "Form1";
            this.Text = "PowerBI";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label projectLable;
        private System.Windows.Forms.TextBox projectText;
        private System.Windows.Forms.Label queryRootLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox queryFolder;
        private System.Windows.Forms.TextBox queryName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileDestination;
    }
}

