namespace LojaManoel.ViewModels
{
    public class PedidoViewModel
    {
        public List<Pedido> pedidos { get; set; }
    }
    public class Produto
    {
        public string produto_id { get; set; }
        public Dimensoes dimensoes { get; set; }
    }
    public class Dimensoes
    {
        public int altura { get; set; }
        public int largura { get; set; }
        public int comprimento { get; set; }
    }

    public class Pedido
    {
        public int pedido_id { get; set; }
        public List<Produto> produtos { get; set; }
    }
}
