local lu = require('luaunit')
local m = require('MapFilterReduce')

TestMapFilterReduce = {}

function TestMapFilterReduce.test_map_empty_list()
    local list = {}
    local actual = m.Map(list, function(x) return 0 end)
    lu.assertEquals(actual, list)
end

function TestMapFilterReduce.test_map_single_item_list_and_func_always_zero()
    local list = { 1 }
    local actual = m.Map(list, function(x) return 0 end)
    local expected = { 0 }
    lu.assertEquals(actual, expected)
end

function TestMapFilterReduce.test_map_multiple_item_list_and_func_always_zero()
    local list = { 1, 2, 3 }
    local actual = m.Map(list, function(x) return 0 end)
    local expected = { 0, 0, 0 }
    lu.assertEquals(actual, expected)
end

function TestMapFilterReduce.test_map_multiple_item_list_and_func_square()
    local list = { 1, 2, 3 }
    local actual = m.Map(list, function(x) return x * x end)
    local expected = { 1, 4, 9 }
    lu.assertEquals(actual, expected)
end

return TestMapFilterReduce
