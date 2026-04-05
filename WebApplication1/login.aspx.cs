using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class login1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            //Unncomment this to secure against the brute force attack.................................................................................................


            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    // Unparametrize query: comment this to secure against sqli.................................................

                    SqlCommand cmd = new SqlCommand(@"
                    SELECT user_name AS Name, 'User' AS Role 
                    FROM user_table 
                    WHERE user_name='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + @"'
                    UNION
                    SELECT admin_name AS Name, 'Admin' AS Role 
                    FROM Admin_login 
                    WHERE admin_name='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);


                    //.............................................................................


                    //this is parametrized query remediation against sqli...........................................................................

                    //SqlCommand cmd = new SqlCommand(@"
                    //SELECT user_name AS Name, 'User' AS Role FROM user_table WHERE user_name=@name AND password=@password
                    //UNION
                    //SELECT admin_name AS Name, 'Admin' AS Role FROM Admin_login WHERE admin_name=@name AND password=@password", con);

                    //cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                    //cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());

                    //.................................................................................................................................


                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read(); // Read the first row only
                        Session["user_name"] = dr["Name"].ToString(); // User or Admin name
                        Session["user_role"] = dr["Role"].ToString(); // User role

                        // Redirect based on role
                        if (Session["user_role"].ToString() == "Admin")
                        {
                            Response.Redirect("admin.aspx"); // Redirect admin to admin dashboard
                        }
                        else
                        {
                            Response.Redirect("users.aspx"); // Redirect user to user dashboard
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Credentials')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }






            ////Comment this against the brute force attack.................................................................................................

            //try
            //{
            //    using (SqlConnection con = new SqlConnection(strcon))
            //    {
            //        if (con.State == System.Data.ConnectionState.Closed)
            //        {
            //            con.Open();
            //        }

            //        // Check if the username exists in either table
            //        SqlCommand checkUserCmd = new SqlCommand(@"
            //        SELECT user_name FROM user_table WHERE user_name=@name
            //        UNION
            //        SELECT admin_name FROM Admin_login WHERE admin_name=@name", con);

            //        checkUserCmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
            //        SqlDataReader userReader = checkUserCmd.ExecuteReader();

            //        // check for username...........................................................
            //        if (!userReader.HasRows)
            //        {
            //            // Username does not exist
            //            Response.Write("<script>alert('Invalid Username')</script>");
            //            return;
            //        }
            //        userReader.Close();

            //        // Now check for the correct password for the given username........................
            //        SqlCommand cmd = new SqlCommand(@"
            //        SELECT user_name AS Name, 'User' AS Role FROM user_table WHERE user_name=@name AND password=@password
            //        UNION
            //        SELECT admin_name AS Name, 'Admin' AS Role FROM Admin_login WHERE admin_name=@name AND password=@password", con);

            //        cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
            //        cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());
            //        SqlDataReader dr = cmd.ExecuteReader();

            //        if (dr.HasRows)
            //        {
            //            // Valid username and password
            //            dr.Read(); // Read the first row only
            //            Session["user_name"] = dr["Name"].ToString(); // User or Admin name
            //            Session["user_role"] = dr["Role"].ToString(); // User role

            //            // Redirect based on role
            //            if (Session["user_role"].ToString() == "Admin")
            //            {
            //                Response.Redirect("admin.aspx"); // Redirect admin to admin dashboard
            //            }
            //            else
            //            {
            //                Response.Redirect("users.aspx"); // Redirect user to user dashboard
            //            }
            //        }
            //        else
            //        {
            //            // Username exists but password is incorrect
            //            Response.Write("<script>alert('Invalid Password')</script>");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('" + ex.Message + "')</script>");
            //}


            //.........................................................................................................

        }
    }
}
    
