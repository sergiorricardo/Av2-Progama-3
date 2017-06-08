using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Poder_Habito
{
    public partial class Alterar_Excluir : Form
    {
        //public string UsuarioSelecionado = "";
        public bool logado = false;
        private Conexao conn;
        private MySqlConnection ConnectOpen;
        public Alterar_Excluir()
        {
            InitializeComponent();
            conn = new Conexao();
            ConnectOpen = conn.ConnectToDataBase();
            
        }
        public void popularLista()
        {
            var conn = CriarRotina.ConnectOpen;
            string sqlCommand = "Select * from habitos where dia = '" + cmbDia.Text + "'";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sqlCommand, ConnectOpen);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void btnVer_Click(object sender, EventArgs e)
        {
            popularLista();
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var conn = CriarRotina.ConnectOpen;
                DialogResult result = MessageBox.Show("Deseja REALMENTE excluir?", "Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (!result.Equals(DialogResult.OK))
                    return;
                string mysql = "Delete from habitos where atividade = '" + dataGridView1.CurrentRow.Cells[1].Value +"'";
                MySqlCommand command = null;
                command = new MySqlCommand(mysql.ToString(), ConnectOpen);
                //command.Parameters.Add(new MySqlParameter("@dia", dataGridView1.Rows[));
                command.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso");
                popularLista();
            
        }
    }
}
