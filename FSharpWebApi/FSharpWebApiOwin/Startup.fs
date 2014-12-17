namespace FSharpWebApiOwin

open Owin
open Microsoft.Owin
open System.Web.Http

type Startup() =
    member this.Configuration(app:IAppBuilder) =
        
        let config = new HttpConfiguration()
        config.MapHttpAttributeRoutes()
        config.Routes.MapHttpRoute("default", "{controller}") |> ignore
        app.UseWebApi(config) |> ignore

        config.Formatters.XmlFormatter.UseXmlSerializer <- true
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
        ()

module StartupModule =
    [<assembly:OwinStartup(typeof<Startup>)>]
    do()