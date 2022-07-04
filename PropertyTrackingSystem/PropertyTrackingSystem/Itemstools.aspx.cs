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
    public partial class Itemstoolsmain : System.Web.UI.Page
    {

        //string connectString = @"Data Source=LAPTOP-RBS68QBU;Initial Catalog=Property;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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

        //Automatic magfill ang ating gridview
        public void gridData()
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM tb_items", sqlCon);
                sqlDa.Fill(dtbl);
            }

            if (dtbl.Rows.Count > 0)
            {
                GridViewTables.DataSource = dtbl;
                GridViewTables.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                GridViewTables.DataSource = dtbl;
                GridViewTables.DataBind();

                GridViewTables.Rows[0].Cells.Clear();
                GridViewTables.Rows[0].Cells.Add(new TableCell());
                GridViewTables.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                GridViewTables.Rows[0].Cells[0].Text = "No Data Found!!!!";
                GridViewTables.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        //Ito yung sa paggamit ng command name para mag insert ng data sa tables ng database
        protected void GridViewTables_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Addnew"))
                {
                    string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    using (SqlConnection sqlCon = new SqlConnection(conn))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO tb_items (itemcode,itemname,quantity,department) VALUES(@itemcode,@itemname,@quantity,@department)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                        sqlCmd.Parameters.AddWithValue("@itemcode", (GridViewTables.FooterRow.FindControl("txtItemCodeFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@itemname", (GridViewTables.FooterRow.FindControl("txtItemNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@quantity", (GridViewTables.FooterRow.FindControl("txtQuantityFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@department", (GridViewTables.FooterRow.FindControl("txtDepartmentFooter") as TextBox).Text.Trim());

                        if (
                            (GridViewTables.FooterRow.FindControl("txtitemCodeFooter") as TextBox).Text.Trim().Equals("") || 
                            (GridViewTables.FooterRow.FindControl("txtItemNameFooter") as TextBox).Text.Trim().Equals("") || 
                            (GridViewTables.FooterRow.FindControl("txtQuantityFooter") as TextBox).Text.Trim().Equals(""))
                        {
                            Response.Write("<script>alert('Please enter necessary informations')</script>");
                            gridData();
                        }
                        else
                        {
                            sqlCmd.ExecuteNonQuery();
                            gridData();
                        }
                    }
                }
            }
            catch (Exception)
            {
                

            }
        }

        //Ito naman yung sa edit ng data or udpate
        protected void GridViewTables_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewTables.EditIndex = e.NewEditIndex;
            gridData();
        }

        //Cancel ang edit
        protected void GridViewTables_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTables.EditIndex = -1;
            gridData();
        }

        protected void GridViewTables_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    string query = "UPDATE [tb_items] SET itemcode=@itemcode,itemname=@itemname,quantity=@quantity,department=@department WHERE No=@No";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@itemcode", (GridViewTables.Rows[e.RowIndex].FindControl("txtItemCode") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@itemname", (GridViewTables.Rows[e.RowIndex].FindControl("txtItemName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@quantity", (GridViewTables.Rows[e.RowIndex].FindControl("txtQuantity") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@department", (GridViewTables.Rows[e.RowIndex].FindControl("txtDepartment") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@No",Convert.ToInt32(GridViewTables.DataKeys[e.RowIndex].Value.ToString()));

                    sqlCmd.ExecuteNonQuery();
                    GridViewTables.EditIndex = -1; //Para bumalik agad siya after mag edit ng row index
                    gridData();

                    
                }
            }
            catch (Exception)
            {
               

            }
        }

        protected void GridViewTables_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM tb_items WHERE No=@No";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@No", Convert.ToInt32(GridViewTables.DataKeys[e.RowIndex].Value.ToString()));

                    sqlCmd.ExecuteNonQuery();
               
                    gridData();

                }
            }
            catch (Exception)
            {
                

            }
        }
        
        //Automatic filtering ng gridview gamit ang search na ito
        protected void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    string query = "SELECT No,itemcode,itemname,quantity,department FROM tb_items WHERE itemname LIKE '%" + TextBoxSearch.Text + "%'";
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                    DataSet ds = new DataSet();
                    sqlDa.Fill(ds);

                    GridViewTables.DataSource = ds;
                    GridViewTables.DataBind();
                    sqlCon.Close();
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
            Response.Redirect("Login.aspx");
        }
    }
}