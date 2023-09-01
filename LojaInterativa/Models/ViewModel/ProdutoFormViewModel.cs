namespace LojaInterativa.Models.ViewModel
{
    public class ProdutoFormViewModel
    {
        public Produto Produto { get; set; }
        public ICollection<Fabricante> Fabricantes { get; set; }

         


    }
}
