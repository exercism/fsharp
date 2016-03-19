module PalindromeTest

open NUnit.Framework

open Palindrome

[<Test>]
let ``Largest palindrome from single digit factors``() =
    let (largest, factors) = largestPalindrome 1 9
    Assert.That(largest, Is.EqualTo(9))
    Assert.That(factors, Is.EqualTo([(1, 9); (3, 3)]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Smallest palindrome from single digit factors``() =
    let (smallest, factors) = smallestPalindrome 1 9
    Assert.That(smallest, Is.EqualTo(1))
    Assert.That(factors, Is.EqualTo([(1, 1)]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Largest palindrome from double digit actors``() =
    let (largest, factors) = largestPalindrome 10 99
    Assert.That(largest, Is.EqualTo(9009))
    Assert.That(factors, Is.EqualTo([(91, 99)]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Smallest palindrome from double digit factors``() =
    let (smallest, factors) = smallestPalindrome 10 99
    Assert.That(smallest, Is.EqualTo(121))
    Assert.That(factors, Is.EqualTo([(11, 11)]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Largest palindrome from triple digit factors``() =
    let (largest, factors) = largestPalindrome 100 999
    Assert.That(largest, Is.EqualTo(906609))
    Assert.That(factors, Is.EqualTo([(913, 993)]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Smallest palindrome from triple digit factors``() =
    let (smallest, factors) = smallestPalindrome 100 999
    Assert.That(smallest, Is.EqualTo(10201))
    Assert.That(factors, Is.EqualTo([(101, 101)]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Largest palindrome from four digit factors``() =
    let (largest, factors) = largestPalindrome 1000 9999
    Assert.That(largest, Is.EqualTo(99000099))
    Assert.That(factors, Is.EqualTo([(9901, 9999)]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Smallest palindrome from four digit factors``() =
    let (smallest, factors) = smallestPalindrome 1000 9999
    Assert.That(smallest, Is.EqualTo(1002001))
    Assert.That(factors, Is.EqualTo([(1001, 1001)]))