# Architectural overview

This is a brief explaination of architecture decisions made while developing tooling for `fsharp` track of Exercism and Linux platform.

[bash-coding-standard]: https://github.com/Open-Technology-Foundation/bash-coding-standard

## Nov 17, 2026

Since I am just learning bash, first of all, I had a look at how others implement command line parsing at bash. And, well... it was a labyrinth of while loops, counters, arrays and associative arrays, `if` and `case` expressions. Each of these concepts is not that hard, but their mixture is hard to understand and test.

So I decided that imperative parsing of command line arguments is not for me, and decided to follow the same recursive approach I usually use in my F# projects.

My approach looks like:

```fsharp
let rec parse_arguments state = function
    | [] -> state
    | argument :: rest ->
        (* parse argument *)
        (* update state *)
        parse_arguments updated_state rest
```

However, looking at Powershell scripts to be translated, one can notice:

1. There are only a few arguments to parse or even none.
2. The most important part is to implement parsing properly.

As a consequence, I decided:

1. Instead of using recursive functions, unfold the recursion to `if..then..else` chains. Since at the time of writing there was no more than three arguments, it seems reasonable to me. Like so:

    ```bash
    if next_argument "ARGUMENT_1" "$@"
    then
        shift
        if next_argument "ARGUMENT_2" "$@"
        then
            shift
            if next_argument "ARGUMENT_3" "$@"
            then
                shift
                ...
            else
                ...
            fi
        else
            ...
        fi
    else
        ...
    fi
    ```

    Yeah, I agree this is at the edge of being ugly, but writing recursive functions in bash doesn't seem as enjoyable as in F#, so I will stick to that simple approach until argument parsing will get more complex.

2. Concentrate on proper parsing and helpful messages in case of failure.

3. Implement different branches of F# pattern match using separate scripts:
    - `no-arguments.sh` for `[]` branch
    - `argument.sh` for `argument :: rest` branch

## Nov 18, 2026

Since there are no direct equivalent of Powershell's comment-based help, decided to replace it with `usage` function.

The template of `usage` function is taken from [Bash coding standard][bash-coding-standard].

### check-code-snippets translation

`$ErrorActionPreference = "Stop"`, `$PSNativeCommandUseErrorActionPreference` - in bash, native command exit codes are checked automatically when `set -e` is on.

In this project, a decision is to use `set -euo pipefail`, which is even more strictier.

### update-exercise-tools translation

- `Get-ChildItem ... -Recurse` is replaced by Linux `find` command.
- `ForEach-Object` is replaced with `while read -r ... do ... done` block.
  
  The flag `-r` stands for raw mode.

  Without `-r`, `read` command treats backslash as an escape character,
  which is not good, as on Windows via Git Bash / Windows Subsystem for Linux
  backslashes in path are common.

- Process substitution `<(...)` to used to keep the `while` loop body execution in the current shell.
