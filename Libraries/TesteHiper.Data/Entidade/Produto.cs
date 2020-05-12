namespace TesteHiper.Data.Entidade
{
    public class Produto : BaseEntity
    {
        public virtual string Nome { get; set; }
        public virtual decimal Preco { get; set; }
        public virtual int? EstoqueId { get; set; }

        public virtual Estoque Estoque { get; set; }
    }
}
