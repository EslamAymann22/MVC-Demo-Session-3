using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class RegisterViewModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password Dosen't Match")]
        public string ConfirmPassword{ get; set; }
        public bool IsAgree{ get; set; }
    }
}
