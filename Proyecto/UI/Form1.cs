using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Configuration;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BE.UsuarioBE tmp = DAL.UsuarioDAL.Obtener(1);
            tmp.Document = "33295514";
            MessageBox.Show(tmp.Id.ToString()+ " " + tmp.Document + " " + tmp.Password + " " + tmp.Tipo+""+tmp.Estado + " " + tmp.FecAlta.ToString());

            DAL.UsuarioDAL.Actualizar(tmp);
            /*
            BE.UsuarioBE nuevo1 = new BE.UsuarioBE();
            nuevo1.Document = "332955150";
            nuevo1.Password = "3629";
            nuevo1.Tipo = BE.UsuarioTipo.Emplado;
            nuevo1.Estado = BE.EstadoUsuario.Activo;
            nuevo1.FecAlta = new DateTime(2019, 8, 24);
            BL.UsuarioBL.Agregar(nuevo1);
            */

            /*
            BE.UsuarioBE nuevo1 = new BE.UsuarioBE();
            nuevo1.Document = "33295515";
            nuevo1.Password = "3629";
            nuevo1.tipo = BE.UsuarioTipo.Emplado;
            nuevo1.activo = true;
            nuevo1.fecAlta = new DateTime(2019,8,24);

            DAL.UsuarioDAL.Agregar(nuevo1);
            */

            /*
            BE.EmpleadoBE nuevo = new BE.EmpleadoBE();
            nuevo.Document = "39295515";
            nuevo.Password = "3629";
            nuevo.Nombre = "Gordon";
            nuevo.Apellido = "Shomwey";
            nuevo.Email = "aaaa@gmail.com";
            nuevo.FecNac = new DateTime(2019, 8, 24);
            nuevo.Document = "33295515";
            nuevo.Password = "33295515";

            //DAL.EmpleadoDAL.Agregar(nuevo);
            //DAL.EmpleadoDAL.Actualizar(nuevo);
            //DAL.EmpleadoDAL.Eliminar(nuevo);
            */
            /*
            BE.ClienteBE nuevo2 = new BE.ClienteBE();
            nuevo2.Document = "39295515";
            nuevo2.Password = "3629";
            nuevo2.Nombre   = "Gordon";
            nuevo2.Apellido = "Shomwey";
            nuevo2.Email    = "aaaa@gmail.com";
            nuevo2.Telefono = "1566587382";

            //DAL.ClienteDAL.Agregar(nuevo2);*/
            //BE.ClienteBE tmp3 = DAL.ClienteDAL.Obtener(1);
            //MessageBox.Show(tmp3.Id.ToString()+" "+tmp3.Nombre+" "+tmp3.Apellido+" "+tmp3.Document+" "+tmp3.Email+" "+tmp3.Telefono);

            //BE.EmpleadoBE tmp2 = DAL.EmpleadoDAL.Obtener(1);
            //MessageBox.Show(tmp2.Id.ToString()+" "+tmp2.Nombre+" "+tmp2.Apellido+" "+tmp2.Document+" "+tmp2.Email+" "+tmp2.FecNac.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(BL.Password.RandomPassword());
            
            /*
            string original = "Here is some data to encrypt!";
            byte[] encrypted = BL.Cripto.Encrypt(original);

            // Decrypt the bytes to a string. 
            string roundtrip = BL.Cripto.Decrypt(encrypted);

            //Display the original data and the decrypted data.
            Console.WriteLine("Original:   {0}", original);
            Console.WriteLine("Encrypted (b64-encode): {0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Round Trip: {0}", roundtrip);
            
            byte[] key = BL.Cripto.KeyToBytes();
            
            //string keyStr = ConfigurationManager.AppSettings["SecretKey"];
            //string keyStr = System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
            //var keyStr = ConfigurationManager.AppSettings["SecretKey"];
            //Console.WriteLine(keyStr);
            //MessageBox.Show(keyStr);
            */

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            BE.UsuarioBE user = BL.UsuarioBL.Acceder("33295215", "0000");

            if (user != null)
                MessageBox.Show(user.Document);
            else
                MessageBox.Show("Not found");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            BL.UsuarioBL.ResetPassword(1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            BL.UsuarioBL.Bloquear(1);

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            BL.UsuarioBL.Desbloquear(1);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
