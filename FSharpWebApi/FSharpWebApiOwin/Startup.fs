namespace FSharpWebApiOwin

open Owin
open Microsoft.Owin
open System.Web.Http
open Microsoft.Owin.Security.Cookies
open Microsoft.Owin.Security
open Microsoft.AspNet.Identity
open System
open Microsoft.AspNet.Identity

type Startup() =
    member this.Configuration(app:IAppBuilder) =
        
//        // cookie authentication
//        let cookieOptions = new CookieAuthenticationOptions()
//        cookieOptions.AuthenticationType <- DefaultAuthenticationTypes.ApplicationCookie
//        cookieOptions.LoginPath <- new PathString("/Login/LoginExternal") // must be set
//        cookieOptions.ExpireTimeSpan <- TimeSpan.FromMinutes(10.0) // default 14 days
//        cookieOptions.AuthenticationMode <- AuthenticationMode.Active
//        
//        // cookieOptions.SlidingExpiration <- true // default anyways
//        // cookieOptions.CookieSecure <- CookieSecureOption.Always // optional but important in prod
//
//        // overwrite 401 behaviour if necessary
//        // let cookieAuthenticationProvider = new CookieAuthenticationProvider()
//        // cookieAuthenticationProvider.OnApplyRedirect <- fun ctx -> ctx.Response.Redirect(ctx.RedirectUri)
//        // cookieOptions.Provider <- cookieAuthenticationProvider
//        
//        app.UseCookieAuthentication(cookieOptions) |> ignore

        // these two lines of code are needed if you are using any of the external authentication middleware
        app.Properties.["Microsoft.Owin.Security.Constants.DefaultSignInAsAuthenticationType"] <- DefaultAuthenticationTypes.ExternalCookie;
        let externalOptions = new CookieAuthenticationOptions()
        externalOptions.AuthenticationType <- DefaultAuthenticationTypes.ExternalCookie
        externalOptions.AuthenticationMode <- AuthenticationMode.Active
        
        app.UseCookieAuthentication(externalOptions) |> ignore

        let msOptions = new MicrosoftAccount.MicrosoftAccountAuthenticationOptions()
        msOptions.ClientId <- ""
        msOptions.ClientSecret <- ""

        app.UseMicrosoftAccountAuthentication(msOptions) |> ignore

        let config = new HttpConfiguration()
        config.MapHttpAttributeRoutes()
        config.Routes.MapHttpRoute("default", "{controller}") |> ignore

        config.Formatters.Remove config.Formatters.XmlFormatter |> ignore
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
        
        app.UseWebApi config |> ignore

module StartupModule =
    [<assembly:OwinStartup(typeof<Startup>)>]
    do()