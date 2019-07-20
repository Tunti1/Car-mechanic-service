using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RobertTomic
{

    public static class PozivBaze
    {
        public static SqlConnection konekcija()
        {
            return new SqlConnection(@"Data Source=DESKTOP-71KF32U;Initial Catalog=Baza;Integrated Security=True;Pooling=False");
        }
    }

}