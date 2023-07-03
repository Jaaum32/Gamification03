using System.Globalization;
using Gamification03.Controller;
using Gamification03.Model;

namespace Gamification03.Services;

using Interfaces;

public class GerenciamentoDePedidos : IGerenciamentoDePedidoRepository
{
    private readonly PedidoRepositoryMySql _pedidoRepositoryMySqlr = new PedidoRepositoryMySql();
    private readonly ItemPedidoRepositoryMySql _itemPedidoRepositoryMySqlpr = new ItemPedidoRepositoryMySql();

    public void CriarPedido()
    {
        Console.WriteLine("PREENCHA OS DADOS DO PEDIDO:");
        Console.Write("Data do pedido (dd/mm/aaaa): ");
        string? dataPedido = readData();

        Console.Write("Cliente: ");
        string? cliente = Console.ReadLine();

        Console.Write("Status [Entregue|Enviado|Pendente]: ");
        string? status = readStatus();

        Pedido pedido = new Pedido(dataPedido, cliente, status);

        _pedidoRepositoryMySqlr.Adicionar(pedido);
    }

    public void AdicionarItemPedidos()
    {
        _pedidoRepositoryMySqlr.ImprimirTodos();
        Console.WriteLine("PREENCHA OS DADOS DO ITEM:");
        Console.Write("ID do pedido: ");
        int pedidoId;
        while (true)
        {
            try
            {
                pedidoId = Convert.ToInt32(Console.ReadLine());
                if (_pedidoRepositoryMySqlr.ObterPorId(pedidoId) == null)
                    Console.WriteLine("Nenhum pedido com esse ID!");
                else
                    break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        Console.Write("Nome do produto: ");
        string? produto = Console.ReadLine();

        Console.Write("Quantidade: ");
        int quantidade = readInt();

        Console.Write("Preço unitário: ");
        double precoUnitario = readDouble();

        ItemPedido itemPedido = new ItemPedido(produto, quantidade, precoUnitario, pedidoId);

        _itemPedidoRepositoryMySqlpr.Adicionar(itemPedido);
    }

    public void AtualizarStatus()
    {
        _pedidoRepositoryMySqlr.ImprimirTodos();
        Console.Write("ID do pedido: ");
        int pedidoId;
        while (true)
        {
            try
            {
                pedidoId = Convert.ToInt32(Console.ReadLine());
                if (_pedidoRepositoryMySqlr.ObterPorId(pedidoId) == null)
                    Console.WriteLine("Nenhum pedido com esse ID!");
                else
                    break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        Console.Write("Status [Entregue|Enviado|Pendente]: ");
        string? status = readStatus();

        _pedidoRepositoryMySqlr.AtualizarStatus(pedidoId, status);
    }

    public void RemoverPedido()
    {
        _pedidoRepositoryMySqlr.ImprimirTodos();
        Console.WriteLine("Digite o ID do pedido para excluir:");
        int pedidoId;
        while (true)
        {
            try
            {
                pedidoId = Convert.ToInt32(Console.ReadLine());
                if (_pedidoRepositoryMySqlr.ObterPorId(pedidoId) == null)
                    Console.WriteLine("Nenhum pedido com esse ID! Digite outro");
                else
                    break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        _pedidoRepositoryMySqlr.Excluir(pedidoId);
    }

    public void ListarPedidos(string filtro)
    {
        IEnumerable<Pedido> pedidos = new List<Pedido>();

        if (filtro == "Cliente")
        {
            Console.Write("Cliente: ");
            string? cliente = Console.ReadLine();

            if (cliente != null)
                pedidos = _pedidoRepositoryMySqlr.ObterPorNome(cliente);
        }

        else if (filtro == "Status")
        {
            Console.Write("Status [Entregue|Enviado|Pendente]: ");
            string? status = readStatus();

            if (status != null)
                pedidos = _pedidoRepositoryMySqlr.ObterPorStatus(status);
        }

        else if (filtro == "Data")
        {
            Console.Write("Data do pedido (dd/mm/aaaa): ");
            string? dataPedido = readData();

            if (dataPedido != null)
                pedidos = _pedidoRepositoryMySqlr.ObterPorData(dataPedido);
        }

        if (pedidos.Count() == 0)
            Console.WriteLine("Nenhum pedido com esses dados!");
        else
        {
            foreach (var pedido in pedidos)
            {
                Console.WriteLine(pedido.ToString());
                IEnumerable<ItemPedido> itens = _itemPedidoRepositoryMySqlpr.ListarTodosPorId(pedido.Id);
                foreach (var item in itens)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }

    public void CalcularValorPedido()
    {
        double sum = 0;

        Console.Write("ID do pedido: ");
        int pedidoId = Convert.ToInt32(Console.ReadLine());

        IEnumerable<ItemPedido> itens = _itemPedidoRepositoryMySqlpr.ListarTodosPorId(pedidoId);

        foreach (var item in itens)
        {
            sum += item.Quantidade * item.PrecoUnit;
        }

        Console.WriteLine("Valor Total Pedido: " + sum);
    }

    public int readInt()
    {
        int x;
        while (!int.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Digite um valor válido!");
        }

        return x;
    }

    public double readDouble()
    {
        double x;
        while (!double.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Digite um valor válido!");
        }

        return x;
    }

    public string readStatus()
    {
        string x;
        while (true)
        {
            x = Console.ReadLine();
            if (x != "Entregue" && x != "Enviado" && x != "Pendente")
                Console.WriteLine("Status inválido!");
            else
                break;
        }

        return x;
    }

    public string readData()
    {
        DateOnly dataValida;

        while (!DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture,
                   DateTimeStyles.None,
                   out dataValida))
        {
            Console.WriteLine("Digite uma data válida!");
        }

        return dataValida.ToString("yyyy-MM-dd");
    }
}