using Gamification03.Interfaces;
using Gamification03.Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace Gamification03.Controller;

public class ItemPedidoRepositoryMySQL : IItemPedidoRepository
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
    
    public void Adicionar(ItemPedido itemPedido)
    {
        throw new NotImplementedException();
    }

    public void Atualizar(ItemPedido itemPedido)
    {
        throw new NotImplementedException();
    }

    public void Excluir(int id)
    {
        throw new NotImplementedException();
    }

    public ItemPedido ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ItemPedido> ListarTodos()
    {
        throw new NotImplementedException();
    }
}