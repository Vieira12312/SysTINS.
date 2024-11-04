using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTINSClass;

namespace SysTINSApp
{
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {

            CarregaGridUsuarios();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Produto produto = new(
                txtCodbarra.Text,
                txtDescricao.Text,
                txtValor.Text,
                txtEstoque.Text
                );
            produto.Inserir();
            if (produto.Id > 0)
            {
                // carrega grid
                CarregaGridUsuarios();
                MessageBox.Show($"Produto {produto.Descricao} inserido com sucesso");
                btnInserir.Enabled = false;
            }

        }
        private void CarregaGridUsuarios()
        {
            dgvProduto.Rows.Clear();
            var listaDeProdutos = Produto.ObterLista;
            int linha = 0;
            foreach (var produto in listaDeProdutos)
            {
                dgvProduto.Rows.Add();
                dgvProduto.Rows[linha].Cells[0].Value = produto.Id;
                dgvProduto.Rows[linha].Cells[1].Value = produto.Codbarra;
                dgvProduto.Rows[linha].Cells[2].Value = produto.Descricao;
                dgvProduto.Rows[linha].Cells[3].Value = produto.Valor;
                dgvProduto.Rows[linha].Cells[4].Value = produto.Estoque;
                linha++;

            }
        }
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linhaAtual = dgvProduto.CurrentRow.Index;
            int idProduto = Convert.ToInt32(dgvProduto.Rows[linhaAtual].Cells[0].Value);
            var produto = Produto.ObterPorId(idProduto);
            txtId.Text = produto.Id.ToString();
            txtCodbarra.Text = produto.Codbarra;
            txtDescricao.Text = produto.Descricao;
            txtValor.Text = produto.Valor;
            txtEstoque.Text = produto.Estoque;
  //MessageBox.Show(idUser.ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)//atualizar
        {
            Produto produto = new();
            produto.Id = int.Parse(txtId.Text);
            produto.Codbarra = txtCodbarra.Text;
            produto.Descricao = txtDescricao.Text;
            produto.Valor = txtValor.Text;
            produto.Estoque = txtEstoque.Text;
            if (produto.Atualizar())
            {
                CarregaGridUsuarios();
                MessageBox.Show("Usuário atualizado com sucesso!");
            }


        }
    }
}

