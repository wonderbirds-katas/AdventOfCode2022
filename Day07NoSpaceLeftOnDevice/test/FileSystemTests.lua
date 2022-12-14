local lu = require('luaunit')
local fs = require('FileSystem')
local mfr = require('MapFilterReduce')

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

function TestFileSystem.test_calculate_total_directory_size_considering_single_subdirectory()
    local root = fs.CreateDirectory("/", nil)
    local a = fs.CreateDirectory("a", root)
    fs.CreateFile("b", 42, a)

    fs.CalculateTotalDirectorySizes(root)
    local actual = root.totalSize
    
    lu.assertEquals(actual, 42)
end

function TestFileSystem.test_calculate_total_directory_size_considering_nested_subdirectories()
    local root = fs.CreateDirectory("/", nil)
    local a = fs.CreateDirectory("a", root)
    fs.CreateFile("c", 100, a)
    local b = fs.CreateDirectory("b", a)
    fs.CreateFile("d", 200, b)

    fs.CalculateTotalDirectorySizes(root)
    local actual = root.totalSize
    
    lu.assertEquals(actual, 300)
end

function TestFileSystem.test_ToList_when_directory_nil()
    local root = nil
    local actual = fs.ToList(root)
    local expected = {}
    lu.assertEquals(actual, expected)
end

function TestFileSystem.test_ToList_when_directory_empty()
    local root = fs.CreateDirectory("/")
    local actual = fs.ToList(root)
    local expected = { root }
    lu.assertEquals(actual, expected)
end

function TestFileSystem.test_ToList_when_directory_contains_single_entry()
    local root = fs.CreateDirectory("/")
    file = fs.CreateFile("file", 1, root)

    local actual = fs.ToList(root)
    
    local expected = { root, file }
    lu.assertEquals(actual, expected)
end

function TestFileSystem.test_ToList_when_directory_contains_multiple_entries_on_single_level()
    local root = fs.CreateDirectory("/")
    file1 = fs.CreateFile("file1", 1, root)
    file2 = fs.CreateFile("file2", 1, root)
    file3 = fs.CreateFile("file3", 1, root)

    local actual = fs.ToList(root)
    
    local expected = { root, file1, file2, file3 }
    lu.assertEquals(actual, expected)
end

function TestFileSystem.test_ToList_when_directory_contains_nested_directories()
    local root = fs.CreateDirectory("/")
    dir1 = fs.CreateDirectory("dir1", root)
    dir1_file1 = fs.CreateFile("dir1_file1", 1, dir1)
    root_file1 = fs.CreateFile("root_file1", 1, root)
    root_file2 = fs.CreateFile("root_file2", 1, root)

    local actual = fs.ToList(root)
    
    local expected = { root, dir1, dir1_file1, root_file1, root_file2 }
    lu.assertEquals(actual, expected)
end

return TestFileSystem
