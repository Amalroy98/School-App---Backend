using System.ComponentModel.DataAnnotations;

namespace HandsOnWebApiUsingModelValidation.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter name")]
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Mobile")]
        [RegularExpression("[6-9]\\d{9}", ErrorMessage = "Invalid Mobile number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [RegularExpression("[a-zA-Z0-9]{6,8}", ErrorMessage = "Password should be 6 to 8 character")]
        public string Password { get; set; }
    }
}