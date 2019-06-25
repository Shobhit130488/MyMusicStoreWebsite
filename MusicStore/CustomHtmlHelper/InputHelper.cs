using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicStore.CustomHtmlHelper
{
    [ExcludeFromCodeCoverage]
    public static class InputHelper
    {
        public static MvcHtmlString CustomInput<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var objects = (htmlAttributes.ToString());
            TagBuilder tb = new TagBuilder("input");
            tb.Attributes.Add("name", name);
            tb.Attributes.Add("value", metadata.Model as string);
            tb.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}