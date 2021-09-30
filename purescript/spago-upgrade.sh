#/bin/sh

find . -type d -maxdepth 1 -not -path ./output -not -path . -exec sh -c "cd {} && pwd && spago upgrade-set && cd .." \;

