module CircularBuffer

type CircularBuffer<'a>(size: int) = 

    let mutable items = []

    member this.clear() = 
        items <- []

    member this.write(value) =
        if List.length items = size then failwith "Cannot write to full buffer"
        else items <- items @ [value]

    member this.forceWrite(value) =
        if List.length items = size then items <- List.tail items @ [value]
        else items <- items @ [value]

    member this.read() =
        match items with    
        | x::xs -> 
            items <- xs
            x
        | [] -> failwith "Cannot read from empty buffer" 