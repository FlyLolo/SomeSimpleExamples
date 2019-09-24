using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelperDemo.Models
{
    public class Book
    {
        [Display(Name = "编号")]
        public string Code { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "前缀")]
        public string Prefix { get; set; }

    }
}
