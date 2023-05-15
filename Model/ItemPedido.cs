namespace Gamification03.Model;

public class ItemPedido
{
    public int Id { get; private set; }
    public string Produto { get; private set; }
    public int Quantidade { get; private set; }
    public double PrecoUnit { get; private set; }
    public int PedidoId { get; private set; }

    public ItemPedido(int id, string produto, int quantidade, double precoUnit, int pedidoId)
    {
        if (string.IsNullOrWhiteSpace(produto))
        {
            throw new ArgumentException("Nome do produto não pode ser vazio ou nulo.");
        }
        if (quantidade <= 0)
         {
             throw new ArgumentException("Quantidade do produto deve ser maior que zero.");
         }
         if (precoUnit <= 0)
         {
             throw new ArgumentException("Preço unitário deve ser maior que zero.");
         }
         
        Id = id;
        Produto = produto;
        Quantidade = quantidade;
        PrecoUnit = precoUnit;
        PedidoId = pedidoId;
    }


}

