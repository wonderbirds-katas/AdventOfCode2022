local lu = require('luaunit')
local parser = require('TerminalOutputParser')
local fs = require('FileSystem')

TestTerminalOutputParser = {}

function TestTerminalOutputParser.test_root_directory_contains_1_file()
    local terminalOutput = [[$ cd /
$ ls
1 a
]]

    local root = parser.Parse(terminalOutput)
    local actual = fs.ToString(root)

    lu.assertEquals(actual,
[[/ (dir)
+-- a (file, size=1)
]])
end

function TestTerminalOutputParser.test_root_directory_contains_2_files()
    local terminalOutput = [[$ cd /
$ ls
1 a
42 b
]]

    local root = parser.Parse(terminalOutput)
    local actual = fs.ToString(root)

    lu.assertEquals(actual,
[[/ (dir)
+-- a (file, size=1)
+-- b (file, size=42)
]])
end

function TestTerminalOutputParser.test_root_directory_contains_a_subdirectory()
    local terminalOutput = [[$ cd /
$ ls
dir a
]]

    local root = parser.Parse(terminalOutput)
    local actual = fs.ToString(root)

    lu.assertEquals(actual,
[[/ (dir)
+-- a (dir)
]])
end

return TestTerminalOutputParser
