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
            this.btnReplaceEmpty = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.txtReplaceWith = new System.Windows.Forms.TextBox();
            this.txtReplaceEmpty = new System.Windows.Forms.TextBox();
            this.txtReplaceNonEmpty = new System.Windows.Forms.TextBox();
            this.btnReplaceNonEmpty = new System.Windows.Forms.Button();
            this.btnMoveColumnLast = new System.Windows.Forms.Button();
            this.btnSplitText = new System.Windows.Forms.Button();
            this.txtSplitSeparator = new System.Windows.Forms.TextBox();
            this.btnRenameHeader = new System.Windows.Forms.Button();
            this.txtRenameHeader = new System.Windows.Forms.TextBox();
            this.btnSaveAsInput = new System.Windows.Forms.Button();
            this.btnToInt = new System.Windows.Forms.Button();
            this.chkDoubleMeansQuotes = new System.Windows.Forms.CheckBox();
            this.rdoPoint = new System.Windows.Forms.RadioButton();
            this.rdoComma = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.txtResult.Location = new System.Drawing.Point(12, 69);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(292, 140);
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
            this.lstHeaders.Size = new System.Drawing.Size(752, 394);
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
            // btnReplaceEmpty
            // 
            this.btnReplaceEmpty.Location = new System.Drawing.Point(12, 273);
            this.btnReplaceEmpty.Name = "btnReplaceEmpty";
            this.btnReplaceEmpty.Size = new System.Drawing.Size(186, 23);
            this.btnReplaceEmpty.TabIndex = 8;
            this.btnReplaceEmpty.Text = "ReplaceEmpty";
            this.btnReplaceEmpty.UseVisualStyleBackColor = true;
            this.btnReplaceEmpty.Click += new System.EventHandler(this.btnReplaceEmpty_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(12, 331);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(80, 23);
            this.btnReplace.TabIndex = 9;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(98, 334);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(100, 20);
            this.txtReplace.TabIndex = 10;
            this.txtReplace.Text = "NULL";
            // 
            // txtReplaceWith
            // 
            this.txtReplaceWith.Location = new System.Drawing.Point(204, 334);
            this.txtReplaceWith.Name = "txtReplaceWith";
            this.txtReplaceWith.Size = new System.Drawing.Size(100, 20);
            this.txtReplaceWith.TabIndex = 11;
            this.txtReplaceWith.Text = "empty";
            // 
            // txtReplaceEmpty
            // 
            this.txtReplaceEmpty.Location = new System.Drawing.Point(204, 275);
            this.txtReplaceEmpty.Name = "txtReplaceEmpty";
            this.txtReplaceEmpty.Size = new System.Drawing.Size(100, 20);
            this.txtReplaceEmpty.TabIndex = 12;
            this.txtReplaceEmpty.Text = "empty";
            // 
            // txtReplaceNonEmpty
            // 
            this.txtReplaceNonEmpty.Location = new System.Drawing.Point(204, 304);
            this.txtReplaceNonEmpty.Name = "txtReplaceNonEmpty";
            this.txtReplaceNonEmpty.Size = new System.Drawing.Size(100, 20);
            this.txtReplaceNonEmpty.TabIndex = 14;
            this.txtReplaceNonEmpty.Text = "Set";
            // 
            // btnReplaceNonEmpty
            // 
            this.btnReplaceNonEmpty.Location = new System.Drawing.Point(12, 302);
            this.btnReplaceNonEmpty.Name = "btnReplaceNonEmpty";
            this.btnReplaceNonEmpty.Size = new System.Drawing.Size(186, 23);
            this.btnReplaceNonEmpty.TabIndex = 13;
            this.btnReplaceNonEmpty.Text = "Replace non-Empty";
            this.btnReplaceNonEmpty.UseVisualStyleBackColor = true;
            this.btnReplaceNonEmpty.Click += new System.EventHandler(this.btnReplaceNonEmpty_Click);
            // 
            // btnMoveColumnLast
            // 
            this.btnMoveColumnLast.Location = new System.Drawing.Point(12, 444);
            this.btnMoveColumnLast.Name = "btnMoveColumnLast";
            this.btnMoveColumnLast.Size = new System.Drawing.Size(142, 23);
            this.btnMoveColumnLast.TabIndex = 15;
            this.btnMoveColumnLast.Text = "Move column last";
            this.btnMoveColumnLast.UseVisualStyleBackColor = true;
            this.btnMoveColumnLast.Click += new System.EventHandler(this.btnMoveColumnLast_Click);
            // 
            // btnSplitText
            // 
            this.btnSplitText.Location = new System.Drawing.Point(12, 386);
            this.btnSplitText.Name = "btnSplitText";
            this.btnSplitText.Size = new System.Drawing.Size(186, 23);
            this.btnSplitText.TabIndex = 16;
            this.btnSplitText.Text = "Split text on separator";
            this.btnSplitText.UseVisualStyleBackColor = true;
            this.btnSplitText.Click += new System.EventHandler(this.btnSplitText_Click);
            // 
            // txtSplitSeparator
            // 
            this.txtSplitSeparator.Location = new System.Drawing.Point(204, 388);
            this.txtSplitSeparator.Name = "txtSplitSeparator";
            this.txtSplitSeparator.Size = new System.Drawing.Size(100, 20);
            this.txtSplitSeparator.TabIndex = 17;
            this.txtSplitSeparator.Text = ";";
            // 
            // btnRenameHeader
            // 
            this.btnRenameHeader.Location = new System.Drawing.Point(12, 360);
            this.btnRenameHeader.Name = "btnRenameHeader";
            this.btnRenameHeader.Size = new System.Drawing.Size(186, 23);
            this.btnRenameHeader.TabIndex = 18;
            this.btnRenameHeader.Text = "Rename header";
            this.btnRenameHeader.UseVisualStyleBackColor = true;
            this.btnRenameHeader.Click += new System.EventHandler(this.btnRenameHeader_Click);
            // 
            // txtRenameHeader
            // 
            this.txtRenameHeader.Location = new System.Drawing.Point(204, 362);
            this.txtRenameHeader.Name = "txtRenameHeader";
            this.txtRenameHeader.Size = new System.Drawing.Size(100, 20);
            this.txtRenameHeader.TabIndex = 19;
            this.txtRenameHeader.Text = "newHeader";
            // 
            // btnSaveAsInput
            // 
            this.btnSaveAsInput.Location = new System.Drawing.Point(12, 40);
            this.btnSaveAsInput.Name = "btnSaveAsInput";
            this.btnSaveAsInput.Size = new System.Drawing.Size(292, 23);
            this.btnSaveAsInput.TabIndex = 20;
            this.btnSaveAsInput.Text = "Save as input file (tab separated, .txt)";
            this.btnSaveAsInput.UseVisualStyleBackColor = true;
            this.btnSaveAsInput.Click += new System.EventHandler(this.btnSaveAsInput_Click);
            // 
            // btnToInt
            // 
            this.btnToInt.Location = new System.Drawing.Point(12, 415);
            this.btnToInt.Name = "btnToInt";
            this.btnToInt.Size = new System.Drawing.Size(186, 23);
            this.btnToInt.TabIndex = 21;
            this.btnToInt.Text = "Round decimals to integers";
            this.btnToInt.UseVisualStyleBackColor = true;
            this.btnToInt.Click += new System.EventHandler(this.btnToInt_Click);
            // 
            // chkDoubleMeansQuotes
            // 
            this.chkDoubleMeansQuotes.AutoSize = true;
            this.chkDoubleMeansQuotes.Checked = true;
            this.chkDoubleMeansQuotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoubleMeansQuotes.Location = new System.Drawing.Point(748, 16);
            this.chkDoubleMeansQuotes.Name = "chkDoubleMeansQuotes";
            this.chkDoubleMeansQuotes.Size = new System.Drawing.Size(143, 17);
            this.chkDoubleMeansQuotes.TabIndex = 22;
            this.chkDoubleMeansQuotes.Text = "Save double with quotes";
            this.chkDoubleMeansQuotes.UseVisualStyleBackColor = true;
            // 
            // rdoPoint
            // 
            this.rdoPoint.AutoSize = true;
            this.rdoPoint.Checked = true;
            this.rdoPoint.Location = new System.Drawing.Point(310, 454);
            this.rdoPoint.Name = "rdoPoint";
            this.rdoPoint.Size = new System.Drawing.Size(248, 17);
            this.rdoPoint.TabIndex = 23;
            this.rdoPoint.TabStop = true;
            this.rdoPoint.Text = "Weka & Azure ML Studio (use . as float delimiter)";
            this.rdoPoint.UseVisualStyleBackColor = true;
            // 
            // rdoComma
            // 
            this.rdoComma.AutoSize = true;
            this.rdoComma.Location = new System.Drawing.Point(577, 454);
            this.rdoComma.Name = "rdoComma";
            this.rdoComma.Size = new System.Drawing.Size(161, 17);
            this.rdoComma.TabIndex = 24;
            this.rdoComma.Text = "Other (use , as float delimiter)";
            this.rdoComma.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(574, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "; required for azue ML & Weka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(574, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = ", default after Excel export";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Decimal delimiter setting:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 482);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoComma);
            this.Controls.Add(this.rdoPoint);
            this.Controls.Add(this.chkDoubleMeansQuotes);
            this.Controls.Add(this.btnToInt);
            this.Controls.Add(this.btnSaveAsInput);
            this.Controls.Add(this.txtRenameHeader);
            this.Controls.Add(this.btnRenameHeader);
            this.Controls.Add(this.txtSplitSeparator);
            this.Controls.Add(this.btnSplitText);
            this.Controls.Add(this.btnMoveColumnLast);
            this.Controls.Add(this.txtReplaceNonEmpty);
            this.Controls.Add(this.btnReplaceNonEmpty);
            this.Controls.Add(this.txtReplaceEmpty);
            this.Controls.Add(this.txtReplaceWith);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnReplaceEmpty);
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
        private System.Windows.Forms.Button btnReplaceEmpty;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.TextBox txtReplaceWith;
        private System.Windows.Forms.TextBox txtReplaceEmpty;
        private System.Windows.Forms.TextBox txtReplaceNonEmpty;
        private System.Windows.Forms.Button btnReplaceNonEmpty;
        private System.Windows.Forms.Button btnMoveColumnLast;
        private System.Windows.Forms.Button btnSplitText;
        private System.Windows.Forms.TextBox txtSplitSeparator;
        private System.Windows.Forms.Button btnRenameHeader;
        private System.Windows.Forms.TextBox txtRenameHeader;
        private System.Windows.Forms.Button btnSaveAsInput;
        private System.Windows.Forms.Button btnToInt;
        private System.Windows.Forms.CheckBox chkDoubleMeansQuotes;
        private System.Windows.Forms.RadioButton rdoPoint;
        private System.Windows.Forms.RadioButton rdoComma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

