using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket
{
    public class Constants
    {
        public static string ConnectionString;

        public Constants(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
