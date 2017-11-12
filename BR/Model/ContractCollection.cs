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
    public class ContractCollection : List<Contract>
    {
        public ContractCollection() 
        {
        
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public static ContractCollection getAllContractsForDynasty(int dynastyId)
        {

            ContractCollection cc = new ContractCollection();


            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())  
            {
                string query = "Select * from vContracts WHERE DynastyIdOne = " + dynastyId + " OR DynastyIdTwo =" + dynastyId +" ; ";
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
                        cc.Add(new Contract(dr));
                    }
                }

                return cc;
            }
        }

    }
}