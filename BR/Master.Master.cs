using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BR
{
    public partial class Master : System.Web.UI.MasterPage  //Used by contractList and CharacterList
    {
       // public Label lblError {  set; }

        protected void Page_Init(object sender, EventArgs e)
        {

            if (Session["LoggedInUserId"] == null)
            {
                Session["Error"] = "You need to login";
                Response.Redirect("Login.aspx");
            }
            if (Session["GameId"] == null)
            {
                Session["Error"] = "No game choosen";
                Response.Redirect("default.aspx");
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
           // lblError.Text = "";   
        }


        public void showPanels(Panel england, Panel france, Panel germany, Panel italy, Panel spain) 
        {
            
            Model.User loggedInUser = ExtraLib.Sql.getUserFromId(Convert.ToInt32(Session["LoggedInUserId"]));
            Model.Game theGame = Model.Game.GetSpecificGame(Convert.ToInt32(Session["GameId"]));
            Model.Dynasty loggedInDynasty = ExtraLib.Sql.getDynasty(loggedInUser.userId, theGame.gameId);
            char LoggedInDynastyCountry = ' ';

            if (loggedInDynasty != null)
            {
                LoggedInDynastyCountry = loggedInDynasty.country;
            }

            if (LoggedInDynastyCountry.Equals('E') || theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
            {
                //So non-played countries dosnt show up to creator
                if (ExtraLib.Sql.getDynastyId(theGame.gameId, 'E') > 0)
                {
                    england.Visible = true;

                }
            }

            if (LoggedInDynastyCountry.Equals('F') || theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
            {
                //So non-played countries dosnt show up to creator
                if (ExtraLib.Sql.getDynastyId(theGame.gameId, 'F') > 0)
                {
                    france.Visible = true;

                }
            }

            if (LoggedInDynastyCountry.Equals('G') || theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
            {
                //So non-played countries dosnt show up to creator
                if (ExtraLib.Sql.getDynastyId(theGame.gameId, 'G') > 0)
                {
                    germany.Visible = true;

                }
            }

            if (LoggedInDynastyCountry.Equals('I') || theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
            {
                //So non-played countries dosnt show up to creator
                if (ExtraLib.Sql.getDynastyId(theGame.gameId, 'I') > 0)
                {
                    italy.Visible = true;

                }
            }

            if (LoggedInDynastyCountry.Equals('S') || theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
            {
                //So non-played countries dosnt show up to creator
                if (ExtraLib.Sql.getDynastyId(theGame.gameId, 'S') > 0)
                {
                    spain.Visible = true;

                }
            }
        }
    }
}