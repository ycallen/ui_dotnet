using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persist
{
    [Serializable]
    public static class Persister
    {
        public static LinkedList<PersistDM> LL { get; set; } = new LinkedList<PersistDM>();


        public static void DeleteFoward()
        {
            while (LL.Count > (Index))
                LL.RemoveLast();
        }
      

        public static int Index { get; set; }

    }
}
