using System;
using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")] //Exibir o nome como Descrição, ao invés de Descricao
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Descricao { get; set; }

        [Range(1, 10, ErrorMessage = "valor fora da faixa")]
        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }
    }
}
