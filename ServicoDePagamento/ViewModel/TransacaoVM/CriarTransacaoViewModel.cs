using System.ComponentModel.DataAnnotations;
using static ServicoDePagamento.Enum.Enumerador;

namespace ServicoDePagamento.ViewModel.TransacaoVM
{
    public class CriarTransacaoViewModel
    {
        [Required(ErrorMessage = "Descricao é um campo obrigatório")]
        [Length(3,100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "valor é um campo obrigatório")]
        [Range(1, double.MaxValue)]
        public double Valor {get;set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [Length(3,50)]
        public string NomeDonoCartao { get; set; }

        [Required(ErrorMessage = "Metodo de Pagamento é um campo obrigatório")]
        public EMetodoPagamento MetodoPagamento { get; set; }

        [Required(ErrorMessage = "Insira o numero do cartão")]
        [RegularExpression(@"\b\d{4}\b", ErrorMessage ="somente os 4 ultimos numeros do cartão")]
        public string NumeroCartao { get; set; }

        [Required(ErrorMessage = "Insira a validade do cartão")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$",ErrorMessage ="insira um formato valido")]
        public string ValidadeCartao { get; set; }

        [Required(ErrorMessage = "Insira o CVV do cartão")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "insira um CVV valido")]
        public string CVV { get; set; }

        [Required]
        public int ClienteId { get; set; }
    }
}
