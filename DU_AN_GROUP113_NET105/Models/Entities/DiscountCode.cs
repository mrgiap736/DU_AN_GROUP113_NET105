using System.ComponentModel.DataAnnotations;

namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class DiscountCode
    {
        [Key]
        [RegularExpression(@"^[A-Z]{2}\d{6}$", ErrorMessage = "Id must start with 2 uppercase letters followed by 6 digits.")]
        public string Id { get; set; } //Id này sẽ tự nhập và nó sẽ là code để khách nhập luôn 
        
        [Required]
        [CustomValidation(typeof(DiscountCode),"ValidateValue")]
        public int Value { get; set; } //Giá trị mã 

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Condition must be a non-negative number.")]
        public int Condition { get; set; } //Kiểu như tổng đơn hàng phải lớn hơn ... mới được áp dụng mã

        [Required]
        [MinLength(1)]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; } //Số lượng mã 

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Status must be a non-negative number.")]
        public int Status { get; set; } //Tình trạng mã 

        //Quan hệ

        public Guid? CustomerId { get; set; }
        public int CategoryId { get; set; } 
        public DiscountCategory DiscountCategory { get; set; }
        public Cart? Cart { get; set; }


        public static ValidationResult ValidateValue(int value, ValidationContext context)
        {
            var instance = context.ObjectInstance as DiscountCode;

            if (instance != null)
            {
                // Nếu CategoryId = 0, cho phép nhập số bình thường và số dương
                if (instance.CategoryId == 0)
                {
                    if (value <= 0)
                    {
                        return new ValidationResult("Value must be a positive number.");
                    }
                }
                // Nếu CategoryId = 1, chỉ cho phép nhập giá trị từ 1 đến 100 và số dương
                else if (instance.CategoryId == 1)
                {
                    if (value <= 0 || value > 100)
                    {
                        return new ValidationResult("Value must be a positive number between 1 and 100.");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
