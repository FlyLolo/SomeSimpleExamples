using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelperDemo.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "simple-type")]
    public class Simple1TagHelpers : TagHelper
    {
        public string SimpleType { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (SimpleType.Equals("Simple1"))
            {
                output.SuppressOutput();
            }
            else if (SimpleType.Equals("Simple2"))
            {
                output.Content.SetHtmlContent("<p>Simple2</p>");
            }
            else if (SimpleType.Equals("Simple3"))
            {
                var p = new TagBuilder("p");
                p.InnerHtml.Append("Simple3");
                output.Content.SetHtmlContent(p);
            }
        }
    }
}
