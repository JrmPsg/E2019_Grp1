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
    public partial class Report : System.Web.UI.Page
    {
        //Ang ating connection string
        //string connectString = @"Data Source=LAPTOP-RBS68QBU;Initial Catalog=Property;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    populateGrid(); 
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

        //GridviewBorrowers tables auto generate columns based sa number ng mga borrowers natin
        public void populateGrid()
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM tb_borrowers", sqlCon);
                sqlDa.Fill(dtbl); //Fill ang Data table
            }

            if (dtbl.Rows.Count > 0)
            {
                GridViewBorrowers.DataSource = dtbl;
                GridViewBorrowers.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                GridViewBorrowers.DataSource = dtbl;
                GridViewBorrowers.DataBind();

                GridViewBorrowers.Rows[0].Cells.Clear();
                GridViewBorrowers.Rows[0].Cells.Add(new TableCell());
                GridViewBorrowers.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                GridViewBorrowers.Rows[0].Cells[0].Text = "No Data Found!!!!";
                GridViewBorrowers.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        //Ito pang edit
        protected void GridViewBorrowers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewBorrowers.EditIndex = e.NewEditIndex;
            populateGrid();
        }

        //Ito pang cancel
        protected void GridViewBorrowers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewBorrowers.EditIndex = -1;
            populateGrid();
        }

        protected void GridViewBorrowers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    //,firstname=@firstname,department=@department,contactno=@contactno,coursec=@coursec,gender=@gender,clienttype=@clienttype
                    string query = "UPDATE [tb_borrowers] SET lastname=@lastname,firstname=@firstname,department=@department,contactno=@contactno,coursec=@coursec,gender=@gender,clienttype=@clienttype WHERE id=@id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@lastname",(GridViewBorrowers.Rows[e.RowIndex].FindControl("txtlastname") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@firstname",(GridViewBorrowers.Rows[e.RowIndex].FindControl("txtfirstname") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@department",(GridViewBorrowers.Rows[e.RowIndex].FindControl("txtdepartment") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@contactno", (GridViewBorrowers.Rows[e.RowIndex].FindControl("txtcontactno") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@coursec", (GridViewBorrowers.Rows[e.RowIndex].FindControl("txtcoursec") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@gender", (GridViewBorrowers.Rows[e.RowIndex].FindControl("txtgender") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@clienttype", (GridViewBorrowers.Rows[e.RowIndex].FindControl("txtclienttype") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", GridViewBorrowers.DataKeys[e.RowIndex].Value.ToString());

                    sqlCmd.ExecuteNonQuery();
                    GridViewBorrowers.EditIndex = -1; //Para bumalik agad siya after mag edit ng row index
                    populateGrid();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert("+ex.StackTrace +")</script>");
            }
        }

        protected void GridViewBorrowers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM tb_borrowers WHERE id=@id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@id", (GridViewBorrowers.DataKeys[e.RowIndex].Value.ToString()));

                    sqlCmd.ExecuteNonQuery();

                    populateGrid();


                }
            }
            catch (Exception)
            {


            }
        }

        //Logout Button
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session["Username"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    string query = "SELECT id,lastname,firstname,department,contactno,coursec,gender,clienttype FROM tb_borrowers WHERE id LIKE '%" + TextBoxSearch.Text + "%'";
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    sqlDa.Fill(ds);

                    GridViewBorrowers.DataSource = ds;
                    GridViewBorrowers.DataBind();
                    sqlCon.Close();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}