namespace PR1
{
    partial class Menu
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
            buttonRSA = new Button();
            buttonABKP = new Button();
            buttonМВКР = new Button();
            buttonGAKP = new Button();
            buttonGMKP = new Button();
            buttonHammingCode = new Button();
            SuspendLayout();
            // 
            // buttonRSA
            // 
            buttonRSA.Location = new Point(12, 14);
            buttonRSA.Name = "buttonRSA";
            buttonRSA.Size = new Size(300, 41);
            buttonRSA.TabIndex = 0;
            buttonRSA.Text = "RSA";
            buttonRSA.UseVisualStyleBackColor = true;
            buttonRSA.Click += buttonRSA_Click;
            // 
            // buttonABKP
            // 
            buttonABKP.Location = new Point(12, 61);
            buttonABKP.Name = "buttonABKP";
            buttonABKP.Size = new Size(300, 41);
            buttonABKP.TabIndex = 1;
            buttonABKP.Text = "ABKP";
            buttonABKP.UseVisualStyleBackColor = true;
            buttonABKP.Click += buttonABKP_Click;
            // 
            // buttonМВКР
            // 
            buttonМВКР.Location = new Point(12, 108);
            buttonМВКР.Name = "buttonМВКР";
            buttonМВКР.Size = new Size(300, 41);
            buttonМВКР.TabIndex = 2;
            buttonМВКР.Text = "МВКР";
            buttonМВКР.UseVisualStyleBackColor = true;
            buttonМВКР.Click += buttonМВКР_Click;
            // 
            // buttonGAKP
            // 
            buttonGAKP.Location = new Point(12, 155);
            buttonGAKP.Name = "buttonGAKP";
            buttonGAKP.Size = new Size(300, 41);
            buttonGAKP.TabIndex = 3;
            buttonGAKP.Text = "GAKP";
            buttonGAKP.UseVisualStyleBackColor = true;
            buttonGAKP.Click += buttonGAKP_Click;
            // 
            // buttonGMKP
            // 
            buttonGMKP.Location = new Point(12, 202);
            buttonGMKP.Name = "buttonGMKP";
            buttonGMKP.Size = new Size(300, 41);
            buttonGMKP.TabIndex = 4;
            buttonGMKP.Text = "GMKP";
            buttonGMKP.UseVisualStyleBackColor = true;
            buttonGMKP.Click += buttonGMKP_Click;
            // 
            // buttonHammingCode
            // 
            buttonHammingCode.Location = new Point(12, 249);
            buttonHammingCode.Name = "buttonHammingCode";
            buttonHammingCode.Size = new Size(300, 41);
            buttonHammingCode.TabIndex = 5;
            buttonHammingCode.Text = "Код Хэмминга";
            buttonHammingCode.UseVisualStyleBackColor = true;
            buttonHammingCode.Click += buttonHammingCode_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 305);
            Controls.Add(buttonHammingCode);
            Controls.Add(buttonGMKP);
            Controls.Add(buttonGAKP);
            Controls.Add(buttonМВКР);
            Controls.Add(buttonABKP);
            Controls.Add(buttonRSA);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonRSA;
        private Button buttonABKP;
        private Button buttonМВКР;
        private Button buttonGAKP;
        private Button buttonGMKP;
        private Button buttonHammingCode;
    }
}