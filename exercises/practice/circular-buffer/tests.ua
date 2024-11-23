~ "circular-buffer.ua" ~ CircularBuffer

# Reading empty buffer should fail
    let buffer1 = mkCircularBuffer 1
    (fun () -> read buffer1 |> ignore) |> should throw typeof<Exception>

# Can read an item just written
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let (val3, _) = read buffer2
⍤⤙≍ 1 val3

# Each item may only be read once
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let (val3, buffer3) = read buffer2
⍤⤙≍ 1 val3
    (fun () -> read buffer3 |> ignore) |> should throw typeof<Exception>

# Items are read in the order they are written
    let buffer1 = mkCircularBuffer 2
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let (val4, buffer4) = read buffer3
⍤⤙≍ 1 val4
    let (val5, _) = read buffer4
⍤⤙≍ 2 val5

# Full buffer can't be written to
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    (fun () -> write 2 buffer2 |> ignore) |> should throw typeof<Exception>

# A read frees up capacity for another write
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let (val3, buffer3) = read buffer2
⍤⤙≍ 1 val3
    let buffer4 = write 2 buffer3
    let (val5, _) = read buffer4
⍤⤙≍ 2 val5

# Read position is maintained even across multiple writes
    let buffer1 = mkCircularBuffer 3
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let (val4, buffer4) = read buffer3
⍤⤙≍ 1 val4
    let buffer5 = write 3 buffer4
    let (val6, buffer6) = read buffer5
⍤⤙≍ 2 val6
    let (val7, _) = read buffer6
⍤⤙≍ 3 val7

# Items cleared out of buffer can't be read
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let buffer3 = clear buffer2
    (fun () -> read buffer3 |> ignore) |> should throw typeof<Exception>

# Clear frees up capacity for another write
    let buffer1 = mkCircularBuffer 1
    let buffer2 = write 1 buffer1
    let buffer3 = clear buffer2
    let buffer4 = write 2 buffer3
    let (val5, _) = read buffer4
⍤⤙≍ 2 val5

# Clear does nothing on empty buffer
    let buffer1 = mkCircularBuffer 1
    let buffer2 = clear buffer1
    let buffer3 = write 1 buffer2
    let (val4, _) = read buffer3
⍤⤙≍ 1 val4

# Overwrite acts like write on non-full buffer
    let buffer1 = mkCircularBuffer 2
    let buffer2 = write 1 buffer1
    let buffer3 = forceWrite 2 buffer2
    let (val4, buffer4) = read buffer3
⍤⤙≍ 1 val4
    let (val5, _) = read buffer4
⍤⤙≍ 2 val5

# Overwrite replaces the oldest item on full buffer
    let buffer1 = mkCircularBuffer 2
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let buffer4 = forceWrite 3 buffer3
    let (val5, buffer5) = read buffer4
⍤⤙≍ 2 val5
    let (val6, _) = read buffer5
⍤⤙≍ 3 val6

# Overwrite replaces the oldest item remaining in buffer following a read
    let buffer1 = mkCircularBuffer 3
    let buffer2 = write 1 buffer1
    let buffer3 = write 2 buffer2
    let buffer4 = write 3 buffer3
    let (val5, buffer5) = read buffer4
⍤⤙≍ 1 val5
    let buffer6 = write 4 buffer5
    let buffer7 = forceWrite 5 buffer6
    let (val8, buffer8) = read buffer7
⍤⤙≍ 3 val8
    let (val9, buffer9) = read buffer8
⍤⤙≍ 4 val9
    let (val10, _) = read buffer9
⍤⤙≍ 5 val10

# Initial clear does not affect wrapping around
    let buffer1 = mkCircularBuffer 2
    let buffer2 = clear buffer1
    let buffer3 = write 1 buffer2
    let buffer4 = write 2 buffer3
    let buffer5 = forceWrite 3 buffer4
    let buffer6 = forceWrite 4 buffer5
    let (val7, buffer7) = read buffer6
⍤⤙≍ 3 val7
    let (val8, buffer8) = read buffer7
⍤⤙≍ 4 val8
    (fun () -> read buffer8 |> ignore) |> should throw typeof<Exception>

