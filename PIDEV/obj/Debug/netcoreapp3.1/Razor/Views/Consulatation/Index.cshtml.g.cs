#pragma checksum "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "336ea21abe20078a782bb565f969041f97e5a23f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Consulatation_Index), @"mvc.1.0.view", @"/Views/Consulatation/Index.cshtml")]
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
#line 1 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\_ViewImports.cshtml"
using PIDEV;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\_ViewImports.cshtml"
using PIDEV.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"336ea21abe20078a782bb565f969041f97e5a23f", @"/Views/Consulatation/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6811e4be351f437d5af29fe037e4da2b5ce006f", @"/Views/_ViewImports.cshtml")]
    public class Views_Consulatation_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "336ea21abe20078a782bb565f969041f97e5a23f3266", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title></title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "336ea21abe20078a782bb565f969041f97e5a23f4320", async() => {
                WriteLiteral("\r\n    <a");
                BeginWriteAttribute("href", " href=\"", 136, "\"", 181, 1);
#nullable restore
#line 8 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
WriteAttributeValue("", 143, Url.Action("Create", "Consulatation"), 143, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> add Consultation </a>\r\n    <a");
                BeginWriteAttribute("href", " href=\"", 213, "\"", 259, 1);
#nullable restore
#line 9 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
WriteAttributeValue("", 220, Url.Action("Createe", "Consulatation"), 220, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"> Generate Consultation </a>

    <table cellpadding=""2"" cellspacing=""2"" border=""1"">
        <tr>
            <th>Id</th>
            <th>child_name</th>
            <th>namedoctor</th>
            <th>consultation_date</th>
            <th>consultation_time</th>
            <th>description</th>
        </tr>
");
#nullable restore
#line 20 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
         foreach (var e in ViewBag.result)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
               Write(e.id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
               Write(e.child_name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
               Write(e.namedoctor);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
               Write(e.consultation_date);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
               Write(e.consultation_time);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
               Write(e.description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 946, "\"", 1011, 1);
#nullable restore
#line 30 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
WriteAttributeValue("", 953, Url.Action("Delete", "Consulatation", new { id = @e.id }), 953, 58, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-danger\"> Delete </a>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 1072, "\"", 1134, 1);
#nullable restore
#line 31 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
WriteAttributeValue("", 1079, Url.Action("Edit", "Consulatation",new { id = @e.id }), 1079, 55, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-danger\"> Update </a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\Ala eddinne ghribi\source\repos\PIDEV\PIDEV\Views\Consulatation\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </table>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591