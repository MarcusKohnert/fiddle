// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

open FSharp
open System

let someInt = 32

let someString = "Hello World"

let someOtherString : string = "Hello FSharp"

let someDecimal = 12m

// let someDecimal : decimal = 12.0m

let someFunction () =
    42

let sayHello name =
    sprintf "Hello %s" name

let callSplit(value:string) =
    value.Split('#')