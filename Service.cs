using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas_Station
{
    public class Service
    {
        public Worker worker;
        public List<Worker> workers;
        public Shift shift;
        public bool Manager { get; set; }

        public Service()
        {
            Manager = false;
            if (File.Exists("MyDatabase.sqlite") && (new FileInfo("MyDatabase.sqlite").Length != 0))
            {
                workers = DB_connector.Get_All_Workers();
            }
            else
            {
                DB_connector.Createdb();
                workers = DB_connector.Get_All_Workers();

            }
        }

        public Worker getworker(string text)
        {
            foreach (Worker w in workers)
            {
                if (w.worker_name.Equals(text))
                {
                    return w;
                }
            }
            return null;
        }



        public bool checklogin(string text1, string text2)
        {
            foreach (Worker w in workers)
            {
                if (w.worker_name.Equals(text1))
                {
                    if (w.worker_pass.Equals(text2))
                    {
                        return true;
                    }
                }
            }
            return false;
        }




    }
}
