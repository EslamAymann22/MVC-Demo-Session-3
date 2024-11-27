using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword{ get; set; }
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage = "Dose't Match")]
        public string ConfPassword{ get; set; }
    }
}
