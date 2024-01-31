using ServicoDePagamento.Models;

namespace ServicoDePagamento.ViewModel.Recebivel
{
    public class RecebivelViewModel
    {
        public string status { get; set; }

        public DateTime DataPagamento { get; set; }

        public float Taxa { get; set; }

        public int ClienteId { get; set; }

        public int TransacaoId { get; set; }


    }
}
