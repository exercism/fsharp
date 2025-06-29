type RestApi(database : []u8) =

    member this.Get(url: []u8) =
        failwith "You need to implement this function."
    member this.Get(url: []u8, payload: []u8) =
        failwith "You need to implement this function."
    member this.Post(url: []u8, payload: []u8)  =
        failwith "You need to implement this function."
