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

function M.Reduce(list, accumulator, bifunc)
    local result = accumulator

    for _, value in ipairs(list) do
        result = bifunc(result, value)
    end

    return result
end

function M.Consume(list, consumerFunc)
    for _, value in ipairs(list) do
        consumerFunc(value)
    end
end

return M
