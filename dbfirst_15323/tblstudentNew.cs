using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbfirst_15323
{
    public class tblstudentNew
    {
        public int stnd_id { get; set; }
        public string name { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<int> rollno { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public Nullable<int> country { get; set; }
        public Nullable<int> state { get; set; }
        public string cname { get; set; }
        public string sname { get; set; }
    }
}