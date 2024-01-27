namespace ServicoDePagamento.Models
{
    public class Cliente
    {
        public int Id {  get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public float Saldo { get; set; }

        public string Cep { get; set; }

        public IList<Recebiveis> Recebiveis { get; set; }
        public IList<Transacao> Transacoes { get; set; }

    }
}
