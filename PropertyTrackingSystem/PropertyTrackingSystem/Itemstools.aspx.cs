﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropertyTrackingSystem
{
    public partial class Itemstools : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}