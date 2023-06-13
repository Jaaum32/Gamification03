using Gamification03.Model;

namespace Gamification03.Interfaces;

public interface IGerenciamentoDePedidoRepository
{
    void criarPedido();
    void adicionarItemPedidos();
    void atualizarStatus();
    void removerPedido(List<ItemPedido> itensDoPedido, ItemPedido item);
    void listarPedidos(string filtro);
    void calcularValorPedido(List<ItemPedido> itensDoPedido);
}