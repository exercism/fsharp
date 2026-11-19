#!/usr/bin/env bats

setup() {
  set -euo pipefail
  PARSER="$BATS_TEST_DIRNAME/../../lib/command-line-parser/no-arguments.sh"
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

@test "accepts no arguments" {
  run parse

  [ "$status" -eq 0 ]
  [ -z "$output" ]
}

@test "accepts -h option" {
  run parse -h

  [ "$status" -eq 0 ]
  [ "${lines[0]}" = "Prelude" ]
}

@test "accepts --help option" {
  run parse --help

  [ "$status" -eq 0 ]
  [ "${lines[0]}" = "Prelude" ]
}

@test "rejects unknown short option" {
  run parse -x

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "Unknown option: -x" ]
}

@test "rejects unknown long option" {
  run parse --unknown

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "Unknown option: --unknown" ]
}

@test "rejects unexpected positional argument" {
  run parse filename.txt

  [ "$status" -eq 2 ]
  [ "${lines[0]}" = "Unexpected argument: filename.txt" ]
}

# Execute the parser with a mocked usage function.
parse() {
  (
    set -- "$@"
    source "$PARSER"
  )
}
