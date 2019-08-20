using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BE {
	public class Empleado : Usuario {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FecNac { get; set; }
    }

}