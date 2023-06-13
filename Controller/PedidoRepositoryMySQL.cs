using System.Runtime.InteropServices.JavaScript;
using Gamification03.Interfaces;
using Gamification03.Model;
using MySql.Data.MySqlClient;

namespace Gamification03.Controller;

public class PedidoRepositoryMySQL : IPedidoRepository
{
    private MySqlConnection _mySqlConnection =
        new MySqlConnection("Persist Security Info=False;server=localhost;database=gamefication;uid=root;pwd=260405");

    private void InicializeDatabase()
    {
        try
        {
            //abre a conexao
            _mySqlConnection.Open();
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message.ToString());
        }
    }

    public void Adicionar(Pedido pedido)
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        cmd.CommandText =
            "INSERT INTO PEDIDO(data, cliente, status_pedido) VALUES(@data, @nome, @status); SELECT LAST_INSERT_ID();";

        cmd.Parameters.AddWithValue("@data", pedido.Data);
        cmd.Parameters.AddWithValue("@nome", pedido.Cliente);
        cmd.Parameters.AddWithValue("@status", pedido.Status);

        cmd.Connection = _mySqlConnection;

        pedido.Id = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.ExecuteReader();
    }

    public void Atualizar(Pedido pedido)
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        cmd.CommandText = "UPDATE SET data = @data, nome = @nome, status @status WHERE id = @id";

        cmd.Parameters.AddWithValue("@data", pedido.Data);
        cmd.Parameters.AddWithValue("@nome", pedido.Cliente);
        cmd.Parameters.AddWithValue("@status", pedido.Status);
        cmd.Parameters.AddWithValue("@id", pedido.Id);

        cmd.Connection = _mySqlConnection;
        cmd.ExecuteReader();
    }
    
    public void AtualizarStatus(int id, String status)
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        cmd.CommandText = "UPDATE Pedido SET status = @status WHERE id = @id";

        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@id", id);

        cmd.Connection = _mySqlConnection;
        cmd.ExecuteReader();
    }

    public void Excluir(int id)
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        cmd.CommandText = "DELETE * FROM ItemPedido WHERE pedido_id = @id";

        cmd.Parameters.AddWithValue("@id", id);

        cmd.Connection = _mySqlConnection;
        cmd.ExecuteReader();
        
        cmd.CommandText = "DELETE * FROM pedido WHERE id = @id";

        cmd.Parameters.AddWithValue("@id", id);

        cmd.Connection = _mySqlConnection;
        cmd.ExecuteReader();
    }

    public Pedido ObterPorId(int id)
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();

        cmd.CommandText = "SELECT * FROM pedido WHERE id = @id";

        cmd.Connection = _mySqlConnection;
        cmd.Parameters.AddWithValue("@id", id);

        var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Pedido(id,
                Convert.ToString(reader["data"]),
                Convert.ToString(reader["cliente"]),
                Convert.ToString(reader["status_pedido"])
            );
        }

        return null;
    }
    
    public IEnumerable<Pedido> ObterPorNome(String nome)
    {
        List<Pedido> pedidos = new List<Pedido>();
        
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();

        cmd.CommandText = "SELECT * FROM pedido WHERE cliente LIKE @nome";

        cmd.Connection = _mySqlConnection;
        cmd.Parameters.AddWithValue("@nome", nome);

        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Pedido pedido = new Pedido(Convert.ToInt32(reader["id"]),
                Convert.ToString(reader["data"]),
                Convert.ToString(reader["cliente"]),
                Convert.ToString(reader["status_pedido"])
            );

            pedidos.Add(pedido);
        }

        return pedidos;
    }
    
    public IEnumerable<Pedido> ObterPorStatus(String status)
    {
        List<Pedido> pedidos = new List<Pedido>();
        
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();

        cmd.CommandText = "SELECT * FROM pedido WHERE status_pedido @status";

        cmd.Connection = _mySqlConnection;
        cmd.Parameters.AddWithValue("@nome", status);

        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Pedido pedido = new Pedido(Convert.ToInt32(reader["id"]),
                Convert.ToString(reader["data"]),
                Convert.ToString(reader["cliente"]),
                Convert.ToString(reader["status_pedido"])
            );

            pedidos.Add(pedido);
        }

        return pedidos;
    }
    
    public IEnumerable<Pedido> ObterPorData(String data)
    {
        List<Pedido> pedidos = new List<Pedido>();
        
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();

        cmd.CommandText = "SELECT * FROM pedido WHERE data = @data";

        cmd.Connection = _mySqlConnection;
        cmd.Parameters.AddWithValue("@data", data);

        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Pedido pedido = new Pedido(Convert.ToInt32(reader["id"]),
                Convert.ToString(reader["data"]),
                Convert.ToString(reader["cliente"]),
                Convert.ToString(reader["status_pedido"])
            );

            pedidos.Add(pedido);
        }

        return pedidos;
    }

    public IEnumerable<Pedido> ListarTodos()
    {
        List<Pedido> pedidos = new List<Pedido>();

        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();

        cmd.CommandText = "SELECT * FROM pedido";

        cmd.Connection = _mySqlConnection;
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Pedido pedido = new Pedido(Convert.ToInt32(reader["id"]),
                Convert.ToString(reader["data"]),
                Convert.ToString(reader["cliente"]),
                Convert.ToString(reader["status_pedido"])
            );

            pedidos.Add(pedido);
        }

        return pedidos;
    }
}