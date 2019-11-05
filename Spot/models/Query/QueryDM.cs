using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

namespace Spot
{
    [Serializable]
    public class QueryDM
    {

        public List<string[]> Rows { get; set; }
        public List<string> Columns { get; set; }
        public string Query { get; set; }

        public QueryDM(List<string[]> rows, List<string> columns, string query)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.Query = query;
        }

    }
}
