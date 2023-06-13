using System.ComponentModel.Design;
using System.Data;
using Gamification03.Controller;
using Gamification03.Services;
using System.Data;
using Gamification03.Controller;
using Gamification03.Model;
using MySql.Data.MySqlClient;
    
public class Program

public class Erick

{
    public static void Main()
    {
        PedidoRepositoryMySQL a = new PedidoRepositoryMySQL();

        GerenciamentoDePedido gerenciamento = new GerenciamentoDePedido();

        int sair = 0;

        while (sair != 1)
        {
            switch (menu())
            {
                case 1:
                    gerenciamento.adicionarPedido();
                    break;
                case 2:
                    gerenciamento.adicionarItemPedido();
                    break;
                case 3:
                    gerenciamento.atualizarStatusPedido();
                    break;
                case 4:
                    gerenciamento.removerItemPedido();
                    break;
                case 5:
                    gerenciamento.removerPedido();
                    break;
                case 6:
                    gerenciamento.listarPedidosFiltro();
                    break;
                case 7:
                    gerenciamento.calcularValorPedido();
                    break;
                default:
                    sair = 1;
                    break;
            }
        }
    }

    public static int menu()
    {
        Console.WriteLine("-=: Digite a opção desejada :=-");
        Console.WriteLine("1 - Adicionar novo pedido");
        Console.WriteLine("2 - Adicionar itens a um pedido");
        Console.WriteLine("3 - Atualizar status pedido");
        Console.WriteLine("4 - Remover item de pedido");
        Console.WriteLine("5 - Remover pedido");
        Console.WriteLine("6 - Listar pedido com filtro");
        Console.WriteLine("7 - Calcular valor de pedido");
        Console.WriteLine("0 - Sair");
        return Convert.ToInt32(Console.Read());


        var b = a.ObterPorId(1);


        Console.WriteLine("Id: " + b.Id + ",Data: " + b.Data + ",Cliente: " + b.Cliente + ",Status: " +
                          b.Status);
        
        

    }
}