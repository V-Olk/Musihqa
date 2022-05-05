namespace Volkin.Musihqa.Management.Core.Abstractions
{
    public interface IManagementUnitOfWork
    {
        IAlbumRepository Album { get; }
        IArtistRepository Artist { get; }

        Task CompleteAsync();
    }
}
