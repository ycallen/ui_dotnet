using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using VDS.RDF.Query.Patterns;

namespace Test
{
    public class Document
    {
        public string subject { get; set; }
        public string predicate { get; set; }

        [Text(Name = "object")]
        public string obj { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ElasticSearch();

                string shortcuts = "base <http://yago-knowledge.org/resource/>\n" +
                                        "prefix dbp: <http://dbpedia.org/ontology/>\n" +
                                        "prefix owl: <http://www.w3.org/2002/07/owl#>\n" +
                                        "prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>\n" +
                                        "prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>\n" +
                                        "prefix skos: <http://www.w3.org/2004/02/skos/core#>\n" +
                                        "prefix xsd: <http://www.w3.org/2001/XMLSchema#>\n" +
                                        "\n";


        var query = shortcuts +  "\nSELECT DISTINCT* WHERE {<Albert_Einstein> ?p1 ?o2 . ?o2 ?p2 ?o3 . ?o3 ?p3 <Alfred_Kleiner>}";
                SparqlQueryParser parser = new SparqlQueryParser();
                SparqlQuery q = parser.ParseFromString(query);
                foreach (var item in q.RootGraphPattern.TriplePatterns)
                {
                    var subject = (item as TriplePattern).Subject;
                    var predicate = (item as TriplePattern).Predicate;
                    var obj = (item as TriplePattern).Object;
                }
            }
            catch (Exception ex)
            {

            }
           
        }

        private static void ElasticSearch()
        {
            ConnectionSettings connectionSettings;
            ElasticClient elasticClient;
            StaticConnectionPool connectionPool;

            //Connection string for Elasticsearch
            /*connectionSettings = new ConnectionSettings(new Uri("http://localhost Jump :9200/")); //local PC
            elasticClient = new ElasticClient(connectionSettings);*/

            //Multiple node for fail over (cluster addresses)
            var nodes = new Uri[]
            {
                    new Uri("http://localhost:9200/"),
                //new Uri("Add server 2 address")   //Add cluster addresses here
                //new Uri("Add server 3 address")
            };


            connectionPool = new StaticConnectionPool(nodes);
            connectionSettings = new ConnectionSettings(connectionPool);
            elasticClient = new ElasticClient(connectionSettings);
            var searchResponse = elasticClient.Search<Document>(sd => sd
                                .Index("*")
                                .Size(10000)
                                .Query(q => q
                                    .Match(m => m.Field("object").Query("Daniel Jurafsky")
                                    )));
        }
    }
}
