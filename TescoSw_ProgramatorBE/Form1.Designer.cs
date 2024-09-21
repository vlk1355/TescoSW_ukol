namespace TescoSw_ProgramatorBE
{
    partial class Form1
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
            FindXML_Btn = new Button();
            ParseData_Btn = new Button();
            listView1 = new ListView();
            button1 = new Button();
            label1 = new Label();
            ModelTB = new TextBox();
            DatumTB = new TextBox();
            CenaTB = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            CenaCB = new ComboBox();
            FilterBTN = new Button();
            SuspendLayout();
            // 
            // FindXML_Btn
            // 
            FindXML_Btn.Location = new Point(135, 22);
            FindXML_Btn.Name = "FindXML_Btn";
            FindXML_Btn.Size = new Size(113, 23);
            FindXML_Btn.TabIndex = 0;
            FindXML_Btn.Text = "Find Xml";
            FindXML_Btn.UseVisualStyleBackColor = true;
            FindXML_Btn.Click += FindXML_Btn_Click;
            // 
            // ParseData_Btn
            // 
            ParseData_Btn.Location = new Point(135, 51);
            ParseData_Btn.Name = "ParseData_Btn";
            ParseData_Btn.Size = new Size(113, 23);
            ParseData_Btn.TabIndex = 1;
            ParseData_Btn.Text = "Parse Data";
            ParseData_Btn.UseVisualStyleBackColor = true;
            ParseData_Btn.Click += ParseData_Btn_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(254, 22);
            listView1.Name = "listView1";
            listView1.Size = new Size(534, 255);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // button1
            // 
            button1.Location = new Point(135, 80);
            button1.Name = "button1";
            button1.Size = new Size(113, 23);
            button1.TabIndex = 4;
            button1.Text = "Weekend Report";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 149);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 8;
            label1.Text = "Filter";
            // 
            // ModelTB
            // 
            ModelTB.Location = new Point(56, 167);
            ModelTB.Name = "ModelTB";
            ModelTB.Size = new Size(192, 23);
            ModelTB.TabIndex = 9;
            // 
            // DatumTB
            // 
            DatumTB.Location = new Point(56, 196);
            DatumTB.Name = "DatumTB";
            DatumTB.Size = new Size(192, 23);
            DatumTB.TabIndex = 10;
            // 
            // CenaTB
            // 
            CenaTB.Location = new Point(124, 225);
            CenaTB.Name = "CenaTB";
            CenaTB.Size = new Size(124, 23);
            CenaTB.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 170);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 12;
            label2.Text = "Model";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 199);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 13;
            label3.Text = "Datum";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 228);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 14;
            label4.Text = "Cena";
            // 
            // CenaCB
            // 
            CenaCB.FormattingEnabled = true;
            CenaCB.Items.AddRange(new object[] { ">", "<", "=" });
            CenaCB.Location = new Point(56, 225);
            CenaCB.Name = "CenaCB";
            CenaCB.Size = new Size(62, 23);
            CenaCB.TabIndex = 15;
            // 
            // FilterBTN
            // 
            FilterBTN.Location = new Point(173, 254);
            FilterBTN.Name = "FilterBTN";
            FilterBTN.Size = new Size(75, 23);
            FilterBTN.TabIndex = 16;
            FilterBTN.Text = "Filter";
            FilterBTN.UseVisualStyleBackColor = true;
            FilterBTN.Click += FilterBTN_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 301);
            Controls.Add(FilterBTN);
            Controls.Add(CenaCB);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(CenaTB);
            Controls.Add(DatumTB);
            Controls.Add(ModelTB);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(ParseData_Btn);
            Controls.Add(FindXML_Btn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button FindXML_Btn;
        private Button ParseData_Btn;
        private ListView listView1;
        private Button button1;
        private Label label1;
        private TextBox ModelTB;
        private TextBox DatumTB;
        private TextBox CenaTB;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox CenaCB;
        private Button FilterBTN;
    }
}
