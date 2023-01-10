local lu = require('luaunit')
local s = require('StringOperations')

TestStringOperations = {}

function TestStringOperations.test_empty_line_with_newline()
    local input = [[
]]

    local lines = s.SplitLines(input)

    lu.assertEquals(#lines, 1)
    lu.assertEquals(lines[1], "")
end

function TestStringOperations.test_last_line_does_not_contain_newline()
    local input = "Hello World"

    local lines = s.SplitLines(input)

    lu.assertEquals(#lines, 1)
    lu.assertEquals(lines[1], "Hello World")
end

return TestStringOperations
