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
        static int mId;
        
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

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(mDao.CreateParameter("document", SqlDbType.VarChar, pUsuario.Document));
            list.Add(mDao.CreateParameter("pwd", SqlDbType.VarChar, pUsuario.Password));
            list.Add(mDao.CreateParameter("tipoUser", SqlDbType.VarChar, pUsuario.tipo));
            list.Add(mDao.CreateParameter("activo", SqlDbType.VarChar, pUsuario.activo));
            list.Add(mDao.CreateParameter("fecha", SqlDbType.DateTime, pUsuario.fecAlta));

            return mDao.ExecuteNonQueryWithParams(sql, list);
        }

    }
}