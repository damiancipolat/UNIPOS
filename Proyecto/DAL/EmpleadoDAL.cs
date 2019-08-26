using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmpleadoDAL
    {
        public static BE.EmpleadoBE Obtener(int pId)
        {
            string mCommandText = "select id,usuario_id,nombre,apellido,email,fec_nac from empleado where id=" + pId + ";";
            DAO mDAO = new DAO();

            DataSet mDs = mDAO.ExecuteDataSet(mCommandText);

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
                return Bind(mDs.Tables[0].Rows[0]);
            else
                return null;

        }

        public static BE.EmpleadoBE Bind(DataRow fila)
        {
            //Set base class attributes.
            BE.UsuarioBE userBase = DAL.UsuarioDAL.Obtener(int.Parse(fila["usuario_id"].ToString()));

            //Set class attributes.
            BE.EmpleadoBE mEmpleado = new BE.EmpleadoBE(userBase);

            mEmpleado.Id       = int.Parse(fila["id"].ToString());
            mEmpleado.Nombre   = fila["nombre"].ToString();
            mEmpleado.Apellido = fila["apellido"].ToString();
            mEmpleado.Email    = fila["email"].ToString();
            mEmpleado.FecAlta  = DateTime.Parse(fila["fec_nac"].ToString());

            return mEmpleado;
        }
           
        public static int Eliminar(BE.EmpleadoBE pUsuario)
        {
            string mCommandText = "update empleado set activo='false' where id = " + pUsuario.Id + ";";
            DAO mDao = new DAO();
            return mDao.ExecuteNonQuery(mCommandText);
        }
        
        public static int Agregar(BE.EmpleadoBE pEmpleado)
        {
            ///Creo su padre y lo guardo antes.
            BE.UsuarioBE baseUser = new BE.UsuarioBE();

            baseUser.Document = pEmpleado.Document;
            baseUser.Password = pEmpleado.Password;
            baseUser.FecAlta  = DateTime.Now;
            baseUser.Tipo     = BE.UsuarioTipo.Emplado;
            baseUser.Estado   = BE.EstadoUsuario.Activo;

            UsuarioDAL.Agregar(baseUser);

            //Guardo el empleado.
            string sql = "insert into empleado(usuario_id, nombre, apellido, email, fec_nac, activo) values(@userId, @name, @surname, @email, @fecNac,'true');";
            DAO mDao   = new DAO();

            return mDao.ExecuteNonQueryWithParams(sql, new List<SqlParameter> {
                 mDao.CreateParameter("userId", SqlDbType.Int,1),
                 mDao.CreateParameter("name", SqlDbType.VarChar,pEmpleado.Nombre),
                 mDao.CreateParameter("surname", SqlDbType.VarChar, pEmpleado.Apellido),
                 mDao.CreateParameter("email", SqlDbType.VarChar, pEmpleado.Email),
                 mDao.CreateParameter("fecNac", SqlDbType.DateTime, pEmpleado.FecNac)
            });
            
        }
        
        public static int Actualizar(BE.EmpleadoBE pEmpleado)
        {            
            string sql = "update empleado set nombre=@name, apellido=@surname, email=@email, fec_nac=@fecNac where id=@id;";
            DAO mDao = new DAO();

            return mDao.ExecuteNonQueryWithParams(sql, new List<SqlParameter> {
                mDao.CreateParameter("id", SqlDbType.Int,pEmpleado.Id),
                mDao.CreateParameter("userId", SqlDbType.Int,1),
                mDao.CreateParameter("name", SqlDbType.VarChar,pEmpleado.Nombre),
                mDao.CreateParameter("surname", SqlDbType.VarChar, pEmpleado.Apellido),
                mDao.CreateParameter("email", SqlDbType.VarChar, pEmpleado.Email),
                mDao.CreateParameter("fecNac", SqlDbType.DateTime, pEmpleado.FecNac)
            });
        }

    }
}