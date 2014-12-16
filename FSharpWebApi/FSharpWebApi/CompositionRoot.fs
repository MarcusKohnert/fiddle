namespace FSharpWebApi

open System.Web.Http.Dispatcher
open System.Net.Http
open System.Web.Http.Controllers
open System
open System.Reactive.Disposables

type Resolver() =
    
    let getController (controllerDescriptor:HttpControllerDescriptor) =
        match controllerDescriptor.ControllerName with
        | "Request" -> new RequestController() :> IHttpController
        | "Account" -> new AccountController() :> IHttpController
        | "Cookie" -> new CookieController() :> IHttpController
        | _ -> failwith "no controller with name"
                
    interface IHttpControllerActivator with
        
        member this.Create(request: HttpRequestMessage, controllerDescriptor: HttpControllerDescriptor, controllerType: Type): IHttpController =
            let controller = getController controllerDescriptor

            request.RegisterForDispose(Disposable.Create(fun () -> System.Diagnostics.Debug.WriteLine("disposed")))

            controller