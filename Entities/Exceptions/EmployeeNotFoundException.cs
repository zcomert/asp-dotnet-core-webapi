namespace Entities.Exceptions
{
    public sealed class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(Guid id)
            : base($"The employee with {id} doesn't exists.")
        {

        }
    }
}
