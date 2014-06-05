module BankAccount

type BankAccount() =
    member val Balance = Option<float>.None with get, set

    member this.openAccount() =
        this.Balance <- Some 0.0
        this.Balance.Value

    member this.closeAccount() =
        this.Balance <- None

    member this.getBalance() =
        this.Balance.Value

    member this.updateBalance(newBalance: float) =
        let balance = this.Balance.Value
        let updatedBalance = balance + newBalance

        this.Balance <- Some updatedBalance