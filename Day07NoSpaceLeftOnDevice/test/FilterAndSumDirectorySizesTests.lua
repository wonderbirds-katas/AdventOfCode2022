local lu = require('luaunit')
local f = require('FilterAndSumDirectorySizes')

function cd_root_and_ls_returns(output)
    return
[[$ cd /
$ ls
]] .. output .. [[
]]
end

function test_root_directory_contains_1_file__with_size___1()
    local input = cd_root_and_ls_returns("1 some_file")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 1)
end

function test_root_directory_contains_1_file__with_size___2()
    local input = cd_root_and_ls_returns("2 some_file")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 2)
end

function test_root_directory_contains_1_file__with_size_100()
    local input = cd_root_and_ls_returns("100 some_file")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 100)
end

function test_root_directory_contains_2_files_with_size_1_each()
    local input = cd_root_and_ls_returns("1 file_a\n1 file_b")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 2)
end

function test_root_directory_contains_2_files_with_size_2_each()
    local input = cd_root_and_ls_returns("2 file_a\n2 file_b")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 4)
end

function test_root_directory_contains_4_files_with_different_sizes()
    local input = cd_root_and_ls_returns("200 file_a\n1000 file_b\n10000 file_c\n8800 file_d")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 20000)
end

os.exit(lu.LuaUnit.run())
