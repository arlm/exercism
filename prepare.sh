#!/bin/sh

clear
find . -name package.json -maxdepth 3  -execdir sh -c "pwd && pnpm install" \;
