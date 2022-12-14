local M = {}

function M.print(listOfLines)
    for _, line in ipairs(listOfLines) do
        print (line)
    end
end

function M.SplitLines(text)
    local lengthOfText = string.len(text)
    local endOfLine = 0
    local result = {}

    repeat
        local startOfLine = endOfLine + 1
        
        endOfLine = string.find(text, "\n", startOfLine)
        if endOfLine == nil then
            endOfLine = lengthOfText + 1
        end

        local line = string.sub(text, startOfLine, endOfLine - 1)
        table.insert(result, line)
    until endOfLine > lengthOfText

    return result
end

return M
