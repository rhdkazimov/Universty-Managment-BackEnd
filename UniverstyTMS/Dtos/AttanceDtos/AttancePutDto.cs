namespace UniverstyTMS.Dtos.AttanceDtos
{
    public class AttancePutDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public List<DVMInAttancePutDto> attance { get; set; } = new List<DVMInAttancePutDto>();
    }

    public class DVMInAttancePutDto
    {
        public string DVM { get; set; }
    }
}
