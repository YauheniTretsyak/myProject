using KnowledgeAccounting.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace KnowledgeAccounting.Web.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString AjaxPager(this AjaxHelper helper, PageInfo pageInfo, string TargetDiv, int id = 1, string ActionName = "DetailsForAdmin")
        {

            if (pageInfo.TotalItems > 0)
            {
                StringBuilder sb = new StringBuilder();
                AjaxOptions ao = new AjaxOptions();
                ao.UpdateTargetId = TargetDiv;

                if (pageInfo.PageNumber > 1)
                {

                    sb.Append(AjaxExtensions.ActionLink(helper, "<<", ActionName, new { page = 1, id = id }, ao, new { @class = "btn btn-default" }));
                    sb.Append("  ");
                    sb.Append(AjaxExtensions.ActionLink(helper, "<", ActionName, new { page = pageInfo.PageNumber - 1, id = id }, ao, new { @class = "btn btn-default" }));
                    sb.Append("  ");

                }

                sb.Append((pageInfo.PageNumber).ToString() + " / " + (pageInfo.TotalPages).ToString());

                if (pageInfo.PageNumber < (pageInfo.TotalPages))
                {

                    sb.Append("  ");
                    sb.Append(AjaxExtensions.ActionLink(helper, ">", ActionName, new { page = pageInfo.PageNumber + 1, id = id }, ao, new { @class = "btn btn-default" }));
                    sb.Append("  ");
                    sb.Append(AjaxExtensions.ActionLink(helper, ">>", ActionName, new { page = pageInfo.TotalPages, id = id }, ao, new { @class = "btn btn-default" }));
                }

                return MvcHtmlString.Create(sb.ToString());
            }
            else
            {

                return MvcHtmlString.Create("");
            }
        }
    }
}