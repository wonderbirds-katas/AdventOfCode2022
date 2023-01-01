local lu = require('luaunit')

require('FilterAndSumDirectorySizesTests')
require('FileSystemTests')
require('TerminalOutputParserTests')
require('MapFilterReduceTests')
require('CommandLineRunnerTests')

os.exit(lu.LuaUnit.run())
