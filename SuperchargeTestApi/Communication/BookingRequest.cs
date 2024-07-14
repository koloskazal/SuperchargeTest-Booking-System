using System.ComponentModel.DataAnnotations;

namespace SuperchargeTestApi.Communication
{
    public class BookingRequest
    {
        [Required(ErrorMessage = "VisitorId is required.")]
        public int VisitorId { get; set; }

        [Required(ErrorMessage = "RoomId is required.")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "StartDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "StartDate must be a valid date.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "EndDate must be a valid date.")]
        public DateTime EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate <= StartDate)
            {
                yield return new ValidationResult(
                    "EndDate must be after StartDate.",
                    new[] { nameof(EndDate) });
            }
        }
    }
}
