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

namespace CRUD
{
    public partial class Form1 : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;
        public Form1()
        {
            InitializeComponent();
        }

        private void salvar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=LOCALHOST;Database=cliente;Uid=root;Pwd=root;");
            }
            catch (Exception ex)
            {

             
            }
            finally
            {

            }

        }

        private void editar_Click(object sender, EventArgs e)
        {

        }

        private void excluir_Click(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {

        }
    }
}
