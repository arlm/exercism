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

house.verse = function(which)
    assert(which <= #parts, "Invalid number of stanzas")

    local first = #parts - which + 1
    local last = #parts

    if which == #parts then
        first = 1
        last = #parts
    end

    local result  = {}

    for index = first, last do
        local stanza

        if index == first then
            stanza  = string.format(thisIsThe, parts[index][1])
        else
            stanza = string.format(that, parts[index][2], parts[index][1])
        end

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
