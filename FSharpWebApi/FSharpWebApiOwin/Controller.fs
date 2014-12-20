namespace FSharpWebApiOwin

open System.Web.Http
open System.Net.Http
open System.Web

type RequestController() =
    inherit ApiController()

    member __.Get() =
        [0..10]

type HeaderController() =
    inherit ApiController()

    member __.Get() =
        __.Ok(__.Request.Headers.GetCookies())