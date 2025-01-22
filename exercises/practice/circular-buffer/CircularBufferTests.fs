source("./circular-buffer.R")
library(testthat)

let ``Reading empty buffer should fail`` () =
    buffer1 <- mkCircularBuffer 1
    (fun () -> read buffer1 |> ignore) |> should throw typeof<Exception>

let ``Can read an item just written`` () =
    buffer1 <- mkCircularBuffer 1
    buffer2 <- write 1 buffer1
    let (val3, _) = read buffer2
    val3 |> should equal 1

let ``Each item may only be read once`` () =
    buffer1 <- mkCircularBuffer 1
    buffer2 <- write 1 buffer1
    let (val3, buffer3) = read buffer2
    val3 |> should equal 1
    (fun () -> read buffer3 |> ignore) |> should throw typeof<Exception>

let ``Items are read in the order they are written`` () =
    buffer1 <- mkCircularBuffer 2
    buffer2 <- write 1 buffer1
    buffer3 <- write 2 buffer2
    let (val4, buffer4) = read buffer3
    val4 |> should equal 1
    let (val5, _) = read buffer4
    val5 |> should equal 2

let ``Full buffer can't be written to`` () =
    buffer1 <- mkCircularBuffer 1
    buffer2 <- write 1 buffer1
    (fun () -> write 2 buffer2 |> ignore) |> should throw typeof<Exception>

let ``A read frees up capacity for another write`` () =
    buffer1 <- mkCircularBuffer 1
    buffer2 <- write 1 buffer1
    let (val3, buffer3) = read buffer2
    val3 |> should equal 1
    buffer4 <- write 2 buffer3
    let (val5, _) = read buffer4
    val5 |> should equal 2

let ``Read position is maintained even across multiple writes`` () =
    buffer1 <- mkCircularBuffer 3
    buffer2 <- write 1 buffer1
    buffer3 <- write 2 buffer2
    let (val4, buffer4) = read buffer3
    val4 |> should equal 1
    buffer5 <- write 3 buffer4
    let (val6, buffer6) = read buffer5
    val6 |> should equal 2
    let (val7, _) = read buffer6
    val7 |> should equal 3

let ``Items cleared out of buffer can't be read`` () =
    buffer1 <- mkCircularBuffer 1
    buffer2 <- write 1 buffer1
    buffer3 <- clear buffer2
    (fun () -> read buffer3 |> ignore) |> should throw typeof<Exception>

let ``Clear frees up capacity for another write`` () =
    buffer1 <- mkCircularBuffer 1
    buffer2 <- write 1 buffer1
    buffer3 <- clear buffer2
    buffer4 <- write 2 buffer3
    let (val5, _) = read buffer4
    val5 |> should equal 2

let ``Clear does nothing on empty buffer`` () =
    buffer1 <- mkCircularBuffer 1
    buffer2 <- clear buffer1
    buffer3 <- write 1 buffer2
    let (val4, _) = read buffer3
    val4 |> should equal 1

let ``Overwrite acts like write on non-full buffer`` () =
    buffer1 <- mkCircularBuffer 2
    buffer2 <- write 1 buffer1
    buffer3 <- forceWrite 2 buffer2
    let (val4, buffer4) = read buffer3
    val4 |> should equal 1
    let (val5, _) = read buffer4
    val5 |> should equal 2

let ``Overwrite replaces the oldest item on full buffer`` () =
    buffer1 <- mkCircularBuffer 2
    buffer2 <- write 1 buffer1
    buffer3 <- write 2 buffer2
    buffer4 <- forceWrite 3 buffer3
    let (val5, buffer5) = read buffer4
    val5 |> should equal 2
    let (val6, _) = read buffer5
    val6 |> should equal 3

let ``Overwrite replaces the oldest item remaining in buffer following a read`` () =
    buffer1 <- mkCircularBuffer 3
    buffer2 <- write 1 buffer1
    buffer3 <- write 2 buffer2
    buffer4 <- write 3 buffer3
    let (val5, buffer5) = read buffer4
    val5 |> should equal 1
    buffer6 <- write 4 buffer5
    buffer7 <- forceWrite 5 buffer6
    let (val8, buffer8) = read buffer7
    val8 |> should equal 3
    let (val9, buffer9) = read buffer8
    val9 |> should equal 4
    let (val10, _) = read buffer9
    val10 |> should equal 5

let ``Initial clear does not affect wrapping around`` () =
    buffer1 <- mkCircularBuffer 2
    buffer2 <- clear buffer1
    buffer3 <- write 1 buffer2
    buffer4 <- write 2 buffer3
    buffer5 <- forceWrite 3 buffer4
    buffer6 <- forceWrite 4 buffer5
    let (val7, buffer7) = read buffer6
    val7 |> should equal 3
    let (val8, buffer8) = read buffer7
    val8 |> should equal 4
    (fun () -> read buffer8 |> ignore) |> should throw typeof<Exception>

