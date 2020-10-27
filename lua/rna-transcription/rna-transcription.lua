return function(dna)
    local result = dna:gsub("A", "U")
    result = result:gsub("T", "A")
    result = result:gsub("G", "X")
    result = result:gsub("C", "G")
    result = result:gsub("X", "C")

    return result
end
