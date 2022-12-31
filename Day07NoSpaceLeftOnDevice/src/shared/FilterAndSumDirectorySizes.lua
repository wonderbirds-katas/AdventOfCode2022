local parser = require('TerminalOutputParser')
local fs = require('FileSystem')
local mfr = require('MapFilterReduce')
local M = {}

function M.FilterAndSumDirectorySizes(input)
	local root = parser.Parse(input)
	fs.CalculateTotalDirectorySizes(root)
	nodes = fs.ToList(root)
	onlyDirectories = mfr.Filter(nodes, function(node) return fs.IsDir(node) end)
	totalSize = mfr.Reduce(onlyDirectories, 0, function(acc, dir) return acc + dir.totalSize end)
	
	if totalSize > 100000 then
		return 0
	end
	return totalSize
end

return M
