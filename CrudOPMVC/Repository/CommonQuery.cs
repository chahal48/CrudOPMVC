using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Configuration;

namespace CrudOPMVC.Repository
{
    public class CommonQuery
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ToString();
            con = new SqlConnection(constr);
        }

        #region CommonQuery
        public bool Query(SqlCommand cmd)
        {
            bool result = false;
            try
            {
                connection();

                // Required Open Connection
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //Execution Block start
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                int i = cmd.ExecuteNonQuery();
                //Execution Block end

                // Connection must be close
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                if (i >= 1)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

                return result;
            }
            finally
            {
                // if any exception occurs Connection must be close
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        #endregion

        #region CommonFetchQuery
        public DataTable FetchQuery(SqlCommand cmd)
        {
            try
            {
                connection();

                // Required Open Connection
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //Execution Block start
                cmd.Connection = con;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //Execution Block end

                // Connection must be close
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                return dt;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        #endregion
    }
}