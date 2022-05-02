namespace Entities.Exceptions
{
    public sealed class ProjectNotFoundException : NotFoundException
    {
        public ProjectNotFoundException(Guid projectId)
            : base($"The project with {projectId} doesn't exists.")
        {
        }
    }
}
