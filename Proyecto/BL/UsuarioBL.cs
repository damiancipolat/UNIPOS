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

        public static BE.UsuarioBE Obtener(int pId)
        {
            return UsuarioDAL.Obtener(pId);
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
            return DAL.UsuarioDAL.Actualizar(pUsuario);
        }

        public static int Eliminar(BE.UsuarioBE pUsuario)
        {
            return DAL.UsuarioDAL.Eliminar(pUsuario);
        }

        //Bloquea al usuario.
        public static int Bloquear(int pId)
        {
            BE.UsuarioBE getUser = DAL.UsuarioDAL.Obtener(pId);

            if (getUser != null)
            {
                //Setea el estado a suspendido.
                getUser.Estado = BE.EstadoUsuario.Suspendido;

                //Actualizo en la bd.
                return DAL.UsuarioDAL.Actualizar(getUser);
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
        }

        //Desbloquea al usuario.
        public static int Desbloquear(int pId)
        {
            BE.UsuarioBE getUser = DAL.UsuarioDAL.Obtener(pId);

            if (getUser != null)
            {
                //Setea el estado a suspendido.
                getUser.Estado = BE.EstadoUsuario.Activo;

                //Actualizo en la bd.
                return DAL.UsuarioDAL.Actualizar(getUser);
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
        }
        
        //Blanquea la password de un usuario seteando otra.
        public static int ResetPassword(int pId)
        {            
            BE.UsuarioBE getUser = DAL.UsuarioDAL.Obtener(pId);

            if (getUser != null)
            {
                
                //Genero un password aleatorio.
                string pwd = BL.Password.RandomPassword();

                //Guardo el password encriptado.
                getUser.Password = BL.Cripto.GetHash(pwd);

                //Actualizo en la bd.
                return DAL.UsuarioDAL.Actualizar(getUser);
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
        }

        //Acceder
        public static BE.UsuarioBE Acceder(string user, string password)
        {
            BE.UsuarioBE loginUser = DAL.UsuarioDAL.Acceder(user, password);

            //Si el login es exitoso, retorno el usuario.
            if (loginUser != null)
                return loginUser;

            //Busco el usuario por nDoc.
            BE.UsuarioBE docUser = DAL.UsuarioDAL.ObtenerPorDoc(user);
            
            //Si encuentro el usuario de ese documento intento aumentar el contador.
            if (docUser != null)
            {   
                //Si supera los intentos lo bloqueo, sino incremento en 1.
                if (docUser.Intentos >= 3)
                {
                    //Seteo estado.
                    docUser.Estado = BE.EstadoUsuario.Suspendido;

                    throw new System.ArgumentException("LOGIN_ERROR_USER_BLOQ", "original");
                }
                else                    
                    docUser.Intentos++;

                //Guardo el usuario.
                Actualizar(docUser);

                throw new System.ArgumentException("LOGIN_ERROR", "original");

            }

            return null;

        }
    }
}
