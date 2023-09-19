﻿namespace UniverstyTMS.Core.Entities
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
