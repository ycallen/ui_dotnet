using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persist
{
    [Serializable]
    public class PersistDM
    {
        public List<string[]> Rows { get; set; }
        public List<string> Columns { get; set; }
        public string Query { get; set; }

        public PersistDM(List<string[]> rows, List<string> columns, string query)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.Query = query;
        }
    }
}
