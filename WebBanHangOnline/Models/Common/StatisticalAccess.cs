using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.Common
{
    public class StatisticalAccess
    {
        public static string strConnect = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
   
        public static StatisticViewModel ThongKe()
        {
            using(var connect=new SqlConnection(strConnect))
            {
                var item = connect.QueryFirstOrDefault<StatisticViewModel>("sp_ThongKe", commandType: CommandType.StoredProcedure);
                return item;
            }
        }
    }
}