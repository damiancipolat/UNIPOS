using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
 
    class DAO
    {
        SqlConnection mCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        //Crea rapidamente un sql parameter
        public SqlParameter CreateParameter(string name, SqlDbType type, object value)
        {
            SqlParameter newParam = new SqlParameter();
            newParam.TypeName = name;
            newParam.SqlDbType = type;
            newParam.Value = value;

            return newParam;
        }

        public DataSet ExecuteDataSet(string pCommandText)
        {
            try
            {
                mCon.Open();
                SqlDataAdapter mDa = new SqlDataAdapter(pCommandText, mCon);
                DataSet mDs = new DataSet();
                mDa.Fill(mDs);

                return mDs;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public int ExecuteNonQuery(string pCommandText)
        {
            try
            {
                mCon.Open();
                SqlCommand mCd = new SqlCommand(pCommandText, mCon);
                
                return mCd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public int ExecuteNonQueryWithParams(string pCommandText, List<SqlParameter> qParams)
        {
            try
            {
                mCon.Open();
                SqlCommand mCd = new SqlCommand(pCommandText, mCon);

                foreach (SqlParameter pParam in qParams)
                    mCd.Parameters.Add(pParam);

                return mCd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public int GetLastId(string pTabla)
        {
            try
            {
                mCon.Open();
                SqlCommand mCd = new SqlCommand("SELECT isnull(max(id),0) from " + pTabla + ";", mCon);
                return int.Parse(mCd.ExecuteScalar().ToString());
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }
    }
}
