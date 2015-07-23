module Conversions

    [<Measure>] type m

    [<Measure>] 
    type km =
        static member inMetre value = value * 1000.0<m/km>

    let Do() =
        let oneKm = 1.0<km>

        let inM = km.inMetre oneKm

        ()