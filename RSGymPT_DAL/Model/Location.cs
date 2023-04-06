using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Model
{
    public class Location
    {

        // Tabela 1 (Request)
        // Tabela 1 (Client)

        #region Scalar Properties

        // PK
        public int LocationID { get; set; }

        [Display(Name = "Postal code")]
        [Required(ErrorMessage = "Postal code is required.")]
        [MaxLength(7, ErrorMessage = "7 character limit.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [MaxLength(100, ErrorMessage = "100 character limit.")]
        public string City { get; set; }

        #endregion


        #region Navigation Properties

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<PersonalTrainer> PersonalTrainers { get; set; }

        #endregion
    }
}
