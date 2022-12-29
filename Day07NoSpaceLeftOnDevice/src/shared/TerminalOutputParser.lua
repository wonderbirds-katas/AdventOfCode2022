local fs = require('FileSystem')

local M = {}

function M.Parse(terminalOutput)

    local result = fs.CreateDirectory("/", nil)

    local filePattern = "(%d+%s%a+)"
    local line
    local endIndex = -1

    repeat
        local size, filename
        _, endIndex, line = string.find(terminalOutput, filePattern, endIndex + 1)

        if line ~= nil then
            _, _, size, filename = string.find(line, "(%d+)%s(%a+)", 0)
            fs.CreateFile(filename, size, result)
        end
    until line == nil

    return result
end

return M
