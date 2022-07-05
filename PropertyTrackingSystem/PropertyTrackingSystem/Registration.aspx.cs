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
using System.Globalization;

namespace PropertyTrackingSystem
{
    public partial class Registration : System.Web.UI.Page
    {
        //string connectString = @"Data Source=LAPTOP-RBS68QBU;Initial Catalog=Property;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                //No code here ahhahahaha well ganun talaga registration ehh
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        //Para dun sa dashboard button
        protected void ButtonDashboard_Click(object sender, EventArgs e)
        {
            //ButtonDashboard.PostBackUrl = "Dashboard.aspx";
            Response.Redirect("Dashboard.aspx");
        }

        //Para dun sa request item button
        protected void ButtonRequestitem_Click(object sender, EventArgs e)
        {
            //ButtonRequestitem.PostBackUrl = "RequestItem.aspx";
            Response.Redirect("RequestItem.aspx");
        }

        //Para dun sa items / tools button
        protected void ButtonItemstools_Click(object sender, EventArgs e)
        {
            //ButtonItemstools.PostBackUrl = "Itemstools.aspx";
            Response.Redirect("Itemstools.aspx");
        }

        //Para dun sa borrowed history button
        protected void ButtonBorrowedhistory_Click(object sender, EventArgs e)
        {
            //ButtonBorrowedhistory.PostBackUrl = "Borrowedhistory.aspx";
            Response.Redirect("Borrowedhistory.aspx");
        }

        //Para dun sa reports button
        protected void ButtonBorrowers_Click(object sender, EventArgs e)
        {
            //ButtonReports.PostBackUrl = "Report.aspx";
            Response.Redirect("Borrower.aspx");
        }

        //Register button natin pag pinindot toh mag iinsert ng data sa database base sa mga input sa textbox natin
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    using (SqlConnection sqlCon = new SqlConnection(conn))
                    {
                        string query = "INSERT INTO tb_borrowers (id,lastname,firstname,department,contactno,coursec,gender,clienttype) VALUES (@id,@lastname,@firstname,@department,@contactno,@coursec,@gender,@clienttype)";
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand(query, sqlCon);

                        //Kuhanin ang laman ng textbox at ipasok sa ating parameters
                        cmd.Parameters.AddWithValue("@id", TextBoxId.Text.Trim());
                        cmd.Parameters.AddWithValue("@lastname", TextBoxLastname.Text.Trim());
                        cmd.Parameters.AddWithValue("@firstname", TextBoxFirstname.Text.Trim());
                        cmd.Parameters.AddWithValue("@department", TextBoxDepartment.Text.Trim());
                        cmd.Parameters.AddWithValue("@contactno", TextBoxContactno.Text.Trim());
                        cmd.Parameters.AddWithValue("@coursec", TextBoxCourse.Text.Trim());
                        cmd.Parameters.AddWithValue("@gender", DropDownListGender.Text.Trim());
                        cmd.Parameters.AddWithValue("@clienttype", TextBoxClienttype.Text.Trim());

                        //Execute
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();

                        if (IsPostBack)
                        {
                            //Clear ko sila lahat
                            TextBoxId.Text = "";
                            TextBoxLastname.Text = "";
                            TextBoxFirstname.Text = "";
                            TextBoxDepartment.Text = "";
                            TextBoxContactno.Text = "";
                            TextBoxCourse.Text = "";
                            DropDownListGender.SelectedIndex = 0;
                            TextBoxClienttype.Text = "";
                            Response.Write("<script>alert('Data Added Successfully')</script>");
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
                Response.Write("<script>alert('"+ex.StackTrace+"')</script>");
            }
        }
        //Logout Button
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session["Username"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            //Clear ko sila lahat
            TextBoxLastname.Text = "";
            TextBoxClienttype.Text = "";
            TextBoxFirstname.Text = "";
            TextBoxDepartment.Text = "";
            TextBoxContactno.Text = "";
            TextBoxCourse.Text = "";
            DropDownListGender.SelectedValue = "none";
        }
    }
}