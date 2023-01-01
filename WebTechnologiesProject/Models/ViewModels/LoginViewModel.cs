using System.ComponentModel.DataAnnotations;

namespace WebTechnologiesProject.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required,MinLength(4,ErrorMessage ="Kullanıcı adı en az 4 karakter olmalıdır.")]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }

        [DataType(DataType.Password),Required,MinLength(4,ErrorMessage ="Şifre adı en az 4 karakter olmalıdır.")]
        public string Password { get; set; }

        public string ReturnURL { get; set; }

    }
}
