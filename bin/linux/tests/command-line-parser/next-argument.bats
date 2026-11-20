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
  local ANSWER
  next_argument ANSWER "hello"

  [ "$ANSWER" = "hello" ]
}

@test "assigns numeric argument to variable" {
  local ANSWER
  next_argument ANSWER 123

  [ "$ANSWER" = "123" ]
}

@test "assigns argument containing spaces" {
  local ANSWER
  next_argument ANSWER "hello world"

  [ "$ANSWER" = "hello world" ]
}

@test "returns 111 when argument is missing" {
  local RETURN_CODE=0
  local ANSWER="original"
  next_argument ANSWER || RETURN_CODE=$?

  [ "$RETURN_CODE" -eq 111 ]
  [ "$ANSWER" = "original" ]
}

@test "returns 111 for empty argument" {
  local RETURN_CODE=0
  local ANSWER="original"
  next_argument ANSWER "" || RETURN_CODE=$?

  [ "$RETURN_CODE" -eq 111 ]
  [ "$ANSWER" = "original" ]
}

@test "rejects empty option" {
  local ANSWER
  run next_argument ANSWER -

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "'-' is not a valid argument" ]
}

@test "accepts -h option" {
  local ANSWER
  run next_argument ANSWER -h

  [ "$status" -eq 0 ]
  [ "${lines[0]}" = "Prelude" ]
}

@test "accepts --help option" {
  local ANSWER
  run next_argument ANSWER --help

  [ "$status" -eq 0 ]
  [ "${lines[0]}" = "Prelude" ]
}

@test "rejects unknown short option" {
  local ANSWER
  run next_argument ANSWER -x

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "Unknown option: -x" ]
}

@test "rejects unknown long option" {
  local ANSWER
  run next_argument ANSWER --unknown

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "Unknown option: --unknown" ]
}

@test "accepts negative numbers" {
  local ANSWER
  next_argument ANSWER -123

  [ "$ANSWER" = "-123" ]
}

@test "rejects option starting with digits" {
  local ANSWER
  run next_argument ANSWER -123abc

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "Unknown option: -123abc" ]
}
