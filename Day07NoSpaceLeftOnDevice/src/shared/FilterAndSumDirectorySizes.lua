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
	-- TODO: Follow the Approach to solving part 2:
	-- 1. Find the minimum required space X
	-- 2. List all directories >= X
	-- 3. What is the size of the the smallest directory >= X?

	-- Current step:
	-- TODO Create an integration test running the application on an input file

	local rootDirectory = parser.Parse(input)
	fs.CalculateTotalDirectorySizes(rootDirectory)
	local allDirectoryEntries = fs.ToList(rootDirectory)
	local onlyDirectories = mfr.Filter(allDirectoryEntries, fs.IsDir)
	local onlySmallDirectories = mfr.Filter(onlyDirectories, IsDirectorySmallEnough)
	local totalSize = mfr.Reduce(onlySmallDirectories, 0, SumTotalSize)
	
	return totalSize
end

return M
