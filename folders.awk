#!/usr/bin/awk -f

# Usage:
# ls typescript -ln | ./folders.awk  language="typescript" 

BEGIN {
    if (language == "") {
        print "Usage: awk -f folders.awk -v language=\"language-name\"";
         exit
        }
}

{
    print "{\"name\": \"language:" $NF "\", \"path\": \"language/" $NF "\"},"
}