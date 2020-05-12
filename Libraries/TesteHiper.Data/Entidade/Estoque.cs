using System.Collections.Generic;

namespace TesteHiper.Data.Entidade
{
    public class Estoque : BaseEntity
    {
        public virtual string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
