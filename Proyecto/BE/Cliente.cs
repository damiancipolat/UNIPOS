using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BE
{
    public class Cliente:Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string telefono { get; set; }
    }
}