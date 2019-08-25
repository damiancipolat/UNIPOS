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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //BE.UsuarioBE tmp = DAL.UsuarioDAL.Obtener(1);
            //MessageBox.Show(tmp.Id.ToString()+ " " + tmp.Document + " " + tmp.Password + " " + tmp.tipo+""+tmp.activo + " " + tmp.fecAlta.ToString());

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

            BE.ClienteBE nuevo2 = new BE.ClienteBE();
            nuevo2.Document = "39295515";
            nuevo2.Password = "3629";
            nuevo2.Nombre   = "Gordon";
            nuevo2.Apellido = "Shomwey";
            nuevo2.Email    = "aaaa@gmail.com";
            nuevo2.Telefono = "1566587382";

            //DAL.ClienteDAL.Agregar(nuevo2);
            BE.ClienteBE tmp3 = DAL.ClienteDAL.Obtener(4);
            MessageBox.Show(tmp3.Id.ToString()+" "+tmp3.Nombre+" "+tmp3.Apellido+" "+tmp3.Document+" "+tmp3.Email+" "+tmp3.Telefono);

            //BE.EmpleadoBE tmp2 = DAL.EmpleadoDAL.Obtener(1);
            //MessageBox.Show(tmp2.Id.ToString()+" "+tmp2.Nombre+" "+tmp2.Apellido+" "+tmp2.Document+" "+tmp2.Email+" "+tmp2.FecNac.ToString());
        }
    }
}
