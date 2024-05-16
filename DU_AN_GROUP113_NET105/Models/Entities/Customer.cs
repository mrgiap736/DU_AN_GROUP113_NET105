using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 6)]
        [RegularExpression(@"^[a-z0-9]{6,15}$", ErrorMessage = "Usernames can only be entered using lowercase letters and numbers, between 6-15 characters !")]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]

        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Customer), "ValidateBirthday")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        [Phone]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        //Quan he
        public Cart? Cart { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }


        public static ValidationResult ValidateBirthday(DateTime birthday, ValidationContext context)
        {
            if (birthday >= DateTime.Now)
            {
                return new ValidationResult("Birthday must be a date in the past.");
            }
            return ValidationResult.Success;
        }
    }
}
