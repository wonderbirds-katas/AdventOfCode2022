local parser = require('TerminalOutputParser')
local fs = require('FileSystem')
local mfr = require('MapFilterReduce')
local M = {}

local function SumTotalSize(accumulator, directory)
	return accumulator + fs.TotalSize(directory)
end

function M.FilterAndSumDirectorySizes(input)
	local root = parser.Parse(input)
	fs.CalculateTotalDirectorySizes(root)
	local nodes = fs.ToList(root)
	local onlyDirectories = mfr.Filter(nodes, fs.IsDir)
	local totalSize = mfr.Reduce(onlyDirectories, 0, SumTotalSize)
	
	if totalSize > 100000 then
		return 0
	end
	return totalSize
end

return M
