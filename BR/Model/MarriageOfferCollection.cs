using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
//using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace BR.Model
{
    [DataObject(true)]
    public class MarriageOfferCollection :List<MarriageOffer>
    {

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static MarriageOfferCollection getMarriageOffers(int dynastyId)
        {

            MarriageOfferCollection mc = new MarriageOfferCollection();

            
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Select * from vMarriageOffers WHERE TargetDynasty = " + dynastyId ;
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        mc.Add(new MarriageOffer(dr));
                    }
                }

                return mc;
            }
        }
    }
}