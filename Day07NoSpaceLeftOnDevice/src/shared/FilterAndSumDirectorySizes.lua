local parser = require('TerminalOutputParser')
local fs = require('FileSystem')
local M = {}

function M.FilterAndSumDirectorySizes(input)
	local root = parser.Parse(input)
	fs.CalculateTotalDirectorySizes(root)

	-- TODO: Sum sizes of dirs < 100.000

	local sum = 0
	local startIndex = 0
	local endIndex = -1
	local size

	repeat
		_, endIndex, size = string.find(input, "(%d+)", endIndex + 1)
		if size ~= nil then
			sum = sum + size
		end
	until size == nil

	if sum > 100000 then
		return 0
	end

	return tonumber(sum)
end

return M
