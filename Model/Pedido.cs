namespace Gamification03.Model;

public class Pedido
{
    public int Id { get; private set; }
    public string Data { get; private set; }
    public string Cliente { get; private set; }
    public string Status { get; private set; }

    public Pedido(int id, string data, string cliente, string status)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            throw new ArgumentException("Data não pode ser vazio ou nulo.");
        }
        if (string.IsNullOrWhiteSpace(cliente))
        {
            throw new ArgumentException("Nome do cliente não pode ser vazio ou nulo.");
        }
        if (string.IsNullOrWhiteSpace(status))
        {
            throw new ArgumentException("Status não pode ser vazio ou nulo.");
        }
        
        Id = id;
        Data = data;
        Cliente = cliente;
        Status = status;
    }
}