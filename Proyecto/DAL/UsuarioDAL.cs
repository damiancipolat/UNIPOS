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
            string mCommandText = "select id,document,pwd,tipo,estado,fecha_alta,intentos from usuario where id=" + pId + ";";
            Console.WriteLine(mCommandText);
            DAO mDAO = new DAO();

            DataSet mDs = mDAO.ExecuteDataSet(mCommandText);

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
                return Bind(mDs.Tables[0].Rows[0]);
            else
                return null;

        }

        public static BE.UsuarioBE ObtenerPorDoc(string pDocument)
        {
            string mCommandText = "select id,document,pwd,tipo,estado,fecha_alta,intentos from usuario where document='" + pDocument + "';";
            Console.WriteLine(mCommandText);
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

            mPersona.Id       = int.Parse(fila["id"].ToString());
            mPersona.Document = fila["document"].ToString();
            mPersona.Password = fila["pwd"].ToString();

            //Seteo el tipo de usuario.
            if (fila["tipo"].ToString() == "1")
                mPersona.Tipo = BE.UsuarioTipo.Emplado;
            else
                mPersona.Tipo = BE.UsuarioTipo.Cliente;

            //Seteo el estado del usuario.
            switch (fila["estado"])
            {
                case 'A':
                    mPersona.Estado = BE.EstadoUsuario.Activo;
                    break;
                case 'S':
                    mPersona.Estado = BE.EstadoUsuario.Suspendido;
                    break;
                case 'B':
                    mPersona.Estado = BE.EstadoUsuario.Baja;
                    break;
            }

            mPersona.FecAlta  = DateTime.Parse(fila["fecha_alta"].ToString());
            mPersona.Intentos = int.Parse(fila["intentos"].ToString());
            
            return mPersona;
        }

        public static int Eliminar(BE.UsuarioBE pUsuario)
        {
            string mCommandText = "update usuario set estado='B' where id = " + pUsuario.Id+";";
            DAO mDao = new DAO();
            return mDao.ExecuteNonQuery(mCommandText);
        }

        public static int Agregar(BE.UsuarioBE pUsuario)
        {
            string sql = "insert into usuario(document,pwd,tipo,estado,fecha_alta,intentos) values(@document,@pwd,@tipoUser,@estado,@fecha,@intentos);";

            DAO mDao = new DAO();

            return mDao.ExecuteNonQueryWithParams(sql, new List<SqlParameter> {
                mDao.CreateParameter("document", SqlDbType.VarChar, pUsuario.Document),
                mDao.CreateParameter("pwd", SqlDbType.VarChar, pUsuario.Password),
                mDao.CreateParameter("tipoUser", SqlDbType.Int, (int)pUsuario.Tipo),
                mDao.CreateParameter("estado", SqlDbType.VarChar,((char)BE.EstadoUsuario.Activo).ToString()),
                mDao.CreateParameter("fecha", SqlDbType.DateTime, pUsuario.FecAlta),
                mDao.CreateParameter("intentos", SqlDbType.Int, pUsuario.Intentos)
            });
        }

        public static int Actualizar(BE.UsuarioBE pUsuario)
        {
            string sql = "update usuario set pwd=@pwd,document=@document,tipo=@tipoUser,estado=@estado,fecha_alta=@fecha,intentos=@intentos where id = @id;";

            DAO mDao = new DAO();

            return mDao.ExecuteNonQueryWithParams(sql, new List<SqlParameter> {
                mDao.CreateParameter("id", SqlDbType.Int, pUsuario.Id),
                mDao.CreateParameter("document", SqlDbType.VarChar, pUsuario.Document),
                mDao.CreateParameter("pwd", SqlDbType.VarChar, pUsuario.Password),
                mDao.CreateParameter("tipoUser", SqlDbType.Int, ((int)pUsuario.Tipo)),
                mDao.CreateParameter("estado", SqlDbType.VarChar, ((char)pUsuario.Estado).ToString()),
                mDao.CreateParameter("fecha", SqlDbType.DateTime, pUsuario.FecAlta),
                mDao.CreateParameter("intentos", SqlDbType.Int, pUsuario.Intentos)
            });
        }

        public static BE.UsuarioBE Acceder(string user,string password)
        {
            string mCommandText = "select id,document,tipo,estado,fecha_alta,intentos from usuario where document='"+user+"' and pwd='"+password+"';";

            DAO mDAO = new DAO();

            DataSet mDs = mDAO.ExecuteDataSet(mCommandText);

            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
                return Bind(mDs.Tables[0].Rows[0]);
            else
                return null;
        }
    }
}