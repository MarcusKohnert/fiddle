module UnitsOfMeasure

    [<Measure>] type km
    [<Measure>] type h

    let Do() =
        
        let strecke = 5.0<km>
        let zeit = 1.0<h>

        let geschwindigkeit = strecke / zeit

//        let foo = geschwindigkeit + strecke

        ()