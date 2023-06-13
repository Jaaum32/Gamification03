using Gamification03.Model;

namespace Gamification03.Interfaces;

public interface IGerenciamentoDePedidoRepository
{
    void criarPedido();
    void adicionarItemPedidos();
    void atualizarStatus();
    List<ItemPedido> removerPedido(List<ItemPedido> itensDoPedido, ItemPedido item);
    void listarPedidos(string filtro);
    double calcularValorPedido(List<ItemPedido> itensDoPedido);
}