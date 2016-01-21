module Deque

type Element<'a> = { value: 'a; mutable prev: Element<'a> Option; mutable next: Element<'a> Option }

type Deque<'a>() =    
   
    let mutable first = Option<Element<'a>>.None
    let mutable last  = Option<Element<'a>>.None

    let addToEmpty newValue = 
        let newElement = { value = newValue; prev = None; next = None }
        last  <- Some newElement
        first <- Some newElement

    member this.pop() =
        match last with
        | None -> failwith "Cannot pop from empty list"
        | Some(x) ->
            last <- x.prev
            x.value

    member this.shift() =
        match first with
        | None -> failwith "Cannot shift from empty list"
        | Some(x) ->
            first <- x.next
            x.value
        
    member this.push(newValue: 'a) = 
        match last with
        | None -> addToEmpty newValue
        | Some(x) ->     
            last   <- Some { value = newValue; prev = last; next = x.next }
            x.next <- last            

    member this.unshift(newValue: 'a) =        
        match first with
        | None -> addToEmpty newValue
        | Some(x) ->     
            first  <- Some { value = newValue; prev = x.prev; next = first }
            x.prev <- first