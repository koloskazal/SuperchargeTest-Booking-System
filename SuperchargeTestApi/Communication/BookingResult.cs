namespace SuperchargeTestApi.Communication
{
    public class BookingResult
    {
        public bool Successfull{ get; set; }
        public string? ErrorDescription{ get; set; }
        public int? BookingId{ get; set; }
    }
}
