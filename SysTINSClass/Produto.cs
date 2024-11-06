using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTINSApp;

namespace SysTINSClass
{
    public class Produto : ProdutoBase
    {
        public int Id { get; set; }
        public string? Codbarra { get; set; }
        public string? Descricao { get; set; }
        public string? Valor { get; set; }

        public string? Estoque { get; set; }

        public Produto(string codbarra, string descricao, string valor, string estoque)
        {
            Codbarra = codbarra;
            Descricao = descricao;
            Valor = valor;
            Estoque = estoque;
        }
        public Produto(int id, string codbarra, string descricao, string valor, string estoque)
        {
            {
                Id = id;
                Codbarra = codbarra;
                Descricao = descricao;
                Valor = valor;
                Estoque = estoque;
            }

        }
        public void Inserir()
        {
            var cmd = Banco.Abrir();

    }

}
