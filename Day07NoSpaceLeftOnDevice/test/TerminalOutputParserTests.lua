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

function TestTerminalOutputParser.test_root_directory_contains_1_file_with_underscore()
    local terminalOutput = [[$ cd /
$ ls
1 name_contains_underscore
]]

    local root = parser.Parse(terminalOutput)
    local actual = fs.ToString(root)

    lu.assertEquals(actual,
[[/ (dir)
+-- name_contains_underscore (file, size=1)
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

function TestTerminalOutputParser.test_root_directory_contains_subdirectory()
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

function TestTerminalOutputParser.test_root_directory_contains_subdirectory_with_underscore()
    local terminalOutput = [[$ cd /
$ ls
dir name_with_underscore
]]

    local root = parser.Parse(terminalOutput)
    local actual = fs.ToString(root)

    lu.assertEquals(actual,
[[/ (dir)
+-- name_with_underscore (dir)
]])
end

function TestTerminalOutputParser.test_root_directory_contains_subdirectory_with_file()
    local terminalOutput = [[$ cd /
$ ls
dir a
$ cd a
$ ls
99 b
]]

    local root = parser.Parse(terminalOutput)
    local actual = fs.ToString(root)

    lu.assertEquals(actual,
[[/ (dir)
+-- a (dir)
    +-- b (file, size=99)
]])
end

function TestTerminalOutputParser.test_root_directory_contains_two_subdirectories_with_file_in_each()
    local terminalOutput = [[$ cd /
$ ls
dir a
dir c
$ cd a
$ ls
99 b
$ cd ..
$ cd c
$ ls
98 d
]]

    local root = parser.Parse(terminalOutput)
    local actual = fs.ToString(root)

    lu.assertEquals(actual,
[[/ (dir)
+-- a (dir)
    +-- b (file, size=99)
+-- c (dir)
    +-- d (file, size=98)
]])
end

function TestTerminalOutputParser.test_comprehensive_representative_command_list()
    local terminalOutput = [[$ cd /
$ ls
dir a
dir l
dir m
$ cd a
$ ls
dir b
dir e
dir i
500 j
0 k
$ cd b
$ ls
100 c
200 d
$ cd ..
$ cd e
$ ls
dir f
300 g
400 h
$ cd f
$ ls
$ cd ..
$ cd ..
$ cd i
$ ls
$ cd ..
$ cd ..
$ cd l
$ ls
$ cd ..
$ cd m
$ ls
]]

    local root = parser.Parse(terminalOutput)
    local actual = fs.ToString(root)

    lu.assertEquals(actual,
[[/ (dir)
+-- a (dir)
    +-- b (dir)
        +-- c (file, size=100)
        +-- d (file, size=200)
    +-- e (dir)
        +-- f (dir)
        +-- g (file, size=300)
        +-- h (file, size=400)
    +-- i (dir)
    +-- j (file, size=500)
    +-- k (file, size=0)
+-- l (dir)
+-- m (dir)
]])
end

return TestTerminalOutputParser
