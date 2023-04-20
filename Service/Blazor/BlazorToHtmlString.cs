using BlazorTemplater;
using Service.User.Impl;
using Service.User;
using Model.Mark;
using RazorTemplates;

namespace Service.Blazor
{
    /// <summary>
    /// Blazor转html字符串
    /// </summary>
    public class BlazorToHtmlString
    {
        private UserService Service = new UserServiceImpl();
        /// <summary>
        /// EmailTable组件转html字符串
        /// </summary>
        /// <returns></returns>
        public string GetEmailTable()
        {
            List<用户表> users = Service.GetUserAll();
            //使用BlazorTemplater将blazor组件转化为html页面
            string html = new ComponentRenderer<EmailTable>()
                .Set(c=>c.cssPath, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmailTable.razor.css"))
                .Set(c => c.users, users)
                .Render();
            //使用PreMailer.Net将css样式文件内联到html中
            var result = PreMailer.Net.PreMailer.MoveCssInline(html);
            return result.Html;
        }
    }
}
