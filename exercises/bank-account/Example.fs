module BankAccount

let inline (|?) (a: 'a option) b = if a.IsSome then a.Value else b

type BankAccount() =
    let mutable balance = Option<float>.None
    
    member this.openAccount() = balance <- Some(0.0)
    member this.updateBalance change = balance <- Some(this.getBalance() + change)
    member this.getBalance() = balance |? 0.0
    member this.closeAccount() = balance <- Option<float>.None
    member this.Balance = balance