#!/bin/sh

clear

YARNRC=`realpath .yarnrc.yml`
YARN_RELEASE=`realpath .yarn`

#yarn set version classic

echo "Removing old yarnrc configuration..."
find typescript -maxdepth 2 -mindepth 2 -type d -name .yarn -execdir sh -c "rm -rv {}" \;

echo "Copying current .yarnrc.yml..."
find typescript -maxdepth 2 -mindepth 2 -name package.json -execdir sh -c "pwd && cp $YARNRC ." \;

echo "Copying local .yarn installation..."
find typescript -maxdepth 2 -mindepth 2 -name package.json -execdir sh -c "pwd && cp -r $YARN_RELEASE ." \;
