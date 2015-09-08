module Domain

    // record types

    type Customer = { Firstname : string; Lastname : string }

    // type inference

    let GetFirstname customer =
        customer.Firstname