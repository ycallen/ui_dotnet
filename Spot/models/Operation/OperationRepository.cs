using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using VDS.RDF.Query.Patterns;

namespace Spot
{
    public class OperationRepository : IOperationRepository
    {

        public DataTable GenerateQuery(string query)
        {
            DataTable table = new DataTable();
            var triples = GetTriples(query);
            foreach (var triple in triples)
            {
                table = ElasticSearch(triple);
            }

            return table;
        }

        private DataTable ElasticSearch(DocumentDM doc)
        {
            DataTable table = new DataTable();

            ConnectionSettings connectionSettings;
            ElasticClient elasticClient;
            StaticConnectionPool connectionPool;

            var nodes = new Uri[]
            {
                new Uri("http://localhost:9200/"),
            };

            connectionPool = new StaticConnectionPool(nodes);
            connectionSettings = new ConnectionSettings(connectionPool);
            elasticClient = new ElasticClient(connectionSettings);
            //var searchResult = elasticClient.Search<DocumentDM>(s => s
            //                    .Size(500)
            //                    .Index("*")
            //                    .Query(q => q
            //                        .MultiMatch(m => m
            //                            //get fields that are not variables
            //                            .Fields(doc.GetTripleFields().Split(' ').ToList<string>().Select(x => new Field(x)).ToArray())
            //                            //.Fields(f=> f
            //                            //        .Field("subject")
            //                            //        .Field("predicate")
            //                            //        .Field("object"))
            //                            //get text that is not variables
            //                            .Query(doc.GetTripleText())
            //                        )
            //                    )
            //                );

            BoolQueryDescriptor<DocumentDM> boolQuery = ExactQuery(doc);

            var searchResult = elasticClient.Search<DocumentDM>(s => s
                .Size(500)
                .Index("*")
                .Query(q => q.Bool(b => boolQuery))
            );

            table.Columns.Add("subject", typeof(String));
            table.Columns.Add("predicate", typeof(String));
            table.Columns.Add("object", typeof(String));
            table.Columns.Add("score", typeof(String));
            table.Columns.Add("index", typeof(String));
            table.Columns.Add("invisible", typeof(String));
            for (int i = 0; i < searchResult.Documents.Count; i++)
            {
                var subject = searchResult.Documents.ElementAt(i).Subject;
                var predicate = searchResult.Documents.ElementAt(i).Predicate;
                var obj = searchResult.Documents.ElementAt(i).Obj;
                var score = searchResult.HitsMetadata.Hits.ElementAt(i).Score;
                var index = searchResult.HitsMetadata.Hits.ElementAt(i).Index;
                StringBuilder sb = new StringBuilder();
                sb.Append(subject);
                sb.Append(" ");
                sb.Append(predicate);
                sb.Append(" ");
                sb.Append(obj);
                sb.Append(" ");
                sb.Append(score);
                sb.Append(" ");
                sb.Append(index);
                var row = new object[] { subject, predicate, obj, score, index, sb.ToString() };
                table.Rows.Add(row);


            }

            return table;
            //if (!doc.Subject[0].Equals('?'))
            //{ 
            //    var subjectResponse = elasticClient.Search<DocumentDM>(sd => sd
            //                        .Index("*")
            //                        .Size(1000)
            //                        .Query(q => q
            //                            .Match(m => m.Field("subject").Query(doc.Subject)
            //                            )));
            //}

            //if (!doc.Predicate[0].Equals('?'))
            //{
            //    var predicateResponse = elasticClient.Search<DocumentDM>(sd => sd
            //                    .Index("*")
            //                    .Size(1000)
            //                    .Query(q => q
            //                        .Match(m => m.Field("predicate").Query(doc.Predicate)
            //                        )));
            //}

            //if (!doc.Obj[0].Equals('?'))
            //{
            //    var objectResponse = elasticClient.Search<DocumentDM>(sd => sd
            //                    .Index("*")
            //                    .Size(1000)
            //                    .Query(q => q
            //                        .Match(m => m.Field("object").Query(doc.Obj)
            //                        )));
            //}
        }

        private static BoolQueryDescriptor<DocumentDM> ExactQuery(DocumentDM doc)
        {
            var boolQuery = new BoolQueryDescriptor<DocumentDM>();
            //ex
            boolQuery.Must(mu => mu
                .Match(m => !doc.Subject[0].Equals('?') ? m
                    .Field(f => f.Subject)
                    .Query(doc.Subject) : m
                ), mud => mud
                .Match(m => !doc.Predicate[0].Equals('?') ? m
                    .Field(f => f.Predicate)
                    .Query(doc.Predicate) : m
                ),
                mud => mud
                .Match(m => !doc.Obj[0].Equals('?') ? m
                    .Field(f => f.Obj)
                    .Query(doc.Obj) : m
                )

            );
            return boolQuery;
        }

        private string getName(PatternItem item)
        {
            if(item is VariablePattern || (item as NodeMatchPattern).Node.NodeType.ToString().Equals("Literal"))
            {
                return (item.ToString());
            }
            else 
            {
                var node = (item as NodeMatchPattern).ToString().Replace("<", "").Replace(">", "");
                Uri uri = new Uri(node);
                var last = uri.Segments.Last<string>();
                return last;
            }
        }

        private (string, string, string) getNames(TriplePattern item)
        {
            var subject = getName(item.Subject); //(item as TriplePattern).Subject;
            var predicate = getName(item.Predicate);
            var obj = getName(item.Object);

            return (subject, predicate, obj);
        }

        private List<DocumentDM> GetTriples(string query)
        {
            List<DocumentDM> list = new List<DocumentDM>();
            SparqlQueryParser parser = new SparqlQueryParser();
            SparqlQuery q = parser.ParseFromString(query);
            foreach (var item in q.RootGraphPattern.TriplePatterns)
            {
                (string subject,string predicate, string obj) = getNames((item as TriplePattern));
                list.Add(new DocumentDM(subject, predicate, obj));
            }
            return list;
        }
    }
}
