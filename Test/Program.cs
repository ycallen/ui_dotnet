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
                                        .Match(m => m.Field("subject").Query("Albert_Einstein")
                                        )));

            }
            catch (Exception ex)
            {

            }
           
        }
    }
}
