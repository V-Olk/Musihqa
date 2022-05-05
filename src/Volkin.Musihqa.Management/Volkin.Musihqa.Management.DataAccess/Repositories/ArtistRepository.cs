using Volkin.Musihqa.Management.Core.Abstractions;
using Volkin.Musihqa.Management.Core.Domain.Management;
using Volkin.Musihqa.Management.DataAccess.Common;

namespace Volkin.Musihqa.Management.DataAccess.Repositories
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
