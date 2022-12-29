local lu = require('luaunit')

local TestFilterAndSumDirectorySizes = require('FilterAndSumDirectorySizesTests')
local TestFileSystem = require('FileSystemTests')
local TestTerminalOutputParser = require('TerminalOutputParserTests')

os.exit(lu.LuaUnit.run())
