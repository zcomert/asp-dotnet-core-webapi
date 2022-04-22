using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee()
                {
                    Id = new Guid("bc1ae16a-3572-40de-bd02-dab970697d20"),
                    ProjectId = new Guid("b67e3d43-23ef-444f-a022-5294810a5428"),
                    FirstName = "Ahmet",
                    LastName = "Yıldırım",
                    Age = 30,
                    Position = "Senior Developer"
                }
                );
        }
    }
}
