using SysTINSClass;

internal static class ProdutoHelpers
{
    public static List<Produto> ObterLista()
    {
        List<Produto> lista = new();
        var cmd = Banco.Abrir();
        cmd.CommandText = $"select * from produtos order by cod_barras asc";
        var dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            lista.Add(new(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4)
                )
            );
        }
        return lista;
    }
    public static Produto ObterPorId(int id)
    {
        Produto produto = new();
        var cmd = Banco.Abrir();
    }
}