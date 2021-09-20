#!/bin/sh

 
find . -name node_modules -type d -exec rm -Rf {} \;
find . -name bin -type d -exec rm -Rf {} \;
find . -name obj -type d -exec rm -Rf {} \;
