using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System.ComponentModel.DataAnnotations;

namespace WebTechnologiesProject.Infrastructure.Validation
{
    public class FileExtensionAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            if(value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                string[] extensions = { "jpg", "png" };
                bool result = extension.Any(x => extension.EndsWith(x));

                if(!result)
                {
                    return new ValidationResult("JPG veya PNG olmalıdır.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
