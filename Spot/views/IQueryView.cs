using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spot
{
    public interface IQueryView
    {

        QueryPresenter Presenter { set; }

        void UpdateView(DataTable table, string query, int index, int max);
    }
}
