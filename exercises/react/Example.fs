module React

[<AbstractClass>]
type Cell() =
    abstract Value : int with get, set
    abstract Changed: IEvent<int>
    
type InputCell(initialValue: int) =
    inherit Cell() 

    let mutable value = initialValue 
    let changed = new Event<int>()    

    override this.Changed = changed.Publish
    
    override this.Value 
        with get() = value 
        and set(newValue : int) = 
            if value <> newValue then
                value <- newValue
                changed.Trigger(newValue)

type ComputeCell(inputs: Cell list, compute: (int list -> int)) =
    inherit Cell() 

    let computeValue() = inputs |> List.map (fun x -> x.Value) |> compute

    let mutable value = computeValue()
    let changed = new Event<int>()
    
    let updateValue() =
        let newValue = computeValue()

        if newValue <> value then
            value <- newValue        
            changed.Trigger(newValue)        

    let subscribeToInputChanges() =
        [for input in inputs do 
            input.Changed.Add(fun _ -> updateValue())]
        |> ignore

    do        
        subscribeToInputChanges()

    override this.Changed = changed.Publish

    override this.Value 
        with get() = value 
        and set(v : int) = failwith "Cannot directly set value of compute cell"

let mkInputCell value = new InputCell(value)
let mkComputeCell (inputs: Cell list) (compute: (int list -> int)) = new ComputeCell(inputs, compute)

let setValue value (cell: Cell) = cell.Value <- value
let value (cell: Cell) = cell.Value