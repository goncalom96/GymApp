using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Model
{
    public class User
    {

        #region Enums

        public enum EnumProfile
        {
            admin = 1,
            colab = 2
        }

        #endregion

        #region Scalar Properties

        // PK
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(100, ErrorMessage = "100 character limit.")]
        public string UserName { get; set; }

        [Display(Name="User code")]
        [Required(ErrorMessage = "User code is required.")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "4 to 6 character limit")]
        public string UserCode { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "8 to 12 character limit.")]
        public string Password { get; set; }

        [Display(Name = "Profile")]
        [Required(ErrorMessage = "Profile is required.")]
        [EnumDataType(typeof(EnumProfile?))]
        public EnumProfile? Profile { get; set; }

        #endregion


        #region Navigation Properties


        #endregion
    }
}
