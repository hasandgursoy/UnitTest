using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationLibrary.Models
{
    public class JobApplication
    {
        public Applicant Applicant { get; set; }
        public int YearsOfExperience { get; set; }
        public List<int> TechStackList { get; set; }

    }
}
