using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spot
{
    public class OperationPresenter
    {
        private readonly IView _view;
        private readonly IOperationRepository _repository;

        public OperationPresenter(IView view, IOperationRepository repository)
        {
            _view = view;
            view.OperationPresenter = this;
            _repository = repository;
            //UpdateQueryView();
        }

        public void Wand(string query)
        {
            var table = _repository.GenerateQuery(query);
            _view.UpdateView(table);
        }
    }
}
