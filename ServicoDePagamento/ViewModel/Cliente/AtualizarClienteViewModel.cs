using System.ComponentModel.DataAnnotations;

namespace ServicoDePagamento.ViewModel.Cliente
{
    public class AtualizarClienteViewModel
    {
        [Required]
        public int Id { get; set; }

        [Length(3, 50, ErrorMessage = "Minimo 3 maximo 50 caracteres")]
        public string Nome { get; set; }

        [Length(5, 8, ErrorMessage = "Cep invalido")]
        public string Cep { get; set; }
    }
}
