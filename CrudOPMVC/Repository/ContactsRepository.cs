using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using CrudOPMVC.Models;

namespace CrudOPMVC.Repository
{
    public class ContactsRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ToString();
            con = new SqlConnection(constr);
        }

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

        public List<ContactModel> GetAllContacts()
        {
            List<ContactModel> ContactsList = new List<ContactModel>();

            SqlCommand com = new SqlCommand("GetAllContact");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            dt = FetchQuery(com);

            foreach (DataRow dr in dt.Rows)
            {
                ContactsList.Add(

                    new ContactModel
                    {
                        SerialNo = Convert.ToInt32(dr["SerialNo"]),
                        ContactID = Convert.ToInt32(dr["ContactID"]),
                        //Profession = (dr["Profession"]),
                        fName = Convert.ToString(dr["fName"]),
                        lName = Convert.ToString(dr["lName"]),
                        emailAddr = Convert.ToString(dr["emailAddr"]),
                        Company = Convert.ToString(dr["Company"]),
                        Category = (Category)Convert.ToInt32(dr["Category"])
                    }
                    );

            }

            return ContactsList;
        }

        
    }
}