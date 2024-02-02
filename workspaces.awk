#!/usr/bin/awk -f

# Usage:
# ls typescript -ln | ./workspaces.awk

BEGIN {
  printf "\"workspaces\": [\n"
}

{
  printf "  \"%s\",\n", $NF
}

END {
  printf "]\n"
}
