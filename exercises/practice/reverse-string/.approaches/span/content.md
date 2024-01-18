# Span&lt;T&gt;

```fsharp
module ReverseString

open System
open Microsoft.FSharp.NativeInterop

let reverse (input: string) =
    let memory = NativePtr.stackalloc<byte>(input.Length) |> NativePtr.toVoidPtr
    let span = Span<char>(memory, input.Length)

    for i in 0..input.Length - 1 do
        span[input.Length - 1 - i] <- input[i]

    span.ToString()
```

F# 4.5 introduced support for the [`Span<T>`][span-t] class, which was specifically designed to allow performant iteration/mutation of _array-like_ objects.
The `Span<T>` class helps improve performance by always being allocated on the _stack_, and not the _heap_.
As objects on the stack don't need to be garbage collected, this can help improve performance (check [this blog post][using-span-t] for more information).

How can we leverage `Span<T>` to reverse our `string`?
The `string` class has an [`AsSpan()`][string-as-span] method, but that returns a `ReadOnlySpan<char>`, which doesn't allow mutation (otherwise we'd be able to indirectly modify the `string`).

We can work around this by manually allocating a `char[]` and assigning to a `Span<char>`:

```fsharp
let array = Array.zeroCreate<char>(input.Length)
let span = Span<char>(array)

for i in 0..input.Length - 1 do
    span[input.Length - 1 - i] <- input[i]

span.ToString()
```

After creating `Span<char>`, we use a regular `for`-loop to iterate over the string's characters and assign them to the right position in the span.
Finally, we can use the `string` constructor overload that takes a `Span<char>` to create the `string`.

However, this is basically the same approach as the `Array.Reverse()` approach, but with us also having to manually write a `for`-loop.
We _can_ do one better though, and that is to use [`NativePtr.stackalloc`]nativeptr.stackalloc.
With `stackalloc`, we can assign a block of memory _on the stack_ (whereas the array would be stored on the heap).

```fsharp
let memory = NativePtr.stackalloc<byte>(input.Length) |> NativePtr.toVoidPtr
let span = Span<char>(memory, input.Length)
```

With this version, the memory allocated for the `Span<char>` is all on the stack and no garbage collection is needed for that data.

```exercism/caution
The stack has a finite amount of memory.
This means that for large strings, the above code will result in a `StackOverflowException` being thrown.
```

So what is the limit for the amount of memory we can allocate?
Well, this depends on how memory has already been allocated on the stack.
That said, a small test program successfully stack-allocated memory for `750_000` characters, so you might be fine.

[nativeptr.stackalloc]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-nativeinterop-nativeptrmodule.html#stackalloc
[using-span-t]: https://learn.microsoft.com/en-us/archive/msdn-magazine/2018/january/csharp-all-about-span-exploring-a-new-net-mainstay
[span-t]: https://learn.microsoft.com/en-us/dotnet/api/system.span-1
[string-as-span]: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.asspan
[approach-performance]: https://exercism.org/tracks/csharp/exercises/reverse-string/articles/performance
