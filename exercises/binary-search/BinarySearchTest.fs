module BinarySearchTest

open NUnit.Framework

open BinarySearch

[<Test>]
let ``Should return None when an empty array is searched`` () =
    let input = [||]
    Assert.That(binarySearch input 6, Is.EqualTo(None))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should be able to find a value in a single element array with one access`` () =
    let input = [|6|]
    Assert.That(binarySearch input 6, Is.EqualTo(Some 0))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Should return None if a value is less than the element in a single element array`` () =
    let input = [|94|]
    Assert.That(binarySearch input 6, Is.EqualTo(None))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Should return None if a value is greater than the element in a single element array`` () =
    let input = [|94|]
    Assert.That(binarySearch input 602, Is.EqualTo(None))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should find an element in a longer array`` () =
    let input = [|6; 67; 123; 345; 456; 457; 490; 2002; 54321; 54322|]
    Assert.That(binarySearch input 2002, Is.EqualTo(Some 7))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should find elements at the beginning of an array`` () =
    let input = [|6; 67; 123; 345; 456; 457; 490; 2002; 54321; 54322|]
    Assert.That(binarySearch input 6, Is.EqualTo(Some 0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should find elements at the end of an array`` () =
    let input = [|6; 67; 123; 345; 456; 457; 490; 2002; 54321; 54322|]
    Assert.That(binarySearch input 54322, Is.EqualTo(Some 9))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should return None if a value is less than all elements in a long array`` () =
    let input = [|6; 67; 123; 345; 456; 457; 490; 2002; 54321; 54322|]
    Assert.That(binarySearch input 2, Is.EqualTo(None))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should return None if a value is greater than all elements in a long array`` () =
    let input = [|6; 67; 123; 345; 456; 457; 490; 2002; 54321; 54322|]
    Assert.That(binarySearch input 54323, Is.EqualTo(None))
