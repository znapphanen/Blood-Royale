using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BR
{
    public partial class CharacterList2 : System.Web.UI.Page
    {
        public new Master master { get { return base.Master as Master; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            master.showPanels(this.panelEnglandCharacterList, this.panelFranceCharacterList, this.panelGermanyCharacterList, this.panelItalyCharacterList, this.panelSpainCharacterList);

        }

        protected void characterList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[5].Text == "M")
                {
                    //  e.Row.Cells[5].Text = "IN";
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Pink;
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                }


                if (e.Row.Cells[6].HasControls())
                {
                    if (((CheckBox)e.Row.Cells[6].Controls[0]).Checked)
                    {
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Gold;
                    }


                }
               


            }



        }



        protected void changeName(object sender, GridViewCommandEventArgs e)
        {
            GridView gv = sender as GridView;

            LinkButton lb = (LinkButton)e.CommandSource;
            string textBoxValue = ((TextBox)lb.Parent.FindControl("newName")).Text; //get the name in the textbox that correlate to the button pressed
            if (textBoxValue.Equals(""))
            {
                lblError.Text = "Name cant be empty";

            }
            else
            {
                if (ExtraLib.Sql.changeName(Convert.ToInt32(e.CommandArgument.ToString()), textBoxValue)) //returns true if ok
                {
                    gv.DataBind();
                }
                else
                {
                    lblError.Text = "Name to long";
                }

            }

        }

      



        protected void characterList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;

            switch (command)
            {
                case "ChangeName":
                    changeName(sender, e);


                    break;

            }
        }

    }
}