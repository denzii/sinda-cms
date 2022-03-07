using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SindaCMS.Models;

namespace SindaCMS.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static async Task RenderContentAsync(this IHtmlHelper helper, List<Detail> tabDetails)
        {
            foreach(Detail detail in tabDetails){
                switch (detail.Type)
                {
                    case ContentType.Paragraph:
                        await helper.RenderPartialAsync("../Shared/_Paragraph", detail);
                        break;

                    case ContentType.Warning:
                        await helper.RenderPartialAsync("../Shared/_Warning", detail);
                        break;

                    case ContentType.Code:
                        await helper.RenderPartialAsync("../Shared/_Code", detail);
                        break;

                    case ContentType.Picture:
                        await helper.RenderPartialAsync("../Shared/_Picture", detail);
                        break;
                }
            }
        }
    }
}
