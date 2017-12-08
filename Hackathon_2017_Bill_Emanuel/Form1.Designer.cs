namespace Hackathon_2017_Bill_Emanuel
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
            this.btnImport = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtOutFile = new System.Windows.Forms.TextBox();
            this.lstHeaders = new System.Windows.Forms.ListBox();
            this.txtSeparator = new System.Windows.Forms.TextBox();
            this.btnColumnRemove = new System.Windows.Forms.Button();
            this.btnColDateToYearMonth = new System.Windows.Forms.Button();
            this.btnSomething = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(142, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import xls";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 41);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(292, 168);
            this.txtResult.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(458, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtOutFile
            // 
            this.txtOutFile.Location = new System.Drawing.Point(160, 14);
            this.txtOutFile.Name = "txtOutFile";
            this.txtOutFile.Size = new System.Drawing.Size(292, 20);
            this.txtOutFile.TabIndex = 3;
            this.txtOutFile.Text = "C:\\tmp\\output.csv";
            // 
            // lstHeaders
            // 
            this.lstHeaders.Location = new System.Drawing.Point(310, 41);
            this.lstHeaders.Name = "lstHeaders";
            this.lstHeaders.ScrollAlwaysVisible = true;
            this.lstHeaders.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstHeaders.Size = new System.Drawing.Size(558, 368);
            this.lstHeaders.TabIndex = 4;
            // 
            // txtSeparator
            // 
            this.txtSeparator.Location = new System.Drawing.Point(539, 14);
            this.txtSeparator.Name = "txtSeparator";
            this.txtSeparator.Size = new System.Drawing.Size(29, 20);
            this.txtSeparator.TabIndex = 5;
            this.txtSeparator.Text = ",";
            // 
            // btnColumnRemove
            // 
            this.btnColumnRemove.Location = new System.Drawing.Point(12, 215);
            this.btnColumnRemove.Name = "btnColumnRemove";
            this.btnColumnRemove.Size = new System.Drawing.Size(292, 23);
            this.btnColumnRemove.TabIndex = 6;
            this.btnColumnRemove.Text = "Remove column";
            this.btnColumnRemove.UseVisualStyleBackColor = true;
            this.btnColumnRemove.Click += new System.EventHandler(this.btnColumnRemove_Click);
            // 
            // btnColDateToYearMonth
            // 
            this.btnColDateToYearMonth.Location = new System.Drawing.Point(12, 244);
            this.btnColDateToYearMonth.Name = "btnColDateToYearMonth";
            this.btnColDateToYearMonth.Size = new System.Drawing.Size(292, 23);
            this.btnColDateToYearMonth.TabIndex = 7;
            this.btnColDateToYearMonth.Text = "Date to year-month-day cols";
            this.btnColDateToYearMonth.UseVisualStyleBackColor = true;
            this.btnColDateToYearMonth.Click += new System.EventHandler(this.btnColDateToYearMonth_Click);
            // 
            // btnSomething
            // 
            this.btnSomething.Location = new System.Drawing.Point(12, 273);
            this.btnSomething.Name = "btnSomething";
            this.btnSomething.Size = new System.Drawing.Size(292, 23);
            this.btnSomething.TabIndex = 8;
            this.btnSomething.Text = "button3";
            this.btnSomething.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 422);
            this.Controls.Add(this.btnSomething);
            this.Controls.Add(this.btnColDateToYearMonth);
            this.Controls.Add(this.btnColumnRemove);
            this.Controls.Add(this.txtSeparator);
            this.Controls.Add(this.lstHeaders);
            this.Controls.Add(this.txtOutFile);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnImport);
            this.Name = "Form1";
            this.Text = "Tabbed .txt to .csv";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtOutFile;
        private System.Windows.Forms.ListBox lstHeaders;
        private System.Windows.Forms.TextBox txtSeparator;
        private System.Windows.Forms.Button btnColumnRemove;
        private System.Windows.Forms.Button btnColDateToYearMonth;
        private System.Windows.Forms.Button btnSomething;
    }
}

