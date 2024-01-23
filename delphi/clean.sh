#!/usr/bin/env bash

BUILD_DIR="$(dirname -- "${BASH_SOURCE[0]}")" # relative
BUILD_DIR="$(cd -- "$BUILD_DIR" && pwd)"      # absolutized and normalized
if [[ -z "$BUILD_DIR" ]]; then
    # error; for some reason, the path is not accessible
    # to the script (e.g. permissions re-evaled after suid)
    exit 1 # fail
fi

# clean files for a clean build of everything
echo "Removing ..."
find "$BUILD_DIR" -name "*.o" -delete -print
find "$BUILD_DIR" -name "*.ppu" -delete -print
find "$BUILD_DIR" -name "*.dcu" -delete -print
find "$BUILD_DIR" -name "*.exe" -delete -print
find "$BUILD_DIR" -name "*.dcp" -delete -print
find "$BUILD_DIR" -name "*.bpl" -delete -print
find "$BUILD_DIR" -name "*.drc" -delete -print
find "$BUILD_DIR" -name "*.map" -delete -print
find "$BUILD_DIR" -name "*.rsj" -delete -print
find "$BUILD_DIR" -name "*.ddp" -delete -print
find "$BUILD_DIR" -name ".~*" -delete -print
