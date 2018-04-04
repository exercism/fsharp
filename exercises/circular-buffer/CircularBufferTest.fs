// This file was auto-generated based on version 1.1.0 of the canonical data.

module CircularBufferTest

open FsUnit.Xunit
open Xunit
open System

open CircularBuffer

[<Fact>]
let ``Reading empty buffer should fail`` () =
    let buffer1 = mkCircularBuffer 1
    (fun () -> read buffer1 |> ignore) |> should throw typeof<Exception>

[<Fact(Skip = "Remove to run test")>]
let ``Can read an item just written`` () =
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let (val3, _) = read buffer2
    val3 |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Each item may only be read once`` () =
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let (val3, buffer3) = read buffer2
    val3 |> should equal 1
    (fun () -> read buffer3 |> ignore) |> should throw typeof<Exception>

[<Fact(Skip = "Remove to run test")>]
let ``Items are read in the order they are written`` () =
    let buffer1 = mkCircularBuffer 2
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let (val4, buffer4) = read buffer3
    val4 |> should equal 1
    let (val5, _) = read buffer4
    val5 |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Full buffer can't be written to`` () =
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    (fun () -> write 2 buffer2 |> ignore) |> should throw typeof<Exception>

[<Fact(Skip = "Remove to run test")>]
let ``A read frees up capacity for another write`` () =
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let (val3, buffer3) = read buffer2
    val3 |> should equal 1
    let buffer4 = write 2 buffer3
    let (val5, _) = read buffer4
    val5 |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Read position is maintained even across multiple writes`` () =
    let buffer1 = mkCircularBuffer 3
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let (val4, buffer4) = read buffer3
    val4 |> should equal 1
    let buffer5 = write 3 buffer4
    let (val6, buffer6) = read buffer5
    val6 |> should equal 2
    let (val7, _) = read buffer6
    val7 |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``Items cleared out of buffer can't be read`` () =
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let buffer3 = clear buffer2
    (fun () -> read buffer3 |> ignore) |> should throw typeof<Exception>

[<Fact(Skip = "Remove to run test")>]
let ``Clear frees up capacity for another write`` () =
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let buffer3 = clear buffer2
    let buffer4 = write 2 buffer3
    let (val5, _) = read buffer4
    val5 |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Clear does nothing on empty buffer`` () =
    let buffer1 = mkCircularBuffer 1
    let buffer2 = clear buffer1
    let buffer3 = write 1 buffer2
    let (val4, _) = read buffer3
    val4 |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Overwrite acts like write on non-full buffer`` () =
    let buffer1 = mkCircularBuffer 2
    let buffer2 = write 1 buffer1
    let buffer3 = forceWrite 2 buffer2
    let (val4, buffer4) = read buffer3
    val4 |> should equal 1
    let (val5, _) = read buffer4
    val5 |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Overwrite replaces the oldest item on full buffer`` () =
    let buffer1 = mkCircularBuffer 2
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let buffer4 = forceWrite 3 buffer3
    let (val5, buffer5) = read buffer4
    val5 |> should equal 2
    let (val6, _) = read buffer5
    val6 |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``Overwrite replaces the oldest item remaining in buffer following a read`` () =
    let buffer1 = mkCircularBuffer 3
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let buffer4 = write 3 buffer3
    let (val5, buffer5) = read buffer4
    val5 |> should equal 1
    let buffer6 = write 4 buffer5
    let buffer7 = forceWrite 5 buffer6
    let (val8, buffer8) = read buffer7
    val8 |> should equal 3
    let (val9, buffer9) = read buffer8
    val9 |> should equal 4
    let (val10, _) = read buffer9
    val10 |> should equal 5

