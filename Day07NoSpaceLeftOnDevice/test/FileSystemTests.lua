local lu = require('luaunit')
local fs = require('FileSystem')

TestFileSystem = {}

function TestFileSystem.test_create_root_directory()
    local root = fs.CreateDirectory("/", nil)
    local actual = fs.ToString(root)
    lu.assertEquals(actual,
[[/ (dir)
]])
end

function TestFileSystem.test_create_sub_directories()
    local root = fs.CreateDirectory("/", nil)
    fs.CreateDirectory("a", root)
    fs.CreateDirectory("b", root)

    local actual = fs.ToString(root)
    
    lu.assertEquals(actual, 
[[/ (dir)
+-- a (dir)
+-- b (dir)
]])
end

function TestFileSystem.test_create_nested_sub_directories()
    local root = fs.CreateDirectory("/", nil)
    local a = fs.CreateDirectory("a", root)
    fs.CreateDirectory("c", a)
    fs.CreateDirectory("b", root)

    local actual = fs.ToString(root)
    
    lu.assertEquals(actual,
[[/ (dir)
+-- a (dir)
    +-- c (dir)
+-- b (dir)
]])
end

function TestFileSystem.test_create_file_of_size_1()
    local root = fs.CreateDirectory("/", nil)
    fs.CreateFile("a", 1, root)

    local actual = fs.ToString(root)
    
    lu.assertEquals(actual,
[[/ (dir)
+-- a (file, size=1)
]])
end

function TestFileSystem.test_create_file_of_size_42()
    local root = fs.CreateDirectory("/", nil)
    fs.CreateFile("a", 42, root)

    local actual = fs.ToString(root)
    
    lu.assertEquals(actual,
[[/ (dir)
+-- a (file, size=42)
]])
end

function TestFileSystem.test_calculate_total_directory_sizes_1_file()
    local root = fs.CreateDirectory("/", nil)
    fs.CreateFile("a", 42, root)

    fs.CalculateTotalDirectorySizes(root)
    local actual = root.totalSize
    
    lu.assertEquals(actual, 42)
end

function TestFileSystem.test_calculate_total_directory_sizes_2_files()
    local root = fs.CreateDirectory("/", nil)
    fs.CreateFile("a", 42, root)
    fs.CreateFile("b", 100, root)

    fs.CalculateTotalDirectorySizes(root)
    local actual = root.totalSize
    
    lu.assertEquals(actual, 142)
end

function TestFileSystem.test_calculate_total_directory_sizes_2_files_and_directory()
    local root = fs.CreateDirectory("/", nil)
    fs.CreateDirectory("a", root)
    fs.CreateFile("b", 42, root)
    fs.CreateFile("c", 100, root)

    fs.CalculateTotalDirectorySizes(root)
    local actual = root.totalSize
    
    lu.assertEquals(actual, 142)
end

return TestFileSystem
