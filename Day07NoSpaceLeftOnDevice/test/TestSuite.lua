local lu = require('luaunit')

require('FileSystemTests')
require('StringOperationsTests')
require('TerminalOutputParserTests')
require('TemplateTests')
require('MapFilterReduceTests')
require('CommandLineRunnerTests')

os.exit(lu.LuaUnit.run())
