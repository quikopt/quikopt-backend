using mangux.quikopt.Providers;
using mangux.quikopt.web.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Twitter;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(mangux.quikopt.web.Startup))]

namespace mangux.quikopt.web
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public static GoogleOAuth2AuthenticationOptions googleAuthOptions { get; private set; }
        public static FacebookAuthenticationOptions facebookAuthOptions { get; private set; }
        public static TwitterAuthenticationOptions twitterAuthOptions { get; private set; }
        

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<QuikOptContext, mangux.quikopt.web.Migrations.Configuration>());

        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            //use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions() {
            
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

            //Configure Google External Login
            googleAuthOptions = new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "667365230941-7583a180030gerdjfmkd4ai1r21sk60c.apps.googleusercontent.com",
                ClientSecret = "Z5CVgL04ML5tdfAKnL2pyJ3X",
                Provider = new GoogleAuthProvider()
            };
            app.UseGoogleAuthentication(googleAuthOptions);

            //Configure Facebook External Login
            facebookAuthOptions = new FacebookAuthenticationOptions()
            {
                AppId = "1602131330041169",
                AppSecret = "5b6a4cda8fc3bfa9451e3d4192375706",
                Provider = new FacebookAuthProvider()
            };
            app.UseFacebookAuthentication(facebookAuthOptions);

            //Configure twitter External Login
            twitterAuthOptions = new TwitterAuthenticationOptions()
            {
                ConsumerKey = "FTeZwkne0gahQb86DitDuK6cK",
                ConsumerSecret = "AD7G5Dnlsx1TMqnzSC3j2W8jQ2uk24PcVFDSMDz1vk3iQqXY3q",
                Provider = new TwitterAuthenticationProvider()
                
            };
            app.UseFacebookAuthentication(facebookAuthOptions);

        }
    }

}