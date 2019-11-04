using System;
using System.Data;
using System.Windows.Forms;

namespace Spot
{
    public partial class QueryForm : Form, IQueryView
    {

        public QueryForm()
        {
            InitializeComponent();
        }


        public QueryPresenter Presenter { private get; set; }

        
        private void run_Click(object sender, EventArgs e)
        {
            string query = richTextBox2.Text;
            richTextBox3.Text = "";
            try
            {
                Presenter.ExecuteQuery(query);
                back.Enabled = true;
                foward.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }
        
        
        private void backward_Click(object sender, EventArgs e)
        {
            Presenter.GetPrevious();
            foward.Enabled = true;
        }

        private void foward_Click(object sender, EventArgs e)
        {
            Presenter.GetNext();
            back.Enabled = true;
        }

        private void erase_Click(object sender, EventArgs e)
        {
            Presenter.ClearRepository();
        }

        public void UpdateView(DataTable table, string query, int index, int max)
        {
            if(index == 0)
            {
                back.Enabled = false;
            }
            if (index == max)
            {
                foward.Enabled = false;
            }

            richTextBox3.Text = "";

            dataGridView1.DataSource = table;

            if(table.Rows.Count == 0)
            {
                richTextBox3.Enabled = false;
            }
            else
            {
                richTextBox3.Enabled = true;

            }

            richTextBox2.Text = query;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Show();
        }

        private void wand_Click(object sender, EventArgs e)
        {
            string query = richTextBox2.Text;
            Presenter.Wand(query);
            
        }
    }
}
