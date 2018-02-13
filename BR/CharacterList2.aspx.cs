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

        protected void showSpouse(int spouseId)
        {
            BR.Model.Character spouse = BR.ExtraLib.Sql.getCharacter(spouseId);
            if (spouse != null)
            {
                lblSpouseInfo.Text = spouse.firstName + " " + spouse.dynastyName + " " + spouse.age;

                switch (spouse.country)
                {
                    case 'E':
                        imgSpouseFlag.ImageUrl = "~/images/800px-Flag_of_England.svg.png";
                        break;
                    case 'F':
                        imgSpouseFlag.ImageUrl = "~/images/800px-Flag_of_France_(XIV-XVI).svg.png";
                        break;
                    case 'G':
                        imgSpouseFlag.ImageUrl = "~/images/Banner_of_Charles_V_as_Holy_Roman_Emperor.svg";
                        break;
                    case 'I':
                        imgSpouseFlag.ImageUrl = "~/images/it_ven3.gif";
                        break;
                    case 'S':
                        imgSpouseFlag.ImageUrl = "~/images/Flag_of_Cross_of_Burgundy.svg.png";
                        break;
                }

                ModalPopupExtenderSpouse.Show();

            }
           

        }
        
        

      



        protected void characterList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;
            int commandArg = Convert.ToInt32( e.CommandArgument);

            switch (command)
            {
                case "ChangeName":
                    changeName(sender, e);
                    break;
                case "showSpouse":
                    showSpouse(commandArg);
                    break;

            }
        }





    }
}