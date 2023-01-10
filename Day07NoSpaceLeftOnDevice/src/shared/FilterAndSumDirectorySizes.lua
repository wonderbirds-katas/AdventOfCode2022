local parser = require('TerminalOutputParser')
local fs = require('FileSystem')
local mfr = require('MapFilterReduce')
local M = {}

local minimumSizeToDelete = 0

local function MinimumTotalSize(accumulator, directory)
	local dirSize = fs.TotalSize(directory)
	if dirSize < accumulator then
		print ('Name of smaller Dir: ' .. directory.name .. ', size: ' .. dirSize)
		return dirSize
	end

	return accumulator
end

local function IsDirectoryLargeEnough(directory)
	return fs.TotalSize(directory) >= minimumSizeToDelete
end

function M.FilterAndSumDirectorySizes(inputFileLines)
	local totalDiskSpace = 70000000
	local requiredDiskSpace = 30000000
	local allowedRootSize = totalDiskSpace - requiredDiskSpace

	local rootDirectory = parser.Parse(inputFileLines)
	fs.CalculateTotalDirectorySizes(rootDirectory)

	local rootSize = fs.TotalSize(rootDirectory)
	minimumSizeToDelete = rootSize - allowedRootSize

	local allDirectoryEntries = fs.ToList(rootDirectory)
	local onlyDirectories = mfr.Filter(allDirectoryEntries, fs.IsDir)
	local onlyLargeEnoughDirectories = mfr.Filter(onlyDirectories, IsDirectoryLargeEnough)
	local minimumSizeToFree = mfr.Reduce(onlyLargeEnoughDirectories, rootSize, MinimumTotalSize)
	
	return minimumSizeToFree
end

return M
