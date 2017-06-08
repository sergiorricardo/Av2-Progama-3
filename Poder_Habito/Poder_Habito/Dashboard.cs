using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poder_Habito
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void criarRotinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var criar = new CriarRotina();
            criar.MdiParent = this;
            criar.Show();
        }

        private void alterarExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var altex = new Alterar_Excluir();
            altex.MdiParent = this;
            altex.Show();
        }

        private void verRotinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
