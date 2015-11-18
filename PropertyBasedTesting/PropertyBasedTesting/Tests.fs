module Tests

    open Xunit
    open FsCheck
    open FsCheck.Xunit
    open Swensen.Unquote
    
    let fizzbuzz() =
        let cycle x = Seq.initInfinite (fun _ -> x) |> Seq.concat
        let zipWith f xs ys = Seq.zip xs ys |> Seq.map (fun (x,y) -> f x y)
        
        let fizz     = seq ["";"";"fizz"]       |> cycle
        let buzz     = seq ["";"";"";"";"buzz"] |> cycle
        let numbers  = seq [1 .. 100]           |> Seq.map string
        let fizzBuzz = zipWith (+) fizz buzz    |> zipWith max numbers
        
        fizzBuzz |> Seq.take 20 |> Seq.toList
        //val it : string list =
        //  ["1"; "2"; "fizz"; "4"; "buzz"; "fizz"; "7"; "8"; "fizz"; "buzz"; "11";
        //   "fizz"; "13"; "14"; "fizzbuzz"; "16"; "17"; "fizz"; "19"; "buzz"]
    
    type Payment =
    | Cash of decimal
    | CreditCard of string * int
    | Check of string
    
    let tocheck paymentmethod =
    
        match paymentmethod with
        | Cash value -> string value
        | CreditCard (person, number) -> person
        | Check value -> value
        
    
    [<Property>]
    let ``Check`` (meth:Payment) = 
        
        let result = tocheck meth
    
        test <@ System.String.IsNullOrEmpty(result) = false @>
    
    [<Property>]
    let ``Makes something`` (number:int) = 
    
        let s = ""
    
        test <@ number < 75 @>