module RestApi

type RestApi(database : string) =

    member this.Get(url: string) =
        failwith "You need to implement this function."
    member this.Get(url: string, payload: string) =
        failwith "You need to implement this function."
    member this.Post(url: string, payload: string)  =
        failwith "You need to implement this function."
