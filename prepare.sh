#!/bin/sh

clear
find . -name package.json -maxdepth 3  -execdir sh -c "pwd && pnpm install" \;
find . -name gradlew -maxdepth 3  -execdir sh -c "pwd && chmod ugo+x {} && ./{} wrapper --gradle-version latest && ./{} clean" \;
