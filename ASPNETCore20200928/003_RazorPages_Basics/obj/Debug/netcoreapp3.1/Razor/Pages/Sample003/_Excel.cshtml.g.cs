#pragma checksum "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\003_RazorPages_Basics\Pages\Sample003\_Excel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d29662c07c96fdf780a25470b064aba41691caec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(_003_RazorPages_Basics.Pages.Sample003.Pages_Sample003__Excel), @"mvc.1.0.view", @"/Pages/Sample003/_Excel.cshtml")]
namespace _003_RazorPages_Basics.Pages.Sample003
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
#line 1 "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\003_RazorPages_Basics\Pages\_ViewImports.cshtml"
using _003_RazorPages_Basics;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d29662c07c96fdf780a25470b064aba41691caec", @"/Pages/Sample003/_Excel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2e6eef11a66060e3f8924bb4a515ee86b6bba2f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Sample003__Excel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<_003_RazorPages_Basics.Pages.Sample003.PartialViewSample2Model>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<table>\r\n    <tr>\r\n        <th>Wochentag</th>\r\n    </tr>\r\n");
#nullable restore
#line 9 "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\003_RazorPages_Basics\Pages\Sample003\_Excel.cshtml"
     foreach (var item in Model.Tage)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 12 "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\003_RazorPages_Basics\Pages\Sample003\_Excel.cshtml"
           Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 14 "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\003_RazorPages_Basics\Pages\Sample003\_Excel.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<_003_RazorPages_Basics.Pages.Sample003.PartialViewSample2Model> Html { get; private set; }
    }
}
#pragma warning restore 1591