local M = {}

function M.FilterAndSumDirectorySizes(input)
	_, _, size = string.find(input, "(%d+)")
	return tonumber(size)
end

return M
