using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using CrudOPMVC.Models;
using System.Collections;

namespace CrudOPMVC.Repository
{
    public class ProfessionRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ToString();
            con = new SqlConnection(constr);
        }

        #region CommonQuery
        private bool Query(SqlCommand cmd)
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

        public bool AddProfession(ProfessionModel obj)
        {

            SqlCommand com = new SqlCommand("AddNewProfession");
            com.Parameters.AddWithValue("@Profession", obj.Profession);
            com.Parameters.AddWithValue("@Description", obj.Description);

            return Query(com);
        }

        public List<ProfessionModel> GetAllProfessions()
        {
            List<ProfessionModel> ProfessionsList = new List<ProfessionModel>();

            SqlCommand com = new SqlCommand("GetAllProfessions");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            dt = FetchQuery(com);

            foreach (DataRow dr in dt.Rows)
            {
                ProfessionsList.Add(

                    new ProfessionModel
                    {
                        SerialNo = Convert.ToInt32(dr["SerialNo"]),
                        ProfessionID = Convert.ToInt32(dr["ProfessionID"]),
                        Profession = Convert.ToString(dr["Profession"]),
                        Description = Convert.ToString(dr["Description"])
                    }
                    );

            }

            return ProfessionsList;


        }

        public bool UpdateProfession(ProfessionModel obj)
        {
            SqlCommand com = new SqlCommand("UpdateProfession");
            com.Parameters.AddWithValue("@ProfessionID", obj.ProfessionID);
            com.Parameters.AddWithValue("@Profession", obj.Profession);
            com.Parameters.AddWithValue("@Description", obj.Description);

            return Query(com);
        }
        public bool DeleteProfession(int Id)
        {
            SqlCommand com = new SqlCommand("DeleteProf_Contact");
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProfessionID", Id);

            return Query(com);
        }
    }
}