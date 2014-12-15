namespace FSharpWebApi

open System
open System.Net.Http
open System.Web
open System.Web.Http
open System.Web.Routing

type HttpRoute = {
    controller : string
    id : RouteParameter }

type Global() =
    inherit System.Web.HttpApplication() 

    static member RegisterWebApi(config: HttpConfiguration) =
        config.MapHttpAttributeRoutes()
        config.Routes.MapHttpRoute(
            "Default",
            "{controller}/{id}",
            { controller = "{controller}"; id = RouteParameter.Optional }
        ) |> ignore

        config.Formatters.XmlFormatter.UseXmlSerializer <- true
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()

    member this.Application_Start() =
        GlobalConfiguration.Configure(Action<_> Global.RegisterWebApi)