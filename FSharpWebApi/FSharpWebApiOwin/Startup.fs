namespace FSharpWebApiOwin

open Owin
open Microsoft.Owin
open System.Web.Http

type Startup() =
    member this.Configuration(app:IAppBuilder) =
        
        let config = new HttpConfiguration()
        config.MapHttpAttributeRoutes()
        config.Routes.MapHttpRoute("default", "{controller}") |> ignore

        config.Formatters.Remove config.Formatters.XmlFormatter |> ignore
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
        
        app.UseWebApi config |> ignore

module StartupModule =
    [<assembly:OwinStartup(typeof<Startup>)>]
    do()