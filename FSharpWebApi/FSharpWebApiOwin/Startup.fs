namespace FSharpWebApiOwin

open Owin
open Microsoft.Owin
open System.Web.Http

type Startup() =
    member this.Configuration(app:IAppBuilder) =
        
        let config = new HttpConfiguration()
        config.Routes.MapHttpRoute("default", "{controller}") |> ignore
        app.UseWebApi(config) |> ignore
        ()

module StartupModule =
    [<assembly:OwinStartup(typeof<Startup>)>]
    do()