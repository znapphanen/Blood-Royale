using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BR
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            ExtraLib.Sql.createUser(tbUserName.Text.ToString(), tbPassword.Text.ToString(), tbEmail.Text.ToString());
            Response.Redirect("Login.aspx");
        }

        
    }
}