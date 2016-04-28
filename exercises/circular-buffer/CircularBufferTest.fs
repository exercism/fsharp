module CircularBufferTest

open NUnit.Framework

open CircularBuffer

[<Test>]
let ``Write and read back one item`` () =
    let buffer = new CircularBuffer<char>(1)
    buffer.write('1') |> ignore
    Assert.That(buffer.read(), Is.EqualTo('1'))    
    Assert.That((fun () -> buffer.read() |> ignore), Throws.Exception)
  
[<Test>]
[<Ignore("Remove to run test")>]
let ``Write and read back multiple items`` () =    
    let buffer = new CircularBuffer<char>(2)
    buffer.write('1') |> ignore
    buffer.write('2') |> ignore
    Assert.That(buffer.read(), Is.EqualTo('1'))
    Assert.That(buffer.read(), Is.EqualTo('2'))
    Assert.That((fun () -> buffer.read() |> ignore), Throws.Exception)
  
[<Test>]
[<Ignore("Remove to run test")>]
let ``Clearing buffer`` () =    
    let buffer = new CircularBuffer<char>(3)
    List.iter (fun value -> buffer.write(value) |> ignore) ['1'..'3']
    buffer.clear() |> ignore
    Assert.That((fun () -> buffer.read() |> ignore), Throws.Exception)
    buffer.write('1') |> ignore
    buffer.write('2') |> ignore
    Assert.That(buffer.read(), Is.EqualTo('1'))
    buffer.write('3') |> ignore
    Assert.That(buffer.read(), Is.EqualTo('2'))
  
[<Test>]
[<Ignore("Remove to run test")>]
let ``Alternate write and read`` () =    
    let buffer = new CircularBuffer<char>(2)
    buffer.write('1') |> ignore
    Assert.That(buffer.read(), Is.EqualTo('1'))
    buffer.write('2') |> ignore
    Assert.That(buffer.read(), Is.EqualTo('2'))
  
[<Test>]
[<Ignore("Remove to run test")>]
let ``Reads back oldest item`` () =    
    let buffer = new CircularBuffer<char>(3)
    buffer.write('1') |> ignore
    buffer.write('2') |> ignore
    buffer.read() |> ignore
    buffer.write('3') |> ignore
    Assert.That(buffer.read(), Is.EqualTo('2'))
    Assert.That(buffer.read(), Is.EqualTo('3'))
  
[<Test>]
[<Ignore("Remove to run test")>]
let ``Writing to a full buffer throws an exception`` () =    
    let buffer = new CircularBuffer<char>(2)
    buffer.write('1') |> ignore
    buffer.write('2') |> ignore
    Assert.That((fun () -> buffer.write('A') |> ignore), Throws.Exception)
  
[<Test>]
[<Ignore("Remove to run test")>]
let ``Overwriting oldest item in a full buffer`` () =    
    let buffer = new CircularBuffer<char>(2)
    buffer.write('1') |> ignore
    buffer.write('2') |> ignore
    buffer.forceWrite('A') |> ignore
    Assert.That(buffer.read(), Is.EqualTo('2'))
    Assert.That(buffer.read(), Is.EqualTo('A'))
    Assert.That((fun () -> buffer.read() |> ignore), Throws.Exception)
  
[<Test>]
[<Ignore("Remove to run test")>]
let ``Forced writes to non full buffer should behave like writes`` () =    
    let buffer = new CircularBuffer<char>(2)
    buffer.write('1') |> ignore
    buffer.forceWrite('2') |> ignore
    Assert.That(buffer.read(), Is.EqualTo('1'))
    Assert.That(buffer.read(), Is.EqualTo('2'))
    Assert.That((fun () -> buffer.read() |> ignore), Throws.Exception)
  
[<Test>]
[<Ignore("Remove to run test")>]
let ``Alternate read and write into buffer overflow`` () =    
    let buffer = new CircularBuffer<char>(5)
    List.iter (fun value -> buffer.write(value) |> ignore) ['1'..'3']
    buffer.read() |> ignore
    buffer.read() |> ignore
    buffer.write('4') |> ignore
    buffer.read() |> ignore
    List.iter (fun value -> buffer.write(value) |> ignore) ['5'..'8']
    buffer.forceWrite('A') |> ignore
    buffer.forceWrite('B') |> ignore

    List.iter (fun value -> Assert.That(buffer.read(), Is.EqualTo(value)) |> ignore) ['6'..'8']        
    
    Assert.That(buffer.read(), Is.EqualTo('A'))
    Assert.That(buffer.read(), Is.EqualTo('B'))
    Assert.That((fun () -> buffer.read() |> ignore), Throws.Exception)  