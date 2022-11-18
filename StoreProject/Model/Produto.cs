using System.ComponentModel.DataAnnotations;

namespace StoreProject.Model
{
    public class Produto : Entity
    {
        [StringLength(150)]
        public string Nome { get; set; }
        public string Imagem { get; set; }
        [StringLength(2000)]
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public bool Status { get; set; }
        public decimal Preco { get; set; }
    }
}
