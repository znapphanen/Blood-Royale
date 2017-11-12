using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BR.Model;







namespace BR
{
    public partial class Main : System.Web.UI.Page
    {
        /// <summary>
        /// Contains list of possible heirs from the diffrent dynasties.
        /// </summary>
        public class PossibleHeirs 
        {
            private int index = 0;
            private List<List<Character>> list = new List<List<Character>>();

            private PossibleHeirs() { }  //not accessible from the outside

            public PossibleHeirs(List<List<Character>> L)         
            {
                list = L;
            
            }

            public List<Character> getList() 
            {
                List<Character> returnvalue;
                if (index < list.Count)
                {
                    returnvalue = list[index];
                    index++;
                    return returnvalue;
                    
                }
                else 
                {
                    return null;
                }
            }


           
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack) //so page_load dosn't trigger when pressing a button
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

                this.lblYear.Text = "Year: " + ((Convert.ToInt32(Session["Turn"]) * 5) + 1300).ToString();
                this.lblGame.Text = "Game: " + Convert.ToString(Session["GameName"]);
                

                //Make country panels visible
                
                Model.User loggedInUser = ExtraLib.Sql.getUserFromId(Convert.ToInt32(Session["LoggedInUserId"]));
                Model.Game theGame = Model.Game.GetSpecificGame(Convert.ToInt32(Session["GameId"]));
                Model.Dynasty loggedInDynasty = ExtraLib.Sql.getDynasty(loggedInUser.userId, theGame.gameId);
                char LoggedInDynastyCountry = ' ';

                if (loggedInDynasty != null) 
                {
                    LoggedInDynastyCountry = loggedInDynasty.country;
                }
               

