using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Agensi.Web
{
    public partial class Startup
    {
        // 認証設定の詳細については、http://go.microsoft.com/fwlink/?LinkId=301864 を参照してください
        public void ConfigureAuth(IAppBuilder app)
        {
            // アプリケーションが Cookie を使用して、サインインしたユーザーの情報を格納できるようにします
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // 次の行のコメントを解除して、サード パーティのログイン プロバイダーを使用したログインを有効にします
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            app.UseTwitterAuthentication(
               consumerKey: "mDKFHlngDva9diVwrDO3g",
               consumerSecret: "s0kus0IETQwJIIj257bR8wgi3vJUCJaJ89vZkMk2dc");

            app.UseFacebookAuthentication(
               appId: "469953176444061",
               appSecret: "23111c4ef7b5ebbbb8553e8e402d5047");

            app.UseGoogleAuthentication();
        }
    }
}