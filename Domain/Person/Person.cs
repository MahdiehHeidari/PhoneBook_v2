using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain
{
	public class Person
	{

        [Required, Key]//not null,primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [StringLength(30, MinimumLength = 3)]
        [MaxLength(30, ErrorMessage = ErrorMessages.MaxLength)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.Required)]
        public string FirstName { get; set; }



        [Display(Name = "نام خانوادگی")]
        [StringLength(30, MinimumLength = 3)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.Required)]
        public string LastName { get; set; }


        public List<Phone> Phones { get; set; }

    }
}

