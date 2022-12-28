local lu = require('luaunit')
local f = require('FilterAndSumDirectorySizes')

function cd_root_and_ls_returns(output)
    return
[[$ cd /
$ ls
]] .. output .. [[
]]
end

function test_root_directory_contains_single_file_with_size___1()
    local input = cd_root_and_ls_returns("1 some_file")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 1)
end

function test_root_directory_contains_single_file_with_size___2()
    local input = cd_root_and_ls_returns("2 some_file")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 2)
end

function test_root_directory_contains_single_file_with_size_100()
    local input = cd_root_and_ls_returns("100 some_file")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 100)
end

os.exit(lu.LuaUnit.run())
