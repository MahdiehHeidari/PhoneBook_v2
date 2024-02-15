using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Domain.Validate;

namespace Domain
{
	public class Phone
	{
        [Required, Key]//not null,primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Mobile(ErrorMessages.Mobile)]
        [Display(Name = "موبایل")]
       // [RegularExpression(@"^\d+$", ErrorMessage = "شماره تلفن باید فقط شامل اعداد باشد.")]
        [MaxLength(11, ErrorMessage = ErrorMessages.MaxLength)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.Required)]
      
        public string PhoneNumber { get; set; }

        [Display(Name = "نوع تلفن")]
        public PhoneType Type { get; set; }
        public int PersonId { get; set; } // Foreign key to Person
        public Person Person { get; set; } // Navigation property
    }
}

