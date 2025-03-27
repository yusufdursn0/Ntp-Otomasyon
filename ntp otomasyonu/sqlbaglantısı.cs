using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ntp_otomasyonu
{
     class sqlbaglantısı
    {
       public SqlConnection baglantı()
        {

            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-VE4A1G9\SQLEXPRESS;Initial Catalog=InsaatOtomasyonu; Integrated Security=True");

            baglan.Open();
            return baglan;


        }
    
    
    }
}
