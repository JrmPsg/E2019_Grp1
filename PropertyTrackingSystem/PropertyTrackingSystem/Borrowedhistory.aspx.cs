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
        string connectString = @"Data Source=LAPTOP-RBS68QBU;Initial Catalog=Property;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridData();
            }
        }

        //Para dun sa dashboard button
        protected void ButtonDashboard_Click(object sender, EventArgs e)
        {
            ButtonDashboard.PostBackUrl = "Dashboard.aspx";
        }

        //Para dun sa request item button
        protected void ButtonRequestitem_Click(object sender, EventArgs e)
        {
            ButtonRequestitem.PostBackUrl = "RequestItem.aspx";
        }

        //Para dun sa items / tools button
        protected void ButtonItemstools_Click(object sender, EventArgs e)
        {
            ButtonItemstools.PostBackUrl = "Itemstools.aspx";
        }

        //Para dun sa borrowed history button
        protected void ButtonBorrowedhistory_Click(object sender, EventArgs e)
        {
            ButtonBorrowedhistory.PostBackUrl = "Borrowedhistory.aspx";
        }

        //Para dun sa reports button
        protected void ButtonReports_Click(object sender, EventArgs e)
        {
            ButtonReports.PostBackUrl = "Report.aspx";
        }

        //First is to bind the data from the database to the gridview
        public void gridData()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectString))
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

        protected void GridViewBorrowHistory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectString))
                {
                    sqlCon.Open();
                    string query = "UPDATE [tb_borrowhistory] SET is_returned=@is_returned WHERE transno=@transno";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@transno",(GridViewBorrowHistory.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.Parameters.AddWithValue("@is_returned",(GridViewBorrowHistory.Rows[e.RowIndex].FindControl("DropDownReturn") as DropDownList).Text.Trim());


                    sqlCmd.ExecuteNonQuery();
                    GridViewBorrowHistory.EditIndex = -1; //Para bumalik agad siya after mag edit ng row index
                    gridData();
                    
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        protected void GridViewBorrowHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM tb_borrowhistory WHERE transno=@transno";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@transno", (GridViewBorrowHistory.DataKeys[e.RowIndex].Value.ToString()));

                    sqlCmd.ExecuteNonQuery();

                    gridData();

                   
                }
            }
            catch (Exception ex)
            {
               

            }
        }
    }
}