local parser = require('TerminalOutputParser')
local M = {}

function M.FilterAndSumDirectorySizes(input)
	-- TODO local root = parser.Parse(input)
	-- TODO calculateTotalDirectorySizes(root)

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
