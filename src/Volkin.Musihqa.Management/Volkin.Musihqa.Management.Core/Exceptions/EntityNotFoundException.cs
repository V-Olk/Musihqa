namespace Volkin.Musihqa.Management.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string repositoryName, Guid id)
            : base(GetExceptionMessage(repositoryName, id))
        {

        }

        private static string GetExceptionMessage(string repositoryName, Guid id)
            => $"Failed to find entity with Guid \"{id}\" in repository \"{repositoryName}\"";
    }
}
