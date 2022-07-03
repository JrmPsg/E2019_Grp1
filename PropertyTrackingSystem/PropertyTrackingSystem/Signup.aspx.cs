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
    public partial class Signup : System.Web.UI.Page
    {
        string connectString = @"Data Source=LAPTOP-RBS68QBU;Initial Catalog=Property;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Insert sa database gumamit ako dito ng stored procedure also plano ko gumamit ng hashing algorithn such as sha1 and md5
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectString))
                    {
                        string query = "INSERT INTO tb_admin (username,password,lastname,firstname) VALUES (@username,HASHBYTES('MD5',@password),@lastname,@firstname)";
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand(query, sqlCon);

                        //Kuhanin ang laman ng textbox at ipasok sa ating parameters
                        cmd.Parameters.AddWithValue("@username",TextBoxUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", TextBoxPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@lastname", TextBoxLastname.Text.Trim());
                        cmd.Parameters.AddWithValue("@firstname", TextBoxFirstname.Text.Trim());
                        
                        //Execute
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();

                        if (IsPostBack)
                        {
                            //Clear ko sila lahat
                            TextBoxUsername.Text = "";
                            TextBoxPassword.Text = "";
                            TextBoxConfirmPassword.Text = "";
                            TextBoxLastname.Text = "";
                            TextBoxFirstname.Text = "";
                            
                            Response.Write("<script>alert('Data Added Successfully')</script>");
                            Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Please fill up necessary informations')</script>");
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