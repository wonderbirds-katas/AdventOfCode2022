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
    originalPrint(...)
end

local function PrintSavedOutput()
    for _, printArgs in ipairs(savedOutput) do
        local printArgsAsString = ""
        for _, printArg in ipairs(printArgs) do
            printArgsAsString = printArgsAsString .. printArg
        end
        print(printArgsAsString)
    end
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

function TestCommandLineRunner.setUp()
    print ("Setting up test")
    print = InterceptedPrint
end

function TestCommandLineRunner.tearDown()
    print = originalPrint
    PrintSavedOutput()
    print ("Tearing down test")
end

function TestCommandLineRunner.test_advent_of_code_sample_data()
    local inputFile = 'data/advent_of_code_example.txt'
    clr.Run(inputFile)

    lu.assertTrue(IsContainedInSavedOutput("Input file: data/advent_of_code_example.txt"))
end

return TestCommandLineRunner
