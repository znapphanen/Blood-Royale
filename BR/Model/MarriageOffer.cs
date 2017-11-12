using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;

namespace BR.Model
{
    [DataObject(true)]  
    public class MarriageOffer
    {
        #region Attributes
        private int m_marriageOfferId;
        private int m_offererId;
        private int m_targetId;
        private int m_OffererDynasty;
        private int m_TargetDynasty;
        private string m_contractText;
        private int m_GameId;
        #endregion

        #region property
        public int marriageOfferId { get { return m_marriageOfferId; } }
        public int offererId { get { return m_offererId; } }
        public int targetId { get { return m_targetId; } }
        public int offererDynasty { get { return m_OffererDynasty; } }
        public int targetDynasty { get { return m_TargetDynasty; } }

        public string contractText { get { return m_contractText; } }
        public int GameId { get { return m_GameId; } }

        #endregion

            //constructor
        private MarriageOffer() {
        
        }


        public MarriageOffer(DataRow dr)
            : this()
        {
            try
            {
                CreateObjectFromDataRow(dr);

            }
            catch (Exception ex){
                throw; 
            }

        }


        private void CreateObjectFromDataRow(DataRow dr) {

            try {
                if (dr["MarriageOfferId"] != DBNull.Value)
                    this.m_marriageOfferId = Convert.ToInt32(dr["MarriageOfferId"]);

                if (dr["OffererId"] != DBNull.Value)
                    this.m_offererId = Convert.ToInt32(dr["OffererId"]);
                if (dr["TargetId"] != DBNull.Value)
                    this.m_targetId = Convert.ToInt32(dr["TargetId"]);
                if (dr["OffererDynasty"] != DBNull.Value)
                    this.m_OffererDynasty = Convert.ToInt32(dr["OffererDynasty"]);

                if (dr["TargetDynasty"] != DBNull.Value)
                    this.m_TargetDynasty = Convert.ToInt32(dr["TargetDynasty"]);



                if (dr["ContractText"] != DBNull.Value)
                    this.m_contractText = (dr["ContractText"].ToString());
                if (dr["GameId"] != DBNull.Value)
                    this.m_GameId = Convert.ToInt32(dr["GameId"]);
               
            }
            catch (Exception ex) {
                throw;

            }


        }



    }
}