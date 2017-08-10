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

namespace RSAKeyGenerate
{
    public partial class RSAKeyGenerate : Form
    {
        public RSAKeyGenerate()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            string publickey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);


            byte[] privateKeyBytes = Encoding.UTF8.GetBytes(privateKey);
            txtPrivateKey.Text = Convert.ToBase64String(privateKeyBytes);


            byte[] publicKeyBytes = Encoding.UTF8.GetBytes(publickey);
            txtPublicKey.Text = Convert.ToBase64String(publicKeyBytes);
        }
    }
}
