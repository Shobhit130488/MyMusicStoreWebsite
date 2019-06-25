
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MusicStore.Core.Models
{
    [ExcludeFromCodeCoverage]
    public class CustomerDetails
    {

        [Required]
        [RegularExpression("[a-zA-Z]{2,20}", ErrorMessage = "Enter a valid name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("[a-zA-Z]{2,20}", ErrorMessage = "Enter a valid Last name")]
        public string LastName { get; set; }
        
        public string payableAmount { get; set; }
        public int CardFee { get; set; }
        public string customerIp { get; set; }

        [Required]
        [RegularExpression("[0-9]{16}", ErrorMessage = "Card Number must be 16 numeric numbers.")]
        public string CardNo { get; set; }

        [Required]
        [RegularExpression("[0-9]{3}", ErrorMessage = "CCV must be 3 numeric numbers.")]
        public string CardCCVNo { get; set; }

        [Required]
        [RegularExpression("[a-zA-Z]{3}", ErrorMessage = "Not a valid month")]
        public string CardExpiryMonth { get; set; }

        [Required]
        [RegularExpression("(20)[1-9][0-9]", ErrorMessage = "Not a valid year")]
        public string CardExpiryYear { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }


        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        public string State { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(24)]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

       



    }
}
