using System.ComponentModel.DataAnnotations;

namespace ServicoDePagamento.ViewModel.Clientes
{
    public class ClienteViewModel
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [Length(3, 50, ErrorMessage = "Minimo 3 maximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Documento é um campo obrigatório")]
        [Length(9,12,ErrorMessage ="Digite um documento valido")]        
        public string Documento { get; set; }

        [Required(ErrorMessage ="Cep é um campo obrigatório")]
        public string Cep { get; set; }

    }
}
