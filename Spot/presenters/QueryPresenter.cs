using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spot
{
    public class QueryPresenter
    {

        private readonly IQueryView _view;
        private readonly IQueryRepository _repository;


        public QueryPresenter(IQueryView view, IQueryRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            UpdateQueryView();
        }

        public void GetNext()
        {
            _repository.IncIndex();
            (DataTable table, string query, int index, int max) = _repository.GetCurrent();
            _view.UpdateView(table, query, index, max);
        }

        public void GetPrevious()
        {
            _repository.DecIndex();
            (DataTable table, string query, int index, int max) = _repository.GetCurrent();
            _view.UpdateView(table, query, index, max);
        }

        public void ExecuteQuery(string query)
        {
            _repository.ValidateQuery(query);
            (DataTable table1, string query1, int index1, int max1) = _repository.GetCurrent();
            if(query1.Equals(query))
            {
                return;
            }
            _repository.ExecuteQuery(query);
            (DataTable table2, string query2, int index2, int max2) = _repository.GetCurrent();
            _view.UpdateView(table2, query2, index2, max2);
        }

        public void Wand(string query)
        {

        }

        public void ClearRepository()
        {
            _repository.ClearRepository();
            (DataTable table, string query, int index, int max) = _repository.GetCurrent();
            _view.UpdateView(table, query, index, max);
        }

        public void UpdateQueryView()
        {
            (DataTable table, string query, int index, int max) = _repository.GetCurrent();
            _view.UpdateView(table, query, index, max);
        }

        public void SaveQuery()
        {

        }
    }
}
