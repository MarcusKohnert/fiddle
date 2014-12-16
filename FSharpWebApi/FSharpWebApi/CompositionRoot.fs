namespace FSharpWebApi

open System.Web.Http.Dispatcher
open System.Net.Http
open System.Web.Http.Controllers
open System
open System.Reactive.Disposables

type Resolver() =
    
    let getController (controllerDescriptor:HttpControllerDescriptor) =
                let controllerName = controllerDescriptor.ControllerName
                if controllerName = "Request" then new RequestController() :> IHttpController
                elif controllerName = "Cookie" then new CookieController() :> IHttpController
                else
                    failwith "no controller with name"

    interface IHttpControllerActivator with
        
        member x.Create(request: HttpRequestMessage, controllerDescriptor: HttpControllerDescriptor, controllerType: Type): IHttpController =
            let controller = getController controllerDescriptor

            request.RegisterForDispose(Disposable.Create(fun () -> System.Diagnostics.Debug.WriteLine("disposed")))

            controller