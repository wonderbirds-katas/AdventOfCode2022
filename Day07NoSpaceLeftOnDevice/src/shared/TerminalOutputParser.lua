local fs = require('FileSystem')

local M = {}

function M.Parse(terminalOutput)
    local result = fs.CreateDirectory("/", nil)
    fs.CreateFile("a", 1, result)
    return result
end

return M
