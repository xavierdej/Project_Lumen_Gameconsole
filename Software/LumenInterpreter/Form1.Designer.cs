namespace LumenCompiler
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
            this.inputTxt = new System.Windows.Forms.TextBox();
            this.compileBtn = new System.Windows.Forms.Button();
            this.ramLst = new System.Windows.Forms.ListBox();
            this.runBtn = new System.Windows.Forms.Button();
            this.pseudoTxt = new System.Windows.Forms.TextBox();
            this.compileProgress = new System.Windows.Forms.ProgressBar();
            this.resetBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.bytecodeView = new System.Windows.Forms.DataGridView();
            this.InstrColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Op1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Op2Header = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Op3Header = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byteView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bytecodeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.byteView)).BeginInit();
            this.SuspendLayout();
            // 
            // inputTxt
            // 
            this.inputTxt.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTxt.Location = new System.Drawing.Point(13, 13);
            this.inputTxt.Multiline = true;
            this.inputTxt.Name = "inputTxt";
            this.inputTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTxt.Size = new System.Drawing.Size(215, 439);
            this.inputTxt.TabIndex = 0;
            this.inputTxt.Text = "var a = 53\r\nvar b = a\r\nvar a = 723\r\na++\r\na--\r\na+=b\r\na-=k\r\na*=k\r\na/=b\r\na?b\r\nwhile(" +
    "b)\r\nb--\r\nvar e = 7\r\nfor(f=0,5,f++)\r\nc*=7\r\nif(c==0)\r\nc=2\r\nend\r\nend\r\nend\r\na = 11\r\n" +
    "c = a\r\na += c\r\nf = 9\r\nc -= f\r\na *= f";
            // 
            // compileBtn
            // 
            this.compileBtn.Location = new System.Drawing.Point(234, 13);
            this.compileBtn.Name = "compileBtn";
            this.compileBtn.Size = new System.Drawing.Size(122, 23);
            this.compileBtn.TabIndex = 1;
            this.compileBtn.Text = "Compile";
            this.compileBtn.UseVisualStyleBackColor = true;
            this.compileBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ramLst
            // 
            this.ramLst.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ramLst.FormattingEnabled = true;
            this.ramLst.Items.AddRange(new object[] {
            "0",
            "0",
            "0",
            "0",
            "0",
            "0",
            "0",
            "0",
            "0",
            "0",
            "0"});
            this.ramLst.Location = new System.Drawing.Point(306, 100);
            this.ramLst.Name = "ramLst";
            this.ramLst.Size = new System.Drawing.Size(49, 147);
            this.ramLst.TabIndex = 2;
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(234, 42);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(122, 23);
            this.runBtn.TabIndex = 3;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // pseudoTxt
            // 
            this.pseudoTxt.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pseudoTxt.Location = new System.Drawing.Point(362, 14);
            this.pseudoTxt.Multiline = true;
            this.pseudoTxt.Name = "pseudoTxt";
            this.pseudoTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pseudoTxt.Size = new System.Drawing.Size(102, 438);
            this.pseudoTxt.TabIndex = 4;
            this.pseudoTxt.Visible = false;
            // 
            // compileProgress
            // 
            this.compileProgress.Location = new System.Drawing.Point(-1, 576);
            this.compileProgress.Name = "compileProgress";
            this.compileProgress.Size = new System.Drawing.Size(1000, 10);
            this.compileProgress.TabIndex = 5;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(234, 71);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(122, 23);
            this.resetBtn.TabIndex = 6;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "PC",
            "SP",
            "HL",
            "R0",
            "R1",
            "R2",
            "R3",
            "R4",
            "R5",
            "R6",
            "R7"});
            this.listBox1.Location = new System.Drawing.Point(234, 100);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(67, 147);
            this.listBox1.TabIndex = 7;
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(234, 253);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(122, 199);
            this.listBox2.TabIndex = 8;
            // 
            // bytecodeView
            // 
            this.bytecodeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bytecodeView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InstrColumn,
            this.Op1Column,
            this.Op2Header,
            this.Op3Header});
            this.bytecodeView.Location = new System.Drawing.Point(362, 14);
            this.bytecodeView.Name = "bytecodeView";
            this.bytecodeView.Size = new System.Drawing.Size(310, 438);
            this.bytecodeView.TabIndex = 10;
            // 
            // InstrColumn
            // 
            this.InstrColumn.HeaderText = "Instruction";
            this.InstrColumn.Name = "InstrColumn";
            this.InstrColumn.Width = 70;
            // 
            // Op1Column
            // 
            this.Op1Column.HeaderText = "Op 1";
            this.Op1Column.Name = "Op1Column";
            this.Op1Column.Width = 60;
            // 
            // Op2Header
            // 
            this.Op2Header.HeaderText = "Op 2";
            this.Op2Header.Name = "Op2Header";
            this.Op2Header.Width = 60;
            // 
            // Op3Header
            // 
            this.Op3Header.HeaderText = "Op 3";
            this.Op3Header.Name = "Op3Header";
            this.Op3Header.Width = 60;
            // 
            // byteView
            // 
            this.byteView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.byteView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.byteView.Location = new System.Drawing.Point(678, 14);
            this.byteView.Name = "byteView";
            this.byteView.Size = new System.Drawing.Size(310, 438);
            this.byteView.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Instruction";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Op 1";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Op 2";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Op 3";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // resultTxt
            // 
            this.resultTxt.Location = new System.Drawing.Point(13, 459);
            this.resultTxt.Multiline = true;
            this.resultTxt.Name = "resultTxt";
            this.resultTxt.Size = new System.Drawing.Size(975, 111);
            this.resultTxt.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 582);
            this.Controls.Add(this.resultTxt);
            this.Controls.Add(this.byteView);
            this.Controls.Add(this.bytecodeView);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.compileProgress);
            this.Controls.Add(this.pseudoTxt);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.ramLst);
            this.Controls.Add(this.compileBtn);
            this.Controls.Add(this.inputTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.bytecodeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.byteView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTxt;
        private System.Windows.Forms.Button compileBtn;
        private System.Windows.Forms.ListBox ramLst;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.TextBox pseudoTxt;
        private System.Windows.Forms.ProgressBar compileProgress;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.DataGridView bytecodeView;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstrColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Op1Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Op2Header;
        private System.Windows.Forms.DataGridViewTextBoxColumn Op3Header;
        private System.Windows.Forms.DataGridView byteView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox resultTxt;
    }
}

