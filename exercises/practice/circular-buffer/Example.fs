module CircularBuffer

type CircularBuffer<'a> = { items: 'a list; size: int }

let mkCircularBuffer size = { items = []; size = size }

let clear buffer = { buffer with items = [] }    

let write value buffer = 
    if List.length buffer.items = buffer.size then failwith "Cannot write to full buffer"
    else { buffer with items = buffer.items @ [value] }
        
let forceWrite value buffer =
    if List.length buffer.items = buffer.size then  { buffer with items = List.tail buffer.items @ [value] }
    else { buffer with items = buffer.items @ [value] }

let read buffer =
    match buffer.items with    
    | x::xs -> x, { buffer with items = xs }
    | [] -> failwith "Cannot read from empty buffer" 