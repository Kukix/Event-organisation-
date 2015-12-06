using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace Shpping_Order
{
    class connection
    {
        public string Connection { get;private set; }

        public connection()
        {
            FileStream fs = new FileStream("../../../connection_local.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            this.Connection = sr.ReadLine();
            //this.Connection = "server=athena01.fhict.local;Uid=dbi289315;Pwd=ZuD7UVJ5jv;Database=dbi289315;";
            sr.Dispose();
            fs.Dispose();
        }
    }
}