                if (theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
                {
                    this.panelDynasticSequence.Visible = true;
                }
                if (LoggedInDynastyCountry.Equals('E') || theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
                {
                    //So non-played countries dosnt show up to creator
                    if (ExtraLib.Sql.getDynastyId(theGame.gameId, 'E') > 0)
                    {
                        panelEnglandBirth.Visible = true;
                        panelEnglandSurvival.Visible = true;
                        panelEnglandMarriage.Visible = true;
                    }
                }
                if (LoggedInDynastyCountry.Equals('F') || theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
                {
                    if (ExtraLib.Sql.getDynastyId(theGame.gameId, 'F') > 0)
                    {
                        panelFranceBirth.Visible = true;
                        panelFranceSurvival.Visible = true;
                        panelFranceMarriage.Visible = true;
                    }
                }
                if (LoggedInDynastyCountry.Equals('G') || theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
                {
                    if (ExtraLib.Sql.getDynastyId(theGame.gameId, 'G') > 0)
                    {
                        panelGermanyBirth.Visible = true;
                        panelGermanySurvival.Visible = true;
                        panelGermanyMarriage.Visible = true;
                    }
                }
                if (LoggedInDynastyCountry.Equals('I') || theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
                {
                    if (ExtraLib.Sql.getDynastyId(theGame.gameId, 'I') > 0)
                    {
                        panelItalyBirth.Visible = true;
                        panelItalySurvival.Visible = true;
                        panelItalyMarriage.Visible = true;
                    }
                }
                if (LoggedInDynastyCountry.Equals('S') || theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
                {
                    if (ExtraLib.Sql.getDynastyId(theGame.gameId, 'S') > 0)
                    {
                        panelSpainBirth.Visible = true;
                        panelSpainSurvival.Visible = true;
                        panelSpainMarriage.Visible = true;
                    }
                }

                //Make panels visible acording to phase

                int ds = ExtraLib.Sql.getDynasticSequence(Convert.ToInt32(Session["GameId"]));

                switch (ds)
                {
                    case 1:                        
                        itsBirthPhase();
                        break;
                    case 2:
                        itsSurvivalPhase();
                        break;
                    case 3:
                        itsMarriagePhase();
                        break;
                    case 4:
                        itsEventPhase();
                        break;

                }

            }

          

        }

        protected void breeders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandArg = e.CommandArgument.ToString();
            string command = e.CommandName;

            switch (command)
            {
                case "Breed":

                    ExtraLib.DynasticSequence.Breed(Convert.ToInt32(commandArg), Convert.ToInt32(Session["Turn"]), Convert.ToInt32(Session["GameId"]));
                    (sender as GridView).DataBind();

                    if ((sender as GridView) == gvEnglandBreeders)
                    {
                        this.gvEnglandNewBorn.DataBind();
                    }

                    if ((sender as GridView) == gvFranceBreeders)
                    {
                        this.gvFranceNewBorn.DataBind();
                    }

                    if ((sender as GridView) == gvGermanyBreeders)
                    {
                        this.gvGermanyNewBorn.DataBind();
                    }

                    if ((sender as GridView) == gvItalyBreeders)
                    {
                        this.gvItalyNewBorn.DataBind();
                    }

                    if ((sender as GridView) == gvSpainBreeders)
                    {
                        this.gvSpainNewBorn.DataBind();
                    }


                    break;

            }
        }

        /* att slängas
        protected void gvEnglandBreeders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandArg = e.CommandArgument.ToString();
            string  command = e.CommandName;

            switch (command)
            { 
                case "Breed":
                    
                    ExtraLib.DynasticSequence.Breed(Convert.ToInt32(commandArg), Convert.ToInt32(Session["Turn"]), Convert.ToInt32(Session["GameId"]) );
                    this.gvEnglandBreeders.DataBind();
                    this.gvEnglandNewBorn.DataBind();
                    break;
            
            }
        }


        

        protected void gvFranceBreeders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandArg = e.CommandArgument.ToString();
            string command = e.CommandName;

            switch (command)
            {
                case "Breed":
                   
                    ExtraLib.DynasticSequence.Breed(Convert.ToInt32(commandArg), Convert.ToInt32(Session["Turn"]), Convert.ToInt32(Session["GameId"]));
                    this.gvFranceBreeders.DataBind();
                    this.gvFranceNewBorn.DataBind();
                    break;

            }
        }

        protected void gvGermanyBreeders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandArg = e.CommandArgument.ToString();
            string command = e.CommandName;

            switch (command)
            {
                case "Breed":
                 
                    ExtraLib.DynasticSequence.Breed(Convert.ToInt32(commandArg), Convert.ToInt32(Session["Turn"]), Convert.ToInt32(Session["GameId"]));
                    this.gvGermanyBreeders.DataBind();
                    this.gvGermanyNewBorn.DataBind();
                    break;

            }
        }

        protected void gvItalyBreeders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandArg = e.CommandArgument.ToString();
            string command = e.CommandName;

            switch (command)
            {
                case "Breed":
                   
                    ExtraLib.DynasticSequence.Breed(Convert.ToInt32(commandArg), Convert.ToInt32(Session["Turn"]), Convert.ToInt32(Session["GameId"]));
                    this.gvItalyBreeders.DataBind();
                    this.gvItalyNewBorn.DataBind();
                    break;

            }
        }

        protected void gvSpainBreeders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandArg = e.CommandArgument.ToString();
            string command = e.CommandName;

            switch (command)
            {
                case "Breed":
                    
                    ExtraLib.DynasticSequence.Breed(Convert.ToInt32(commandArg), Convert.ToInt32(Session["Turn"]), Convert.ToInt32(Session["GameId"]));
                    this.gvSpainBreeders.DataBind();
                    this.gvSpainNewBorn.DataBind();
                    break;

            }
        }
        */

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
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
            }
        }


        protected void gvBreeders_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Removes the button when 2 extra birthrolls are made
            int nbr = 0;
            try
            {
                nbr = Convert.ToInt32(e.Row.Cells[0].Text);
            }
            catch
            {
            }
       
            if (nbr > 2)
            {
                e.Row.FindControl("lbBreed").Visible = false;
            }

        }

