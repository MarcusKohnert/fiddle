module Domain

    open System    
    open System.Collections.Generic

    // record types

    type Customer = 
        { Firstname : string; Lastname : string }

        override __.ToString() =
            sprintf "Hello %s %s" __.Firstname __.Lastname

    // discriminated unions

    type Zahlungsmittel =
    | Bar of decimal
    | Kreditkarte of int * DateTime
    | Paypal of string

    let DruckeRechnung zahlungsmittel =
        match zahlungsmittel with
        | Bar betrag -> sprintf "Bar: %A" betrag
        | _ -> ""


    // single case discriminated unions

    type CustomerId = CustomerId of int

    type OrderId = 
    | OrderId of int

    let Get id =
        // get something by id
        ()

    let GetCustomer (CustomerId id) =
        // get customer by id
        ()

    let GetOrder (OrderId id) =
        // get order by id
        ()

    let customerId = CustomerId 5

    // GetOrder customerId // comile error