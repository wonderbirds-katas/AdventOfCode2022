local lu = require('luaunit')
local clr = require('CommandLineRunner')

TestCommandLineRunner = {}

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

local function PrintSavedOutput()
    msg = ConvertSavedOutputToString()
    print(msg)
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

local function AssertSavedOutputContains(expected)
    local savedOutputAsString = ConvertSavedOutputToString()
    local msg = string.format("expected captured output to contain: %s\nThe following output has been captured: %s",
        expected, savedOutputAsString)

    assert(IsContainedInSavedOutput(expected), msg)
end

function TestCommandLineRunner.setUp()
    print = InterceptedPrint
end

function TestCommandLineRunner.tearDown()
    print = originalPrint
    PrintSavedOutput()
end

function TestCommandLineRunner.test_advent_of_code_sample_data()
    local inputFile = 'data/advent_of_code_example.txt'
    clr.Run(inputFile)

    local expected = 95437
    AssertSavedOutputContains("" .. expected)
    lu.assertTrue(IsContainedInSavedOutput("" .. expected))
end

return TestCommandLineRunner
