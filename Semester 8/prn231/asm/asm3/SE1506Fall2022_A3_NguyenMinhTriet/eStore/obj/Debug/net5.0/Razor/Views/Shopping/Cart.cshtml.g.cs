#pragma checksum "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be52bfa4f3b09a8ce1b705c8100619a9baeb9b92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shopping_Cart), @"mvc.1.0.view", @"/Views/Shopping/Cart.cshtml")]
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
#line 1 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\_ViewImports.cshtml"
using eStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\_ViewImports.cshtml"
using eStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
using BusinessObject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be52bfa4f3b09a8ce1b705c8100619a9baeb9b92", @"/Views/Shopping/Cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6a7cd37460f953b9787e736e6c4fe42df2fc1ad", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shopping_Cart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProductInCart>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ddlMembers"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "MemberId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shopping", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SetMember", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
  
    ViewData["Title"] = "Cart";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var listMembers = (SelectList)TempData["ListMembers"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Cart</h1>\r\n<h4>");
#nullable restore
#line 14 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<h4>");
#nullable restore
#line 15 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
Write(ViewBag.ChosenUser);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be52bfa4f3b09a8ce1b705c8100619a9baeb9b927990", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
     if (User.IsInRole("Administrator")) {

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be52bfa4f3b09a8ce1b705c8100619a9baeb9b928530", async() => {
                    WriteLiteral("\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be52bfa4f3b09a8ce1b705c8100619a9baeb9b928810", async() => {
                        WriteLiteral("--Select Member--");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 19 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = listMembers;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"MemberEmail\" />\r\n        <br />\r\n        <input type=\"submit\" value=\"Submit\" />\r\n");
#nullable restore
#line 25 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
    } 
    else 
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <input type=\"hidden\" name=\"MemberId\"");
                BeginWriteAttribute("value", " value=\"", 850, "\"", 905, 1);
#nullable restore
#line 28 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
WriteAttributeValue("", 858, User.FindFirstValue(ClaimTypes.NameIdentifier), 858, 47, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <p>Cart of ");
#nullable restore
#line 29 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
              Write(User.FindFirstValue(ClaimTypes.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n");
#nullable restore
#line 30 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    
    

    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/select2@4.0.13/dist/css/select2.min.css""/>
    <script type=""text/javascript"" src=""https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/npm/select2@4.0.13/dist/js/select2.min.js"">
    </script>
    <script type=""text/javascript"">
        $(function () {
            $(""#ddlMembers"").select2();
        });
        $(""body"").on(""change"", ""#ddlMembers"", function () {
            $(""input[name=MemberEmail]"").val($(this).find(""option:selected"").text());
        });
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 52 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 55 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 58 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 61 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
           Write(Html.DisplayNameFor(model => model.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 64 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 71 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 74 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 77 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 80 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 83 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
           Write(Html.DisplayFor(modelItem => item.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 86 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be52bfa4f3b09a8ce1b705c8100619a9baeb9b9219346", async() => {
                WriteLiteral("\r\n                    <input type=\"number\" min=\"1\" step=\"1\"");
                BeginWriteAttribute("value", " value=\"", 3000, "\"", 3052, 1);
#nullable restore
#line 90 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
WriteAttributeValue("", 3008, Html.DisplayFor(modelItem => item.Quantity), 3008, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"quantity1\" value=\"1\" />\r\n\r\n                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 3127, "\"", 3180, 1);
#nullable restore
#line 92 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
WriteAttributeValue("", 3135, Html.DisplayFor(modelItem => item.ProductId), 3135, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"id1\" />\r\n\r\n                    <input type=\"submit\" value=\"Update Quantity\" class=\"btn btn-primary\" />\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be52bfa4f3b09a8ce1b705c8100619a9baeb9b9222418", async() => {
                WriteLiteral("\r\n                    \r\n                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 3505, "\"", 3558, 1);
#nullable restore
#line 101 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
WriteAttributeValue("", 3513, Html.DisplayFor(modelItem => item.ProductId), 3513, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"id1\" />\r\n\r\n                    <input type=\"submit\" value=\"Remove\" class=\"btn btn-primary\" />\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 108 "C:\Users\ADMIN\Desktop\Sem8\prn231\asm\asm3\1\SE1506Fall2022_A3_NguyenMinhTriet\eStore\Views\Shopping\Cart.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<h4><a href=\"Checkout\">Checkout</a></h4>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<eStoreUser> UserManager { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProductInCart>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591