return function(dna)
    return  dna:gsub('%a', { C = 'G', G = 'C', A = 'U', T = 'A' })
end
