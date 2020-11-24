local DNA = {}

DNA.__index = DNA

local function countNucleotides(strand)
    local result = {
        A = 0,
        T = 0,
        C = 0,
        G = 0
    }

    for char in string.gmatch(string.upper(strand), ".") do
        result[char] = result[char] + 1
    end

    return result
end

function DNA:new(strand)
    local valid = string.match(strand, '[ATCGatcg]*')
    assert(valid and #valid == #strand, "Invalid nucleotide on strand: " .. strand)

    local object = setmetatable({}, self)

    object.strand = strand
    object.nucleotideCounts = countNucleotides(strand)
    return object
end

function DNA:count(nucleotide)
    local value = self.nucleotideCounts[nucleotide]
    assert(value, "Invalid Nucleotide")

    return value
end

return DNA