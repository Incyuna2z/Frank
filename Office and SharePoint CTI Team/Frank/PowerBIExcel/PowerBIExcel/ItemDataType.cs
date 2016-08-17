using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBIExcel
{
    public class ItemDataType
    {
        public ItemDataType()
        { }
        public int Id { get; set; }
        public string Title { get; set; }
        public string IterationPath { get; set; }
        public string AreaPath { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string State { get; set; }
        public Uri URI { get; set; }

    }
}
