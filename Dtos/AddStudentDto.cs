using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool.Dtos
{
    public class AddStudentDto
    {
        public string StudentFirstName { get; set; } = string.Empty;
        public string StudentMiddleName { get; set; } = string.Empty;
        public string StudentLastName { get; set; } = string.Empty;
        public int classroom { get; set; }
        public string section { get; set; } = string.Empty;
    }
}