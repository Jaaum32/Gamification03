using Gamification03.Interfaces;
using Gamification03.Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace Gamification03.Controller;

public class PedidoRepositoryMySQL : IPedidoRepository
{
    private MySqlConnection _mySqlConnection = new MySqlConnection("Persist Security Info=False;server=localhost;database=gamefication;uid=root;pwd=260405");
    private void InicializeDatabase()
    {
        try{
            //abre a conexao
            _mySqlConnection.Open();
        }
        catch(System.Exception e)
        {
            Console.WriteLine(e.Message.ToString());
        }
    }
    
    public void Adicionar(Pedido pedido)
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        cmd.CommandText = "INSERT INTO PEDIDO(data, cliente, status_pedido) VALUES(@data, @nome, @status)";

        cmd.Parameters.AddWithValue("@data", pedido.Data);
        cmd.Parameters.AddWithValue("@nome", pedido.Cliente);
        cmd.Parameters.AddWithValue("@status", pedido.Status);
        
        cmd.Connection = _mySqlConnection;
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

    public void Excluir(int id)
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        cmd.CommandText = "DELETE * FROM pedido WHERE id = @id";
        
        cmd.Parameters.AddWithValue("@id", id);
        
        cmd.Connection = _mySqlConnection;
        cmd.ExecuteReader();
    }

    public Pedido ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pedido> ListarTodos()
    {
        InicializeDatabase();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        cmd.CommandText = "SELECT * FROM pedido";
        
        cmd.Connection = _mySqlConnection;
        cmd.ExecuteReader();
    }
}