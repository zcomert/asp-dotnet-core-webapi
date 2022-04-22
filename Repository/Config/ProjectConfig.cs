using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project
                {
                    Id = new Guid("b67e3d43-23ef-444f-a022-5294810a5428"),
                    Name = "ASP.NET Core Web API Project",
                    Description = "Web Application Programming Interface",
                    Field = "Computer Science"
                });
        }
    }
}
