using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

namespace Query
{
    public abstract class Query
    {
        public SparqlRemoteEndpoint endpoint;

        public void ValidateQuery(string query)
        {
            SparqlQueryParser parser = new SparqlQueryParser();
            SparqlQuery q = parser.ParseFromString(query);

        }

        public (List<string[]>, List<string>) GetQueryResults(string query)
        {
            SparqlResultSet results = endpoint.QueryWithResultSet(query);
            
            List<string[]> rows = new List<string[]>();
            List<String> columns = new List<String>();

            foreach (var result in results)
            {
                List<String> row = new List<String>();
                StringBuilder sb = new StringBuilder();
                foreach (var item in result)
                {
                    if (columns.Count < result.Count)
                    {
                        columns.Add(item.Key);
                    }
                    sb.Append(item.Value.ToString());
                    sb.Append(" ");
                    row.Add(item.Value.ToString());
                }
                row.Add(sb.ToString());
                rows.Add(row.ToArray<String>());
            }

            columns.Add("invisible");
            return (rows, columns);

                
        }

    }
}
