local lu = require('luaunit')
local fs = require('FileSystem')

TestFileSystem = {}

function TestFileSystem.test_create_root_directory()
    root = fs.CreateDirectory("/", nil)
    actual = fs.ToString(root)
    lu.assertEquals(actual,
[[/ (dir)
]])
end

function TestFileSystem.test_create_sub_directories()
    root = fs.CreateDirectory("/", nil)
    fs.CreateDirectory("a", root)
    fs.CreateDirectory("b", root)

    actual = fs.ToString(root)
    
    lu.assertEquals(actual, 
[[/ (dir)
+-- a (dir)
+-- b (dir)
]])
end

function TestFileSystem.test_create_nested_sub_directories()
    root = fs.CreateDirectory("/", nil)
    a = fs.CreateDirectory("a", root)
    fs.CreateDirectory("c", a)
    fs.CreateDirectory("b", root)

    actual = fs.ToString(root)
    
    lu.assertEquals(actual,
[[/ (dir)
+-- a (dir)
    +-- c (dir)
+-- b (dir)
]])
end

function TestFileSystem.test_create_file_of_size_1()
    root = fs.CreateDirectory("/", nil)
    fs.CreateFile("a", 1, root)

    actual = fs.ToString(root)
    
    lu.assertEquals(actual,
[[/ (dir)
+-- a (file, size=1)
]])
end

return TestFileSystem
