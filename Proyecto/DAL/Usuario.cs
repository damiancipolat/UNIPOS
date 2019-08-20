using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class Usuario
    {        
        public static BE.Usuario Obtener(int pId)
        {
            string mCommandText = "select id,document,tipo_usuario,activo,fecha_alta from usuario where id="+pId+";";

            DAO mDAO = new DAO();

            DataSet mDs = mDAO.ExecuteDataSet(mCommandText);

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                BE.Usuario mPersona = new BE.Usuario();
                mPersona.Id = int.Parse(mDs.Tables[0].Rows[0].ToString());
                mPersona.Document = mDs.Tables[0].Rows[1].ToString();
                mPersona.tipo = BE.UsuarioTipo.Cliente;
                mPersona.activo = Boolean.Parse(mDs.Tables[0].Rows[3].ToString());
                mPersona.fecAlta = DateTime.Parse(mDs.Tables[0].Rows[0].ToString());
                
                return mPersona;
            }
            else
            {
                return null;
            }

        }
        public static int Eliminar(BE.Usuario pUsuario)
        {
            string mCommandText = "update usuario set activo='false' where id = " + pUsuario.Id+";";
            DAO mDao = new DAO();
            return mDao.ExecuteNonQuery(mCommandText);
        }

        public static int Agregar(BE.Usuario pUsuario)
        {
            string sql = "insert into usuario(document,pwd,tipo_usuario,activo,fecha_alta) values(@document,@pwd,@tipoUser,@activo,@fecha);";

            DAO mDao = new DAO();

            return mDao.ExecuteNonQueryWithParams(sql, new List<SqlParameter> {
                mDao.CreateParameter("document", SqlDbType.VarChar, pUsuario.Document),
                mDao.CreateParameter("pwd", SqlDbType.VarChar, pUsuario.Password),
                mDao.CreateParameter("tipoUser", SqlDbType.VarChar, pUsuario.tipo),
                mDao.CreateParameter("activo", SqlDbType.VarChar, "true"),
                mDao.CreateParameter("fecha", SqlDbType.DateTime, new DateTime())
            });
        }

        public static int Actualizar(BE.Usuario pUsuario)
        {
            string sql = "update usuario set pwd=@pwd,document=@document,tipo_usuario=@tipoUser,activo=@activo,fecha_alta=@fecha where id = @id;";

            DAO mDao = new DAO();

            return mDao.ExecuteNonQueryWithParams(sql, new List<SqlParameter> {
                mDao.CreateParameter("document", SqlDbType.VarChar, pUsuario.Document),
                mDao.CreateParameter("pwd", SqlDbType.VarChar, pUsuario.Password),
                mDao.CreateParameter("tipoUser", SqlDbType.VarChar, pUsuario.tipo),
                mDao.CreateParameter("activo", SqlDbType.VarChar, pUsuario.activo),
                mDao.CreateParameter("fecha", SqlDbType.DateTime, pUsuario.fecAlta)
            });
        }

    }
}