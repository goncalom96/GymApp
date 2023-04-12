using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static RSGymPT_DAL.Model.User;

namespace RSGymPT_DAL.Model
{
    public class Request
    {

        // Tabela N (Client)
        // Tabela N (PersonalTrainer)
        
        #region Enums

        public enum EnumStatus
        {
            Booked = 1,
            Completed = 2,
            Cancelled = 3
        }

        #endregion

        #region Scalar Properties

        // PK
        public int RequestID { get; set; }

        // FK
        public int ClientID { get; set; }

        public int PersonalTrainerID { get; set; }


        [Required(ErrorMessage = "Date is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Hour is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:t}")]
        public DateTime Hour { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required.")]
        [EnumDataType(typeof(EnumStatus?))]
        public EnumStatus? Status { get; set; }

        [MaxLength(255, ErrorMessage = "255 character limit.")]
        [DisplayFormat(NullDisplayText = "-")]
        public string Comments { get; set; }

        #endregion


        #region Navigation Properties

        public virtual Client Client { get; set; }
        public virtual PersonalTrainer PersonalTrainer { get; set; }

        #endregion

    }
}
