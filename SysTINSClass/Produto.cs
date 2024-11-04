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

            // cmd.CommandText = $"insert into usuarios values (0, '{Nome}', '{Email}', md5('{Senha}'), {Nivel.Id}, default);";

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_produtos_insert";
            cmd.Parameters.AddWithValue("spcod_barra", Codbarra);
            cmd.Parameters.AddWithValue("spvalor_unit", Valor);
            cmd.Parameters.AddWithValue("spestoque_minimo", Estoque);
            cmd.Parameters.AddWithValue("spid", Id);
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Id = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_produto_altera";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spcod_barra", Codbarra);
            cmd.Parameters.AddWithValue("spvalor_unit", Valor);
            cmd.Parameters.AddWithValue("spestoque_minimo", Estoque);
            return cmd.ExecuteNonQuery() > 0 ? true : false;
        }
    }

}
