module LinkedList

type Element<'a> = { value: 'a; mutable prev: Element<'a> option; mutable next: Element<'a> option }
type LinkedList<'a> = { mutable first: Element<'a> option; mutable last: Element<'a> option }

let mkLinkedList () = { first = None; last = None }

let addToEmpty newValue linkedList =
    let newElement = { value = newValue; prev = None; next = None }
    linkedList.first <- Some newElement
    linkedList.last <- Some newElement

let pop linkedList =
    match linkedList.last with
    | None -> failwith "Cannot pop from empty list"
    | Some oldLast ->
        linkedList.last <- oldLast.prev
        linkedList.last |> Option.iter (fun el -> el.next <- None)
        oldLast.value

let shift linkedList =
    match linkedList.first with
    | None -> failwith "Cannot shift from empty list"
    | Some oldFirst ->
        linkedList.first <- oldFirst.next
        linkedList.first |> Option.iter (fun el -> el.prev <- None)
        oldFirst.value

let push newValue linkedList =
    match linkedList.last with
    | None -> addToEmpty newValue linkedList
    | Some oldLast ->
        let newLast = Some { value = newValue; prev = linkedList.last; next = None }
        oldLast.next <- newLast
        linkedList.last <- newLast

let unshift newValue linkedList =
    match linkedList.first with
    | None -> addToEmpty newValue linkedList
    | Some oldFirst ->
        let newFirst = Some { value = newValue; prev = None; next = linkedList.first }
        oldFirst.prev <- newFirst
        linkedList.first <- newFirst