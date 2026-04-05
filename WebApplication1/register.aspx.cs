using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class register : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Server-side validation to ensure all fields are filled
            if (string.IsNullOrWhiteSpace(TextBox1.Text) ||
                string.IsNullOrWhiteSpace(TextBox2.Text) ||
                string.IsNullOrWhiteSpace(TextBox3.Text) ||
                string.IsNullOrWhiteSpace(TextBox4.Text))
            {
                Response.Write("<script>alert('All fields are required!');</script>");
            }
            // senitization for username to protect against XSS if no default settings......................
            else if (!IsValidUsername(TextBox1.Text))
            {
                Response.Write("<script>alert('Invalid username. Only alphanumeric characters and underscores are allowed.');</script>");
            }
            // in this site the IsValidUsername useally not required because ASP.net check the script by default.
            else if (!TextBox2.Text.Contains("@")) // Check if email contains '@'
            {
                Response.Write("<script>alert('Email is not in the correct format!');</script>");
            }
            else if (TextBox3.Text != TextBox4.Text) // Check if password and confirm password match
            {
                Response.Write("<script>alert('Passwords do not match!');</script>");
            }
            else if (check_email()) // Check if email already exists
            {
                Response.Write("<script>alert('This email already exists!')</script>");
            }

            //uncomment for strong password................................................................................................................................................................................

            else if (!IsPasswordStrong(TextBox3.Text.Trim())) // Check if the password is strong
            {
                Response.Write("<script>alert('Password must be at least 8 characters long and contain at least one upper-case letter, one lower-case letter, one number, and one special character!');</script>");
            }

            //...............................................................................................................................................................................................................................

            else
            {
                //Response.Write("<script>alert('You have register sucesssfully!')</script>");
                signupnewuser(); // Proceed to register the new user
                
            }

        }
        bool IsValidUsername(string username)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(username, "^[a-zA-Z0-9_]+$");
        }

        // function to ensure that user enter the strong password.............................................
        bool IsPasswordStrong(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit) &&
                   password.Any(ch => !char.IsLetterOrDigit(ch)); // for uppercase.
        }
        //................................................................................................

        bool check_email()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Select * from user_table where email_address='"+TextBox2.Text.Trim()+"';", con);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd); // use for database connection.

                DataTable dt = new DataTable(); 
                da.Fill(dt);

                if(dt.Rows.Count >= 1) { return true; }
                else {return false; }

                //con.Close();

                //Response.Write("<script>alert('You are register successfuly')</script>");
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }

           
        }
        void signupnewuser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.user_table(user_name, email_address, password, confirm_password ) values(@user_name, @email_address, @password, @confirm_password)", con);
                cmd.Parameters.AddWithValue("@user_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email_address", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@confirm_password", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You have registered successfully!'); window.location='login.aspx';", true);
            
                //Response.Write("<script>alert('You are register successfuly')</script>");
                //Response.Redirect("login.aspx");
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}