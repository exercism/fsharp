module Deque

type Element<'a> = { value: 'a; mutable prev: Element<'a> option; mutable next: Element<'a> option }
type Deque<'a> = { first: Element<'a> option; last: Element<'a> option }

let mkDeque = { first = None; last = None }

let addToEmpty newValue deque = 
    let newElement = { value = newValue; prev = None; next = None }
    { deque with first = Some newElement; last = Some newElement }

let pop deque =
    match deque.last with
    | None -> failwith "Cannot pop from empty list"
    | Some(x) -> x.value, { deque with last = x.prev }

let shift deque =
    match deque.first with
    | None -> failwith "Cannot shift from empty list"
    | Some(x) -> x.value, { deque with first = x.next }
        
let push newValue deque = 
    match deque.last with
    | None -> addToEmpty newValue deque
    | Some(x) ->         
        let last = Some { value = newValue; prev = deque.last; next = x.next }
        x.next <- last            
        { deque with last = last }

let unshift newValue deque =        
    match deque.first with
    | None -> addToEmpty newValue deque
    | Some(x) ->     
        let first = Some { value = newValue; prev = x.prev; next = deque.first }
        x.prev <- first
        { deque with first = first }