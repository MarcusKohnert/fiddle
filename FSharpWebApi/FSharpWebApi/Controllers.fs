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

type CookieController() =
    inherit ApiController()

    member this.Get() =
        let response = this.Request.CreateResponse(HttpStatusCode.OK, "some cookie")
        response.Headers.AddCookies([ new Headers.CookieHeaderValue("name", "Brian Toppy")])
        response