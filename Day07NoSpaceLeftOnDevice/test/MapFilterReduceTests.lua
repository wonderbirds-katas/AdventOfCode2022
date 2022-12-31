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

function TestMapFilterReduce.test_filter_empty_list()
    local list = {}
    local actual = m.Filter(list, function(x) return true end)
    lu.assertEquals(actual, list)
end

function TestMapFilterReduce.test_map_single_item_list_and_func_always_true()
    local list = { 1 }
    local actual = m.Filter(list, function(x) return true end)
    local expected = { 1 }
    lu.assertEquals(actual, expected)
end

function TestMapFilterReduce.test_map_multiple_item_list_and_func_is_true_when_even()
    local list = { 1, 2, 3, 4, 5, 6 }
    local actual = m.Filter(list, function(x) return x % 2 == 0 end)
    local expected = { 2, 4, 6 }
    lu.assertEquals(actual, expected)
end

function TestMapFilterReduce.test_reduce_empty_list_accumulator_0()
    local list = {}
    local actual = m.Reduce(list, 0, function(accumulator, x) return 0 end)
    lu.assertEquals(actual, 0)
end

function TestMapFilterReduce.test_reduce_empty_list_accumulator_42()
    local list = {}
    local actual = m.Reduce(list, 42, function(accumulator, x) return 0 end)
    lu.assertEquals(actual, 42)
end

function TestMapFilterReduce.test_reduce_single_item_list_and_func_returns_42()
    local list = { 1 }
    local actual = m.Reduce(list, 0, function(accumulator, x) return 42 end)
    local expected = 42
    lu.assertEquals(actual, expected)
end

function TestMapFilterReduce.test_reduce_single_item_list_and_func_adds_arguments()
    local list = { 1 }
    local actual = m.Reduce(list, 1, function(accumulator, x) return accumulator + x end)
    local expected = 2
    lu.assertEquals(actual, expected)
end

function TestMapFilterReduce.test_reduce_multiple_item_list_and_func_multiplies_arguments()
    local list = { 2, 4, 6 }
    local actual = m.Reduce(list, 10, function(accumulator, x) return accumulator * x end)
    local expected = 480
    lu.assertEquals(actual, expected)
end

function TestMapFilterReduce.test_consume_empty_list()
    local numberOfConsumerCalls = 0
    local function consumer(x)
        numberOfConsumerCalls = numberOfConsumerCalls + 1
    end

    local list = {}
    m.Consume(list, consumer)

    lu.assertEquals(numberOfConsumerCalls, 0)
end

function TestMapFilterReduce.test_consume_single_item_list()
    local numberOfConsumerCalls = 0
    local function consumer(x)
        numberOfConsumerCalls = numberOfConsumerCalls + 1
    end

    local list = { "a" }
    m.Consume(list, consumer)

    lu.assertEquals(numberOfConsumerCalls, 1)
end

function TestMapFilterReduce.test_consume_multiple_items_list()
    local numberOfConsumerCalls = 0
    local lastConsumerValue
    local function consumer(x)
        numberOfConsumerCalls = numberOfConsumerCalls + 1
        lastConsumerValue = x
    end

    local list = { "a", "b", "c" }
    m.Consume(list, consumer)

    lu.assertEquals(numberOfConsumerCalls, 3)
    lu.assertEquals(lastConsumerValue, "c")
end

return TestMapFilterReduce
