using ServicoDePagamento.Enum;
using static ServicoDePagamento.Enum.Enumerador;

namespace ServicoDePagamento.Models
{
    public class Transacao
    {
        public int Id { get; set; }

        public double Valor { get; set; }

        public string Descricao { get; set; }

        public EMetodoPagamento MetodoPagamento {  get; set; }

        public string NumeroCartao {  get; set; }

        public string ValidadeCartao { get; set; }

        public string CVV {  get; set; }

        public Cliente Cliente { get; set; }

        public Recebiveis Recebivel { get; set;}

    }
}
