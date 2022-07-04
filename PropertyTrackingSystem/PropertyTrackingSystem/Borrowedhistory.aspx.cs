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
    public partial class Borrowedhistory : System.Web.UI.Page
    {
        //Ang ating connection string
        //string connectString = @"Data Source=LAPTOP-RBS68QBU;Initial Catalog=Property;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    gridData(); 
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

        //First is to bind the data from the database to the gridview
        public void gridData()
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM tb_borrowhistory", sqlCon);
                sqlDa.Fill(dtbl); //Fill ang Data table
            }

            if (dtbl.Rows.Count > 0)
            {
                GridViewBorrowHistory.DataSource = dtbl;
                GridViewBorrowHistory.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                GridViewBorrowHistory.DataSource = dtbl;
                GridViewBorrowHistory.DataBind();

                GridViewBorrowHistory.Rows[0].Cells.Clear();
                GridViewBorrowHistory.Rows[0].Cells.Add(new TableCell());
                GridViewBorrowHistory.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                GridViewBorrowHistory.Rows[0].Cells[0].Text = "No Data Found!!!!";
                GridViewBorrowHistory.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void GridViewBorrowHistory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewBorrowHistory.EditIndex = e.NewEditIndex;
            gridData();
        }

        protected void GridViewBorrowHistory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewBorrowHistory.EditIndex = -1;
            gridData();
        }

        //Dito ay returning ng books kapag ang ating dropdownlist ay naka true then mag add ang item inventory ayun langs kasi ito ay history therefore wala akong babaguhin dito
        protected void GridViewBorrowHistory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    string query = "UPDATE [tb_borrowhistory] SET is_returned=@is_returned WHERE transno=@transno";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@transno",(GridViewBorrowHistory.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.Parameters.AddWithValue("@is_returned",(GridViewBorrowHistory.Rows[e.RowIndex].FindControl("DropDownReturn") as DropDownList).Text.Trim());

                    sqlCmd.ExecuteNonQuery();
                    GridViewBorrowHistory.EditIndex = -1; //Para bumalik agad siya after mag edit ng row index
                    gridData();

                    //Since pahirapan makuha yung value sa dropdown kukuhanin ko siya via label after natin mag execute ng first query
                    //Bale ang logic ko dito is after ng first query mag uupdate ang data and ang edit index ay babalik sa dati since done na ang udpate
                    //Therefore, makukuha ko ang value via the label component na nasa item template which is yung pinapakita ng gridview sa mga users
                    //If returned is true then update natin ang table ng items then iadd natin ang quantity na yun then ayun nareturn na siya no need for if else or else dito
                    //Whahahahahhahaa OMG nagawa ko ito ng logic ko langs ahahahhaahahhah
                    if ((GridViewBorrowHistory.Rows[e.RowIndex].FindControl("lblreturn") as Label).Text.Trim().Equals("true"))
                    {
                        string query2 = "UPDATE[tb_items] SET [quantity] = [quantity]+@quantity WHERE itemname=@itemname";
                        SqlCommand cmd2 = new SqlCommand(query2, sqlCon);

                        cmd2.Parameters.AddWithValue("@quantity", Convert.ToInt32(e.NewValues["quantity"]));
                        cmd2.Parameters.AddWithValue("@itemname",e.NewValues["itemborrowed"]);

                        cmd2.ExecuteNonQuery();
                        
                    }

                }
            }
            catch (Exception)
            {
               
            }
        }

        protected void GridViewBorrowHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM tb_borrowhistory WHERE transno=@transno";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@transno", (GridViewBorrowHistory.DataKeys[e.RowIndex].Value.ToString()));

                    sqlCmd.ExecuteNonQuery();

                    gridData();

                   
                }
            }
            catch (Exception)
            {
               

            }
        }

        protected void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                string query = "SELECT transno,borrowerid,itemborrowed,quantity,date_borrowed,date_return,is_returned FROM tb_borrowhistory WHERE transno LIKE '%" + TextBoxSearch.Text + "%'";
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                DataSet ds = new DataSet();
                sqlDa.Fill(ds);

                GridViewBorrowHistory.DataSource = ds;
                GridViewBorrowHistory.DataBind();
                sqlCon.Close();
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