using Controller;
using Persist;
using Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form, IQueryView
    {

        QueryPresenter _controller;
        public Form1()
        {
            InitializeComponent();
        }

       
        protected override void OnLoad(EventArgs e)
        {
            DeserializeLL();

            UpdateModelOnLoad();

        }

        private static void DeserializeLL()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(path, "LL.txt");
            if (File.Exists(fileName))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                Persister.LL = (LinkedList<PersistDM>)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void UpdateModelOnLoad()
        {
            var shortcuts = "base <http://yago-knowledge.org/resource/>\n" +
                                        "prefix dbp: <http://dbpedia.org/ontology/>\n" +
                                        "prefix owl: <http://www.w3.org/2002/07/owl#>\n" +
                                        "prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>\n" +
                                        "prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>\n" +
                                        "prefix skos: <http://www.w3.org/2004/02/skos/core#>\n" +
                                        "prefix xsd: <http://www.w3.org/2001/XMLSchema#>\n" +
                                        "\n";
            if (Persister.LL.Count == 0)
            {
                back.Enabled = false;
                foward.Enabled = false;
                Persister.Index = 0;
                Persister.LL.AddFirst(new PersistDM(new List<string[]>(), new List<string>(), shortcuts));
                UpdateModel(new List<string[]>(), new List<string>(), shortcuts);
            }
            else
            {
                Persister.Index = Persister.LL.Count - 1;
                var dm = Persister.LL.ElementAt(Persister.Index);
                UpdateModel(dm.Rows, dm.Columns, dm.Query);
                foward.Enabled = false;
            }
        }

        
        private void run_Click(object sender, EventArgs e)
        {
            string query = richTextBox2.Text;    

            //Pressed run button when query didn't change
            if(query.Equals(Persister.LL.ElementAt(Persister.Index).Query))
            {
                return;
            }
            try
            {

                new YagoQuery().ValidateQuery(query);

                (List<string[]> rows, List<string> columns) = new YagoQuery().GetQueryResults(query);


                back.Enabled = true;
                foward.Enabled = false;
                Persister.Index++;
                Persister.DeleteFoward();
                Persister.LL.AddLast(new PersistDM(rows, columns, query));
                UpdateModel(rows, columns, query);

                SerializeLL();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }

        private static void SerializeLL()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(path, "LL.txt");
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, Persister.LL);
            stream.Close();
        }


        private void UpdateModel(List<string[]> rows, List<string> columns, string query)
        {
            richTextBox2.Text = query;
            richTextBox2.SelectionStart = query.Length;
            richTextBox3.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();


            DataTable table = new DataTable();

            foreach (var column in columns)
            {
                table.Columns.Add(column, typeof(String));                
            }

            foreach (var row in rows)
            {
                table.Rows.Add(row);
            }

            dataGridView1.DataSource = table;

            if (dataGridView1.Rows.Count > 0)
            {
                richTextBox3.Enabled = true;
                dataGridView1.Columns["invisible"].Visible = false;
            }
            else
            {
                richTextBox3.Enabled = false;
            }

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Show();
        }

        
        private void backward_Click(object sender, EventArgs e)
        {
            foward.Enabled = true;
            Persister.Index--;
            var dm = Persister.LL.ElementAt(Persister.Index);
            UpdateModel(dm.Rows, dm.Columns, dm.Query);

            if (Persister.Index == 0)
            {
                back.Enabled = false;
            }
        }

        private void foward_Click(object sender, EventArgs e)
        {
            back.Enabled = true;            
            Persister.Index++;
            if (Persister.Index == (Persister.LL.Count - 1))
                foward.Enabled = false;
            var dm = Persister.LL.ElementAt(Persister.Index);
            UpdateModel(dm.Rows, dm.Columns, dm.Query);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Query_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void erase_Click(object sender, EventArgs e)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(path, "LL.txt");
            File.Delete(fileName);
            Persister.LL.Clear();
            UpdateModelOnLoad();
        }

        public void SetController(QueryPresenter controller)
        {
            _controller = controller;
        }
    }
}
