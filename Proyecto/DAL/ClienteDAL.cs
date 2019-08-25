using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ClienteDAL
    {
        public static BE.ClienteBE Obtener(int pId)
        {
            string mCommandText = "select id,usuario_id,nombre,apellido,email,tel,activo from cliente where id=" + pId + ";";
            DAO mDAO = new DAO();

            DataSet mDs = mDAO.ExecuteDataSet(mCommandText);

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
                return Bind(mDs.Tables[0].Rows[0]);
            else
                return null;

        }

        public static BE.ClienteBE Bind(DataRow fila)
        {
            //Set base class attributes.
            BE.UsuarioBE userBase = DAL.UsuarioDAL.Obtener(int.Parse(fila["usuario_id"].ToString()));

            //Set class attributes.
            BE.ClienteBE mCliente = new BE.ClienteBE(userBase);

            mCliente.Id       = int.Parse(fila["Id"].ToString());
            mCliente.Nombre   = fila["nombre"].ToString();
            mCliente.Apellido = fila["apellido"].ToString();
            mCliente.Email    = fila["email"].ToString();
            mCliente.Telefono = fila["tel"].ToString();
            mCliente.activo   = Boolean.Parse(fila["activo"].ToString());

            return mCliente;
        }
 
        public static int Eliminar(BE.ClienteBE pUsuario)
        {
            string mCommandText = "update cliente set activo='false' where id = " + pUsuario.Id + ";";
            DAO mDao = new DAO();
            return mDao.ExecuteNonQuery(mCommandText);
        }
        
        public static int Agregar(BE.ClienteBE pCliente)
        {
            ///Creo su padre y lo guardo antes.
            BE.UsuarioBE baseUser = new BE.UsuarioBE();

            baseUser.Document = pCliente.Document;
            baseUser.Password = pCliente.Password;
            baseUser.fecAlta  = DateTime.Now;
            baseUser.tipo     = BE.UsuarioTipo.Cliente;
            baseUser.activo   = true;

            UsuarioDAL.Agregar(baseUser);
            
            //Guardo el Cliente.
            string sql = "insert into cliente(usuario_id, nombre, apellido, email, tel, activo) values(@userId, @name, @surname, @email, @tel, 'true');";
            DAO mDao = new DAO();

            return mDao.ExecuteNonQueryWithParams(sql, new List<SqlParameter> {
                 mDao.CreateParameter("userId", SqlDbType.Int,1),
                 mDao.CreateParameter("name", SqlDbType.VarChar,pCliente.Nombre),
                 mDao.CreateParameter("surname", SqlDbType.VarChar, pCliente.Apellido),
                 mDao.CreateParameter("email", SqlDbType.VarChar, pCliente.Email),
                 mDao.CreateParameter("tel", SqlDbType.VarChar, pCliente.Telefono)
            });

        }
        
        public static int Actualizar(BE.ClienteBE pCliente)
        {
            string sql = "update cliente set nombre=@name, surname=@surname, email=@email, tel=@tel where id = @id;";
            DAO mDao = new DAO();

            return mDao.ExecuteNonQueryWithParams(sql, new List<SqlParameter> {
                 mDao.CreateParameter("id", SqlDbType.Int,pCliente.Id),
                 mDao.CreateParameter("userId", SqlDbType.Int,1),
                 mDao.CreateParameter("name", SqlDbType.VarChar,pCliente.Nombre),
                 mDao.CreateParameter("surname", SqlDbType.VarChar, pCliente.Apellido),
                 mDao.CreateParameter("email", SqlDbType.VarChar, pCliente.Email),
                 mDao.CreateParameter("tel", SqlDbType.VarChar, pCliente.Telefono)
            });
        }

    }
}