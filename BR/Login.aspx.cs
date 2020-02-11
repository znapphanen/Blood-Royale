using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;


namespace BR
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Error"] != null)
            {
                this.lblError.Text = Session["Error"].ToString();

            }
            //todo:  forgott psw
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int userid = ExtraLib.Sql.login(this.txtUserName.Text, this.txtPassword.Text);

            if(userid > 0 )
            {
                Session["LoggedInUserId"] = userid;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                this.lblError.Text = "Wrong username or password.";
            }

        }

       
    }
}