using Gamification03.Interfaces;
using Gamification03.Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace Gamification03.Controller;

public class PedidoRepositoryMySQL : IPedidoRepository
{
    public void Adicionar(Pedido pedido)
    {
        throw new NotImplementedException();
    }

    public void Atualizar(Pedido pedido)
    {
        throw new NotImplementedException();
    }

    public void Excluir(int id)
    {
        throw new NotImplementedException();
    }

    public Pedido ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pedido> ListarTodos()
    {
        throw new NotImplementedException();
    }
}