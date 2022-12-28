local M = {}

function M.FilterAndSumDirectorySizes(input)
	sum = 0
	startIndex = 0
	endIndex = -1

	repeat
		_, endIndex, size = string.find(input, "(%d+)", endIndex + 1)
		if size ~= nil then
			sum = sum + size
		end
	until size == nil

	return tonumber(sum)
end

return M
