namespace LojaManoel.ViewModels
{
    public class ResultViewModel
    {
        public List<PedidoCaixa> pedidosCaixa { get; set; }
    }

    public class PedidoCaixa
    {
        public int pedido_id { get; set; }
        public List<Caixa> caixas { get; set; } 
    }
    public class Caixa
    {
        public string caixa_id { get; set; }
        public List<string> produtos { get; set; }
        public string observacao { get; set; }
    }
}
