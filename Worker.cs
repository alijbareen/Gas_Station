﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas_Station
{
    public class Worker
    {
        public string worker_id { get; set; }
        public string worker_name { get; set; } 
        public string worker_pass { get; set; }


        public Worker(string worker_name, string worker_pass)
        {
            this.worker_id = "1"; //REMEMBER TO CHANGE TO GUID
            this.worker_name = worker_name;
            this.worker_pass = worker_pass;

        }


        public Worker(string worker_id, string worker_name, string worker_pass)
        {
            this.worker_id = worker_id; //REMEMBER TO CHANGE TO GUID
            this.worker_name = worker_name;
            this.worker_pass = worker_pass;
        }


    }
}