#!/usr/bin/env bats

set -euo pipefail

setup() {
  source "$BATS_TEST_DIRNAME/../bin/update-exercise-tools.sh"
  MOCKED_MANIFESTS="$BATS_TEST_DIRNAME/update-exercise-tools"
}

dotnet() {
    echo "Updating manifest $5..."
}

@test "can enumerate manifests to be updated" {
  run process_manifests "$MOCKED_MANIFESTS"

  [ "$status" -eq 0 ]
  [ "${lines[0]}" = "Updating manifest $MOCKED_MANIFESTS/bar/dotnet-tools.json..." ]
  [ "${lines[1]}" = "Updating manifest $MOCKED_MANIFESTS/foo/dotnet-tools.json..." ]
}