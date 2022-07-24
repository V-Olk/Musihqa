namespace Volkin.Musihqa.Management.Domain.Abstractions
{
    public interface IManagementUnitOfWork
    {
        IAlbumRepository Album { get; }
        IArtistRepository Artist { get; }

        Task CompleteAsync(CancellationToken cancellationToken);
    }
}
