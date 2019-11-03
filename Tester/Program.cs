using System;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            SparqlQueryParser parser = new SparqlQueryParser();

            //Then we can parse a SPARQL string into a query
            SparqlQuery q = parser.ParseFromString("SELECT * WHERE { ?s a ?type }");
            Console.WriteLine("Hello World!");
        }
    }
}
