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
        //this is the class which will provide the connection between the database and the application.
        //beacuse we are using the local site to debugging so it will be convenient for us if we user a class like this
        //so when you want to change the location of the database from local site to athena all you need to do is changing the location here
        //instead of changing the connection in every class.

        public string Connection { get;private set; }

        public connection()
        {
            FileStream fs = new FileStream("../../../connection.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            this.Connection = sr.ReadLine();
            //this.Connection = "server=athena01.fhict.local;Uid=dbi289315;Pwd=ZuD7UVJ5jv;Database=dbi289315;";
            sr.Dispose();
            fs.Dispose();
        }
    }
}
