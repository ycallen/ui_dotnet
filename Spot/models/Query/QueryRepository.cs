using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using VDS.RDF.Query.Patterns;

namespace Spot
{
    public class QueryRepository : IQueryRepository
    {
        public SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri(@"https://linkeddata1.calcul.u-psud.fr/sparql"));

        private static int Index { get; set; }
        private static LinkedList<QueryDM> LL { get; set; }

        private string shortcuts = "base <http://yago-knowledge.org/resource/>\n" +
                                        "prefix dbp: <http://dbpedia.org/ontology/>\n" +
                                        "prefix owl: <http://www.w3.org/2002/07/owl#>\n" +
                                        "prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>\n" +
                                        "prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>\n" +
                                        "prefix skos: <http://www.w3.org/2004/02/skos/core#>\n" +
                                        "prefix xsd: <http://www.w3.org/2001/XMLSchema#>\n" +
                                        "\n";


        public void ValidateQuery(string query)
        {
            SparqlQueryParser parser = new SparqlQueryParser();
            SparqlQuery q = parser.ParseFromString(query);
        }

        public void ExecuteQuery(string query)
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

            if(rows.Count > 0)
            {
                columns.Add("invisible");
            }
            DeleteFoward();
            LL.AddLast(new QueryDM(rows, columns, query));
            SaveQuery();
            Index++;]]]]]]]]]]]]]]

































        }

        private void SaveQuery()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(path, "LL.txt");
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, LL);
            stream.Close();
        }


        private static void DeleteFoward()
        {
            while ((LL.Count -1) > (Index))
                LL.RemoveLast();
        }

        public (DataTable, string, int, int) GetCurrent()
        {
            DataTable table = new DataTable();

            var curr = LL.ElementAt<QueryDM>(Index);

            foreach (var column in curr.Columns)
            {
                table.Columns.Add(column, typeof(String));
            }

            foreach (var row in curr.Rows)
            {
                table.Rows.Add(row);
            }

            return (table, curr.Query, Index, (LL.Count - 1));
        }

        public void ClearRepository()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(path, "LL.txt");
            File.Delete(fileName);
            LL.Clear();
            Index = 0;
            LL.AddFirst(new QueryDM(new List<string[]>(), new List<string>(), shortcuts));
        }

        public void IncIndex()
        {
            Index++;
        }

        public void DecIndex()
        {
            Index--;
        }

        public List<TriplesDM> GetTriples(string query)
        {
            List<TriplesDM> triples = new List<TriplesDM>();
            SparqlQueryParser parser = new SparqlQueryParser();
            SparqlQuery q = parser.ParseFromString(query);
            foreach (var item in q.RootGraphPattern.TriplePatterns)
            {
                triples.Add(new TriplesDM()
                {
                    Subject = (item as TriplePattern).Subject.ToString(),
                    Predicate = (item as TriplePattern).Predicate.ToString(),
                    Obj = (item as TriplePattern).Object.ToString()
                });
                var subject = (item as TriplePattern).Subject;
                var predicate = (item as TriplePattern).Predicate;
                var obj = (item as TriplePattern).Object;
            }
            return triples;
        }


        public QueryRepository()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(path, "LL.txt");
            if (File.Exists(fileName))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                LL = (LinkedList<QueryDM>)formatter.Deserialize(stream);
                Index = LL.Count - 1;
                stream.Close();
            }
            else
            {
                LL = new LinkedList<QueryDM>();
                Index = 0;
                LL.AddFirst(new QueryDM(new List<string[]>(), new List<string>(), shortcuts));
            }
        }
    }
}
