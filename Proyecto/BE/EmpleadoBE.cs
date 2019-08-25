using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BE {
	public class EmpleadoBE : UsuarioBE {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FecNac { get; set; }        
        public int parentId { get; set; }

        public EmpleadoBE(){}

        public EmpleadoBE(UsuarioBE user)
        {
            base.Id = user.Id;
            base.Password = user.Password;
            base.Document = user.Document;
            base.activo = user.activo;
            base.fecAlta = user.fecAlta;
            base.tipo = user.tipo;
        }

    }

}