module BankAccount

type BankAccount = { balance: float option }

let mkBankAccount() = { balance = None }

let openAccount bankAccount = { bankAccount with balance = Some 0.0 }

let closeAccount bankAccount = { bankAccount with balance = None }

let getBalance bankAccount = bankAccount.balance

let updateBalance change bankAccount = { bankAccount with balance = Option.map (fun current -> current + change) bankAccount.balance }