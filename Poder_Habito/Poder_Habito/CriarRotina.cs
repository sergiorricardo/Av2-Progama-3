using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text;

namespace Poder_Habito
{
    public partial class CriarRotina : Form
    {
        public bool logado = false;
        private Conexao conn;
        public static MySqlConnection ConnectOpen;
        public CriarRotina()
        {
            InitializeComponent();
            conn = new Conexao();
            ConnectOpen = conn.ConnectToDataBase();

        }

        private void timeInicio_Tick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int hhin = Convert.ToInt32(txtHrIn.Text);
            int mmin = Convert.ToInt32(txtMmIni.Text);
            int mmter = Convert.ToInt32(txtMmTer.Text);
            int hhter = Convert.ToInt32(txtHrTerm.Text);
            if (mmin > 59 || hhin > 59 || mmter > 59 || hhter > 59)
            {
                MessageBox.Show("Hora ou minutos inválidos");
                
            }
            else
            {
                string horain = Convert.ToString(hhin) + ":" + Convert.ToString(mmin);
                string horater = Convert.ToString(hhter) + ":" + Convert.ToString(mmter);
                StringBuilder mysql = new StringBuilder();
                mysql.Append("INSERT INTO `habitos`(`dia`, `atividade`, `inicio`, `termino`)");
                mysql.Append("values (@dia, @atividade, @inicio, @termino)");
                MySqlCommand command = null;

                try
                {
                    command = new MySqlCommand(mysql.ToString(), ConnectOpen);
                    command.Parameters.Add(new MySqlParameter("@dia", cmbDia.Text));
                    command.Parameters.Add(new MySqlParameter("@atividade", txtAtividade.Text));
                    command.Parameters.Add(new MySqlParameter("@inicio", horain));
                    command.Parameters.Add(new MySqlParameter("@termino", horater));
                    command.ExecuteNonQuery();

                    MessageBox.Show("Cadastrado com sucesso");
                    
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar" + ex);
                    throw;
                }
                cmbDia.Text = " ";
                txtAtividade.Clear();
                txtHrIn.Text = "HH";
                txtHrTerm.Text = "HH";
                txtMmIni.Text = "MM";
                txtMmTer.Text = "MM";
            }
            
        }
    }
}
