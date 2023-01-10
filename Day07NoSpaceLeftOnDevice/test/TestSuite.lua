local lu = require('luaunit')

require('FilterAndSumDirectorySizesTests')
require('FileSystemTests')
require('StringOperationsTests')
require('TerminalOutputParserTests')
require('MapFilterReduceTests')
require('CommandLineRunnerTests')

os.exit(lu.LuaUnit.run())
