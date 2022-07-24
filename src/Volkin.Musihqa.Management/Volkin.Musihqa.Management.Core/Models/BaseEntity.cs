using System.ComponentModel.DataAnnotations.Schema;

namespace Volkin.Musihqa.Management.Domain.Models
{
    public class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        internal BaseEntity(Guid id)
        {
            Id = id;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; init; }
    }
}
