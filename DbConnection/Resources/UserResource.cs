using System.ComponentModel.DataAnnotations;

namespace DbConnection.Resources
{
    public record UserResource
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }

        public bool IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public string? CreatedOnUtc { get; set; }

        public int? ModifiedBy { get; set; }

        public string? ModifiedOnUtc { get; set; }

        public string? CreatedByName { get; set; }

        public string? ModifiedByName { get; set; }

    }
}
