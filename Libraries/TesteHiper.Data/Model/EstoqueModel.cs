using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteHiper.Data.Model
{
    public class EstoqueModel : BaseModel
    {
        [Required(ErrorMessage = "Deve ser informado um nome para o estoque")]
        public string Nome { get; set; }

        public List<ProdutoModel> Produtos { get; set; }

        public EstoqueModel()
        {
            Produtos = new List<ProdutoModel>();
        }
    }
}
