using StoreProject.Data;
using StoreProject.Model;
using StoreProject.Repositories.Interface;

namespace StoreProject.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext db) : base(db)
        {

        }
    }
}
