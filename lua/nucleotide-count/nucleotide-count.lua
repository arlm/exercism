local DNA = {}

DNA.__index = DNA

local function countNucleotides(strand)
    local result = {
        A = 0,
        T = 0,
        C = 0,
        G = 0
    }

    local uppercaseStrand = string.upper(strand)

    for index = 1, #strand do
        local char = uppercaseStrand:sub(index,index)
        result[char] = result[char] + 1
    end

    return result
end

function DNA:new(strand)
    local valid = string.match(strand, '[ATCGatcg]*')

    if not valid or #valid ~= #strand then
        error("Invalid nucleotide on strand: " .. strand)
    end

    local object = setmetatable({}, self)

    object.strand = strand
    object.nucleotideCounts = countNucleotides(strand)
    return object
end

function DNA:count(nucleotide)
    local value = self.nucleotideCounts[nucleotide]

    if value == nil then
        error("Invalid Nucleotide")
    end

    return value
end

return DNA