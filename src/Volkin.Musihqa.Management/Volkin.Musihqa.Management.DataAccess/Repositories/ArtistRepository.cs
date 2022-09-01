using Volkin.Musihqa.Management.DataAccess.Common;
using Volkin.Musihqa.Management.Domain.Abstractions;
using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.DataAccess.Repositories
{
    internal class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
