using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class admin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            // remediations for the vertical access control:................................................

            if (Session["user_role"] == null || Session["user_role"].ToString() != "Admin")
            {
                Response.Redirect("home.aspx"); // Redirect to an access denied page or login
            }

            //................................................................................................


            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkuser())
            {
                deldeleteuser();
            }
            else
            {
                Response.Write("<script>alert('User is not exist')</script>");

            }
        }
        bool checkuser() {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Select * from user_table where user_name='" + TextBox1.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd); // use for database connection.

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1) { return true; }
                else { return false; }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }

        }

        void deldeleteuser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from user_table where user_name='" + TextBox1.Text.Trim() + "';", con);

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('User is deleted successfuly')</script>");
                clear();
                GridView1.DataBind();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
          
            }


        }

        void clear()
        {
            TextBox1.Text = "";
        }
    }
}