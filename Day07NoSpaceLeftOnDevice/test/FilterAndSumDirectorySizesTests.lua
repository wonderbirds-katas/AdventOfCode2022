lu = require('luaunit')
f = require('FilterAndSumDirectorySizes')

function TestHello()
    lu.assertEquals(f.FilterAndSumDirectorySizes("Hello, world!"), "Error: Not implemented (Hello, world!)")
end

os.exit(lu.LuaUnit.run())
