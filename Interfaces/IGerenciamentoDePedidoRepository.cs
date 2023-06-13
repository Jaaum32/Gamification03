using Gamification03.Model;

namespace Gamification03.Interfaces;

public interface IGerenciamentoDePedidoRepository
{
    void criarPedido();
    void adicionarItemPedidos();
    void atualizarStatus();
    void removerPedido();
    void listarPedidos(string filtro);
    void calcularValorPedido(List<ItemPedido> itensDoPedido);
}