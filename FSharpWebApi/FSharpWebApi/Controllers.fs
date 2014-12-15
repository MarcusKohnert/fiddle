namespace FSharpWebApi

open System.Net
open System.Net.Http
open System.Web.Http

type RequestController() =
    inherit ApiController()

    member this.Delete() =
        this.Request.CreateResponse(HttpStatusCode.Accepted, "someValue")

    member this.Get() =
        [1..10]

    member this.Post() =
        this.Created("Request/1", 1)

    member this.Put() =
        this.Ok()