using floristWebApp.Client.FloristApi;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics;

namespace floristWebApp.TagHelpers
{
    [HtmlTargetElement("getCategoryName")]
    public class CategoryName : TagHelper
    {
        private readonly IFloristClient _floristClient;
        public CategoryName(IFloristClient floristClient)
        {
            _floristClient= floristClient;  
        }
        public int ProductId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data = "";
            var categories = _floristClient.GetProductCategories(ProductId).Result;
            foreach(var category in categories)
            {
                data += category.Name + " ";
            }

            output.Content.SetContent(data);
        }
    }
}
