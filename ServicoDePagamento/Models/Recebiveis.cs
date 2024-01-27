namespace ServicoDePagamento.Models
{
    public class Recebiveis
    {
        public int Id { get; set; }

        public string status {  get; set; }

        public DateTime DataPagamento { get; set; }

        public float Taxa { get; set; }

        public Cliente Cliente { get; set; }

        public int TransacaoId { get; set; }
        public Transacao Transacao { get; set; }

    }
}
