---Checks if a table is used as an array. That is: the keys start with one and are sequential numbers
-- @param t table
-- @return nil,error string if t is not a table
-- @return true/false if t is an array/isn't an array
-- NOTE: it returns true for an empty table
local function isArray(t)
  if type(t)~="table" then return nil,"Argument is not a table! It is: "..type(t) end
  --check if all the table keys are numerical and count their number
  local count=0
  for k,_ in pairs(t) do
      if type(k)~="number" then return false else count=count+1 end
  end
  --all keys are numerical. now let's see if they are sequential and start with 1
  for i=1,count do
      --Hint: the VALUE might be "nil", in that case "not t[i]" isn't enough, that's why we check the type
      if not t[i] and type(t[i])~="nil" then return false end
  end
  return true
end

local function switch(n, ...)
  for _,v in ipairs {...} do
    if v[1] == nil then
      return v[2]()
    end

    if isArray(v[1]) then
      for index = 1, #v[1] do
        if v[1][index]  == n then
          return v[2]()
        end
      end
    elseif v[1] == n then
      return v[2]()
    end
  end
end

local function case(n,f)
  return {n,f}
end

local function default(f)
  return {nil,f}
end

local function translate_codon(codon)
  assert(#codon == 3, "Codon must have exactly three nucleotides.")

  local result = ""

  switch( codon,
    case( "AUG", function() result = "Methionine" end),
    case( {"UUU", "UUC"}, function() result = "Phenylalanine" end),
    case( {"UUA", "UUG"}, function() result = "Leucine" end),
    case( {"UCU", "UCC", "UCA", "UCG"}, function() result = "Serine" end),
    case( {"UAU", "UAC"}, function() result = "Tyrosine" end),
    case( {"UGU", "UGC"}, function() result = "Cysteine" end),
    case( "UGG", function() result = "Tryptophan" end),
    case( {"UAA", "UAG", "UGA"}, function() result = "STOP" end),
    default( function() error("Invalid codon.") end)
  )
  return result
end

local function translate_rna_strand(rna_strand)
  assert(#rna_strand  % 3 == 0, "Codon must have multiple of three nucleotides.")

  local result = {}

  for index = 1, #rna_strand, 3 do
      local codon = rna_strand:sub(index, index + 2)
      local protein = translate_codon(codon)

      if protein == "STOP" then break end

      table.insert(result, protein)
  end

  return result
end

return {
  codon = translate_codon,
  rna_strand = translate_rna_strand
}
