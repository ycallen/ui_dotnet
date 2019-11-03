using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

namespace Query
{
    public class YagoQuery : Query
    {
        //Define a remote endpoint
        //Use the DBPedia SPARQL endpoint with the default Graph set to DBPedia
        
        public YagoQuery() 
        {
            this.endpoint = new SparqlRemoteEndpoint(new Uri(@"https://linkeddata1.calcul.u-psud.fr/sparql"));
        }

    }


}
