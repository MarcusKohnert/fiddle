namespace FSharpWebApiOwin

open System.Web.Http

type RequestController() =
    inherit ApiController()

    member this.Get() =
        [0..10]