namespace ExamControl.Models.ViewModels.Auth
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="LogInModel" />
    /// </summary>
    public class LogInModel
    {
        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the ReturnUrl
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }
    }
}
