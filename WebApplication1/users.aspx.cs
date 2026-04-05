using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication1
{
    public partial class users : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Check if it's not a postback
            {
                if (Session["user_name"] != null)
                {
                    string userName = Session["user_name"].ToString();

                    LabelUsername.Text = "Hello " + userName;
                    email_update(userName);
                }
                else
                {
                    // Redirect to login if user is not authenticated
                    Response.Redirect("login.aspx");
                }
            }
        }
        void email_update(string userName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    // Fetch email address based on the username
                    SqlCommand cmd = new SqlCommand("SELECT email_address FROM user_table WHERE user_name = @user_name", con);
                    cmd.Parameters.AddWithValue("@user_name", userName);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        TextBox2.Text = dr["email_address"].ToString(); // Set the email address
                    }
                    else
                    {
                        Response.Write("<script>alert('User email not found')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string oldPassword = password.Value; // Old password from input field
            string newPassword = newpassword.Value; // New password from input field
            string confirmPassword = confirmpassword.Value; // Confirm password from input field

            // Check if new password matches confirm password
            if (newPassword != confirmPassword)
            {
                Response.Write("<script>alert('New password and Confirm password do not match.')</script>");
                return;
            }

            string userName = Session["user_name"].ToString();

            // Validate the old password
            if (Validatepassword(userName, oldPassword))
            {
                // Update the password
                Updatepassword(userName, newPassword);
            }
            else
            {
                Response.Write("<script>alert('Old password is incorrect.')</script>");
            }
        }

        private bool Validatepassword(string userName, string password)
        {
            bool isValid = false;
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    // Check for an exact match of username and password in the database
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM user_table WHERE user_name = @user_name AND password = @password", con);
                    cmd.Parameters.AddWithValue("@user_name", userName);
                    cmd.Parameters.AddWithValue("@password", password); // Old password

                    int count = (int)cmd.ExecuteScalar(); // Return the number of matches
                    isValid = (count > 0); // If count > 0, the old password is valid
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            return isValid;
        }


        private void Updatepassword(string userName, string newpassword)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    // Update the password directly
                    SqlCommand cmd = new SqlCommand("UPDATE user_table SET password = @new_password, confirm_password = @new_password WHERE user_name = @user_name", con);
                    cmd.Parameters.AddWithValue("@new_password", newpassword); // New password
                    cmd.Parameters.AddWithValue("@user_name", userName); // Username

                    int rowsAffected = cmd.ExecuteNonQuery(); // Execute the update command
                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('password updated successfully.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error updating password.')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

            //email_update(); // Refresh email display after updating password
        }
    }
}