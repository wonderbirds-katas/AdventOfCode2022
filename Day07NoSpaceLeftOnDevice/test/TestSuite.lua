local lu = require('luaunit')

require('FilterAndSumDirectorySizesTests')
require('FileSystemTests')
require('TerminalOutputParserTests')

os.exit(lu.LuaUnit.run())
