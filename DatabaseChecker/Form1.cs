using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DatabaseChecker
{
    public partial class Form1 : Form
    {

        delegate void SetTextCallback(string txt, TextBox lbl);
        delegate void UpdateProgressBarCallback(int c);

        private SqlConnection dbConnection = null;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            String cadConexion = tbCadenaConexion.Text + "MultipleActiveResultSets=true;";

            SetText("Tablas de : " + cadConexion, lblResultados);

            //Abrimos la conexion

            if (this.dbConnection != null)
            {
                if (CheckConectionExists())
                {
                    this.dbConnection.Close();
                }
            }

            this.dbConnection = new SqlConnection(cadConexion);
            dbConnection.Open();

            //Obtenemos los nombres de las tablas
            var colTablas = new List<String>();

            DataTable dtSchema = dbConnection.GetSchema("Tables");
            
            string tName = String.Empty;
            foreach (DataRow dr in dtSchema.Rows)
            {
                tName = (String)dr[2];
                colTablas.Add(tName);
            }

            progressBar1.Maximum = colTablas.Count;

            //Verificamos en paralelo
            Thread auxThread = null;
            List<Thread> threadList = new List<Thread>();

            foreach (String table in colTablas)
            {
                auxThread = new Thread(() => CheckTable(table));
                auxThread.Name = "T" + threadList.Count + "_" + table;
                auxThread.Start();

                threadList.Add(auxThread);
            }
        }

        private void CheckTable(String tName)
        {
            try
            {
                int recordCount = 0;
                String txtToWrite = String.Empty;
                if (this.dbConnection != null && !String.IsNullOrEmpty(tName))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = $"SELECT COUNT(*) As RCOUNT FROM {tName}";
                    sqlCommand.Connection = this.dbConnection;
                    sqlCommand.CommandType = CommandType.Text;

                    var result = sqlCommand.ExecuteReader();

                    while (result.Read())
                    {
                        recordCount += Convert.ToInt32(result["RCOUNT"]);
                    }

                    result.Close();
                    result.DisposeAsync();

                    txtToWrite = $"Tabla {tName} -> {recordCount} registros encontrados. \r\n";
                    SetText(txtToWrite, lblResultados);
                }

                Thread.Sleep((new Random()).Next(1, 150));
                UpdateProgressBar(1);
            }
            catch (Exception ex)
            {
                throw new Exception("Upsy! en " + Thread.CurrentThread.Name + " - " + ex.GetType().FullName);
            }
        }

        private void SetText(string txt, TextBox lbl)
        {
            if (lbl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                lbl.Invoke(d, new object[] { txt, lbl });
            }
            else
            {
                lbl.Text += txt;
                lbl.Refresh();
            }
        }

        private void UpdateProgressBar(int c)
        {
            if (progressBar1.InvokeRequired)
            {
                UpdateProgressBarCallback d = new UpdateProgressBarCallback(UpdateProgressBar);
                progressBar1.Invoke(d, new object[] { c });
            }
            else
            {
                progressBar1.Value += c;
            }
        }

        private void Reset(object sender, EventArgs e)
        {
            if (CheckConectionExists())
            {
                this.dbConnection.Close();
                this.dbConnection.Dispose();
            }

            lblResultados.Text = "Resultados de la busqueda: \r\n";
            lblResultados.Refresh();    
            progressBar1.Value = 0;
        }

        private bool CheckConectionExists()
        {
            if (this.dbConnection.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}