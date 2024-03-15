using System.Data;
using System.Media;

namespace ProgettoDT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nome", typeof(string));
            dataTable.Columns.Add("Cognome", typeof(string));
            dataTable.Columns.Add("Eta", typeof(int));

            DataRow dr; // =dataTable.NewRow();
            for (int i = 0; i < 1000; i++)
            {
                dr = dataTable.NewRow();
                dr["Nome"] = "Giuseppe " + i.ToString();
                dr["Cognome"] = "Verdi " + i.ToString();
                dr["Eta"] = i;
                dataTable.Rows.Add(dr);
            }

            dr = dataTable.NewRow();
            dr["Nome"] = "Pippo";
            dr["Cognome"] = "VePippinordi";
            dr["Eta"] = 22;
            dataTable.Rows.Add(dr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dt = CreaDt("amici", new co[] {
                            new co("Nome", typeof(System.String)),
                            new co("Cognome", typeof(System.String)),
                            new co("Eta", typeof(int))
                            }
            );

            DataRow dr;
            for (int i = 0; i < 100; i++)
            {
                dr = dt.NewRow();
                dr["Nome"] = "Giuseppe " + i.ToString();
                dr["Cognome"] = "Verdi " + i.ToString();
                dr["Eta"] = i;
                dt.Rows.Add(dr);
            }

            dt.WriteXml("C:\\Users\\Mario\\source\\repos\\ProgettoDT\\Dati\\Amici.xml", XmlWriteMode.WriteSchema);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.ReadXml("C:\\Users\\Mario\\source\\repos\\ProgettoDT\\Dati\\Amici.xml");
            Dg1.DataSource = dt;
        }

        public struct co
        {
            public co(string nome, Type tipo)
            {
                this.nome = nome;
                this.tipo = tipo;
            }
            public string nome = "";
            public Type tipo;
        }
        public DataTable CreaDt(string nome, co[] colonna)
        {
            DataTable dt = new DataTable(nome);
            for (int i = 0; i <= colonna.Length - 1; i++)
            {
                dt.Columns.Add(colonna[i].nome, colonna[i].tipo);
            }

            return dt;
        }


    }
}
