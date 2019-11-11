using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            var view = new Form();

            var queryRepository = new QueryRepository();
            var queryPresenter = new QueryPresenter(view, queryRepository);

            var operationRepository = new OperationRepository();
            var operationPresenter = new OperationPresenter(view, operationRepository);


            Application.Run(view);
        }
    }
}
