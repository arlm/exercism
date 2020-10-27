local DNA = {}

DNA.__index = DNA

local function count(strand, nucleotide)
    local valid = string.match(nucleotide, '[ATCGatcg]')

    if not valid then
        error("Invalid Nucleotide")
    end

    local result = 0
    local uppercaseStrand = string.upper(strand)
    local uppercaseNucleotide = string.upper(nucleotide)

    for index = 1, #strand do
        if uppercaseStrand:sub(index,index) == uppercaseNucleotide then
            result = result + 1
        end
    end

    return result
end

function DNA:new(strand)
    local valid = string.match(strand, '[ATCGatcg]*')

    if not valid or #valid ~= #strand then
        error("Invalid nucleotide on strand: " .. strand)
    end

    self.strand = strand
    self.nucleotideCounts = {
            A = count(strand, 'A'),
            T = count(strand, 'T'),
            C = count(strand, 'C'),
            G = count(strand, 'G')
        }
    return self
end

function DNA:count(nucleotide)
    return count(self.strand, nucleotide)
end

return DNA