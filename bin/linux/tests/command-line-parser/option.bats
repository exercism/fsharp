#!/usr/bin/env bats

set -euo pipefail

setup() {
  source "$BATS_TEST_DIRNAME/../../lib/command-line-parser/option.sh"
}

@test "gets option with space-separated value" {
    local VALUE
    get_option --name VALUE --name Foo

    [ "$VALUE" = Foo ]
}

@test "gets option with equals sign as separator" {
    local VALUE
    get_option --name VALUE --name=Foo

    [ "$VALUE" = Foo ]
}

@test "preserves value when option is not found" {
    local VALUE=Original
    local RETURN_CODE=0
    get_option --name VALUE --other Foo || RETURN_CODE=$?

    [ $RETURN_CODE -eq 111 ]
    [ "$VALUE" = Original ]
}

@test "preserves value when no arguments are provided" {
    local VALUE=Original
    local RETURN_CODE=0

    get_option --name VALUE || RETURN_CODE=$?

    [ $RETURN_CODE -eq 111 ]
    [ "$VALUE" = Original ]
}

@test "returns 2 when option value is missing" {
    local VALUE=Original
    local RETURN_CODE=0

    get_option --name VALUE --name || RETURN_CODE=$?

    [ $RETURN_CODE -eq 2 ]
    [ "$VALUE" = Original ]
}

@test "returns 2 when option value is missing after equals sign" {
    local VALUE=Original
    local RETURN_CODE=0

    get_option --name VALUE --name= || RETURN_CODE=$?

    [ $RETURN_CODE -eq 2 ]
    [ "$VALUE" = Original ]
}

@test "gets option before double dash" {
    local VALUE
    get_option --name VALUE --name Foo --

    [ "$VALUE" = Foo ]
}

@test "ignores pseudo-option after double dash" {
    local VALUE=Original
    local RETURN_CODE=0

    get_option --name VALUE -- --name Foo || RETURN_CODE=$?

    [ $RETURN_CODE -eq 111 ]
    [ "$VALUE" = Original ]
}

@test "first occurrence wins" {
    local VALUE

    get_option --name VALUE \
        --name Alice \
        --name Bob

    [ "$VALUE" = Alice ]
}

@test "ignores unrelated options" {
    local VALUE
    get_option --name VALUE \
        --other Bar \
        --name Foo \
        --another Baz

    [ "$VALUE" = Foo ]
}

@test "preserves values containing spaces" {
    local VALUE
    get_option --name VALUE --name "Foo Bar"

    [ "$VALUE" = "Foo Bar" ]
}

@test "preserves value containing equals sign" {
    local VALUE
    get_option --name VALUE --name=foo=bar

    [ "$VALUE" = "foo=bar" ]
}

@test "accepts negative integer as value" {
    local VALUE
    get_option --score VALUE --score -123

    [ "$VALUE" -eq -123 ]
}

@test "does not match partial option name" {
    local VALUE=Original
    local RETURN_CODE=0
    get_option --name VALUE \
        --names "Foo, Bob" || RETURN_CODE=$?

    [ $RETURN_CODE -eq 111 ]
    [ "$VALUE" = Original ]
}

@test "does not match option name as prefix" {
    local VALUE=Original
    local RETURN_CODE=0

    get_option --name VALUE \
        --name-extra=Foo || RETURN_CODE=$?

    [ $RETURN_CODE -eq 111 ]
    [ "$VALUE" = Original ]
}