#!/bin/bash

script_name=$(basename "$0")

if [ $# -ne 1 ]; then
    echo "usage: $script_name exercise_name" >&2
    exit 1
fi

exercise_name="$1"

tracks=(8th abap awk ballerina bash c cfml clojure cobol coffeescript
    common-lisp cpp crystal csharp d dart delphi
    elixir elm emacs-lisp erlang
    fortran fsharp gleam go groovy haskell
    java javascript jq julia kotlin lfe lua
    mips nim objective-c ocaml perl5 pharo-smalltalk php plsql
    powershell prolog purescript python r racket raku
    reasonml red ruby rust scala scheme sml swift tcl typescript
    unison vbnet vimscript vlang wasm wren x86-64-assembly zig
)
total_exercises=${#tracks[@]}
completed_exercises=0

progreSh()
           {
    LR='\033[1;31m'
    LG='\033[1;32m'
    LY='\033[1;33m'
    LC='\033[1;36m'
    LW='\033[1;37m'
    NC='\033[0m'
    BLANK='\033[0K'
    if [ "${1}" = "0" ]; then TME=$(date +"%s"); fi
    SEC=$(printf "%04d\n" $(($(date +"%s") - TME)))
    SEC="$SEC sec"
    PRC=$(printf "%.0f" "$1")
    SHW=$(printf "%3d\n" "$PRC")
    LNE=$(printf "%.0f" $((PRC / 2)))
    LRR=$(printf "%.0f" $((PRC / 2 - 12)))
    if [ "$LRR" -le 0 ]; then LRR=0; fi
    LYY=$(printf "%.0f" $((PRC / 2 - 24)))
    if [ "$LYY" -le 0 ]; then LYY=0; fi
    LCC=$(printf "%.0f" $((PRC / 2 - 36)))
    if [ "$LCC" -le 0 ]; then LCC=0; fi
    LGG=$(printf "%.0f" $((PRC / 2 - 48)))
    if [ "$LGG" -le 0 ]; then LGG=0; fi
    MSG=$(printf "Downloading track %s exercise %s ... " "$2" "$3")
    LRR_=""
    LYY_=""
    LCC_=""
    LGG_=""
    for ((i = 1; i <= 13; i++)); do
        DOTS=""
        for ((ii = i; ii < 13; ii++)); do DOTS="${DOTS}."; done

        if [ ${i} -le "$LNE" ]; then LRR_="${LRR_}#"; else LRR_="${LRR_}."; fi
        echo -ne " ${LW}${SEC}  ${LR}${LRR_}${DOTS}${LY}............${LC}............${LG}............ ${SHW}%${NC} ${BLANK}${MSG}\r"
        if [ "$LNE" -ge 1 ]; then sleep .05; fi
    done
    for ((i = 14; i <= 25; i++)); do
        DOTS=""
        for ((ii = i; ii < 25; ii++)); do DOTS="${DOTS}."; done
        if [ ${i} -le "$LNE" ]; then LYY_="${LYY_}#"; else LYY_="${LYY_}."; fi
        echo -ne " ${LW}${SEC}  ${LR}${LRR_}${LY}${LYY_}${DOTS}${LC}............${LG}............ ${SHW}%${NC} ${BLANK}${MSG}\r"
        if [ "$LNE" -ge 14 ]; then sleep .05; fi
    done
    for ((i = 26; i <= 37; i++)); do
        DOTS=""
        for ((ii = i; ii < 37; ii++)); do DOTS="${DOTS}."; done
        if [ ${i} -le "$LNE" ]; then LCC_="${LCC_}#"; else LCC_="${LCC_}."; fi
        echo -ne " ${LW}${SEC}  ${LR}${LRR_}${LY}${LYY_}${LC}${LCC_}${DOTS}${LG}............ ${SHW}%${NC} ${BLANK}${MSG}\r"
        if [ "$LNE" -ge 26 ]; then sleep .05; fi
    done
    for ((i = 38; i <= 49; i++)); do
        DOTS=""
        for ((ii = i; ii < 49; ii++)); do DOTS="${DOTS}."; done
        if [ ${i} -le "$LNE" ]; then LGG_="${LGG_}#"; else LGG_="${LGG_}."; fi
        echo -ne " ${LW}${SEC}  ${LR}${LRR_}${LY}${LYY_}${LC}${LCC_}${LG}${LGG_}${DOTS} ${SHW}%${NC} ${BLANK}${MSG}\r"
        if [ "$LNE" -ge 38 ]; then sleep .05; fi
    done
}

if [ -e get-exercise.log ]; then
    rm get-exercise.log
fi

for track_name in "${tracks[@]}"; do
    completed_exercises=$((completed_exercises + 1))
    progress=$((completed_exercises * 100 / total_exercises))

    progreSh $progress "$track_name" "$exercise_name"
    echo "Getting $track_name/$exercise_name ..." >> get-exercise.log
    exercism download --track="$track_name" --exercise="$exercise_name" --force >> get-exercise.log  2>&1
done

echo ""
echo "Making files readable ...."

git status -s | grep '.M' | cut -c 4- | xargs -I{} chmod ug+w {}

echo ""
echo "All exercises downloaded successfully!"
