using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class UsuarioBL
    {

        public static int Obtener(int pId)
        {
            BE.UsuarioBE tmpUser = UsuarioDAL.Obtener(pId);
            return 1;
        }

        public static int Agregar(BE.UsuarioBE pUsuario)
        {
            //Codifico el password usando un hash.
            pUsuario.Password = BL.Cripto.GetHash(pUsuario.Password);
            
            //Agregar.
            return DAL.UsuarioDAL.Agregar(pUsuario);
        }

        public static int Actualizar(BE.UsuarioBE pUsuario)
        {
            return BL.UsuarioBL.Actualizar(pUsuario);
        }

        public static int Eliminar(BE.UsuarioBE pUsuario)
        {
            return BL.UsuarioBL.Eliminar(pUsuario);
        }

        public static int ResetPassword(int pId)
        {
            BE.UsuarioBE newUser = Obtener(pId);
            return 0;
        }
    }
}
