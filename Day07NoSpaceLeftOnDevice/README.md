# Day 7: No Space Left On Device

- [Puzzle Instructions for Part 1](./PUZZLE-PART-1.md)
- [Puzzle Instructions for Part 2](./PUZZLE-PART-2.md)

## Run with Lua

### Get Lua by Using a Visual Studio Code Dev Container

If Lua is not installed on your system, then use the configured [Dev
Container](https://code.visualstudio.com/docs/devcontainers/create-dev-container) for Visual Studio Code. Run the
command **Dev Containers: Open Folder in Container** from the Visual Studio Code command palette to start a a lua ready
terminal. From there you can run the application.

### Run the Application with Lua

```shell
LUA_PATH="$PWD/src/shared/?.lua" lua Run.lua input.txt
```

You can leave the dev container by selecting **Dev Containers: Reopen Folder Locally** from the command palette.

## BROKEN - Run with Roblox Studio

Unfortunately the project does not run in Roblox at the moment. The `require` statements in this repository are
not processed by Roblox as I would have expected.

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
