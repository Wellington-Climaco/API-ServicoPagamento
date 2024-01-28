using static ServicoDePagamento.Enum.Enumerador;

namespace ServicoDePagamento.ViewModel.TransacaoVM
{
    public class CriarTransacaoViewModel
    {
        public string Descricao { get; set; }

        public decimal Valor {get;set; }

        public EMetodoPagamento MetodoPagamento { get; set; }

        public string NumeroCartao { get; set; }

        public string ValidadeCartao { get; set; }

        public string CVV { get; set; }

        public int ClienteId { get; set; }
    }
}
