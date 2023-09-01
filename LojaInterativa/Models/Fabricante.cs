using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace LojaInterativa.Models
{
    public class Fabricante
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Data de criação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; } = DateTime.Now;
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        
        public Fabricante()
        {
        }

        public Fabricante(int id, string nome)
        {
            Id = id;
            Nome = nome;
             
        }

        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(produto);
        }
    }
}
