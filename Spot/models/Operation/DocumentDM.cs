using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spot
{
    public class DocumentDM
    {
        public string Subject { get; set; }

        public string Predicate { get; set; }


        [Text(Name = "object")]
        public string Obj { get; set; }

        public DocumentDM(string subject, string predicate, string obj)
        {
            Subject = subject;
            Predicate = predicate;
            Obj = obj;
        }

        public bool IsParameter(String item)
        {
            if(item[0].Equals("?"))
            {
                return true;
            }
            return false;
        }

        public string GetTripleFields()
        {
            StringBuilder sb = new StringBuilder();
            if (!Subject[0].Equals('?'))
            {
                sb.Append(" ");
                sb.Append("subject");
            }
            if (!Predicate[0].Equals('?'))
            {
                sb.Append(" ");
                sb.Append("predicate");
            }
            if (!Obj[0].Equals('?'))
            {
                sb.Append(" ");
                sb.Append("object");
            }

            return sb.Remove(0, 1).ToString();
        }

        public string GetTripleText()
        {
            StringBuilder sb = new StringBuilder();
            if (!Subject[0].Equals('?'))
            {
                sb.Append(" ");
                sb.Append(Subject);            
            }
            if (!Predicate[0].Equals('?'))
            {
                sb.Append(" ");
                sb.Append(Predicate);                
            }
            if (!Obj[0].Equals('?'))
            {
                sb.Append(" ");
                sb.Append(Obj);                
            }
            
            return sb.Remove(0, 1).ToString();
        }

    }
}
