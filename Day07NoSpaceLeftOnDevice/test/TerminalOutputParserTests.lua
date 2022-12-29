local lu = require('luaunit')
local parser = require('TerminalOutputParser')
local fs = require('FileSystem')

TestTerminalOutputParser = {}

function TestTerminalOutputParser.test_root_directory_contains_1_file()
    local root = parser.Parse(terminalOutput)
    actual = fs.ToString(root)
    lu.assertEquals(actual,
[[/ (dir)
+-- a (file, size=1)
]])
end

return TestTerminalOutputParser
