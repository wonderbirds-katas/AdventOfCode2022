local lu = require('luaunit')
local clr = require('CommandLineRunner')
local pai = require('PrintArgumentInterceptor')

TestCommandLineRunner = {}

function TestCommandLineRunner.setUp()
    pai.ReplacePrintByInterceptedPrint()
end

function TestCommandLineRunner.tearDown()
    pai.RestoreOriginalPrint()
end

function TestCommandLineRunner.test_advent_of_code_sample_data()
    local inputFile = 'test/data/advent_of_code_example.txt'

    clr.Run(inputFile)

    local expected = "95437"
    pai.AssertSavedOutputContains(expected)
end

return TestCommandLineRunner
