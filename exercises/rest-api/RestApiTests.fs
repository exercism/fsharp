// This file was auto-generated based on version 1.1.1 of the canonical data.

module RestApiTests

open FsUnit.Xunit
open Xunit

open RestApi

[<Fact>]
let ``No users`` () =
    let database = """{"users":[]}"""
    let url = "/users"
    let expected = """{"users":[]}"""
    let api = RestApi(database)
    api.Get url |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Add user`` () =
    let database = """{"users":[]}"""
    let payload = """{"user":"Adam"}"""
    let url = "/add"
    let expected = """{"name":"Adam","owes":{},"owed_by":{},"balance":0.0}"""
    let api = RestApi(database)
    api.Post (url, payload) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Get single user`` () =
    let database = """{"users":[{"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{},"owed_by":{},"balance":0.0}]}"""
    let payload = """{"users":["Bob"]}"""
    let url = "/users"
    let expected = """{"users":[{"name":"Bob","owes":{},"owed_by":{},"balance":0.0}]}"""
    let api = RestApi(database)
    api.Get (url, payload) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Both users have 0 balance`` () =
    let database = """{"users":[{"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{},"owed_by":{},"balance":0.0}]}"""
    let payload = """{"lender":"Adam","borrower":"Bob","amount":3.0}"""
    let url = "/iou"
    let expected = """{"users":[{"name":"Adam","owes":{},"owed_by":{"Bob":3.0},"balance":3.0},{"name":"Bob","owes":{"Adam":3.0},"owed_by":{},"balance":-3.0}]}"""
    let api = RestApi(database)
    api.Post (url, payload) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Borrower has negative balance`` () =
    let database = """{"users":[{"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{"Chuck":3.0},"owed_by":{},"balance":-3.0},{"name":"Chuck","owes":{},"owed_by":{"Bob":3.0},"balance":3.0}]}"""
    let payload = """{"lender":"Adam","borrower":"Bob","amount":3.0}"""
    let url = "/iou"
    let expected = """{"users":[{"name":"Adam","owes":{},"owed_by":{"Bob":3.0},"balance":3.0},{"name":"Bob","owes":{"Adam":3.0,"Chuck":3.0},"owed_by":{},"balance":-6.0}]}"""
    let api = RestApi(database)
    api.Post (url, payload) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Lender has negative balance`` () =
    let database = """{"users":[{"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{"Chuck":3.0},"owed_by":{},"balance":-3.0},{"name":"Chuck","owes":{},"owed_by":{"Bob":3.0},"balance":3.0}]}"""
    let payload = """{"lender":"Bob","borrower":"Adam","amount":3.0}"""
    let url = "/iou"
    let expected = """{"users":[{"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{"Chuck":3.0},"owed_by":{"Adam":3.0},"balance":0.0}]}"""
    let api = RestApi(database)
    api.Post (url, payload) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Lender owes borrower`` () =
    let database = """{"users":[{"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{},"owed_by":{"Adam":3.0},"balance":3.0}]}"""
    let payload = """{"lender":"Adam","borrower":"Bob","amount":2.0}"""
    let url = "/iou"
    let expected = """{"users":[{"name":"Adam","owes":{"Bob":1.0},"owed_by":{},"balance":-1.0},{"name":"Bob","owes":{},"owed_by":{"Adam":1.0},"balance":1.0}]}"""
    let api = RestApi(database)
    api.Post (url, payload) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Lender owes borrower less than new loan`` () =
    let database = """{"users":[{"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{},"owed_by":{"Adam":3.0},"balance":3.0}]}"""
    let payload = """{"lender":"Adam","borrower":"Bob","amount":4.0}"""
    let url = "/iou"
    let expected = """{"users":[{"name":"Adam","owes":{},"owed_by":{"Bob":1.0},"balance":1.0},{"name":"Bob","owes":{"Adam":1.0},"owed_by":{},"balance":-1.0}]}"""
    let api = RestApi(database)
    api.Post (url, payload) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Lender owes borrower same as new loan`` () =
    let database = """{"users":[{"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{},"owed_by":{"Adam":3.0},"balance":3.0}]}"""
    let payload = """{"lender":"Adam","borrower":"Bob","amount":3.0}"""
    let url = "/iou"
    let expected = """{"users":[{"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{},"owed_by":{},"balance":0.0}]}"""
    let api = RestApi(database)
    api.Post (url, payload) |> should equal expected

