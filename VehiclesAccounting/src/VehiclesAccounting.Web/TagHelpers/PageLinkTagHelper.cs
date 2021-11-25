using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using VehiclesAccounting.Web.ViewModels;

namespace VehiclesAccounting.Web.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageViewModel PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";
            TagBuilder tag = new("ul");
            tag.AddCssClass("pagination");
            TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper);
            if (PageModel.PageNumber - 1 != 1 && PageModel.PageNumber != 1)
            {
                TagBuilder firstItem = CreateTag(1, urlHelper);
                tag.InnerHtml.AppendHtml(firstItem);
            }
            if (PageModel.HasPreviousPage)
            {
                TagBuilder prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                tag.InnerHtml.AppendHtml(prevItem);
            }
            tag.InnerHtml.AppendHtml(currentItem);
            if (PageModel.HasNextPage)
            {
                TagBuilder nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                tag.InnerHtml.AppendHtml(nextItem);
            }
            if (PageModel.TotalPages != PageModel.PageNumber + 1 && PageModel.TotalPages != PageModel.PageNumber)
            {
                TagBuilder lastItem = CreateTag(PageModel.TotalPages, urlHelper);
                tag.InnerHtml.AppendHtml(lastItem);
            }
            output.Content.AppendHtml(tag);
        }
        TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder item = new("li");
            TagBuilder link = new("a");
            if (pageNumber == PageModel.PageNumber)
            {
                item.AddCssClass("active");
            }
            else
            {
                PageUrlValues["page"] = pageNumber;
                link.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
            }
            item.AddCssClass("page-item");
            link.AddCssClass("page-link");
            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);
            return item;
        }
    }
}