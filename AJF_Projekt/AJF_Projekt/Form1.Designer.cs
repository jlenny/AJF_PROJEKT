namespace AJF_Projekt
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
            this.bOtworz = new System.Windows.Forms.Button();
            this.l_Sciezka_NDAS = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.l_Stan_koncowy = new System.Windows.Forms.Label();
            this.l_Stan_poczatkowy = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bOtworz
            // 
            this.bOtworz.Location = new System.Drawing.Point(9, 109);
            this.bOtworz.Name = "bOtworz";
            this.bOtworz.Size = new System.Drawing.Size(75, 23);
            this.bOtworz.TabIndex = 0;
            this.bOtworz.Text = "Otwórz plik";
            this.bOtworz.UseVisualStyleBackColor = true;
            this.bOtworz.Click += new System.EventHandler(this.bOtworz_Click);
            // 
            // l_Sciezka_NDAS
            // 
            this.l_Sciezka_NDAS.AutoSize = true;
            this.l_Sciezka_NDAS.Location = new System.Drawing.Point(6, 16);
            this.l_Sciezka_NDAS.Name = "l_Sciezka_NDAS";
            this.l_Sciezka_NDAS.Size = new System.Drawing.Size(48, 13);
            this.l_Sciezka_NDAS.TabIndex = 1;
            this.l_Sciezka_NDAS.Text = "Ścieżka:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Plik tekstowy *.txt|*.txt";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.l_Stan_koncowy);
            this.groupBox1.Controls.Add(this.l_Stan_poczatkowy);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.bOtworz);
            this.groupBox1.Controls.Add(this.l_Sciezka_NDAS);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 138);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NDAS";
            // 
            // l_Stan_koncowy
            // 
            this.l_Stan_koncowy.AutoSize = true;
            this.l_Stan_koncowy.Location = new System.Drawing.Point(6, 59);
            this.l_Stan_koncowy.Name = "l_Stan_koncowy";
            this.l_Stan_koncowy.Size = new System.Drawing.Size(89, 13);
            this.l_Stan_koncowy.TabIndex = 4;
            this.l_Stan_koncowy.Text = "Stan(y) końcowy:";
            // 
            // l_Stan_poczatkowy
            // 
            this.l_Stan_poczatkowy.AutoSize = true;
            this.l_Stan_poczatkowy.Location = new System.Drawing.Point(6, 37);
            this.l_Stan_poczatkowy.Name = "l_Stan_poczatkowy";
            this.l_Stan_poczatkowy.Size = new System.Drawing.Size(92, 13);
            this.l_Stan_poczatkowy.TabIndex = 3;
            this.l_Stan_poczatkowy.Text = "Stan początkowy:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(266, 37);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 2;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(284, 193);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 160);
            this.listBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "PowerSet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(284, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "DAS_Algorytm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 636);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AJF Projekt - zad 2, Piotr Nowak - Kamila Trzeciak";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bOtworz;
        private System.Windows.Forms.Label l_Sciezka_NDAS;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label l_Stan_koncowy;
        private System.Windows.Forms.Label l_Stan_poczatkowy;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

