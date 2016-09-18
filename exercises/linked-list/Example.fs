module LinkedList

type Element<'a> = { value: 'a; mutable prev: Element<'a> option; mutable next: Element<'a> option }
type LinkedList<'a> = { first: Element<'a> option; last: Element<'a> option }

let mkLinkedList = { first = None; last = None }

let addToEmpty newValue linkedList = 
    let newElement = { value = newValue; prev = None; next = None }
    { linkedList with first = Some newElement; last = Some newElement }

let pop linkedList =
    match linkedList.last with
    | None -> failwith "Cannot pop from empty list"
    | Some(x) -> x.value, { linkedList with last = x.prev }

let shift linkedList =
    match linkedList.first with
    | None -> failwith "Cannot shift from empty list"
    | Some(x) -> x.value, { linkedList with first = x.next }
        
let push newValue linkedList = 
    match linkedList.last with
    | None -> addToEmpty newValue linkedList
    | Some(x) ->         
        let last = Some { value = newValue; prev = linkedList.last; next = x.next }
        x.next <- last            
        { linkedList with last = last }

let unshift newValue linkedList =        
    match linkedList.first with
    | None -> addToEmpty newValue linkedList
    | Some(x) ->     
        let first = Some { value = newValue; prev = x.prev; next = linkedList.first }
        x.prev <- first
        { linkedList with first = first }