local M = {}

local function CreateNode(name, parent)
	local result = {}
	result.name = name
	result.parent = parent

	-- TODO error handling: parent must be a directory
	
	if parent ~= nil then
		table.insert(parent.children, result)
	end

	return result
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

local function GetNodeDetailsString(node)
	if M.IsDir(node) then
		return node.name .. " (dir)\n"
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

return M
