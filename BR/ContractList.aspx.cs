using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BR
{
    public partial class ContractList : System.Web.UI.Page
    {
        public new Master master { get { return base.Master as Master; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            master.showPanels(this.panelEngland,this.panelFrance, this.panelGermany,this.panelItaly,this.panelSpain);
        }
    }
}