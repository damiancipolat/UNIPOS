using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioDAL
    {
        public static BE.UsuarioBE Obtener(int pId)
        {
            string mCommandText = "select id,document,tipo_usuario,activo,fecha_alta from usuario where id=" + pId + ";";

            DAO mDAO = new DAO();

            DataSet mDs = mDAO.ExecuteDataSet(mCommandText);

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
                return Bind(mDs.Tables[0].Rows[0]);
            else
                return null;

        }

        public static BE.UsuarioBE Bind(DataRow fila)
        {
            BE.UsuarioBE mPersona = new BE.UsuarioBE();

            mPersona.Id = int.Parse(fila["id"].ToString());
            mPersona.Document = fila["document"].ToString();

            if (fila["tipo_usuario"].ToString() == "1")
                mPersona.tipo = BE.UsuarioTipo.Emplado;
            else
                mPersona.tipo = BE.UsuarioTipo.Cliente;

            mPersona.activo = Boolean.Parse(fila["activo"].ToString());
            mPersona.fecAlta = DateTime.Parse(fila["fecha_alta"].ToString());

            return mPersona;
        }

        public static int Eliminar(BE.UsuarioBE pUsuario)
        {
            string mCommandText = "update usuario set activo='false' where id = " + pUsuario.Id+";";
            DAO mDao = new DAO();
            return mDao.ExecuteNonQuery(mCommandText);
        }

        public static int Agregar(BE.UsuarioBE pUsuario)
        {
            string sql = "insert into usuario(document,pwd,tipo_usuario,activo,fecha_alta) values(@document,@pwd,@tipoUser,@activo,@fecha);";

            DAO mDao = new DAO();

            return mDao.ExecuteNonQueryWithParams(sql, new List<SqlParameter> {
                mDao.CreateParameter("document", SqlDbType.VarChar, pUsuario.Document),
                mDao.CreateParameter("pwd", SqlDbType.VarChar, pUsuario.Password),
                mDao.CreateParameter("tipoUser", SqlDbType.Int, pUsuario.tipo),
                mDao.CreateParameter("activo", SqlDbType.VarChar, "true"),
                mDao.CreateParameter("fecha", SqlDbType.DateTime, pUsuario.fecAlta)
            });
        }

        public static int Actualizar(BE.UsuarioBE pUsuario)
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