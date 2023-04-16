using System.ComponentModel.DataAnnotations;
using RSGymPT_DAL.Interfaces;

namespace RSGymPT_DAL.Model
{
    public class User : IUser
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
        public string Username { get; set; }

        [Required(ErrorMessage = "UserCode is required.")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "4 to 6 character limit")]
        public string UserCode { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "8 to 12 character limit.")]
        public string Password { get; set; }

        [Display(Name = "Profile")]
        [Required(ErrorMessage = "Profile is required.")]
        [EnumDataType(typeof(EnumProfile))]
        public EnumProfile Profile { get; set; }

        #endregion

    }
}
