namespace FSharpWebApiOwin

open Owin
open Microsoft.Owin

type Startup() =
    member this.Configuration(app:IAppBuilder) =
        
        app.Run(fun context ->
            context.Response.ContentType = "text/plain" |> ignore
            context.Response.WriteAsync("Hello World!")
        )

module StartupModule =
    [<assembly:OwinStartup(typeof<Startup>)>]
    do()