using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyLolo.ConfigurationAndOption.Models
{
    public class Theme
    {
        public Theme()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
