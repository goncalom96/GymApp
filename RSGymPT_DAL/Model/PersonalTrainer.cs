using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Model
{
    public class PersonalTrainer
    {

        // Tabela 1 (Request)
        // Tabela 1 (Client)
        // Tabela N (Location)

        #region Scalar Properties

        // PK
        public int PersonalTrainerID { get; set; }

        // FK
        public int LocationID { get; set; }

        [Display(Name = "PT Code")]
        [Required(ErrorMessage = "PT Code is required.")]
        [MaxLength(4, ErrorMessage = "4 character limit.")]
        public string CodePT { get; set; }

        [Required(ErrorMessage = "Personal Trainer name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "Numbers and special characters are not allowed in the name.")]
        [MaxLength(100, ErrorMessage = "100 character limit.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "NIF is required.")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [MaxLength(9, ErrorMessage = "9 character limit.")]
        public string NIF { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(100, ErrorMessage = "100 character limit.")]
        public string Address { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [MaxLength(9, ErrorMessage = "9 character limit.")]
        //[Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "5 to 100 character limit")]
        public string Email { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Location Location { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Request> Requests { get; set; }

        #endregion

    }
}
