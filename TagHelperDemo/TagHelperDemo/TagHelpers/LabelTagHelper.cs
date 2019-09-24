using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagHelperDemo.Models;

namespace TagHelperDemo.TagHelpers
{
    public class BookCodeTagHelper : TagHelper
    {
        public Book Book { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "label";
            output.Attributes.SetAttribute("class", "codeColor");

            string content = output.Content.IsModified ? output.Content.GetContent() :
                                (await output.GetChildContentAsync()).GetContent(); ;
            output.Content.SetContent(Book.Prefix + content);
        }
    }

    //[HtmlTargetElement("p", Attributes = "show-type", ParentTag = "div")]
    //[HtmlTargetElement("label", Attributes = "show-type", ParentTag = "div")]
    //public class BookCodeTagHelper : TagHelper
    //{
    //    public override  async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    //    {
    //        if (output.Attributes.TryGetAttribute("show-type", out TagHelperAttribute showTypeAttribute))
    //        {
    //            if (showTypeAttribute.Value.ToString().Equals("bookCode"))
    //            {
    //                output.Attributes.SetAttribute("class", "codeColor");

    //                string content = output.Content.IsModified ? output.Content.GetContent() :
    //                                    (await output.GetChildContentAsync()).GetContent(); ;
    //                output.Content.SetContent("BJ" + content);
    //            }
    //        }
    //    }
    //}

    //[HtmlTargetElement("p", Attributes = "show-type", ParentTag = "div")]
    //[HtmlTargetElement("label", Attributes = "show-type", ParentTag = "div")]
    //public class LabelTagHelper : TagHelper
    //{
    //    public override  async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    //    {
    //        if (output.Attributes.TryGetAttribute("show-type", out TagHelperAttribute showTypeAttribute))
    //        {
    //            if (showTypeAttribute.Value.ToString().Equals("bookCode"))
    //            {
    //                output.Attributes.SetAttribute("class", "codeColor");

    //                string content = output.Content.IsModified ? output.Content.GetContent() :
    //                                 (await output.GetChildContentAsync()).GetContent(); ;
    //                output.Content.SetContent("BJ" + content);
    //            }
    //        }
    //    }
    //}
}
