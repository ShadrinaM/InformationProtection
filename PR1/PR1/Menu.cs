using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }


        private void buttonRSA_Click(object sender, EventArgs e)
        {
            RSA rsa = new RSA();
            rsa.ShowDialog();
        }

        private void buttonABKP_Click(object sender, EventArgs e)
        {
            ABKP abkp = new ABKP();
            abkp.Show();
        }

        private void buttonМВКР_Click(object sender, EventArgs e)
        {
            MVKR MVKR = new MVKR();
            MVKR.Show();
        }

        private void buttonGAKP_Click(object sender, EventArgs e)
        {
            GAKP GAKP = new GAKP();
            GAKP.Show();
        }

        private void buttonGMKP_Click(object sender, EventArgs e)
        {
            GMKP GMKP = new GMKP();
            GMKP.Show();
        }

        private void buttonHammingCode_Click(object sender, EventArgs e)
        {
            Hamming Hamming = new Hamming();
            Hamming.Show();
        }
    }
}
