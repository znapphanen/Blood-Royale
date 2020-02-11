using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;



namespace BR.Model
{
    public class Contract 
    {
        #region attributes
       // private int m_ContractId;
        private string m_ContractText;
        private string m_NameOne;
        private int m_IdOne;
        private string m_DynastynameOne;
        private int m_DynastyIdOne;

        private string m_NameTwo;
        private int m_IdTwo;
        private string m_DynastynameTwo;
        private int m_DynastyIdTwo;
        
        #endregion


        #region property
     //   public int contractId { get { return m_ContractId; } }
        public string contractText { get { return m_ContractText; } }
        public string nameOne { get { return m_NameOne; } }
        public int idOne { get { return m_IdOne; } }
        public string dynastynameOne { get { return m_DynastynameOne; } }
        public int dynastyIdOne { get { return m_DynastyIdOne; } }

        public string nameTwo { get { return m_NameTwo; } }
        public int idTwo { get { return m_IdTwo; } }
        public string dynastynameTwo { get { return m_DynastynameTwo; } }
        public int dynastyIdTwo { get { return m_DynastyIdTwo; } }
        
        
        #endregion


        public Contract(DataRow dr)
        {
            try
            {
                CreateObjectFromDataRow(dr);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void CreateObjectFromDataRow(DataRow dr)
        {

            try
            {
             /*   if (dr["ContractId"] != DBNull.Value)
                    this.m_ContractId = Convert.ToInt32(dr["ContractId"]); */
                if (dr["ContractText"] != DBNull.Value)
                    this.m_ContractText = (dr["ContractText"].ToString());
                if (dr["NameOne"] != DBNull.Value)
                    this.m_NameOne = (dr["NameOne"].ToString());
                if (dr["IdOne"] != DBNull.Value)
                    this.m_IdOne = Convert.ToInt32(dr["IdOne"]);
                if (dr["DynastynameOne"] != DBNull.Value)
                    this.m_DynastynameOne = (dr["DynastynameOne"].ToString());
                if (dr["DynastyIdOne"] != DBNull.Value)
                    this.m_DynastyIdOne = Convert.ToInt32(dr["DynastyIdOne"]);

                if (dr["NameTwo"] != DBNull.Value)
                    this.m_NameTwo = (dr["NameTwo"].ToString());
                if (dr["IdTwo"] != DBNull.Value)
                    this.m_IdTwo = Convert.ToInt32(dr["IdTwo"]);
                if (dr["DynastynameTwo"] != DBNull.Value)
                    this.m_DynastynameTwo = (dr["DynastynameTwo"].ToString());
                if (dr["DynastyIdTwo"] != DBNull.Value)
                    this.m_DynastyIdTwo = Convert.ToInt32(dr["DynastyIdTwo"]);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}