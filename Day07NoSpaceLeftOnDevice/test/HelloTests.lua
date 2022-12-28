lu = require('luaunit')
hello = require('Hello')

function TestHello()
    lu.assertEquals(hello.HelloWorld(), "Hello, world!")
end

os.exit(lu.LuaUnit.run())
