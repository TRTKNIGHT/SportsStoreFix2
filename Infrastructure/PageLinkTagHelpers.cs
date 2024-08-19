using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;

namespace SportsStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelpers : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory; // Helps Create URLs

        public PageLinkTagHelpers(IUrlHelperFactory urlHelper)
        {
            urlHelperFactory = urlHelper;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { set; get; } // Creates a Context in which the View executes
        public PagingInfo? PageModel { get; set; }
        public string? PageAction;
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; }
            = new Dictionary<string, object>();

        public bool PageClassEnabled { get; set; } = false;
        public string PageClass { get; set; } = String.Empty;
        public string PageClassNormal { get; set; } = String.Empty;
        public string PageClassSelected { get; set; } = String.Empty;

        public override void Process(TagHelperContext context, // Info about the execution of Tag Helpers
            TagHelperOutput output) // Reresents the output of the TagHelper
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext); // Creates URLs
                TagBuilder result = new TagBuilder("div"); // Used to make HTML elements and tags and tag helpers
                for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    PageUrlValues["productPage"] = i;
                    //
                    //  Summary: 
                    //      Adds an href attribute to the a element
                    //
                    //  PageAction: 
                    //      Specifies the name of the action method
                    //
                    //  PageUrlValues:
                    //      Specifes values to be used as input for the action metohd
                    //
                    tag.Attributes["href"] = urlHelper.Action(PageAction,
                        PageUrlValues);
                    //
                    //  Summary:
                    //      Customizes the a element anchor
                    //
                    if (PageClassEnabled)
                    {
                        //
                        //  Summary:
                        //      
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage
                            ? PageClassSelected : PageClassNormal);
                    }
                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }
                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
