using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

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

        private void parametros()
        {

            try
            {

                conexaoDb();

                strSQL = "USE CLIENTE; INSERT INTO CAD_CLIENTE (NOME, CNPJ) VALUES (@NOME, @CNPJ);";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@CNPJ", txtCnpj.Text);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
                conexao = null;
                conexao = null;
            }

        }

        private void conexaoDb()
        {
            conexao = new MySqlConnection("Server=LOCALHOST;Database=cliente;Uid=root;Pwd=root;");
        }

        //
        // Button
        //

        private void salvar_Click(object sender, EventArgs e)
        {
            parametros();

        }
        private void editar_Click(object sender, EventArgs e)
        {
            try
            {

                conexaoDb();

                strSQL = "USE CLIENTE; UPDATE CAD_CLIENTE SET NOME = @NOME, CNPJ = @CNPJ WHERE ID = @ID;";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@ID", txtId.Text);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@CNPJ", txtCnpj.Text);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
                conexao = null;
                conexao = null;
            }
        }

        private void excluir_Click(object sender, EventArgs e)
        {
            try
            {

                conexaoDb();

                strSQL = "DELETE FROM CAD_CLIENTE WHERE ID = @ID";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@ID", txtId.Text);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
                conexao = null;
                conexao = null;
            }

        }

        private void buscar_Click_1(object sender, EventArgs e)
        {
            try
            {

                conexaoDb();

                strSQL = "SELECT * FROM CAD_CLIENTE WHERE ID = @ID";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@ID", txtId.Text);

                conexao.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    txtNome.Text = Convert.ToString(dr["nome"]);
                     txtCnpj.Text = Convert.ToString(dr["cnpj"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
                conexao = null;
                conexao = null;
            }
        }

        private void txtCnpj_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mostra_Click(object sender, EventArgs e)
        {
            try
            {

                conexaoDb();

                strSQL = "SELECT * FROM CAD_CLIENTE";

                da = new MySqlDataAdapter(strSQL, conexao);

               DataTable dt = new DataTable();

                da.Fill(dt);

                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
                conexao = null;
                conexao = null;
            }
        }
    }
}