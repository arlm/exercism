#!/bin/sh

dry_run=false

if [ "$1" = "--dry-run" ] || [ "$1" = "-n" ]; then
  dry_run=true
fi

# Clean only files that matches .gitignore patterns
# This will also dele the preparation steps like `node install`
# See: https://git-scm.com/docs/git-clean

if $dry_run; then
  git clean -Xdfn
else
  git clean -Xdf
fi
