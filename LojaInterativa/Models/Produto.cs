using System.ComponentModel.DataAnnotations;

namespace LojaInterativa.Models
{
    public class Produto
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "R$ {0:F2}")]
        public double Preco { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }
        [Display(Name = "Categoria")]
        public Fabricante Fabricante { get; set; }
        public int FabricanteId { get; set; }

        public Produto() { }

        public Produto(int id, string nome, double preco, int quantidade, Fabricante fabricante)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            Fabricante = fabricante;
             
        }

        public double CalcularTotal()
        {
            return Preco * Quantidade;
        }
    }
}
