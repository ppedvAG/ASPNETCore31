#pragma checksum "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\MVC_Basics\Views\StateManagement\ViewBagSample.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acd2f272c81a1776dc45eb4863d7966715d89532"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StateManagement_ViewBagSample), @"mvc.1.0.view", @"/Views/StateManagement/ViewBagSample.cshtml")]
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
#line 1 "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\MVC_Basics\Views\_ViewImports.cshtml"
using MVC_Basics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\MVC_Basics\Views\_ViewImports.cshtml"
using MVC_Basics.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acd2f272c81a1776dc45eb4863d7966715d89532", @"/Views/StateManagement/ViewBagSample.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f6eddf17cbfad3c56c8c9023c2ed8f14c8df6d9", @"/Views/_ViewImports.cshtml")]
    public class Views_StateManagement_ViewBagSample : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\MVC_Basics\Views\StateManagement\ViewBagSample.cshtml"
  
    ViewData["Title"] = "ViewBagSample";
    Layout = "~/Views/Shared/_Layout.cshtml";


    var userId = ViewBag.UserId;
    var name = ViewBag.Name;
    var age = ViewBag.Age;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ViewBagSample</h1>\r\n\r\n<p>");
#nullable restore
#line 14 "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\MVC_Basics\Views\StateManagement\ViewBagSample.cshtml"
Write(ViewBag.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n\r\n\r\n<h1>ViewBagSample</h1>\r\n\r\nUserId : ");
#nullable restore
#line 20 "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\MVC_Basics\Views\StateManagement\ViewBagSample.cshtml"
    Write(userId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\nName : ");
#nullable restore
#line 22 "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\MVC_Basics\Views\StateManagement\ViewBagSample.cshtml"
  Write(name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\nAge : ");
#nullable restore
#line 24 "C:\Aktueller Kurs\ASPNETCore31\ASPNETCore20200928\MVC_Basics\Views\StateManagement\ViewBagSample.cshtml"
 Write(age);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n\r\n");
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
