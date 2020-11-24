local house = {}

local thisIsThe = "This is the %s"
local that = "that %s the %s"

local parts = {
    { "horse and the hound and the horn" },
    { "farmer sowing his corn", "belonged to" },
    { "rooster that crowed in the morn", "kept" },
    { "priest all shaven and shorn", "woke" },
    { "man all tattered and torn", "married" },
    { "maiden all forlorn", "kissed" },
    { "cow with the crumpled horn", "milked" },
    { "dog", "tossed" },
    { "cat", "worried" },
    { "rat", "killed" },
    { "malt", "ate"  },
    { "house that Jack built.", "lay in" }
}

local function generate (n)
    assert(n <= #parts, "Invalid number of stanzas")

    local stanzas = {}
    if n == #parts then
        table.move(parts, 1, #parts, 1, stanzas)
    else
        table.move(parts, #parts - n + 1, #parts, 1, stanzas)
    end

    local last = #stanzas

    return coroutine.wrap(function()
        for index, value in pairs(stanzas) do
            local result

            if index == 1 then
                result  = string.format(thisIsThe, value[1])
            elseif index == last then
                result = string.format(that, value[2], value[1])
            else
                result = string.format(that, value[2], value[1])
            end

            coroutine.yield(result)
        end
    end)
end

house.verse = function(which)
    local result = {}

    for stanza in generate(which) do
        table.insert(result, stanza)
    end

    return table.concat(result, '\n')
end

house.recite = function()
    local result = {}

    for verses= 1, #parts do
        local stanza = house.verse(verses)
        table.insert(result, stanza)
    end

    return table.concat(result, '\n')
end

return house
