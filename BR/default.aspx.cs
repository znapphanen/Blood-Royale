using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace BR
{
    public partial class _default : System.Web.UI.Page
    {
        private int engKingId = -1;
        private int frKingId = -1;
        private int gerKingId = -1;
        private int itKingId = -1;
        private int spKingId = -1;
        private int engQueenId = -1;
        private int frQueenId = -1;
        private int gerQueenId = -1;
        private int itQueenId = -1;
        private int spQueenId = -1;
        private char englandChildGender = BR.ExtraLib.Dice.male();
        private char franceChildGender = BR.ExtraLib.Dice.male();
        private char germanyChildGender = BR.ExtraLib.Dice.male();
        private char italyChildGender = BR.ExtraLib.Dice.male();
        private char spainChildGender = BR.ExtraLib.Dice.male();
        private int engDynastyId = -1;
        private int frDynastyId = -1;
        private int gerDynastyId = -1;
        private int itDynastyId = -1;
        private int spDynastyId = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["Error"] != null)
            {
                this.lblError.Text = Session["Error"].ToString();
                Session["Error"] = null;
            }

            if (!this.IsPostBack) //if this is the first time the page is loaded
            {
                List<Model.User> userList = ExtraLib.Sql.getAllUsers();




                //populate the name suggestions
                foreach (string element in BR.ExtraLib.Names.EnglandDynastic)
                {
                    this.ddlEngland.Items.Add(element);
                }

                foreach (string element in BR.ExtraLib.Names.FranceDynastic)
                {
                    this.ddlFrance.Items.Add(element);
                }

                foreach (string element in BR.ExtraLib.Names.GermanyDynastic)
                {
                    this.ddlGermany.Items.Add(element);
                }

                foreach (string element in BR.ExtraLib.Names.ItalyDynastic)
                {
                    this.ddlItaly.Items.Add(element);
                }

                foreach (string element in BR.ExtraLib.Names.SpainDynastic)
                {
                    this.ddlSpain.Items.Add(element);
                }


       

                foreach (Model.User element in userList)
                {

                    ddlEnglandPlayer.Items.Add(element.userName);
                    ddlFrancePlayer.Items.Add(element.userName);
                    ddlGermanyPlayer.Items.Add(element.userName);
                    ddlItalyPlayer.Items.Add(element.userName);
                    ddlSpainPlayer.Items.Add(element.userName);
                }


            }



        }

    



        protected void gvGameList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int commandArgument = Convert.ToInt32(e.CommandArgument);
            string command = e.CommandName;

            switch (command)
            {
                case "ViewGame":
                    BR.Model.Game gameToView = BR.Model.Game.GetSpecificGame(commandArgument);
                    Session["Turn"] = gameToView.turn;
                    Session["GameName"] = gameToView.gameName;
                    Session["GameId"] = gameToView.gameId;
                    Session["EnglandDynastyId"] = ExtraLib.Sql.getDynastyId(gameToView.gameId, 'E');
                    Session["FranceDynastyId"] = ExtraLib.Sql.getDynastyId(gameToView.gameId, 'F');
                    Session["GermanyDynastyId"] = ExtraLib.Sql.getDynastyId(gameToView.gameId, 'G');
                    Session["ItalyDynastyId"] = ExtraLib.Sql.getDynastyId(gameToView.gameId, 'I');
                    Session["SpainDynastyId"] = ExtraLib.Sql.getDynastyId(gameToView.gameId, 'S');
                    Response.Redirect("Main.aspx");
                    break;
                case "DeleteGame":
                    BR.Model.Game gameToDelete = BR.Model.Game.GetSpecificGame(commandArgument);
                    if (gameToDelete != null) 
                    {
                        Session["GameToDelete"] = gameToDelete.gameId;
                        ModalPopupExtenderDeleteGame.Show();
                    }
                   
                    break;
            }

        }



        protected void cbEngland_CheckedChanged(object sender, EventArgs e)
        {
            this.ddlEngland.Visible = !this.ddlEngland.Visible;
        
            this.ddlEnglandPlayer.Visible = !this.ddlEnglandPlayer.Visible;
        }

        protected void cbFrance_CheckedChanged(object sender, EventArgs e)
        {
            this.ddlFrance.Visible = !this.ddlFrance.Visible;
        
            this.ddlFrancePlayer.Visible = !this.ddlFrancePlayer.Visible;
        }
        protected void cbGermany_CheckedChanged(object sender, EventArgs e)
        {
            this.ddlGermany.Visible = !this.ddlGermany.Visible;
      
            this.ddlGermanyPlayer.Visible = !this.ddlGermanyPlayer.Visible;
        }

        protected void cbItaly_CheckedChanged(object sender, EventArgs e)
        {
            this.ddlItaly.Visible = !this.ddlItaly.Visible;
         
            this.ddlItalyPlayer.Visible = !this.ddlItalyPlayer.Visible;
        }

        protected void cbSpain_CheckedChanged(object sender, EventArgs e)
        {
            this.ddlSpain.Visible = !this.ddlSpain.Visible;
       
            this.ddlSpainPlayer.Visible = !this.ddlSpainPlayer.Visible;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtGameName.Text != "")
            {
                BR.Model.Game gc = null; //the created game

                gc = ExtraLib.Sql.createGame(this.txtGameName.Text, Session["LoggedInUserId"].ToString());

                if (gc != null)
                {
                    if (cbEngland.Checked)
                    {

                        this.engDynastyId = ExtraLib.Sql.createDynasty(this.ddlEngland.Text.ToString(), this.ddlEnglandPlayer.Text.ToString(), gc.gameId, 'E');

                        this.engKingId = ExtraLib.Sql.CreateCharacter( BR.ExtraLib.Names.getName('E', 'M'), 0, 0, 0, 'M', -5, gc.gameId, -1, -1, this.engDynastyId);
                        ExtraLib.Sql.crownKing(this.engKingId);
                        this.engQueenId = ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('E', 'F'), 0, 0, 0, 'F', -4, gc.gameId, -1, -1, this.engDynastyId);
                        ExtraLib.Sql.marriage(this.engKingId, this.engQueenId);
                        ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('E', this.englandChildGender), ExtraLib.Dice.createStat(), ExtraLib.Dice.createStat(), ExtraLib.Dice.createStat(), this.englandChildGender, -1, gc.gameId, this.engKingId, this.engQueenId, this.engDynastyId);

                    }
                    if (cbFrance.Checked)
                    {
                        this.frDynastyId = ExtraLib.Sql.createDynasty(this.ddlFrance.Text.ToString(), this.ddlFrancePlayer.Text.ToString(), gc.gameId, 'F');
                        this.frKingId = ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('F', 'M'), 0, 0, 0, 'M', -5, gc.gameId, -1, -1, this.frDynastyId);
                        ExtraLib.Sql.crownKing(this.frKingId);
                        this.frQueenId = ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('F', 'F'), 0, 0, 0, 'F', -4, gc.gameId, -1, -1, this.frDynastyId);
                        ExtraLib.Sql.marriage(this.frKingId, this.frQueenId);
                        ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('F', this.franceChildGender), ExtraLib.Dice.createStat(), ExtraLib.Dice.createStat(), ExtraLib.Dice.createStat(), this.franceChildGender, -1, gc.gameId, this.frKingId, this.frQueenId, this.frDynastyId);

                    }
                    if (cbGermany.Checked)
                    {
                        this.gerDynastyId = ExtraLib.Sql.createDynasty(this.ddlGermany.Text.ToString(), this.ddlGermanyPlayer.Text.ToString(), gc.gameId, 'G');
                        this.gerKingId = ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('G', 'M'), 0, 0, 0, 'M', -5, gc.gameId, -1, -1, this.gerDynastyId);
                        ExtraLib.Sql.crownKing(this.gerKingId);
                        this.gerQueenId = ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('G', 'F'), 0, 0, 0, 'F', -4, gc.gameId, -1, -1, this.gerDynastyId);
                        ExtraLib.Sql.marriage(this.gerKingId, this.gerQueenId);
                        ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('G', this.germanyChildGender), ExtraLib.Dice.createStat(), ExtraLib.Dice.createStat(), ExtraLib.Dice.createStat(), this.germanyChildGender, -1, gc.gameId, this.gerKingId, this.gerQueenId, this.gerDynastyId);

                    }

                    if (cbItaly.Checked)
                    {
                        this.itDynastyId = ExtraLib.Sql.createDynasty(this.ddlItaly.Text.ToString(), this.ddlItalyPlayer.Text.ToString(), gc.gameId, 'I');
                        this.itKingId = ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('I', 'M'), 0, 0, 0, 'M', -5, gc.gameId, -1, -1, this.itDynastyId);
                        ExtraLib.Sql.crownKing(this.itKingId);
                        this.itQueenId = ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('I', 'F'), 0, 0, 0, 'F', -4, gc.gameId, -1, -1, this.itDynastyId);
                        ExtraLib.Sql.marriage(this.itKingId, this.itQueenId);
                        ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('I', this.italyChildGender), ExtraLib.Dice.createStat(), ExtraLib.Dice.createStat(), ExtraLib.Dice.createStat(), this.italyChildGender, -1, gc.gameId, this.itKingId, this.itQueenId, this.itDynastyId);

                    }
                    if (cbSpain.Checked)
                    {
                        this.spDynastyId = ExtraLib.Sql.createDynasty(this.ddlSpain.Text.ToString(), this.ddlSpainPlayer.Text.ToString(), gc.gameId, 'S');

                        this.spKingId = ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('S', 'M'), 0, 0, 0, 'M', -5, gc.gameId, -1, -1, this.spDynastyId);
                        ExtraLib.Sql.crownKing(this.spKingId);
                        this.spQueenId = ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('S', 'F'), 0, 0, 0, 'F', -4, gc.gameId, -1, -1, this.spDynastyId);
                        ExtraLib.Sql.marriage(this.spKingId, this.spQueenId);
                        ExtraLib.Sql.CreateCharacter(BR.ExtraLib.Names.getName('S', this.spainChildGender), ExtraLib.Dice.createStat(), ExtraLib.Dice.createStat(), ExtraLib.Dice.createStat(), this.spainChildGender, -1, gc.gameId, this.spKingId, this.spQueenId, this.spDynastyId);

                    }

                    this.gvGameList.DataBind(); //updates gridview
                }


            }
            else
            {
                lblError.Text = "Must have a game name";
            }

        }

        protected void gvGameList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int gameid = 0;
            BR.Model.Game game;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               /* Label lblgameId = (Label)e.Row.FindControl("gameId");
                gameid = Convert.ToInt32(lblgameId.Text); */
                gameid = Convert.ToInt32(e.Row.Cells[0].Text);
                game = BR.Model.Game.GetSpecificGame(gameid);
                if (game.creator == Convert.ToInt32(Session["LoggedInUserId"]))
                {
                    e.Row.FindControl("lbDeleteGame").Visible = true;

                }

            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {            
            ExtraLib.Sql.DeleteGame(Convert.ToInt32(Session["GameToDelete"]));
            gvGameList.DataBind();
        }
    }
}