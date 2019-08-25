using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BE {

    public enum UsuarioTipo
    {
        Emplado = 1,
        Cliente = 2        
    };

    public class UsuarioBE {

        public int Id { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }
        public UsuarioTipo tipo { get; set; }
        public DateTime fecAlta { get; set; }
        public Boolean activo { get; set; }

        public UsuarioBE() { }
        public UsuarioBE(int id)
        {
            this.Id = Id;
        }
	}

}