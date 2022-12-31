# Day 7: No Space Left On Device

→ [Puzzle Instructions](./PUZZLE.md)

## Run with Lua

```shell
cat input.txt | LUA_PATH="$PWD/src/shared/?.lua" lua Run.lua
```

## Run with Roblox Studio

### Prerequisites

This project can be run with [Roblox Studio](https://www.roblox.com/create). Please install the associated development
toolchain [Rojo](https://rojo.space/docs/v7/getting-started/installation/).

Then install the Rojo Plugin for Roblox Studio by entering the following into a terminal window:

```shell
rojo plugin install
```

### Run

Start the live sync server to expose the project to the Roblox Rojo Plugin:

```shell
rojo serve
```

In Roblox Studio open the file `Day07NoSpaceLeftOnDevice.rbxl` and run it.

The program result is displayed in the Output pane. To see it, select **View → Output** in Roblox Studio.

## Run the Tests

The tests depend on the [LuaUnit](https://github.com/bluebird75/luaunit) framework, which is a submodule in this
directory. When you first clone the repository, you need to fetch the submodule:

```shell
git submodule init
...
git submodule update
```

To run all tests, issue the command

```shell
LUA_PATH="$PWD/src/shared/?.lua;$PWD/test/?.lua;$PWD/luaunit/?.lua" lua ./test/TestSuite.lua -v
```

To run the tests every time a `.lua` file changes, enter

```shell
find . -iname "*.lua" | LUA_PATH="$PWD/src/shared/?.lua;$PWD/test/?.lua;$PWD/luaunit/?.lua" entr -r lua ./test/TestSuite.lua -v
```

This requires the [entr](https://github.com/eradman/entr) utility on your system.

## Links

- [Roblox Studio](https://www.roblox.com/create)
- [Rojo](https://github.com/rojo-rbx/rojo) - Documentation for Rojo.
- [Rojo - Roblox Studio Sync](https://marketplace.visualstudio.com/items?itemName=evaera.vscode-rojo) - Visual Studio Code Plugin for developing with Rojo.
- [Aftman](https://github.com/LPGhatguy/aftman) - Toolchain manager to handle different Rojo versions.
- [LuaUnit](https://luaunit.readthedocs.io/en/latest/) - Lua unit testing framework.
