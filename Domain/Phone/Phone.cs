using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
	public class Phone
	{
        [Required, Key]//not null,primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(14, MinimumLength = 11)]
        [RegularExpression(@"^\d+$", ErrorMessage = "شماره تلفن باید فقط شامل اعداد باشد.")]
        public string PhoneNumber { get; set; }


        public PhoneType Type { get; set; }
        public int PersonId { get; set; } // Foreign key to Person
        public Person Person { get; set; } // Navigation property
    }
}

