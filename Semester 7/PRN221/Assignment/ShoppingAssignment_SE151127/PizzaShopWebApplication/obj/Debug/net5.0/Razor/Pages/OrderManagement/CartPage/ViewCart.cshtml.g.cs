#pragma checksum "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4aa7eb6d19f55e901bb5a679a112557b43e3429b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PizzaShopWebApplication.Pages.OrderManagement.CartPage.Pages_OrderManagement_CartPage_ViewCart), @"mvc.1.0.razor-page", @"/Pages/OrderManagement/CartPage/ViewCart.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4aa7eb6d19f55e901bb5a679a112557b43e3429b", @"/Pages/OrderManagement/CartPage/ViewCart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bf928ce5a96542aca273c9324218c308c033cbd", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_OrderManagement_CartPage_ViewCart : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "UpdateQuantity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "RemoveFromCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link logout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/OrderManagement/CartPage/AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/OrderManagement/CartPage/ViewCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "ConfirmOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Cart</h1>\r\n\r\n<h3>Order of ");
#nullable restore
#line 7 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
        Write(Model.Customer.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 12 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
           Write(Html.DisplayNameFor(model => model.ListProduct[0].ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
           Write(Html.DisplayNameFor(model => model.ListProduct[0].ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
           Write(Html.DisplayNameFor(model => model.ListProduct[0].Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
           Write(Html.DisplayNameFor(model => model.ListProduct[0].UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
           Write(Html.DisplayNameFor(model => model.ListProduct[0].TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
 foreach (var item in @Model.ListProduct) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4aa7eb6d19f55e901bb5a679a112557b43e3429b10509", async() => {
                WriteLiteral("\r\n                    <input type=\"number\" min=\"1\" step=\"1\"");
                BeginWriteAttribute("value", " value=\"", 1577, "\"", 1629, 1);
#nullable restore
#line 50 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
WriteAttributeValue("", 1585, Html.DisplayFor(modelItem => item.Quantity), 1585, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"quantity\" />\r\n\r\n                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1693, "\"", 1746, 1);
#nullable restore
#line 52 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
WriteAttributeValue("", 1701, Html.DisplayFor(modelItem => item.ProductId), 1701, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"id\" />\r\n\r\n                    <input type=\"submit\" value=\"Update Quantity\" class=\"btn btn-primary\" />\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4aa7eb6d19f55e901bb5a679a112557b43e3429b13430", async() => {
                WriteLiteral("\r\n                    \r\n                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 2055, "\"", 2108, 1);
#nullable restore
#line 61 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
WriteAttributeValue("", 2063, Html.DisplayFor(modelItem => item.ProductId), 2063, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"id\" />\r\n\r\n                    <input type=\"submit\" value=\"Remove\" class=\"btn btn-primary\" />\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 68 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
#nullable restore
#line 71 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
 if(@Model.Cart.ListProduct.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4aa7eb6d19f55e901bb5a679a112557b43e3429b16378", async() => {
                WriteLiteral("Add to cart");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 74 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
} else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4aa7eb6d19f55e901bb5a679a112557b43e3429b17901", async() => {
                WriteLiteral("Confirm Order");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 77 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
 if (TempData["Message"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script type=\"text/javascript\">\r\n            window.onload = function () {\r\n                alert(\"");
#nullable restore
#line 82 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
                  Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n            };\r\n        </script>\r\n");
#nullable restore
#line 85 "C:\Users\ADMIN\Desktop\Sem7\PRN221\Assignment\ShoppingAssignment_SE151127\PizzaShopWebApplication\Pages\OrderManagement\CartPage\ViewCart.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PizzaShopWebApplication.Pages.OrderManagement.CartPage.ViewCartModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PizzaShopWebApplication.Pages.OrderManagement.CartPage.ViewCartModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PizzaShopWebApplication.Pages.OrderManagement.CartPage.ViewCartModel>)PageContext?.ViewData;
        public PizzaShopWebApplication.Pages.OrderManagement.CartPage.ViewCartModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
