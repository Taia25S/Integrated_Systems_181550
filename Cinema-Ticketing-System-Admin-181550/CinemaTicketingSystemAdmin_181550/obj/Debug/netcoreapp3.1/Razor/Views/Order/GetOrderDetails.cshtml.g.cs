#pragma checksum "C:\Users\stefa\OneDrive\Desktop\Domashna\CinemaTisketingSystemAdmin_191010\CinemaTisketingSystemAdmin_191010\Views\Order\GetOrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68c799bb20c387998f274399bbd1ee987ff59944"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_GetOrderDetails), @"mvc.1.0.view", @"/Views/Order/GetOrderDetails.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\stefa\OneDrive\Desktop\Domashna\CinemaTisketingSystemAdmin_191010\CinemaTisketingSystemAdmin_191010\Views\_ViewImports.cshtml"
using CinemaTisketingSystemAdmin_191010;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\stefa\OneDrive\Desktop\Domashna\CinemaTisketingSystemAdmin_191010\CinemaTisketingSystemAdmin_191010\Views\_ViewImports.cshtml"
using CinemaTisketingSystemAdmin_191010.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68c799bb20c387998f274399bbd1ee987ff59944", @"/Views/Order/GetOrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46ac0bf1ae46dd2613587dce3786f8136f9fa1a0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Order_GetOrderDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CinemaTisketingSystemAdmin_191010.Models.Order>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n");
#nullable restore
#line 5 "C:\Users\stefa\OneDrive\Desktop\Domashna\CinemaTisketingSystemAdmin_191010\CinemaTisketingSystemAdmin_191010\Views\Order\GetOrderDetails.cshtml"
     for (int i = 0; i < Model.TicketsInOrder.ToList().Count; i++)
    {
        var item = Model.TicketsInOrder[i].Ticket;
        if (i % 3 == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div class=\"row\">\r\n");
#nullable restore
#line 11 "C:\Users\stefa\OneDrive\Desktop\Domashna\CinemaTisketingSystemAdmin_191010\CinemaTisketingSystemAdmin_191010\Views\Order\GetOrderDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card\" style=\"width: 18rem; height: 50rem;\">\r\n                    <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 413, "\"", 435, 1);
#nullable restore
#line 13 "C:\Users\stefa\OneDrive\Desktop\Domashna\CinemaTisketingSystemAdmin_191010\CinemaTisketingSystemAdmin_191010\Views\Order\GetOrderDetails.cshtml"
WriteAttributeValue("", 419, item.MovieImage, 419, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height: 50%\" alt=\"Image for movie!\">\r\n\r\n                    <div class=\"card-body\">\r\n                        <h3 class=\"card-title\">");
#nullable restore
#line 16 "C:\Users\stefa\OneDrive\Desktop\Domashna\CinemaTisketingSystemAdmin_191010\CinemaTisketingSystemAdmin_191010\Views\Order\GetOrderDetails.cshtml"
                                          Write(item.MovieName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <p class=\"card-text\">");
#nullable restore
#line 17 "C:\Users\stefa\OneDrive\Desktop\Domashna\CinemaTisketingSystemAdmin_191010\CinemaTisketingSystemAdmin_191010\Views\Order\GetOrderDetails.cshtml"
                                        Write(item.MovieDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 20 "C:\Users\stefa\OneDrive\Desktop\Domashna\CinemaTisketingSystemAdmin_191010\CinemaTisketingSystemAdmin_191010\Views\Order\GetOrderDetails.cshtml"

            if (i % 3 == 2)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("</div>\r\n");
#nullable restore
#line 24 "C:\Users\stefa\OneDrive\Desktop\Domashna\CinemaTisketingSystemAdmin_191010\CinemaTisketingSystemAdmin_191010\Views\Order\GetOrderDetails.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CinemaTisketingSystemAdmin_191010.Models.Order> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
