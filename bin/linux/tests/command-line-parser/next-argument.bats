#!/usr/bin/env bats

setup() {
  set -euo pipefail
  source "$BATS_TEST_DIRNAME/../../lib/command-line-parser/argument.sh"
}

usage() {
  local PRELUDE
  if [ -z "${1:-}" ]; then
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

@test "returns 255 when argument is missing" {
  local ANSWER="original"
  local RETURN_CODE=0
  next_argument ANSWER || RETURN_CODE=$?

  [ "$RETURN_CODE" -eq 255 ]
  [ "$ANSWER" = "original" ]
}

@test "returns 255 for empty argument" {
  local ANSWER="original"
  local status=0

  next_argument ANSWER "" || RETURN_CODE=$?

  [ "$RETURN_CODE" -eq 255 ]
  [ "$ANSWER" = "original" ]
}

@test "accepts -h option" {
  run next_argument ANSWER -h

  [ "$status" -eq 0 ]
  [ "${lines[0]}" = "Prelude" ]
}

@test "accepts --help option" {
  run next_argument ANSWER --help

  [ "$status" -eq 0 ]
  [ "${lines[0]}" = "Prelude" ]
}

@test "rejects unknown short option" {
  run next_argument ANSWER -x

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "Unknown option: -x" ]
}

@test "rejects unknown long option" {
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
  run next_argument ANSWER -123abc

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "Unknown option: -123abc" ]
}
