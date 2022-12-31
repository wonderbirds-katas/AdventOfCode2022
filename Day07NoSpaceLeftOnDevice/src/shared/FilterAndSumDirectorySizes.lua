local parser = require('TerminalOutputParser')
local fs = require('FileSystem')
local mfr = require('MapFilterReduce')
local M = {}

local function SumTotalSize(accumulator, directory)
	return accumulator + fs.TotalSize(directory)
end

local function IsDirectorySmallEnough(directory)
	return fs.TotalSize(directory) <= 100000
end

function M.FilterAndSumDirectorySizes(input)
	local rootDirectory = parser.Parse(input)
	fs.CalculateTotalDirectorySizes(rootDirectory)
	local allDirectoryEntries = fs.ToList(rootDirectory)
	local onlyDirectories = mfr.Filter(allDirectoryEntries, fs.IsDir)
	local onlySmallDirectories = mfr.Filter(onlyDirectories, IsDirectorySmallEnough)
	local totalSize = mfr.Reduce(onlySmallDirectories, 0, SumTotalSize)
	
	return totalSize
end

return M
