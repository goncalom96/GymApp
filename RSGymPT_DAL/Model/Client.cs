using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSGymPT_DAL.Model
{
    public class Client
    {

        // Tabela 1 (Request)
        // Tabela N (Location)

        #region Scalar Properties

        // PK
        public int ClientID { get; set; }

        // FK
        public int LocationID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "100 character limit.")]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "Numbers are not allowed in the name.")]
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateBirth { get; set; }

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
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "5 to 100 character limit")]
        public string Email { get; set; }

        [MaxLength(255, ErrorMessage = "255 character limit.")]
        [DisplayFormat(NullDisplayText = "-")]
        public string Comments { get; set; }

        [Required]
        public bool Active { get; set; }

        #endregion


        #region Navigation Properties

        public virtual Location Location { get; set; }
        public virtual ICollection<Request> Requests { get; set; }

        #endregion

    }
}
