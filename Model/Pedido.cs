namespace Gamification03.Model;

public class Pedido
{
    private int Id { get; set; }
    private string Data { get; set; }
    private string Cliente { get; set; }
    private string Status { get; set; }

    private List<ItemPedido> ItensDoPedido;

    public Pedido(int id, string data, string cliente, string status, List<ItemPedido> itensDoPedido)
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
        ItensDoPedido = itensDoPedido;

    }
}