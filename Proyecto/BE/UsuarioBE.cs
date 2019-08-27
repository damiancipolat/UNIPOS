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

    public enum EstadoUsuario
    {
        Activo     = 'A',
        Suspendido = 'S',
        Baja       = 'B'
    };

    public class UsuarioBE {

        public int Id { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }
        public EstadoUsuario Estado { get; set; }
        public UsuarioTipo Tipo { get; set; }
        public DateTime FecAlta { get; set; }
        public int Intentos { get; set; }
        public UsuarioBE() { }
        public UsuarioBE(int id)
        {
            this.Id = Id;
        }
	}

}