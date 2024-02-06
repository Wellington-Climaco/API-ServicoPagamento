using ServicoDePagamento.Models;
using static ServicoDePagamento.Enum.Enumerador;

namespace ServicoDePagamento.ViewModel.TransacaoVM
{
    public class ListarTransacao
    {
        public int Id { get; set; }

        public double  Valor { get; set; }

        public string Descricao { get; set; }

        public string NomeDonoCartao { get; set; }

        public EMetodoPagamento MetodoPagamento { get; set; }

        public string NumeroCartao { get; set; }

        public string ValidadeCartao { get; set; }

        public string CVV { get; set; }

        public string Cliente { get; set; }

    }
}
