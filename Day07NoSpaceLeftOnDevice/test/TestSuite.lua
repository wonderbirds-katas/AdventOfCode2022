local lu = require('luaunit')

local TestFilterAndSumDirectorySizes = require('FilterAndSumDirectorySizesTests')
local TestFileSystem = require('FileSystemTests')

os.exit(lu.LuaUnit.run())
