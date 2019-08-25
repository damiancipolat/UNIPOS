using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BE
{
    public class ClienteBE:UsuarioBE
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int parentId { get; set; }

        public ClienteBE() { }

        public ClienteBE(UsuarioBE user)
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