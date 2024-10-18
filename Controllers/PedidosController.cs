using LojaManoel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LojaManoel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController
    {
        [HttpPost("Embalar")]
        public async Task<ActionResult<List<ResultViewModel>>> Embalar(PedidoViewModel pedidoViewModel)
        {
            List<ResultViewModel> result = new List<ResultViewModel>();

            result = Encaixotar(pedidoViewModel);

            return result;
        }

        private List<ResultViewModel> Encaixotar(PedidoViewModel pedidos)
        {
            List<ResultViewModel> result = new List<ResultViewModel>();
            




            int i = 0;
            foreach(var pedido in pedidos.pedidos)
            {
                ResultViewModel caixaResult = new ResultViewModel();
                PedidoCaixa pedidoCaixa = new PedidoCaixa();
                List<PedidoCaixa> listaPedidoCaixa = new List<PedidoCaixa>();
                Caixa caixa = new Caixa();
                List<Caixa> listaCaixas = new List<Caixa>();

                int largura = 0;
                int altura = 0;
                int comprimento = 0;
                int area = 0;
                List<string> produtos = new List<string>();


                foreach(var produtopedido in pedido.produtos)
                {
                    produtos.Add(produtopedido.produto_id);
                    largura = largura + produtopedido.dimensoes.largura;
                    altura = altura + produtopedido.dimensoes.altura;
                    comprimento = comprimento + produtopedido.dimensoes.comprimento;
                }

                area = altura * comprimento * largura;

                if(area < 160000 )
                {
                    pedidoCaixa.pedido_id = pedido.pedido_id;
                    caixa.caixa_id = "Caixa 1";
                    caixa.produtos = produtos;
                    listaCaixas.Add(caixa);
                    pedidoCaixa.caixas = listaCaixas;
                }
                else if (area >= 160000 && area < 240000)
                {
                    pedidoCaixa.pedido_id = pedido.pedido_id;
                    caixa.caixa_id = "Caixa 2";
                    caixa.produtos = produtos;
                    listaCaixas.Add(caixa);
                    pedidoCaixa.caixas = listaCaixas;
                }
                else if(area == 240000)
                {
                    pedidoCaixa.pedido_id = pedido.pedido_id;
                    caixa.caixa_id = "Caixa 3";
                    caixa.produtos = produtos;
                    listaCaixas.Add(caixa);
                    pedidoCaixa.caixas = listaCaixas;
                }
                else
                {
                    if(produtos.Count > 2)
                    {
                        produtos = new List<string>();
                        foreach (var produtossepara in produtos)
                        {

                        }

                    }
                    else
                    {
                        pedidoCaixa.pedido_id = pedido.pedido_id;
                        caixa.caixa_id = null;
                        caixa.produtos = produtos;
                        caixa.observacao = "Produto não cabe em nenhuma caixa disponível.";
                        listaCaixas.Add(caixa);
                        pedidoCaixa.caixas = listaCaixas;
                    }
                    
                }
                

                i = i + 1;

                listaPedidoCaixa.Add(pedidoCaixa);
                
                caixaResult.pedidosCaixa = listaPedidoCaixa; 
                result.Add(caixaResult);
            }

            return result;

        }

    }
}
