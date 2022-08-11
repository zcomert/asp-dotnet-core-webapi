using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;

using System.Text;

namespace ProjectManagement.Utilities.OutputFormatter.cs
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(ProjectDto).IsAssignableFrom(type)
                || typeof(IEnumerable<ProjectDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<ProjectDto>)
            {
                foreach (var project in (IEnumerable<ProjectDto>)context.Object)
                {
                    FormatCsv(buffer, project);
                }
            }
            else
            {
                FormatCsv(buffer, (ProjectDto)context.Object);
            }

            await response.WriteAsync(buffer.ToString());
        }

        private static void FormatCsv(StringBuilder buffer, ProjectDto project)
        {
            buffer.AppendLine($"{project.Id},\"{project.Name},\"{project.Description}\"");
        }

    }
}
