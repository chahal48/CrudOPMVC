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

        //private bool Add()
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("AddContact");
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ProfessionID", Convert.ToInt32(DropDownList1.SelectedValue));
        //        cmd.Parameters.AddWithValue("@fName", fName.Text.Trim());
        //        cmd.Parameters.AddWithValue("@lName", LName.Text.Trim());
        //        cmd.Parameters.AddWithValue("@emailAddr", Email.Text.Trim());
        //        cmd.Parameters.AddWithValue("@Company", Company.Text.Trim());
        //        cmd.Parameters.AddWithValue("@Category", Convert.ToInt32(DropDownCat.SelectedValue));

        //        return commonMethod.Query(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = "Invalid cred... " + Convert.ToString(ex.Message);
        //        lblError.Visible = true;
        //        return false;
        //    }
        //}


        //public bool AddContact(ContactModel obj)
        //{
        //    connection();
        //    SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@Name", obj.Name);
        //    com.Parameters.AddWithValue("@City", obj.City);
        //    com.Parameters.AddWithValue("@Address", obj.Address);

        //    con.Open();
        //    int i = com.ExecuteNonQuery();
        //    con.Close();
        //    if (i >= 1)
        //    {

        //        return true;

        //    }
        //    else
        //    {

        //        return false;
        //    }


        //}
    }
}