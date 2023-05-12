using System.ComponentModel.DataAnnotations;

namespace PustoKen.ViewModels
{
    public class RegisterVM
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        [MaxLength(50), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(25), DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(255), DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }


    }
}
