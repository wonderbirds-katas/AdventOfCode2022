local lu = require('luaunit')

require('FilterAndSumDirectorySizesTests')
require('FileSystemTests')
require('TerminalOutputParserTests')
require('MapFilterReduceTests')

os.exit(lu.LuaUnit.run())
