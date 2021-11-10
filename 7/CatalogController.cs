using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AdvantShop.Areas.Mobile.Handlers.Catalog;
using AdvantShop.Areas.Mobile.Models.Catalog;
using AdvantShop.Catalog;
using AdvantShop.Configuration;
using AdvantShop.Core.Common.Extensions;
using AdvantShop.Core.Services.Catalog;
using AdvantShop.Core.Services.Statistic;
using AdvantShop.Customers;
using AdvantShop.Models.Catalog;
using AdvantShop.Saas;
using AdvantShop.SEO;
using AdvantShop.ViewModel.Catalog;
using AdvantShop.Core.Services.SEO;
using AdvantShop.Core.Modules;
using AdvantShop.Core.Services.Configuration.Settings;
using AdvantShop.CMS;
using AdvantShop.Web.Infrastructure.Extensions;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace AdvantShop.Areas.Mobile.Controllers
{
    public class CatalogController : BaseMobileController
    {
 //код адванта
 
        public string GetSTR(int id)
        {
            string returnSTR = "";
//самая простая связь с бд и возврат строки
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvantConnectionString"].ConnectionString);
                string SqlQuery = "Select ProductId,BriefDescription FROM Catalog.Product Where ProductId = " + id;
                conn.Open();
                SqlCommand command = new SqlCommand(SqlQuery, conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        returnSTR = reader.GetString(1);
                    }
                }
                reader.Close();
                conn.Close();
           
            return returnSTR;
        }
        #endregion
    }
}