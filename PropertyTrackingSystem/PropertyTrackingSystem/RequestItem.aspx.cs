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
    public partial class RequestItem : System.Web.UI.Page
    {
        //Yung ating connection string honestly siguro dapat sa web config ko nalang ito nilagay anoooo??? Para di hassle na ganito kuhanin ko nalang yung name ng inadd ko dun sa config
        //string connectString = @"Data Source=LAPTOP-RBS68QBU;Initial Catalog=Property;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    dropdownData();
                    autoGenerateNumber(); 
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
       
        //Ifill or populate muna natin yung dropdownlist na yun hahhahahha hayyyyyyyy buhayyyyyyyy whoooooo need ko magmeryendaaa gusto ko meryendaaaaaa
        public void dropdownData()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conn))
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
                string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open(); //Buksan ang connection

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlCon;

                    int itemNo = Convert.ToInt32(DropDownListRequesteditem.SelectedValue); //Since ang value ay yung No natin macoconvert ko siya kasi dapat int siya sa database

                    cmd.CommandText = "SELECT itemcode,quantity FROM tb_items WHERE No= " + itemNo;

                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds); //Fill natin ang dataset

                    //Then yung mga textbox natin
                    TextBoxItemcode.Text = ds.Tables[0].Rows[0]["itemcode"].ToString(); //Item Code

                    //Also yung quantity na dropdownlist
                    //Kuhanin ang max value natin then magloloop tayo papasok sa ating dropdownlist
                    int q = Convert.ToInt32(ds.Tables[0].Rows[0]["quantity"]); //So using convert macoconvert ko ang value ng quantity to integer which is annoying talaga ahahha
                    DropDownListQuantity.Items.Clear(); //Clear muna natin lahat to prevent appending sa previous na ano ahhh items ahahahha
                    DropDownListQuantity.Items.Insert(0, new ListItem("--Select Items--", "0"));

                    //Kung equal siya sa zero edi lugi out of stock ganunnn
                    //Since may select items dun ako nilagay subukan ko siya imanipulate as in update
                    if (q==0)
                    {
                        DropDownListQuantity.Items.Clear();
                        DropDownListQuantity.Items.Insert(0, new ListItem("--Out of Stock","0"));
                    }
                    else
                    {
                        for (int i = 1; i <= q; i++)
                        {
                            //So bale ang logic ko is ipasok ang laman sa ating dropdownlist gamit ito value
                            DropDownListQuantity.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));

                        }
                    }
                }
            }
            catch (Exception)
            {

                
            }
        }

        //Ito naman para mafill ang firstname and lastname textbox natin gamit ito makukuha ko ang similar rows niya and maipapasok ko siya sa mga textbox as long as similar siya
        protected void TextBoxId_TextChanged(object sender, EventArgs e)
        {
            checkIdInfo();
            
        }

        public void checkIdInfo()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open(); //Buksan ang connection

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlCon;

                    cmd.CommandText = "SELECT lastname,firstname FROM tb_borrowers WHERE id=@id";

                    cmd.Parameters.AddWithValue("@id", TextBoxId.Text); //After mag text change kaya make sure na meron talagang ganung data

                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);

                    //Then yung firstname and lastname textbox natin na ma auto fill sila
                    TextBoxLastname.Text = ds.Tables[0].Rows[0]["lastname"].ToString(); //lastname natin
                    TextBoxFirstname.Text = ds.Tables[0].Rows[0]["firstname"].ToString(); //firstname natin
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('ID Number not found')</script>");
            }
        }

        //Ito ay para sa pag insert ng data sa tb_borrowhistory sa ating mahal na database ahahhahahah ahahhaha ahahhaha
        protected void ButtonRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    using (SqlConnection sqlCon = new SqlConnection(conn))
                    {
                        string query = "INSERT INTO tb_borrowhistory (transno,borrowerid,itemborrowed,quantity,date_borrowed,date_return,is_returned) VALUES (@transno,@borrowerid,@itemborrowed,@quantity,@date_borrowed,@date_return,@is_returned)";
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand(query, sqlCon);

                        string query2= "UPDATE[tb_items] SET [quantity] = [quantity]-@quantity WHERE itemcode=@itemcode";
                        SqlCommand cmd2 = new SqlCommand(query2, sqlCon);

                        //Kuhanin ang value sa ating mga textbox and dropdownlist using command parameters with add with values
                        cmd.Parameters.AddWithValue("@transno", TextBoxTransno.Text.Trim());
                        cmd.Parameters.AddWithValue("@borrowerid", TextBoxId.Text.Trim());
                        cmd.Parameters.AddWithValue("@itemborrowed", DropDownListRequesteditem.SelectedItem.Text.ToString());
                        cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(DropDownListQuantity.Text.Trim()));
                        cmd.Parameters.AddWithValue("@date_borrowed",DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@date_return", Convert.ToDateTime(TextBoxReturntime.Text));
                        cmd.Parameters.AddWithValue("@is_returned", "false");

                        //Ito yung update ng database
                        cmd2.Parameters.AddWithValue("@quantity", Convert.ToInt32(DropDownListQuantity.Text.Trim()));
                        cmd2.Parameters.AddWithValue("@itemcode",TextBoxItemcode.Text.Trim());


                        //Execute
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        sqlCon.Close();

                        if (IsPostBack)
                        {
                            //Clear ko sila lahat
                            TextBoxLastname.Text = "";
                            TextBoxFirstname.Text = "";
                            TextBoxTransno.Text = "";
                            TextBoxId.Text = "";
                            DropDownListRequesteditem.SelectedIndex = 0;
                            DropDownListQuantity.Items.Clear(); //Since wala namang value ang requested item dropdown sa zero might as well iclear ko nalang ito kasi malalagyan din naman ito ehh
                            TextBoxReturntime.Text = "";
                            TextBoxItemcode.Text = "";
                            Response.Write("<script>alert('Data Added Successfully')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Please fill up necessary informations')</script>");
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.StackTrace + "')</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            //Clear ko sila lahat
            TextBoxLastname.Text = "";
            TextBoxFirstname.Text = "";
            TextBoxTransno.Text = "";
            TextBoxId.Text = "";
            DropDownListRequesteditem.SelectedIndex = 0;
            DropDownListQuantity.Items.Clear(); //Since wala namang value ang requested item dropdown sa zero might as well iclear ko nalang ito kasi malalagyan din naman ito ehh
            TextBoxReturntime.Text = "";
        }
        //Logout Button
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session["Username"] = null;
            Response.Redirect("Login.aspx");
        }

        //Para auto generated sana yung ating transaction numberrrr hayyyyyyyy gusto ko pizzzaaaa with siomaiiiii anddddd anddddd steakkkkkkk
       public void autoGenerateNumber()
        {
            var nums = "0123456789"; //Mga numbers natin
            var chars = new char[8];
            var random = new Random();

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = nums[random.Next(nums.Length)];
            }

            string finalstring = new string(chars);
            TextBoxTransno.Text = finalstring;
        }
    }
}