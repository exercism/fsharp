module InterestIsInterestingTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open InterestIsInteresting

[<Fact>]
[<Task(1)>]
let ``Minimal first interest rate``() = interestRate 0m |> should (equalWithin 0.001) 0.5f

[<Fact>]
[<Task(1)>]
let ``Tiny first interest rate``() = interestRate 0.000001m |> should (equalWithin 0.001) 0.5f

[<Fact>]
[<Task(1)>]
let ``Maximum first interest rate``() = interestRate 999.9999m |> should (equalWithin 0.001) 0.5f

[<Fact>]
[<Task(1)>]
let ``Minimal second interest rate``() = interestRate 1_000.0m |> should (equalWithin 0.001) 1.621f

[<Fact>]
[<Task(1)>]
let ``Tiny second interest rate``() = interestRate 1_000.0001m |> should (equalWithin 0.001) 1.621f

[<Fact>]
[<Task(1)>]
let ``Maximum second interest rate``() = interestRate 4_999.9990m |> should (equalWithin 0.001) 1.621f

[<Fact>]
[<Task(1)>]
let ``Minimal third interest rate``() = interestRate 5_000.0000m |> should (equalWithin 0.001) 2.475f

[<Fact>]
[<Task(1)>]
let ``Tiny third interest rate``() = interestRate 5_000.0001m |> should (equalWithin 0.001) 2.475f

[<Fact>]
[<Task(1)>]
let ``Large third interest rate``() = interestRate 5_639_998.742909m |> should (equalWithin 0.001) 2.475f

[<Fact>]
[<Task(1)>]
let ``Minimal negative interest rate``() = interestRate -0.000001M |> should (equalWithin 0.001) 3.213f

[<Fact>]
[<Task(1)>]
let ``Small negative interest rate``() = interestRate -0.123M |> should (equalWithin 0.001) 3.213f

[<Fact>]
[<Task(1)>]
let ``Regular negative interest rate``() = interestRate -300.0M |> should (equalWithin 0.001) 3.213f

[<Fact>]
[<Task(1)>]
let ``Large negative interest rate``() = interestRate -152964.231M |> should (equalWithin 0.001) 3.213f

[<Fact>]
[<Task(2)>]
let ``Interest on negative balance`` () = interest -10000.0m |> should (equalWithin 0.001) -321.3m

[<Fact>]
[<Task(2)>]
let ``Interest on small balance`` () = interest 555.55m |> should (equalWithin 0.001) 2.77775m

[<Fact>]
[<Task(2)>]
let ``Interest on medium balance`` () = interest 4999.99m |> should (equalWithin 0.001) 81.0498379m

[<Fact>]
[<Task(2)>]
let ``Interest on large balance`` () = interest 34600.80m |> should (equalWithin 0.001) 856.3698m

[<Fact>]
[<Task(3)>]
let ``Annual balance update for empty start balance``() = annualBalanceUpdate 0.0m |> should (equalWithin 0.001) 0.0000m

[<Fact>]
[<Task(3)>]
let ``Annual balance update for small positive start balance``() =
    annualBalanceUpdate 0.000001m |> should (equalWithin 0.001) 0.000001005m

[<Fact>]
[<Task(3)>]
let ``Annual balance update for average positive start balance``() =
    annualBalanceUpdate 1_000.0m |> should (equalWithin 0.001) 1016.210000m

[<Fact>]
[<Task(3)>]
let ``Annual balance update for large positive start balance``() =
    annualBalanceUpdate 1_000.0001m |> should (equalWithin 0.001) 1016.210101621m

[<Fact>]
[<Task(3)>]
let ``Annual balance update for huge positive start balance``() =
    annualBalanceUpdate 898124017.826243404425m |> should (equalWithin 0.001) 920352587.26744292868451875m

[<Fact>]
[<Task(3)>]
let ``Annual balance update for small negative start balance``() =
    annualBalanceUpdate -0.123M |> should (equalWithin 0.001) -0.12695199M

[<Fact>]
[<Task(3)>]
let ``Annual balance update for large negative start balance``() =
    annualBalanceUpdate -152964.231M |> should (equalWithin 0.001) -157878.97174203M

[<Fact>]
[<Task(4)>]
let ``Amount to donate for empty start balance``() = amountToDonate 0.0m 2.0 |> should equal 0

[<Fact>]
[<Task(4)>]
let ``Amount to donate for small positive start balance``() = amountToDonate 0.000001m 2.1 |> should equal 0

[<Fact>]
[<Task(4)>]
let ``Amount to donate for average positive start balance``() = amountToDonate 1_000.0m 2.0 |> should equal 40

[<Fact>]
[<Task(4)>]
let ``Amount to donate for large positive start balance``() = amountToDonate 1_000.0001m 0.99 |> should equal 19

[<Fact>]
[<Task(4)>]
let ``Amount to donate for huge positive start balance``() =
    amountToDonate 898124017.826243404425m 2.65 |> should equal 47600572

[<Fact>]
[<Task(4)>]
let ``Amount to donate for small negative start balance``() = amountToDonate -0.123M 3.33 |> should equal 0

[<Fact>]
[<Task(4)>]
let ``Amount to donate for large negative start balance``() = amountToDonate -152964.231M 5.4 |> should equal 0
