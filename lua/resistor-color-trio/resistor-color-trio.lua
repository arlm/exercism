local resistorColors = {
  black   = 0,
  brown   = 1,
  red     = 2,
  orange  = 3,
  yellow  = 4,
  green   = 5,
  blue    = 6,
  violet  = 7,
  grey    = 8,
  white   = 9,
}

local schiNotation = {
  [0]   = "",
  [3]   = "kilo",
  [6]   = "kilo",
  [9]  = "kilo",
  [12]  = "kilo",
  [15]  = "kilo",
}

local function scientificNumber(number)
  local sciExp =  math.log10(number) // 3 * 3
  local value =  number / 10 ^ sciExp
  local unit =  schiNotation[sciExp] .. "ohms"

  return value, unit
end

return {
  decode = function(c1, c2, c3)
    local value1=resistorColors[c1:lower()]
    local value2=resistorColors[c2:lower()]
    local value3=resistorColors[c3:lower()]

    local number =  (value1 * 10 + value2) *  10 ^ value3
    local value, unit = scientificNumber(number)

    return value, unit
  end
}
