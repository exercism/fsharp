module CircularBufferTest

open NUnit.Framework

open CircularBuffer

[<Test>]
let ``Write and read back one item`` () =
    let buffer1 = mkCircularBuffer 1 |> write '1'    
    let (val2, buffer2) = read buffer1

    Assert.That(val2, Is.EqualTo('1'))    
    Assert.That((fun () -> read buffer2 |> ignore), Throws.Exception)
  
[<Test>]
[<Ignore("Remove to run test")>] 
let ``Write and read back multiple items`` () =    
    let buffer1 = 
        mkCircularBuffer 2
        |> write '1'
        |> write '2'

    let (val2, buffer2) = read buffer1
    let (val3, buffer3) = read buffer2

    Assert.That(val2, Is.EqualTo('1'))
    Assert.That(val3, Is.EqualTo('2'))
    Assert.That((fun () -> read buffer3 |> ignore), Throws.Exception)
    
[<Test>]
[<Ignore("Remove to run test")>] 
let ``Clearing buffer`` () =    
    let buffer1 = mkCircularBuffer 3
    let buffer2 = List.fold (fun buffer value -> write value buffer) buffer1 ['1'..'3']
    let buffer3 = clear buffer2
    
    let buffer4 = 
        buffer3 
        |> write '1' 
        |> write '2'

    let (val5, buffer5) = read buffer4
    let buffer6 = buffer5 |> write '3'
    let (val7, _) = read buffer6

    Assert.That((fun () -> read buffer3 |> ignore), Throws.Exception)
    Assert.That(val5, Is.EqualTo('1'))
    Assert.That(val7, Is.EqualTo('2'))
  
[<Test>]
[<Ignore("Remove to run test")>] 
let ``Alternate write and read`` () =    
    let buffer1 = mkCircularBuffer 2
    let buffer2 = buffer1 |> write '1'
    let (val3, buffer3) = read buffer2
    let buffer4 = buffer3 |> write '2'
    let (val5, _) = read buffer4
    
    Assert.That(val3, Is.EqualTo('1'))
    Assert.That(val5, Is.EqualTo('2'))
  
[<Test>]
[<Ignore("Remove to run test")>] 
let ``Reads back oldest item`` () =    
    let buffer1 = 
        mkCircularBuffer 3
        |> write '1'
        |> write '2'

    let (_, buffer2) = read buffer1
    let buffer3 = buffer2 |> write '3'
    let (val4, buffer4) = read buffer3
    let (val5, _) = read buffer4
    Assert.That(val4, Is.EqualTo('2'))
    Assert.That(val5, Is.EqualTo('3'))
  
[<Test>]
[<Ignore("Remove to run test")>] 
let ``Writing to a full buffer throws an exception`` () =    
    let buffer = 
        mkCircularBuffer 2
        |> write '1'
        |> write '2'

    Assert.That((fun () -> buffer |> write 'A' |> ignore), Throws.Exception)
  
[<Test>]
[<Ignore("Remove to run test")>] 
let ``Overwriting oldest item in a full buffer`` () =    
    let buffer1 = 
        mkCircularBuffer 2
        |> write '1'
        |> write '2'
        |> forceWrite 'A'

    let (val2, buffer2) = read buffer1
    let (val3, buffer3) = read buffer2

    Assert.That(val2, Is.EqualTo('2'))
    Assert.That(val3, Is.EqualTo('A'))
    Assert.That((fun () -> read buffer3 |> ignore), Throws.Exception)
  
[<Test>]
[<Ignore("Remove to run test")>] 
let ``Forced writes to non full buffer should behave like writes`` () =    
    let buffer1 = 
        mkCircularBuffer 2
        |> write '1'
        |> forceWrite '2'

    let (val2, buffer2) = read buffer1
    let (val3, buffer3) = read buffer2

    Assert.That(val2, Is.EqualTo('1'))
    Assert.That(val3, Is.EqualTo('2'))
    Assert.That((fun () -> read buffer3 |> ignore), Throws.Exception)
  
[<Test>]
[<Ignore("Remove to run test")>] 
let ``Alternate read and write into buffer overflow`` () =    
    let buffer1 = mkCircularBuffer 5
    let buffer2 = List.fold (fun buffer value -> write value buffer) buffer1 ['1'..'3']

    let (_, buffer3) = read buffer2
    let (_, buffer4) = read buffer3    
    let buffer5 = buffer4 |> write '4'
    let (_, buffer6) = read buffer5

    let buffer7 = 
        List.fold (fun buffer value -> write value buffer) buffer6 ['5'..'8']
        |> forceWrite 'A'
        |> forceWrite 'B'

    let folder buffer value =
        let (val', buffer') = read buffer    
        Assert.IsTrue((val' = value)) |> ignore
        buffer'

    let buffer8 = List.fold folder buffer7 ['6'..'8']      
    
    let (val9, buffer9) = read buffer8  
    let (val10, buffer10) = read buffer9
    
    Assert.That(val9, Is.EqualTo('A'))
    Assert.That(val10, Is.EqualTo('B'))
    Assert.That((fun () -> read buffer10 |> ignore), Throws.Exception)