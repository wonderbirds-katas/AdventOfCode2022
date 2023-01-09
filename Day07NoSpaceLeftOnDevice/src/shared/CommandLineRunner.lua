local f = require('FilterAndSumDirectorySizes')
local stringOps = require('StringOperations')

local M = {}

local function ReadFile(path)
    local file = io.open(path, "r")
    fileContents = file:read("a")
    file:close()

    return fileContents
end

function M.Run(inputFileName)
    local fileContents = ReadFile(inputFileName)
    local inputFileLines = stringOps.SplitLines(fileContents)

    local result = f.FilterAndSumDirectorySizes(inputFileLines)
    print("" .. result)
end

return M
