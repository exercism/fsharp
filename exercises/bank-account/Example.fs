module BankAccount

type BankAccount = 
    | Open of float
    | Closed

let mkBankAccount() = Closed

let openAccount =
    function
    | Open x -> Open x
    | Closed -> Open 0.0

let closeAccount x = Closed

let getBalance =
    function
    | Open x -> Some x
    | Closed -> None

let updateBalance change =
    function
    | Open x -> Open (x + change)
    | Closed -> Closed