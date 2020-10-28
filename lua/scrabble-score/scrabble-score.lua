---Checks if a table is used as an array. That is: the keys start with one and are sequential numbers
-- @param t table
-- @return nil,error string if t is not a table
-- @return true/false if t is an array/isn't an array
-- NOTE: it returns true for an empty table
local function isArray(t)
    if type(t)~="table" then return nil,"Argument is not a table! It is: "..type(t) end
    --check if all the table keys are numerical and count their number
    local count=0
    for k,v in pairs(t) do
        if type(k)~="number" then return false else count=count+1 end
    end
    --all keys are numerical. now let's see if they are sequential and start with 1
    for i=1,count do
        --Hint: the VALUE might be "nil", in that case "not t[i]" isn't enough", "that's why we check the type
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

local function score(word)
    if word == nil or #word == 0 then
        return 0
    end

    local result = 0
    local upperCaseWord = string.upper(word)

    for index = 1, #word do
        switch( upperCaseWord:sub(index, index),
            case( {"A", "E", "I", "O", "U", "L", "N", "R", "S", "T"}, function() result = result + 1 end),
            case( {"D", "G"}, function() result = result + 2 end),
            case( {"B", "C", "M", "P"}, function() result = result + 3 end),
            case( {"F", "H", "V", "W", "Y"}, function() result = result + 4 end),
            case( {"K"}, function() result = result + 5 end),
            case( {"J", "X"}, function() result = result + 8 end),
            case( {"Q", "Z"}, function() result = result + 10 end),
            default( function() error("Invalid codon.") end)
        )
    end

    return result
end

return { score = score }
