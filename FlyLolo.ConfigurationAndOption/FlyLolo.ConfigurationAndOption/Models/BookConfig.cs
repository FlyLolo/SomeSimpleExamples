using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyLolo.ConfigurationAndOption.Models
{
    public class BookConfig
    {
        public FieldConfig Code { get; set; }
        public FieldConfig Name { get; set; }
    }

    public class FieldConfig
    {
        public string Prefix { get; set; }
        public int Length { get; set; }
    }
}
