#pragma checksum "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb963277a0047a2f3804f060c703d20369da6788"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PizzaShopWebApplication.Pages.OrderManagement.CartPage.Pages_OrderManagement_CartPage_AddToCart), @"mvc.1.0.razor-page", @"/Pages/OrderManagement/CartPage/AddToCart.cshtml")]
namespace PizzaShopWebApplication.Pages.OrderManagement.CartPage
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
#line 1 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\_ViewImports.cshtml"
using PizzaShopWebApplication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb963277a0047a2f3804f060c703d20369da6788", @"/Pages/OrderManagement/CartPage/AddToCart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bf928ce5a96542aca273c9324218c308c033cbd", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_OrderManagement_CartPage_AddToCart : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ddlCustomers"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "CustomerId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "SetCustomer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/OrderManagement/CartPage/ViewCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
  
    ViewData["Title"] = "Add to cart";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb963277a0047a2f3804f060c703d20369da67887416", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb963277a0047a2f3804f060c703d20369da67887678", async() => {
                    WriteLiteral("\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb963277a0047a2f3804f060c703d20369da67887954", async() => {
                        WriteLiteral("--Select Customer--");
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
                    WriteLiteral("\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 9 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.Customer;

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
                WriteLiteral("\r\n    <input type=\"hidden\" name=\"CustomerEmail\"/>\r\n    <br/>\r\n    <br/>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cb963277a0047a2f3804f060c703d20369da678810913", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 16 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
     if (TempData["Message"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script type=\"text/javascript\">\r\n            window.onload = function () {\r\n                alert(\"");
#nullable restore
#line 20 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
                  Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n            };\r\n        </script>\r\n");
#nullable restore
#line 23 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/select2@4.0.13/dist/css/select2.min.css""/>
    <script type=""text/javascript"" src=""https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/npm/select2@4.0.13/dist/js/select2.min.js"">
    </script>
    <script type=""text/javascript"">
        $(function () {
            $(""#ddlCustomers"").select2();
        });
        $(""body"").on(""change"", ""#ddlCustomers"", function () {
            $(""input[name=CustomerEmail]"").val($(this).find(""option:selected"").text());
        });
    </script>
 ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
  
    if(@Model.Cart == null || @Model.Cart.CustomerId == null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>Add a customer to view cart!</p>\r\n");
#nullable restore
#line 41 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
    } else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb963277a0047a2f3804f060c703d20369da678815839", async() => {
                WriteLiteral("View Cart");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 44 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 51 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayNameFor(model => model.Product[0].ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 54 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayNameFor(model => model.Product[0].QuantityPerUnit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 57 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayNameFor(model => model.Product[0].UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 60 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayNameFor(model => model.Product[0].ProductImage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 63 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayNameFor(model => model.Product[0].ProductStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 66 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayNameFor(model => model.Product[0].Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 69 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayNameFor(model => model.Product[0].Supplier));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 75 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
 foreach (var item in @Model.Product) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 78 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 81 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.QuantityPerUnit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 84 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <img");
            BeginWriteAttribute("src", " src = \"", 2916, "\"", 2950, 2);
            WriteAttributeValue("", 2924, "/Images/", 2924, 8, true);
#nullable restore
#line 87 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
WriteAttributeValue("", 2932, item.ProductImage, 2932, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"200\" width=\"200\"/>\r\n                ");
#nullable restore
#line 88 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductImage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 91 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 94 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.Category.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 97 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.Supplier.CompanyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb963277a0047a2f3804f060c703d20369da678824102", async() => {
                WriteLiteral("\r\n                    <input type=\"number\" min=\"1\" step=\"1\"");
                BeginWriteAttribute("max", " max=\"", 3505, "\"", 3562, 1);
#nullable restore
#line 101 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
WriteAttributeValue("", 3511, Html.DisplayFor(modelItem => item.QuantityPerUnit), 3511, 51, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"quantity\" value=\"1\"/>\r\n                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 3633, "\"", 3686, 1);
#nullable restore
#line 102 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
WriteAttributeValue("", 3641, Html.DisplayFor(modelItem => item.ProductId), 3641, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"id\" />\r\n                    <input type=\"submit\" value=\"Add to cart\" class=\"btn btn-primary\" />\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 107 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\AddToCart.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PizzaShopWebApplication.Pages.OrderManagement.CartPage.AddToCartModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PizzaShopWebApplication.Pages.OrderManagement.CartPage.AddToCartModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PizzaShopWebApplication.Pages.OrderManagement.CartPage.AddToCartModel>)PageContext?.ViewData;
        public PizzaShopWebApplication.Pages.OrderManagement.CartPage.AddToCartModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
