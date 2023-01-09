local fs = require('FileSystem')

local M = {}

local function TryParseFileAndAddToDirectory(line, directoryNode)
    local fileSizeAndNamePattern = "(%d+)%s(.+)"
    local size, filename
    _, _, size, filename = string.find(line, fileSizeAndNamePattern)
    if size ~= nil and filename ~= nil then
        fs.CreateFile(filename, size, directoryNode)
    end
end

local function TryParseDirectoryAndAddToDirectory(line, directoryNode)
    local dirAndNamePattern = "dir%s(.+)"
    local dirname
    _, _, dirname = string.find(line, dirAndNamePattern)
    if dirname ~= nil then
        fs.CreateDirectory(dirname, directoryNode)
    end
end

local function TryParseChangeDirectory(line, currentDirectory)
    local cdCommandAndDirectoryPattern = "$ cd (.+)"
    local dirname
    _, _, dirname = string.find(line, cdCommandAndDirectoryPattern)
    if dirname == "/" then
        return fs.GetRoot(currentDirectory)
    elseif dirname == ".." then
        return fs.GetParent(currentDirectory)
    elseif dirname ~= nil then
        local subDir = fs.FindSubDirectory(dirname, currentDirectory)
        if subDir ~= nil then
            return subDir
        else
            print ("ERROR: Directory '" .. dirname .. "' not found.")
        end
    end
    return currentDirectory
end

function M.Parse(inputFileLines)
    local result = fs.CreateDirectory("/", nil)

    local line
    local currentDirectory = result
    for _, line in ipairs(inputFileLines) do
        currentDirectory = TryParseChangeDirectory(line, currentDirectory)
        TryParseFileAndAddToDirectory(line, currentDirectory)
        TryParseDirectoryAndAddToDirectory(line, currentDirectory)
    end

    return result
end

return M
