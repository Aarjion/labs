using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;

namespace Веб_приложение
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ServiceReference1.Service1Client s = new ServiceReference1.Service1Client("NetTcpBinding_IService1");
                GridView1.DataSource = s.GetData();
                GridView1.DataBind();

                DropDownList2.DataSource = s.Fill();
                DropDownList2.DataTextField = "Название книги";
                DropDownList2.DataValueField = "Название книги";
                DropDownList2.DataBind();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");
            if (!(dateEx.Text == "" || dateEx0.Text == ""))
            {
                s.NewRec(TextBox1.Text, DropDownList2.Text, dateEx.Text, dateEx0.Text);
                Response.Redirect("WebForm2.aspx");
            }
        }
    }
}