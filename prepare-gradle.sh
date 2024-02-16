#!/bin/sh

clear
find . -maxdepth 3 -name gradlew -execdir sh -c "pwd && chmod ugo+x {} && ./{} wrapper --gradle-version latest && ./{} clean" \;
