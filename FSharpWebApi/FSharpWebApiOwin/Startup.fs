namespace FSharpWebApiOwin

open Owin
open Microsoft.Owin
open System.Web.Http
open Microsoft.Owin.Security.Cookies
open Microsoft.Owin.Security
open Microsoft.AspNet.Identity
open System

type Startup() =
    member this.Configuration(app:IAppBuilder) =
        
        // cookie authentication
        let cookieOptions = new CookieAuthenticationOptions()
        cookieOptions.AuthenticationType <- DefaultAuthenticationTypes.ApplicationCookie
        cookieOptions.LoginPath <- new PathString("/Login/LoginExternal") // must be set
        cookieOptions.ExpireTimeSpan <- TimeSpan.FromMinutes(10.0) // default 14 days
        // cookieOptions.SlidingExpiration <- true // default anyways
        // cookieOptions.CookieSecure <- CookieSecureOption.Always // optional but important in prod
        app.UseCookieAuthentication(cookieOptions) |> ignore

//        app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
//
//        let options = new MicrosoftAccount.MicrosoftAccountAuthenticationOptions()
//        options.ClientId <- ""
//        options.ClientSecret <- ""
//        options.Provider <- new MicrosoftAuth()
//        app.UseMicrosoftAccountAuthentication(options) |> ignore

        let config = new HttpConfiguration()
        config.MapHttpAttributeRoutes()
        config.Routes.MapHttpRoute("default", "{controller}") |> ignore

        config.Formatters.Remove config.Formatters.XmlFormatter |> ignore
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
        
        app.UseWebApi config |> ignore

module StartupModule =
    [<assembly:OwinStartup(typeof<Startup>)>]
    do()