module BookingUpForBeautyTests

open System
open FsUnit.Xunit
open Xunit
open Exercism.Tests
open BookingUpForBeauty

[<Fact>]
[<UseCulture("en-US")>]
[<Task(1)>]
let ``Schedule date using only numbers`` () =
    schedule "7/25/2019 13:45:00"
    |> should equal (DateTime(2019, 7, 25, 13, 45, 0))

[<Fact>]
[<UseCulture("en-US")>]
[<Task(1)>]
let ``Schedule date with textual month`` () =
    schedule "June 3, 2019 11:30:00"
    |> should equal (DateTime(2019, 6, 3, 11, 30, 0))

[<Fact>]
[<UseCulture("en-US")>]
[<Task(1)>]
let ``Schedule date with textual month and weekday`` () =
    schedule "Thursday, December 5, 2019 09:00:00"
    |> should equal (DateTime(2019, 12, 5, 9, 0, 0))

[<Fact>]
[<UseCulture("en-US")>]
[<Task(2)>]
let ``Has passed with appointment 1 year ago`` () =
    hasPassed (DateTime.Now.AddYears(-1).AddHours(2.0))
    |> should equal true

[<Fact>]
[<UseCulture("en-US")>]
[<Task(2)>]
let ``Has passed with appointment months ago`` () =
    hasPassed (DateTime.Now.AddMonths(-8))
    |> should equal true

[<Fact>]
[<UseCulture("en-US")>]
[<Task(2)>]
let ``Has passed with appointment days ago`` () =
    hasPassed (DateTime.Now.AddDays(-23.0))
    |> should equal true

[<Fact>]
[<UseCulture("en-US")>]
[<Task(2)>]
let ``Has passed with appointment hours ago`` () =
    hasPassed (DateTime.Now.AddHours(-12.0))
    |> should equal true

[<Fact>]
[<UseCulture("en-US")>]
[<Task(2)>]
let ``Has passed with appointment minutes ago`` () =
    hasPassed (DateTime.Now.AddMinutes(-55.0))
    |> should equal true

[<Fact>]
[<UseCulture("en-US")>]
[<Task(2)>]
let ``Has passed with appointment 1 minute ago`` () =
    hasPassed (DateTime.Now.AddMinutes(-1.0))
    |> should equal true

[<Fact>]
[<UseCulture("en-US")>]
[<Task(2)>]
let ``Has passed with appointment in 1 minute`` () =
    hasPassed (DateTime.Now.AddMinutes(1.0))
    |> should equal false

[<Fact>]
[<UseCulture("en-US")>]
[<Task(2)>]
let ``Has passed with appointment in minutes`` () =
    hasPassed (DateTime.Now.AddMinutes(5.0))
    |> should equal false

[<Fact>]
[<UseCulture("en-US")>]
[<Task(2)>]
let ``Has passed with appointment in days`` () =
    hasPassed (DateTime.Now.AddDays(19.0))
    |> should equal false

[<Fact>]
[<UseCulture("en-US")>]
[<Task(2)>]
let ``Has passed with appointment in months`` () =
    hasPassed (DateTime.Now.AddMonths(10))
    |> should equal false

[<Fact>]
[<UseCulture("en-US")>]
[<Task(2)>]
let ``Has passed with appointment in years`` () =
    hasPassed (DateTime.Now.AddYears(2).AddMonths(3).AddDays(6.0))
    |> should equal false

[<Fact>]
[<UseCulture("en-US")>]
[<Task(3)>]
let ``Is afternoon appointment for early morning appointment`` () =
    isAfternoonAppointment (DateTime(2019, 6, 17, 8, 15, 0))
    |> should equal false

[<Fact>]
[<UseCulture("en-US")>]
[<Task(3)>]
let ``Is afternoon appointment for late morning appointment`` () =
    isAfternoonAppointment (DateTime(2019, 2, 23, 11, 59, 59))
    |> should equal false

[<Fact>]
[<UseCulture("en-US")>]
[<Task(3)>]
let ``Is afternoon appointment for noon appointment`` () =
    isAfternoonAppointment (DateTime(2019, 8, 9, 12, 0, 0))
    |> should equal true

[<Fact>]
[<UseCulture("en-US")>]
[<Task(3)>]
let ``Is afternoon appointment for early afternoon appointment`` () =
    isAfternoonAppointment (DateTime(2019, 8, 9, 12, 0, 1))
    |> should equal true

[<Fact>]
[<UseCulture("en-US")>]
[<Task(3)>]
let ``Is afternoon appointment for late afternoon appointment`` () =
    isAfternoonAppointment (DateTime(2019, 9, 1, 17, 59, 59))
    |> should equal true

[<Fact>]
[<UseCulture("en-US")>]
[<Task(3)>]
let ``Is afternoon appointment for early evening appointment`` () =
    isAfternoonAppointment (DateTime(2019, 9, 1, 18, 0, 0))
    |> should equal false

[<Fact>]
[<UseCulture("en-US")>]
[<Task(3)>]
let ``Is afternoon appointment for late evening appointment`` () =
    isAfternoonAppointment (DateTime(2019, 9, 1, 23, 59, 59))
    |> should equal false

[<Fact>]
[<UseCulture("en-US")>]
[<Task(4)>]
let ``Description on Friday afternoon`` () =
    description (DateTime(2019, 3, 29, 15, 0, 0))
    |> should equal "You have an appointment on 3/29/2019 3:00:00 PM."

[<Fact>]
[<UseCulture("en-US")>]
[<Task(4)>]
let ``Description on Thursday afternoon`` () =
    description (DateTime(2019, 7, 25, 13, 45, 0))
    |> should equal "You have an appointment on 7/25/2019 1:45:00 PM."

[<Fact>]
[<UseCulture("en-US")>]
[<Task(4)>]
let ``Description on Wednesday morning`` () =
    description (DateTime(2020, 9, 9, 9, 9, 9))
    |> should equal "You have an appointment on 9/9/2020 9:09:09 AM."

[<Fact>]
[<UseCulture("en-US")>]
[<Task(5)>]
let ``Anniversary date this year`` () =
    anniversaryDate ()
    |> should equal (DateTime(DateTime.Now.Year, 9, 15))
