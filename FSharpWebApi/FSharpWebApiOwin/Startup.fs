namespace FSharpWebApiOwin

open Owin
open Microsoft.Owin
//open System.Web.Http

type Startup() =
    member this.Configuration(app:IAppBuilder) =
        
//        let config = new HttpConfiguration();
//        config.Routes.MapHttpRoute("default", "{controller}");
//        app.UseWebApi(config);

        app.Run(fun context ->
            context.Response.ContentType = "text/plain" |> ignore
            context.Response.WriteAsync("Hello World!")
        )

module StartupModule =
    [<assembly:OwinStartup(typeof<Startup>)>]
    do()