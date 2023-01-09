-- This module redirects the Lua print command to an internal memory buffer
--
-- The module is intended for unit tests which want to assert that specific
-- messages have been printed using the print command.
--
-- Usage:
--
-- 1. From the tearDown() method call RestoreOriginalPrint()
-- 2. From the setUp() method of your unit test suite call ReplacePrintByInterceptedPrint()
-- 3. Create the unit test executing code that uses the print command
-- 4. Verify your expectations using AssertSavedOutputContains(expected)
--
-- Helpers for Debugging
--
-- - PrintSavedOutput() - print saved output bypassing the capture mechanism and using the original print command
--
local M = {}

local savedOutput = {}
local function SaveOutput(...)
    table.insert(savedOutput, {...})
end

local originalPrint = print
local function InterceptedPrint(...)
    SaveOutput(...)
    -- Uncomment the following line if you want to see the output for debugging
    -- originalPrint(...)
end

function M.RestoreOriginalPrint()
    print = originalPrint
end

function M.ReplacePrintByInterceptedPrint()
    print = InterceptedPrint
end

local function ConvertSavedOutputToString()
    local result = ""
    for _, printArgs in ipairs(savedOutput) do
        local printArgsAsString = ""
        for _, printArg in ipairs(printArgs) do
            printArgsAsString = printArgsAsString .. printArg
        end
        result = result .. printArgsAsString .. "\n"
    end
    return result
end

function M.PrintSavedOutput()
    msg = ConvertSavedOutputToString()
    originalPrint(msg)
end

local function IsContainedInSavedOutput(expected)
    for _, printArgs in ipairs(savedOutput) do
        local printArgsAsString = ""
        for _, printArg in ipairs(printArgs) do
            if expected == printArg then
                return true
            end
        end
    end
    return false
end

function M.AssertSavedOutputContains(expected)
    local savedOutputAsString = ConvertSavedOutputToString()
    local msg = string.format("expected captured output to contain: '%s'\nThe following output has been captured: '%s'",
        expected, savedOutputAsString)

    assert(IsContainedInSavedOutput(expected), msg)
end

return M
