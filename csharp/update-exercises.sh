#!/bin/sh

find . \( -name '*.md' -o -name '*.csproj' -o -name '*Tests.cs' -o -name '.editorconfig'  \) -exec sh -c "echo 'Removing {} ...' && rm {}" \; 
find . -maxdepth 1 -type d -exec echo {} \;  | awk '{print "exercism download --exercise=" substr($1,3) " --track=csharp"; }' | bash
