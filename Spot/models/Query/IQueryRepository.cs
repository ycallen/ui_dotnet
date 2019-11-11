using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spot
{
    public interface IQueryRepository
    {
        void ExecuteQuery(string query);

        void ValidateQuery(string query);

        (DataTable, string, int, int) GetCurrent();

        void ClearRepository();

        void IncIndex();

        void DecIndex();

    }
}
