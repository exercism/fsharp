module ListOpsTest

open NUnit.Framework
open ListOps

[<TestFixture>]
type ListOpsTest() =

  [<Test>]
  member tests.Length_of_empty_list() =
    Assert.That(length [], Is.EqualTo(0))

  [<Test>]
  member tests.Length_of_normal_list() =
    Assert.That(length [1;2;3;4], Is.EqualTo(4))

  [<Test>]
  member tests.Length_of_huge_list() =
    Assert.That(length [1..1000000], Is.EqualTo(1000000))

  [<Test>]
  member tests.Rev_of_empty_list() =
    Assert.That(rev [], Is.EqualTo([]))

  [<Test>]
  member tests.Rev_of_normal_list() =
    Assert.That(rev [1;2;3;4], Is.EqualTo([4;3;2;1]))

  [<Test>]
  member tests.Rev_of_huge_list() =
    // Use List.toArray before comparing because the GetHashCode method on F#'s list
    // (at least on Mono) isn't tail recursive and would overflow.
    Assert.That(rev [1..1000000] |> List.toArray, Is.EqualTo([1000000..-1..1] |> List.toArray))

  [<Test>]
  member tests.Map_of_empty_list() =
    Assert.That(map (fun x -> x+1) [], Is.EqualTo([]))

  [<Test>]
  member tests.Map_of_normal_list() =
    Assert.That(map (fun x -> x+1) [1;2;3;4], Is.EqualTo([2;3;4;5]))

  [<Test>]
  member tests.Map_of_huge_list() =
    Assert.That(map (fun x -> x+1) [1..1000000] |> List.toArray, Is.EqualTo([2..1000001] |> List.toArray))

  [<Test>]
  member tests.Filter_of_empty_list() =
    Assert.That(filter (fun x -> x % 2 = 0) [], Is.EqualTo([]))

  [<Test>]
  member tests.Filter_of_normal_list() =
    Assert.That(filter (fun x -> x % 2 = 0) [1;2;3;4], Is.EqualTo([2;4]))

  [<Test>]
  member tests.Filter_of_huge_list() =
    Assert.That(filter (fun x -> x % 2 = 0) [1..1000000] |> List.toArray,
                Is.EqualTo([2..2..1000000] |> List.toArray))

  [<Test>]
  member tests.Append_of_empty_lists() =
    Assert.That(append [] [], Is.EqualTo([]))

  [<Test>]
  member tests.Append_of_empty_and_nonempty_list() =
    Assert.That(append [] [3;4], Is.EqualTo([3;4]))

  [<Test>]
  member tests.Append_of_nonempty_and_empty_list() =
    Assert.That(append [1;2] [], Is.EqualTo([1;2]))

  [<Test>]
  member tests.Append_of_nonempty_and_nonempty_list() =
    Assert.That(append [1;2] [3;4], Is.EqualTo([1;2;3;4]))

  [<Test>]
  member tests.Append_of_huge_lists() =
    Assert.That(append [1..1000000] [1000001..2000000] |> List.toArray,
                Is.EqualTo([1..2000000] |> List.toArray))

  [<Test>]
  member tests.Concat_of_empty_list() =
    Assert.That(concat [], Is.EqualTo([]))

  [<Test>]
  member tests.Concat_of_list_of_empty_lists() =
    Assert.That(concat [[];[];[]], Is.EqualTo([]))

  [<Test>]
  member tests.Concat_of_list_of_lists() =
    Assert.That(concat [[1;2];[3];[4;5];[];[6]], Is.EqualTo([1;2;3;4;5;6]))

  [<Test>]
  member tests.Concat_of_huge_list_of_lists() =
    Assert.That(concat (List.init 100000 (fun i -> [i*10+1..(i+1)*10])) |> List.toArray,
                Is.EqualTo([1..1000000] |> List.toArray))

  [<Test>]
  member tests.Concat_of_list_of_huge_lists() =
    Assert.That(concat (List.init 10 (fun i -> [i*100000+1..(i+1)*100000])) |> List.toArray,
                Is.EqualTo([1..1000000] |> List.toArray))
