namespace UniverstyTMS.Dtos.AttanceDtos
{
    public class AttanceGetDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public List<DVMInAttanceGetDto> attance { get; set; } = new List<DVMInAttanceGetDto>();
    }

    public class DVMInAttanceGetDto
    {
        public string DVM { get; set; }
    }
}
