using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class QueryPresenter
    {

        IQueryView _view;

        public QueryPresenter(IQueryView view)
        {
            _view = view;
            view.SetController(this);
        }
    }
}
