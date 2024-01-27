using System.ComponentModel.DataAnnotations;

namespace ServicoDePagamento.ViewModel.Cliente
{
    public class ClienteViewModel
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [Length(3, 50, ErrorMessage = "Minimo 3 maximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Documento é um campo obrigatório")]
        [StringLength(12)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Saldo é um campo obrigatório")]
        public float Saldo { get; set; }


        public string Cep { get; set; }

    }
}
