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

function M.ToString(rootDirectory, indent)
	indent = indent or ""
    result = ""

	result = result .. indent .. rootDirectory.name .. "\n"

    if indent == "" then
        indent = "+-- "
    else
        indent = "    " .. indent
    end

	for _, directory in ipairs(rootDirectory.children) do
		result = result .. M.ToString(directory, indent)
	end

    return result
end

return M
