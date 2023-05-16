using System.Data;
using Gamification03.Controller;
using Gamification03.Model;
using MySql.Data.MySqlClient;


public class Erick
{
    public static void Main()
    {
        PedidoRepositoryMySQL a = new PedidoRepositoryMySQL();

        var b = a.ObterPorId(1);


        Console.WriteLine("Id: " + b.Id + ",Data: " + b.Data + ",Cliente: " + b.Cliente + ",Status: " +
                          b.Status);
    }
}