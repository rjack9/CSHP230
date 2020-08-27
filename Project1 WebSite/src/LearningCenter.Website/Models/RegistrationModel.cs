using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCenter.Website.Models
{
    public class RegistrationItem
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public decimal ClassPrice { get; set; }
    }
}