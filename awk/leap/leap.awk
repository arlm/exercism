BEGIN {
    getline year < "-"

    if ((year % 100 == 0) ? (year % 400 == 0) : (year % 4 == 0))
        print "true";
    else
        print "false";
    fi
}
