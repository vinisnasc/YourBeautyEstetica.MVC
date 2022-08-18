using Microsoft.AspNetCore.Razor.TagHelpers;
using YourBeautyEstetica.MVC.Extensions;

namespace YourBeautyEstetica.MVC.Configs
{
    [HtmlTargetElement("*", Attributes = "supress-by-role")]
    public class ApagaElementoByRoleTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ApagaElementoByRoleTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("supress-by-role")]
        public string Role { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(context == null) throw new ArgumentNullException(nameof(context));
            if(output == null) throw new ArgumentNullException(nameof(output));

            var temAcesso = CustomAuthorize.ValidarRolesUsuario(_contextAccessor.HttpContext, Role);

            if (temAcesso) return;

            output.SuppressOutput();
        }
    }
}