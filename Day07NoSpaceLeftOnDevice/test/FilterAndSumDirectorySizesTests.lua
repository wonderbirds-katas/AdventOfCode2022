local lu = require('luaunit')
local f = require('FilterAndSumDirectorySizes')

function cd_root_and_ls_returns(output)
    return
[[$ cd /
$ ls
]] .. output .. [[
]]
end

function test_root_directory_contains_1_file__of_size______1()
    local input = cd_root_and_ls_returns("1 some_file")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 1)
end

function test_root_directory_contains_1_file__of_size______2()
    local input = cd_root_and_ls_returns("2 some_file")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 2)
end

function test_root_directory_contains_1_file__of_size____100()
    local input = cd_root_and_ls_returns("100 some_file")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 100)
end

function test_root_directory_contains_2_files_of_size_1_each()
    local input = cd_root_and_ls_returns("1 file_a\n1 file_b")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 2)
end

function test_root_directory_contains_2_files_of_size_2_each()
    local input = cd_root_and_ls_returns("2 file_a\n2 file_b")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 4)
end

function test_root_directory_contains_4_files_with_different_sizes()
    local input = cd_root_and_ls_returns("200 file_a\n1000 file_b\n10000 file_c\n8800 file_d")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 20000)
end

function test_root_directory_contains_1_folder__with_1_file_of_size_42()
    local input =
[[$ cd /
$ ls
dir some_dir
$ cd some_dir
$ ls
42 some_file
]]
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 42)
end

function test_root_directory_contains_2_folders_with_1_file_in_each_having_different_sizes()
    local input =
[[$ cd /
$ ls
dir folder_a
dir folder_b
dir folder_c
$ cd folder_a
$ ls
13 file_a
$ cd ..
$ cd folder_b
$ ls
23 file_b
$ cd ..
$ cd folder_c
$ ls
29 file_c
]]
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 13+23+29)
end

function test_root_directory_contains_1_file__of_size_100001()
    local input = cd_root_and_ls_returns("100001 file_a")
    local actual = f.FilterAndSumDirectorySizes(input)
    lu.assertEquals(actual, 0)
end

os.exit(lu.LuaUnit.run())
