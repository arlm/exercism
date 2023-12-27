#!/usr/bin/env bash

set -ex

BUILD_DIR="$(dirname -- "${BASH_SOURCE[0]}")" # relative
BUILD_DIR="$(cd -- "$BUILD_DIR" && pwd)" # absolutized and normalized
if [[ -z "$BUILD_DIR" ]] ; then
# error; for some reason, the path is not accessible
# to the script (e.g. permissions re-evaled after suid)
exit 1 # fail
fi

OBJ_DIR="$BUILD_DIR/obj"

mkdir -p "$OBJ_DIR"

SCRIPT_NAME=$(basename "$0")

if [ $# -ne 1 ]; then
    echo "usage: $SCRIPT_NAME dpr_file_path" >&2
    exit 1
fi

COMPILER_VERSION=20.0

/usr/local/fpc-3.3.1/bin/fpc -d"CompilerVersion:=$COMPILER_VERSION" -I"$BUILD_DIR/DUnitX/Source" -Fo"$OBJ_DIR" -FU"$OBJ_DIR" -FE"$OBJ_DIR" -Fi"$BUILD_DIR/DUnitX/Source" -I"$BUILD_DIR/DUnitX/Source" -Fu"$BUILD_DIR/DUnitX/Source" -Sd $1
