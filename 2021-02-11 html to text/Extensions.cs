using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NUglify;

namespace _2021_02_11_html_to_text
{
    public static class Extensions
    {
        public static IHtmlContent HtmlToText<T>(this IHtmlHelper<T> html, string htmlText)
            => new StringHtmlContent(Uglify.HtmlToText($"<div>{htmlText}</div>").ToString());
    }
}
