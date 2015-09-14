using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectData
{
    public class RunInfo
    {
        public string BuildNo { set; get; }
        public string IntialPR { set; get; }
        public string FinalPR { set; get; }
        public string RunID { set; get; }
        public string OS { set; get; }
        public string OSLan { set; get; }
        public string VSLan { set; get; }
        public string TestQuery { set; get; }
    }
}