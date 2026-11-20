#!/usr/bin/env bats

set -euo pipefail

setup() {
  source "$BATS_TEST_DIRNAME/../bin/update-exercises.sh"
  source "$BATS_TEST_DIRNAME/../lib/command-line-parser/option.sh"
  sync() {
    local EXERCISE
    if get_option --exercise EXERCISE "${@:2}"
    then
      echo "Syncronizing exercise '$EXERCISE' and its metadata from problem specifications repository..."
    else
      echo "Syncronizing exercises and metadata from problem specifications repository..."
    fi
  }
}

dotnet() {
  echo "Compiling and running F# project to generate tests from definitions..."
}

@test "can update all exercises" {
  run main

  [ "$status" -eq 0 ]
  [ "${lines[0]}" = "Syncronizing exercises and metadata from problem specifications repository..." ]
  [ "${lines[1]}" = "Compiling and running F# project to generate tests from definitions..." ]
}

@test "can update a single exercise" {
  run main foo

  [ "$status" -eq 0 ]
  [ "${lines[0]}" = "Syncronizing exercise 'foo' and its metadata from problem specifications repository..." ]
  [ "${lines[1]}" = "Compiling and running F# project to generate tests from definitions..." ]
}
