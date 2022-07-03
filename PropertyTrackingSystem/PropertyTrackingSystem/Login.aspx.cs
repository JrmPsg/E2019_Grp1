using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace PropertyTrackingSystem
{
    public partial class Login : System.Web.UI.Page
    {
        string connectString = @"Data Source=LAPTOP-RBS68QBU;Initial Catalog=Property;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Papuntang Signup kung sakali
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        //Response redirect parin gagamitin ko dito hayyy umay sa post back url
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectString))
                    {
                        string query = "SELECT * FROM tb_admin WHERE username=@username AND [password]=HASHBYTES('MD5',@password)";
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand(query, sqlCon);

                        //Kuhanin ang laman ng textbox at ipasok sa ating parameters
                        cmd.Parameters.AddWithValue("@username", TextBoxUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", TextBoxPassword.Text.Trim());

                        //Execute
                        SqlDataReader sdr = cmd.ExecuteReader();

                        if (IsPostBack && sdr.HasRows)
                        {
                            //Clear ko sila lahat
                            Response.Write("<script>alert('Data Added Successfully')</script>");
                            Response.Redirect("Dashboard.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Wrong username or password')</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.StackTrace + "')</script>");
            }
        }
    }
}