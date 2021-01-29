module React

open System

type Cell(ord: int, initialValue: int, changed: (Cell -> int -> unit)) = 
    let changedEvent = new Event<int>()

    member val Ord = ord    
    member val Consumers = List.empty<int> with get,set
    member val Producers = List.empty<Cell> with get,set
    member val Compute = (fun _ -> 0) with get,set

    member val ChangedEvent = changedEvent
    member val Changed = changedEvent.Publish
    
    member val FValue = initialValue with get, set

    member this.Value
        with get() = this.FValue 
        and set(newValue) = 
            if this.FValue <> newValue then
                this.FValue <- newValue
                changed this newValue

type Reactor() =
    let mutable cells = List.empty<Cell>

    let computeValue (producers: Cell list) (compute: (int list -> int)) = 
        producers |> List.map (fun producer -> producer.FValue) |> compute

    let changed (cell: Cell) value = 

        let rec aux needCheck =
            function
            | [] -> 
                ()
            | id::xs when Set.contains id needCheck ->
                let consumer = List.item id cells                               
                let newValue = computeValue consumer.Producers consumer.Compute

                if newValue <> consumer.Value then
                    consumer.FValue <- newValue
                    consumer.ChangedEvent.Trigger newValue

                    aux (consumer.Consumers |> List.fold (fun acc consumer -> Set.add consumer acc) needCheck) xs                    
                else
                    aux needCheck xs
            | id::xs -> 
                aux needCheck xs

        aux (cell.Consumers |> set) [cell.Ord + 1 .. cells.Length - 1]            

    let addCell value = 
        let cell = new Cell(cells.Length, value, changed)
        cells <- cells @ [cell]
        cell

    member __.createInputCell value =
        addCell value

    member __.createComputeCell (producers: Cell list) (compute: (int list -> int)) =
        let value = computeValue producers compute
        let cell = addCell value
        cell.Producers <- producers
        cell.Compute <- compute
        cell.Producers |> List.iter (fun producer -> producer.Consumers <- producer.Consumers @ [cell.Ord])
        cell