        protected bool isAvaiableForMarriage(Character c) 
        {
            //must be 15 or older, alive, not in prison and unmarried
            if (c.age >= 15 && c.Dead == false && c.Prisoner == false && c.SpouseId == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void propose(object sender, GridViewCommandEventArgs e) 
        {
            int characterId = Convert.ToInt32(e.CommandArgument);
            LinkButton lb = (LinkButton)e.CommandSource;
            int targetId = 0;
            try
            {
                targetId = Convert.ToInt32(((TextBox)lb.Parent.FindControl("proposedId")).Text);
            }
            catch (FormatException exception)
            {
                this.lblError.Text = "Must enter a number in Proposed Id";
            }

            ((TextBox)lb.Parent.FindControl("proposedId")).Text = "";
            string contract = ((TextBox)lb.Parent.FindControl("contract")).Text;
            ((TextBox)lb.Parent.FindControl("contract")).Text = "";
            Character offerer = ExtraLib.Sql.getCharacter(characterId);
            Character target = ExtraLib.Sql.getCharacter(targetId);


            if (ExtraLib.DynasticSequence.IdBelongsToThisGame(targetId, (int)Session["GameId"]))
            {
                if (!targetId.Equals("") && target != null)
                {
                    if (isAvaiableForMarriage(offerer))
                    {
                        if (isAvaiableForMarriage(target))
                        {
                            if (offerer.DynastyId != target.DynastyId)
                            {
                                if (offerer.Gender != target.Gender)
                                {
                                    ExtraLib.Sql.createMarriageOffer(characterId, targetId, contract, Convert.ToInt32(Session["GameId"]));
                                    switch (ExtraLib.Sql.getCountryFromCharacterId(targetId))
                                    {

                                        // refresh the gridview of the targets country
                                        case "E":
                                            gvEnglandProposals.DataBind();
                                            break;

                                        case "F":
                                            gvFranceProposals.DataBind();
                                            break;
                                        case "G":
                                            gvGermanyProposals.DataBind();
                                            break;
                                        case "I":
                                            gvItalyProposals.DataBind();
                                            break;
                                        case "S":
                                            gvSpainProposals.DataBind();
                                            break;

                                    }

                                }
                                else
                                {
                                    this.lblError.Text = "They cant be of the same sex";
                                }
                            }
                            else
                            {
                                this.lblError.Text = "They cant be from the same family (incest?)";
                            }
                        }
                        else
                        {
                            this.lblError.Text = "Your target isnt available for marriage";
                        }
                    }
                    else
                    {
                        this.lblError.Text = "Your character isnt available for marriage anymore";
                    }

                }
                else
                {
                    this.lblError.Text = "Must have a valid target for marriage";
                }
            }
            else
            {
                lblError.Text = "This Id dosn't belong to this game.";
            }

            
        }




        protected void gvEnglandMarriage_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;

            switch (command)
            {
                case "Propose":
                    propose(sender, e);

                  
                    break;

            }

        }

        protected void gvFranceMarriage_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;

            switch (command)
            {
                case "Propose":
                    propose(sender, e);
                    break;

            }

        }

        protected void gvGermanyMarriage_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;

            switch (command)
            {
                case "Propose":
                    propose(sender, e);
                    break;

            }

        }

        protected void gvItalyMarriage_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;

