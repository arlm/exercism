#!/bin/sh

dry_run=false
untracked=false
recursive=false

for arg in "$@"
do
  case $arg in
    --dry-run|-n)
      dry_run=true
      ;;
    --untracked|-u)
      untracked=true
      ;;
    --recursive|-r)
      recursive=true
      ;;
    *)
      echo "Unknown argument: $arg"
      exit 1
      ;;
  esac
done

# Clean only files that matches .gitignore patterns
# This will also dele the preparation steps like `node install`
# See: https://git-scm.com/docs/git-clean

flags=""

if $untracked; then
  flags="$flags -x"
else
  flags="$flags -X"
fi

if $recursive; then
  flags="$flags -d"
fi

if $dry_run; then
  flags="$flags --dry-run"
else
  flags="$flags --force"
fi

echo ">> git clean $flags"

git clean $flags
