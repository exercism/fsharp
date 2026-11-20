#!/usr/bin/env bats

set -euo pipefail

setup() {
  source "$BATS_TEST_DIRNAME/../../lib/command-line-parser/argument.sh"
}

usage() {
  local PRELUDE
  if [ -z "${1:-}" ]
  then
    PRELUDE="Prelude"
  else
    PRELUDE="$1"
  fi
  cat <<HELP
$PRELUDE

Usage: ...
HELP
}

@test "assigns valid argument to variable" {
  local VALUE
  next_argument VALUE "hello"

  [ "$VALUE" = "hello" ]
}

@test "assigns numeric argument to variable" {
  local VALUE
  next_argument VALUE 123

  [ "$VALUE" = "123" ]
}

@test "assigns argument containing spaces" {
  local VALUE
  next_argument VALUE "hello world"

  [ "$VALUE" = "hello world" ]
}

@test "returns 77 when argument is missing" {
  local VALUE="original"
  local RETURN_CODE=0
  next_argument VALUE || RETURN_CODE=$?

  [ "$RETURN_CODE" -eq 77 ]
  [ "$VALUE" = "original" ]
}

@test "returns 77 for empty argument" {
  local VALUE="original"
  local RETURN_CODE=0
  next_argument VALUE "" || RETURN_CODE=$?

  [ "$RETURN_CODE" -eq 77 ]
  [ "$VALUE" = "original" ]
}

@test "rejects empty option" {
  local VALUE
  run next_argument VALUE -

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "'-' is not a valid argument" ]
}

@test "accepts -h option" {
  local VALUE
  run next_argument VALUE -h

  [ "$status" -eq 0 ]
  [ "${lines[0]}" = "Prelude" ]
}

@test "accepts --help option" {
  local VALUE
  run next_argument VALUE --help

  [ "$status" -eq 0 ]
  [ "${lines[0]}" = "Prelude" ]
}

@test "rejects unknown short option" {
  local VALUE
  run next_argument VALUE -x

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "Unknown option: -x" ]
}

@test "rejects unknown long option" {
  local VALUE
  run next_argument VALUE --unknown

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "Unknown option: --unknown" ]
}

@test "accepts negative numbers" {
  local VALUE
  next_argument VALUE -123

  [ "$VALUE" = "-123" ]
}

@test "rejects option starting with digits" {
  local VALUE
  run next_argument VALUE -123abc

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "Unknown option: -123abc" ]
}
