using LojaManoel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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
                        List<string> produtos2 = new List<string>();
                        List<string> produtos1 = new List<string>();
                        int largura1 = 0;
                        int altura1 = 0;
                        int comprimento1 = 0;
                        int largura2 = 0;
                        int altura2 = 0;
                        int comprimento2 = 0;
                        int area1 = 0;
                        int area2 = 0;
                        

                        for (int j = 0; j <2; j++)
                        {
                            produtos1.Add(produtos[j]);
                        }
                        for(int i = 2; i < 4; i++)
                        {
                            produtos2.Add(produtos[i]);
                        }


                        int p = 0;
                        List<string> produtosNovo1 = new List<string>();
                        List<string> produtosNovo2 = new List<string>();
                        List<int> areas = new List<int>();

                        foreach (var produtopedido in pedido.produtos)
                        {

                            if (produtos1[p] == produtopedido.produto_id)
                            {
                                produtosNovo1.Add(produtopedido.produto_id);
                                largura1 = largura1 + produtopedido.dimensoes.largura;
                                altura1 = altura1 + produtopedido.dimensoes.altura;
                                comprimento1 = comprimento1 + produtopedido.dimensoes.comprimento;

                            }
                            else
                            {
                                produtosNovo2.Add(produtopedido.produto_id);
                                largura2 = largura2 + produtopedido.dimensoes.largura;
                                altura2 = altura2 + produtopedido.dimensoes.altura;
                                comprimento2 = comprimento2 + produtopedido.dimensoes.comprimento;
                            }
                            if (p < 1)
                            {
                                p = p + 1;
                            }                            
                        }

                        area1 = altura1 * comprimento1 * largura1;
                        area2 = altura2 * comprimento2 * largura2;
                        areas.Add(area1);
                        areas.Add(area2);
                        for (int n = 0; n <= 1; n++)
                        {
                            caixa = new Caixa();
                            
                            if (areas[n] < 160000)
                            {
                                caixa.caixa_id = "Caixa 1";
                                if (n == 0)
                                {
                                    caixa.produtos = produtosNovo1;
                                }
                                else
                                {
                                    caixa.produtos = produtosNovo2;
                                }                                
                                                                
                            }
                            else if (areas[n] >= 160000 && areas[n] < 240000)
                            {
                                
                                caixa.caixa_id = "Caixa 2";
                                if (n == 0)
                                {
                                    caixa.produtos = produtosNovo1;
                                }
                                else
                                {
                                    caixa.produtos = produtosNovo2;
                                }
                                
                            }
                            else if (areas[n] == 240000)
                            {                                
                                caixa.caixa_id = "Caixa 3";
                                if (n == 0)
                                {
                                    caixa.produtos = produtosNovo1;
                                }
                                else
                                {
                                    caixa.produtos = produtosNovo2;
                                }                                
                                
                            }
                            else
                            {
                                caixa.caixa_id = null;
                                if (n == 0)
                                {
                                    caixa.produtos = produtosNovo1;
                                }
                                else
                                {
                                    caixa.produtos = produtosNovo2;
                                }
                                caixa.observacao = "Produto não cabe em nenhuma caixa disponível.";
                                
                            }

                            listaCaixas.Add(caixa);
                        }
                        pedidoCaixa.pedido_id = pedido.pedido_id;
                        pedidoCaixa.caixas = listaCaixas;

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
                

                

                listaPedidoCaixa.Add(pedidoCaixa);
                
                caixaResult.pedidosCaixa = listaPedidoCaixa; 
                result.Add(caixaResult);
            }

            return result;

        }

    }
}
