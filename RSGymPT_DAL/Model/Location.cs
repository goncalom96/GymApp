﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RSGymPT_DAL.Interfaces;

namespace RSGymPT_DAL.Model
{
    public class Location : ILocation
    {

        // Tabela 1 (Request)
        // Tabela 1 (Client)

        #region Scalar Properties
        // PK
        public int LocationID { get; set; }

        [Display(Name = "Postal code")]
        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"[0-9]{4}-[0-9]{3}", ErrorMessage = "Must be a Number (Example: 2500-231).")]
        [MaxLength(9, ErrorMessage = "8 character limit.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "Numbers are not allowed in the name.")]
        [MaxLength(100, ErrorMessage = "100 character limit.")]
        public string City { get; set; }
        #endregion

        #region Navigation Properties
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<PersonalTrainer> PersonalTrainers { get; set; }
        #endregion

    }
}
