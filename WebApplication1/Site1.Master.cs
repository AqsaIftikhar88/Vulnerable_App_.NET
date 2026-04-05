using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                if (!IsPostBack) // Ensure this logic runs only when the page is first loaded, not on postbacks
                {
                    if (Session["user_role"] == null || string.IsNullOrEmpty(Session["user_role"].ToString()))
                    {
                        LinkButton1.Visible = true;  // Show login button
                        LinkButton2.Visible = false; // Hide logout button
                    }
                    else
                    {
                        LinkButton1.Visible = false;  // Hide login button
                        LinkButton2.Visible = true;   // Show logout button

                        // Optionally, you can also personalize the page
                        if (Session["user_role"].ToString() == "Admin")
                        {
                            // You can add any admin-specific logic here
                        }
                        else if (Session["user_role"].ToString() == "User")
                        {
                            // You can add any user-specific logic here
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Optionally log the exception
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Clear all session variables
            Response.Redirect("login.aspx"); // Redirect to login page
        }

    }
}