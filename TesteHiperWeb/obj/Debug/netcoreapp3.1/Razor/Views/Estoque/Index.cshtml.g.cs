#pragma checksum "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ab3d6a21247a6752889adb0aea3ca9cedff31ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Estoque_Index), @"mvc.1.0.view", @"/Views/Estoque/Index.cshtml")]
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
#line 1 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\_ViewImports.cshtml"
using TesteHiperWeb;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ab3d6a21247a6752889adb0aea3ca9cedff31ac", @"/Views/Estoque/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dceb70d1346e36ea1a85f54734a3e26bf6ac9d7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Estoque_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TesteHiper.Data.Model.EstoqueModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-lg-12\">\r\n        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                <h4 class=\"card-title\">Estoques</h4>\r\n                <span class=\"float-right\"><a");
            BeginWriteAttribute("href", " href=\"", 271, "\"", 308, 1);
#nullable restore
#line 8 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
WriteAttributeValue("", 278, Url.Action("Novo", "Estoque"), 278, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\"><i class=\"fa fa-plus\">+</i></a></span>\r\n            </div>\r\n            <div class=\"card-body\">\r\n");
#nullable restore
#line 11 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
                 if(TempData["MsgChangeStatus"] != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"row\">\r\n                        <div class=\"col-lg-12\">\r\n                            <p class=\"alert alert-danger\">\r\n                                ");
#nullable restore
#line 16 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
                           Write(TempData["MsgChangeStatus"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 20 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <table class=\"table table-striped\">\r\n                    <thead>\r\n                        <tr>\r\n                            <th>\r\n                                ");
#nullable restore
#line 25 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 28 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th></th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 34 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 38 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 41 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 44 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
                               Write(Html.ActionLink("Editar", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                    ");
#nullable restore
#line 45 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
                               Write(Html.ActionLink("Excluir", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 48 "D:\Testes\Hiper\TesteHiper\TesteHiperWeb\Views\Estoque\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TesteHiper.Data.Model.EstoqueModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
