namespace TesteHiper.Data.Model
{
    public class ProdutoModel : BaseModel
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public EstoqueModel Estoque { get; set; }
    }
}
