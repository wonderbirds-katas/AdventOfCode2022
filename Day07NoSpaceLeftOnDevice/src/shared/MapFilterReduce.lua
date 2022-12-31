M = {}

function M.Map(list, func)
    local result = {}

    for _, value in ipairs(list) do
        table.insert(result, func(value))
    end
    
    return result
end

function M.Filter(list, predicate)
    local result = {}

    for _, value in ipairs(list) do
        if predicate(value) then
            table.insert(result, value)
        end
    end
    
    return result
end

return M
