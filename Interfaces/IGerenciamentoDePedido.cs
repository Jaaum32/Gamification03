using Gamification03.Model;

namespace Gamification03.Interfaces;

public interface IGerenciamentoDePedido
{
    ItemPedido criarPedido(ItemPedido itemPedido);
    List<ItemPedido> adicionarItemPedidos(List<ItemPedido> itensDoPedido, ItemPedido item);
    Pedido atualizarStatus(Pedido pedido);
    List<ItemPedido> removerPedido(List<ItemPedido> itensDoPedido, ItemPedido item);
    void listarPedidos(string filtro);
    double calcularValorPedido(List<ItemPedido> itensDoPedido);
}