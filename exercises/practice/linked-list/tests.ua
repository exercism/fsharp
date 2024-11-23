// This file was created manually and its version is 1.0.0.

module LinkedListTest


# Push and pop are first in last out order
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = pop linkedList
    let val2 = pop linkedList

⍤⤙≍ 20 val1
⍤⤙≍ 10 val2

# Push and shift are first in first out order
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = shift linkedList
    let val2 = shift linkedList

⍤⤙≍ 10 val1
⍤⤙≍ 20 val2

# Unshift and shift are last in first out order
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    let val1 = shift linkedList
    let val2 = shift linkedList

⍤⤙≍ 20 val1
⍤⤙≍ 10 val2

# Unshift and pop are last in last out order
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    let val1 = pop linkedList
    let val2 = pop linkedList

⍤⤙≍ 10 val1
⍤⤙≍ 20 val2

# Push and pop can handle multiple values
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20
    linkedList |> push 30

    let val1 = pop linkedList
    let val2 = pop linkedList
    let val3 = pop linkedList

⍤⤙≍ 30 val1
⍤⤙≍ 20 val2
⍤⤙≍ 10 val3

# Unshift and shift can handle multiple values
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20
    linkedList |> unshift 30

    let val1 = shift linkedList
    let val2 = shift linkedList
    let val3 = shift linkedList

⍤⤙≍ 30 val1
⍤⤙≍ 20 val2
⍤⤙≍ 10 val3

# All methods of manipulating the linkedList can be used together
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = pop linkedList

⍤⤙≍ 20 val1

    linkedList |> push 30
    let val2 = shift linkedList

⍤⤙≍ 10 val2

    linkedList |> unshift 40
    linkedList |> push 50

    let val3 = shift linkedList
    let val4 = pop linkedList
    let val5 = shift linkedList

⍤⤙≍ 40 val3
⍤⤙≍ 50 val4
⍤⤙≍ 30 val5