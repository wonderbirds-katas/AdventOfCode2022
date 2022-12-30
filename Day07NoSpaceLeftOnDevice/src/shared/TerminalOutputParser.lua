local fs = require('FileSystem')

local M = {}

local function SplitLines(text)
    local lengthOfText = string.len(text)
    local endOfLine = -1
    local result = {}

    repeat
        local startOfLine = endOfLine + 1
        
        endOfLine = string.find(text, "\n", startOfLine)
        if endOfLine == nil then
            endOfLine = lengthOfText
        end

        local line = string.sub(text, startOfLine, endOfLine - 1)
        table.insert(result, line)
    until endOfLine == lengthOfText

    return result
end

function M.Parse(terminalOutput)

    local fileSizeAndNamePattern = "(%d+)%s(%a+)"
    
    lines = SplitLines(terminalOutput)

    local result = fs.CreateDirectory("/", nil)

    local line
    for _, line in ipairs(lines) do
        local size, filename
        _, _, size, filename = string.find(line, fileSizeAndNamePattern)
        if size ~= nil and filename ~= nil then
            fs.CreateFile(filename, size, result)
        end

        local dirAndNamePattern = "dir%s(%a+)"
        local dirname
        _, _, dirname = string.find(line, dirAndNamePattern)
        if dirname ~= nil then
            fs.CreateDirectory(dirname, result)
        end
    end

    return result
end

return M
