local M = {}

function M.CreateDirectory(name, parent)
	directory = {}
	directory.name = name
	directory.parent = parent
	directory.children = {}

	if parent ~= nil then
		table.insert(parent.children, directory)
	end

	return directory
end

function M.PrintDirectoryTree(rootDirectory, indent)
	indent = indent or ""

	print(indent .. rootDirectory.name)
	for _, directory in ipairs(rootDirectory.children) do
		M.PrintDirectoryTree(directory, indent .. "   ")
	end
end

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

	if sum > 100000 then
		return 0
	end

	return tonumber(sum)
end

return M
