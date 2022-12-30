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

local function TryParseFileAndAddToDirectory(line, directoryNode)
    local fileSizeAndNamePattern = "(%d+)%s(%a+)"
    local size, filename
    _, _, size, filename = string.find(line, fileSizeAndNamePattern)
    if size ~= nil and filename ~= nil then
        fs.CreateFile(filename, size, directoryNode)
    end
end

function M.Parse(terminalOutput)
    
    lines = SplitLines(terminalOutput)

    local result = fs.CreateDirectory("/", nil)

    local line
    for _, line in ipairs(lines) do
        TryParseFileAndAddToDirectory(line, result)

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
