namespace UniverstyTMS.Dtos.AttanceDtos
{
    public class AttanceGetDtoById
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int Time { get; set; }
        public int Plus { get; set; }
        public int Absance { get; set; }
        public int Percentage { get; set; }
    }
}
