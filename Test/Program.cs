using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

namespace Test
{
    class Program
    {
        static (int, int) Test()
        {
            return (0, 1);
        }
        static void Main(string[] args)
        {
            


            try
            {
                //Then we can parse a SPARQL string into a query
                (int x, int y) = Test();
            }
            catch(Exception ex)
            {

            }
           
        }
    }
}
