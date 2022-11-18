using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Model
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
