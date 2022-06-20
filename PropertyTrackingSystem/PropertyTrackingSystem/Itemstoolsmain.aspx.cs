using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PropertyTrackingSystem
{
    public partial class Itemstoolsmain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter tableItemInfo = new SqlDataAdapter("SELECT * FROM Table_items", );
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
            ButtonItemstools.PostBackUrl = "Itemstoolsmain.aspx";
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

        protected void GridViewTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}