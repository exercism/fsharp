# Usage: ./update-docs.ps1. This will regenerate the docs for all exercises.
# Usage: ./update-docs.ps1 -o <exercise>. This will regenerate the docs for the specified exercise.

./update-canonical-data.ps1

./bin/fetch-configlet
./bin/configlet generate . -p problem-specifications $args

exit $LastExitCode