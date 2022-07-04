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
    public partial class Dashboard : System.Web.UI.Page
    {
        //string connectString = @"Data Source=LAPTOP-RBS68QBU;Initial Catalog=Property;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    LabelWelcome.Text = Session["Username"].ToString();

                    SumItem();
                    totalBorrowed();
                    totalReturn();
                    totalBorrower();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
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

        public void SumItem()
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                string query = "SELECT SUM(quantity) FROM tb_items";

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Connection = sqlCon;
                object totalitems = cmd.ExecuteScalar();
                
                LabelNumItems.Text = totalitems.ToString(); 

            }
        }
        public void totalBorrowed()
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                string query = "SELECT SUM(quantity) FROM tb_borrowhistory";

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Connection = sqlCon;
                object totalitems = cmd.ExecuteScalar();
               
                
                LabelNumBorrowedItem.Text = totalitems.ToString(); 
                



            }
        }
        public void totalReturn()
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                string query = "SELECT SUM(quantity) FROM tb_borrowhistory WHERE is_returned='true'";

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Connection = sqlCon;
                object totalitems = cmd.ExecuteScalar();
               
                LabelNumReturned.Text = totalitems.ToString(); 
                

            }
        }
        public void totalBorrower()
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                string query = "SELECT count(*) FROM tb_borrowers";

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Connection = sqlCon;
                object totalitems = cmd.ExecuteScalar();
                
                LabelNumBorrower.Text = totalitems.ToString();
                
            }
        }
        //Logout Button
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
    }
}