#!/bin/bash

VERSION=${1:-latest}

 find . -maxdepth 3 -name gradlew -execdir chmod ugo+x {} \;
 find . -maxdepth 3 -name gradlew -ls -execdir {} wrapper --gradle-version $VERSION  \;
 find . -maxdepth 3 -name gradlew -ls -execdir {} --version \; | grep Gradle -A1 -B3
