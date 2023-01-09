local f = require('FilterAndSumDirectorySizes')
local stringOps = require('StringOperations')

local M = {}

local function ReadFile(path)
    local file = io.open(path, "r")
    fileContents = file:read("a")
    file:close()

    return stringOps.SplitLines(fileContents)
end

function M.Run(inputFileName)
    local inputFileLines = ReadFile(inputFileName)
    local result = f.FilterAndSumDirectorySizes(inputFileLines)
    print("" .. result)
end

return M
