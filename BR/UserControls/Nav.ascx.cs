using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace BR
{
    public partial class Nav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BuildNav();
            }
        }


        private void BuildNav() {
           StringBuilder sb = new StringBuilder();

            sb.Append("<ul>");
            sb.Append("<li><a href=\"default.aspx\">Games</a></li>");
            sb.Append("<li><a href=\"Main.aspx\">Main</a></li>");
            sb.Append("<li><a href=\"CharacterList2.aspx\">Characters</a></li>");
            sb.Append("<li><a href=\"ContractList.aspx\">Contracts</a></li>");
            sb.Append("<li><a href=\"Logout.aspx\">Logout</a></li>");

            
            sb.Append("</ul>");

            // Finally write it to the label
            this.lblNav.Text = sb.ToString();

        }

    }
}