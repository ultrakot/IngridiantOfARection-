using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDASearcher.DataAccess
{
    public class FDAResult
    {
        public Meta meta { get; set; }
        public List<Result> results { get; set; }
    }

    public class Meta
    {
        public string disclaimer { get; set; }
        public string terms { get; set; }
        public string license { get; set; }
        public string last_updated { get; set; }
    }

    public class Result
    {
        public string term { get; set; }
        public int count { get; set; }
    }

}
