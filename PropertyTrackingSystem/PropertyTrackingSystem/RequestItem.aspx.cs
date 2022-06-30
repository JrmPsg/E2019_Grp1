﻿using System;
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
    public partial class RequestItem : System.Web.UI.Page
    {
        //Yung ating connection string honestly siguro dapat sa web config ko nalang ito nilagay anoooo??? Para di hassle na ganito kuhanin ko nalang yung name ng inadd ko dun sa config
        string connectString = @"Data Source=LAPTOP-RBS68QBU;Initial Catalog=Property;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropdownData();
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
       
        //Ifill or populate muna natin yung dropdownlist na yun hahhahahha hayyyyyyyy buhayyyyyyyy whoooooo need ko magmeryendaaa gusto ko meryendaaaaaa
        public void dropdownData()
        {
            try
            {
                using(SqlConnection sqlCon = new SqlConnection(connectString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT No, itemname FROM tb_items")) //Dalawang toh need ko yung No magiging parang ahh int value then ang name ay text
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = sqlCon;
                        sqlCon.Open();
                        DropDownListRequesteditem.DataSource = cmd.ExecuteReader();
                        DropDownListRequesteditem.DataTextField = "itemname";
                        DropDownListRequesteditem.DataValueField = "No";
                        DropDownListRequesteditem.DataBind();
                        sqlCon.Close();
                    }
                }
                DropDownListRequesteditem.Items.Insert(0, new ListItem("--Select Items--", "0"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Dito itong function na ito ay para sana sa dropdownlist ng requested item as long as may item dun then ayun makakapagselect ng item 
        //then kuhanin ang similar rows sa database then ipopulate or ifill ang textbox with the similar row sana gumana ito para di hassle magtype sa textbox
        //Pag gumana ito imark ko as readonly yung item code textbox boommmm panessss
        protected void DropDownListRequesteditem_SelectedIndexChanged(object sender, EventArgs e)
        {
            selecteditemDetail(); //Dito ko ito ipapasok para all goods ahahhahahah
        }

        public void selecteditemDetail()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectString))
                {
                    sqlCon.Open(); //Buksan ang connection

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlCon;

                    int itemNo = Convert.ToInt32(DropDownListRequesteditem.SelectedValue); //Since ang value ay yung No natin macoconvert ko siya

                    cmd.CommandText = "SELECT itemcode FROM tb_items WHERE No= " + itemNo;

                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds); //Fill natin ang dataset

                    //Then yung mga textbox natin
                    TextBoxItemcode.Text = ds.Tables[0].Rows[0]["itemcode"].ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}