            switch (command)
            {
                case "Propose":
                    propose(sender, e);
                    break;

            }

        }

        protected void gvSpainMarriage_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;

            switch (command)
            {
                case "Propose":
                    propose(sender, e);
                    break;

            }

        }


        protected void AcceptMarriage(int OfferId) 
        {
            Model.MarriageOffer mo = ExtraLib.Sql.getMarriageOffer(OfferId);
            if (mo != null)
            {//mo is still valid
                ExtraLib.Sql.marriage(mo.offererId, mo.targetId);
                ExtraLib.Sql.makeContract(mo.contractText,mo.offererId,mo.targetId,Convert.ToInt32(Session["GameId"]));
                ExtraLib.Sql.deleteMarriageOffer(mo.targetId);
                ExtraLib.Sql.deleteMarriageOffer(mo.offererId); 
                this.refreshAvailableAndProposals();
               
            }
            else 
            {
                this.lblError.Text = "This marriage offer is old.";
            }

        }
        
        protected void gvEnglandProposals_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;
            int marriageOfferId = Convert.ToInt32( e.CommandArgument);

            switch (command)
            {
                case "Accept":
                    AcceptMarriage(marriageOfferId);
                    break;

            }

        }

        protected void gvFranceProposals_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;
            int marriageOfferId = Convert.ToInt32( e.CommandArgument);

            switch (command)
            {
                case "Accept":
                    AcceptMarriage(marriageOfferId);
                    break;

            }

        }

        protected void gvGermanyProposals_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;
            int marriageOfferId = Convert.ToInt32(e.CommandArgument);

            switch (command)
            {
                case "Accept":
                    AcceptMarriage(marriageOfferId);
                    break;

            }

        }

        protected void gvItalyProposals_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;
            int marriageOfferId = Convert.ToInt32(e.CommandArgument);

            switch (command)
            {
                case "Accept":
                    AcceptMarriage(marriageOfferId);
                    break;

            }

        }

        protected void gvSpainProposals_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;
            int marriageOfferId = Convert.ToInt32(e.CommandArgument);

            switch (command)
            {
                case "Accept":
                    AcceptMarriage(marriageOfferId);
                    break;

            }

        }

        private void itsBirthPhase() 
        {
            int gameId = Convert.ToInt32(Session["GameId"]);
            this.lblPhase.Text = "Phase: Birth";
            this.panelBirth.Visible = true;
           
            this.gvEnglandBreeders.DataBind();
            this.gvFranceBreeders.DataBind();
            this.gvGermanyBreeders.DataBind();
            this.gvItalyBreeders.DataBind();
            this.gvSpainBreeders.DataBind();
            this.gvEnglandNewBorn.DataBind();
            this.gvFranceNewBorn.DataBind();
            this.gvGermanyNewBorn.DataBind();
            this.gvItalyNewBorn.DataBind();
            this.gvSpainNewBorn.DataBind();
        
        }

        private void itsSurvivalPhase() 
        { 
            this.lblPhase.Text = "Phase: Survival";
            this.panelBirth.Visible = false;
            panelSurvival.Visible = true;
            Session["PassoverList"] = "";
            
        }

        private void itsMarriagePhase() 
        {
            this.panelMarriage.Visible = true;
            this.lblPhase.Text = "Phase: Marriages";
        }

        private void itsEventPhase()
        {
            this.lblPhase.Text = "Phase: Event & Combat";
            Model.Game theGame = Model.Game.GetSpecificGame(Convert.ToInt32(Session["GameId"]));
            if (theGame.creator == Convert.ToInt32(Session["LoggedInUserId"]))
            {
                this.panelEventCombat.Visible = true;

            }

        }

        protected void btnDynasticSequence_Click(object sender, EventArgs e)
        {
            if (Session["GameId"] != null)
            {
                int gameId = Convert.ToInt32(Session["GameId"]);
                int ds = ExtraLib.Sql.getDynasticSequence(gameId);
                ds++;
                if (ds > 4) { ds = 1; }
                ExtraLib.Sql.increaseDynasticSequence(gameId, ds);


                switch (ds)
                {

                    case 1://Birth
                        ExtraLib.Sql.increaseTurn(Convert.ToInt32(Session["GameId"]));
                        Session["Turn"] = Convert.ToInt32(Session["Turn"]) + 1;

                        this.lblYear.Text = "Year: " + ((Convert.ToInt32(Session["Turn"]) * 5) + 1300).ToString();
                        this.panelEventCombat.Visible = false;
                        //breed all here so its only triggered when the button is clicked and not on every refresh of page.
                        ExtraLib.DynasticSequence.BreedAll(gameId, Convert.ToInt32(Session["Turn"]));
                        itsBirthPhase();

                        break;
                    case 2:
                        //survival
                        itsSurvivalPhase();

                        List<List<Character>> theListOfLists = new List<List<Character>>();


                        Model.CharacterCollection allNewDeaths = ExtraLib.DynasticSequence.SurviveAll(Convert.ToInt32(Session["GameId"]), ref theListOfLists);
                        Model.CharacterCollection englandNewDeaths = new Model.CharacterCollection();
                        Model.CharacterCollection franceNewDeaths = new Model.CharacterCollection();
                        Model.CharacterCollection germanyNewDeaths = new Model.CharacterCollection();
                        Model.CharacterCollection italyNewDeaths = new Model.CharacterCollection();
                        Model.CharacterCollection spainNewDeaths = new Model.CharacterCollection();

                        foreach (Character element in allNewDeaths)
                        {
                            if (element.country == 'E')
                            {
                                englandNewDeaths.Add(element);
                            }
                            if (element.country == 'F')
                            {
                                franceNewDeaths.Add(element);
                            }
                            if (element.country == 'G')
                            {
                                germanyNewDeaths.Add(element);
                            }
                            if (element.country == 'I')
                            {
                                italyNewDeaths.Add(element);
                            }
                            if (element.country == 'S')
                            {
                                spainNewDeaths.Add(element);
                            }

                        }

                        gvEnglandNewDeath.DataSource = englandNewDeaths;
                        gvEnglandNewDeath.DataBind();
                        gvFranceNewDeath.DataSource = franceNewDeaths;
                        gvFranceNewDeath.DataBind();
                        gvGermanyNewDeath.DataSource = germanyNewDeaths;
                        gvGermanyNewDeath.DataBind();

                        gvItalyNewDeath.DataSource = italyNewDeaths;
                        gvGermanyNewDeath.DataBind();

                        gvSpainNewDeath.DataSource = spainNewDeaths;
                        gvSpainNewDeath.DataBind();



                        PossibleHeirs ph = new PossibleHeirs(theListOfLists);
                        Session["PassoverList"] = ph;
                        showPassoverHeir();

                        break;

                    case 3: // Marriages
                        //show all available to all players
                        this.panelSurvival.Visible = false;
                        itsMarriagePhase();
                        refreshAvailableAndProposals();


                        //new table MarriageOffers   (so only 1 per c)  check if allready married when accepting and making the offer.  Empty table when changing phase
                        //new table activeMarriageContracts
                        break;
                    case 4:
                        ExtraLib.Sql.emptyMarriageOffers(Convert.ToInt32(Session["GameId"]));
                        itsEventPhase();

                        this.panelMarriage.Visible = false;
                        break;

                }

            }
            else
            {
                Session["Error"] = "Session timed out";
                Response.Redirect("default.aspx");
            
            }
        }

        protected void showPassoverHeir()
        {

            PossibleHeirs ph = (PossibleHeirs)Session["PassoverList"];
            List<Character> list = ph.getList();

            if(list != null)
            {
                gvPossibleHeirs.DataSource = list;
                gvPossibleHeirs.DataBind();
                ModalPopupExtenderHeirs.Show();

            }
                
                
            
            
                

            
        }

        protected void refreshAvailableAndProposals() 
        {
            gvAllAvailable.DataBind();
            gvEnglandAvailable.DataBind();
            gvEnglandProposals.DataBind();
            gvFranceAvailable.DataBind();
            gvFranceProposals.DataBind();
            gvGermanyAvailable.DataBind();
            gvGermanyProposals.DataBind();
            gvItalyAvailable.DataBind();
            gvItalyProposals.DataBind();
            gvSpainAvailable.DataBind();
            gvSpainProposals.DataBind();
        }
        
        protected void btnKill_Click(object sender, EventArgs e)
        {
            List<Character> possibleHeirs= new List<Character>();

            int id = Convert.ToInt32(this.txtId.Text);
            if (ExtraLib.DynasticSequence.IdBelongsToThisGame(id, (int)Session["GameId"]))
            {
               possibleHeirs = ExtraLib.DynasticSequence.Death(ExtraLib.Sql.getCharacter(id));
            }
            else
            {
                lblError.Text = "This Id dosn't belong to this game.";
            }

            if (possibleHeirs != null) 
            {
                

                gvPossibleHeirs.DataSource = possibleHeirs;
                gvPossibleHeirs.DataBind();

                ModalPopupExtenderHeirs.Show();
                

               
            }
        }

        protected void btnPrison_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(this.txtId.Text);
            if (ExtraLib.DynasticSequence.IdBelongsToThisGame(id, (int)Session["GameId"]))
            {
                ExtraLib.Sql.imprison(id);
            }
            else
            {
                lblError.Text = "This Id dosn't belong to this game.";
            }
                
            
        }

        protected void btnRelease_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(this.txtId.Text);
            if (ExtraLib.DynasticSequence.IdBelongsToThisGame(id, (int)Session["GameId"]))
            {
                ExtraLib.Sql.release(id);
            }
            else 
            {
                lblError.Text = "This Id dosn't belong to this game.";
            }

            
            
        }


        protected void gvPossibleHeirs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //TODO: if passover of a male in prison, the cha of the new king shall be reduced
            ExtraLib.Sql.crownKing(Convert.ToInt32(e.CommandArgument));
            showPassoverHeir(); //show the next passover, if more than one dynasty king have died.
        }
       
       
    }
}