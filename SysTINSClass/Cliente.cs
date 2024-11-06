using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysTINSApp;

namespace SysTINSClass
{
    public class Cliente
    {


        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNasc { get; set; }
        public DateTime? DataCad { get; set; }
        public string? Ativo { get; set; }
        public List<Endereco> Enderecos { get; set; }

        public Cliente(string? nome, string? cpf, string? telefone, string? email, DateTime? datanasc, DateTime? dataCad, string? ativo)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            DataNasc = datanasc;
            DataCad = dataCad;
            Ativo = ativo;
        }
        public Cliente(string? nome, string? cpf, string? telefone, string? email, DateTime? datanasc, DateTime? dataCad, string? ativo, List<Endereco> enderecos)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            DataNasc = datanasc;
            DataCad = dataCad;
            Ativo = ativo;
            Enderecos = enderecos;
        }

        public Cliente(int id, string? nome, string? cpf, string? telefone, string? email, DateTime? datanasc, DateTime? dataCad, string? ativo, List<Endereco> enderecos)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            DataNasc = datanasc;
            DataCad = dataCad;
            Ativo = ativo;
            Enderecos = enderecos;
        }

        public Cliente()
        {
        }

        public void Inserir()

        {
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_cliente_insert";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spcpf", Cpf);
            cmd.Parameters.AddWithValue("sptelefone", Telefone);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("spdatanasc", DataNasc);
            cmd.Parameters.AddWithValue("spdatacad", DataCad);
            cmd.Parameters.AddWithValue("spativo", Ativo);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static Cliente ObterPorId(int id)
        {
            Cliente cliente = new();
            var cmd = Banco.Abrir();
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cliente = new(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetDateTime(5),
                        dr.GetDateTime(6),
                        dr.GetBoolean(7),
                    );
            }
            return cliente;
        }
        public static List<Cliente> ObterLista()
        {
            List<Cliente> clientes = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from cliente where id ={id}";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clientes = new(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetDateTime(5),
                        dr.GetDateTime(6),
                        dr.GetBoolean(7),
                        (dr.GetInt32(8))

                    );
            }
            return clientes;

        }
    }
}