local M = {}

local function CreateNode(name, parent)
	local result = {}
	result.name = name
	result.parent = parent

	-- TODO error handling: parent must be a directory
	
	if parent ~= nil then
		table.insert(parent.children, result)

		result.root = parent.root
	else
		result.root = result
	end

	return result
end

function M.CalculateTotalDirectorySizes(directory)
	directory.totalSize = 0

	for _, child in ipairs(directory.children) do
		if (M.IsDir(child)) then
			M.CalculateTotalDirectorySizes(child)
			directory.totalSize = directory.totalSize + child.totalSize
		else
			directory.totalSize = directory.totalSize + child.size
		end
	end
end

function M.CreateDirectory(name, parent)
    local result = CreateNode(name, parent)
	result.children = {}

	return result
end

function M.CreateFile(name, size, parent)
	local result = CreateNode(name, parent)
	result.size = size
	return result
end

function M.IsDir(node)
	return node.children ~= nil
end

function M.FindSubDirectory(name, currentDirectory)
	local node
	for _, node in ipairs(currentDirectory.children) do
		if node.name == name and M.IsDir(node) then
			return node
		end
	end

	-- TODO Error handling: What if the current directory does not contain name?
	-- TODO Fix all FindSubDirectory method calls ignoring the return value
	return nil
end

function M.GetParent(node)
	return node.parent
end

function M.GetRoot(node)
	return node.root
end

local function GetNodeDetailsString(node)
	if M.IsDir(node) then
		if node.totalSize ~= nil then
			return node.name .. "(dir, size=" .. node.totalSize .. ")\n"
		else
			return node.name .. " (dir)\n"
		end
	else
		return node.name .. " (file, size=" .. node.size .. ")\n"
	end
end

local function GetNextIndent(indent)
    if indent == "" then
        return "+-- "
    else
        return "    " .. indent
    end
end

function M.ToString(node, indent)
	local indent = indent or ""

	local result = indent .. GetNodeDetailsString(node)
	
	if not M.IsDir(node) then
		return result
	end

	indent = GetNextIndent(indent)

	for _, directory in ipairs(node.children) do
		result = result .. M.ToString(directory, indent)
	end

    return result
end

function M.ToList(node)
	if node == nil then
		return {}
	end

	local result = { node }

	for _, child in ipairs(node.children) do
		if M.IsDir(child) then
			local childList = M.ToList(child)
			for _, childNode in ipairs(childList) do
				table.insert(result, childNode)
			end
		else
			table.insert(result, child)
		end
	end

	return result
end

return M
