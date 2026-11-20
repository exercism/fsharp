#!/usr/bin/env bats

set -euo pipefail

setup() {
  source "$BATS_TEST_DIRNAME/../bin/check-code-snippets.sh"
}

dotnet() {
    echo "Compiling and running F# project to check code snippets..."
}

@test "can run the process of checking code snippets" {
  run main

  [ "$status" -eq 0 ]
  [ "${lines[1]}" = "Compiling and running F# project to check code snippets..." ]
}