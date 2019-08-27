using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                BE.UsuarioBE user = BL.UsuarioBL.Acceder(txtDoc.Text, txtPwd.Text);

                if (user != null)
                    MessageBox.Show("Bienvenido!");
            }
            catch(Exception error)
            {
                Console.WriteLine("CCC", error.Message);
            }
        }
    }
}
