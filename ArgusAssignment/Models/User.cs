using System;
using System.Collections.Generic;

namespace ArgusAssignment.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Adress { get; set; }
        public long? PhoneNumber { get; set; }
    }
}
