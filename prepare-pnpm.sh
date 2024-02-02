#!/bin/sh

clear

echo "package-import-method=clone-or-copy" > ~/.npmrc

echo "Installing packages with pnpm..."
find . -maxdepth 3 -name package.json -execdir sh -c "pnpm install" \;

echo "Removing duplicate babel.config files..."
find javascript -maxdepth 2 -name babel.config.js -ls -execdir sh -c "mv babel.config.js babel.config.cjs" \;
find typescript -maxdepth 2 -name babel.config.js -ls -execdir sh -c "mv babel.config.js babel.config.cjs" \;

echo "Removing duplicate jest.config files..."
find javascript -maxdepth 2 -name jest.config.js -ls -execdir sh -c "mv jest.config.js jest.config.cjs" \;
find typescript -maxdepth 2 -name jest.config.js -ls -execdir sh -c "mv jest.config.js jest.config.cjs" \;
