# Day 8: Treetop Tree House

- [Puzzle Instructions for Part 1](./PUZZLE-PART-1.md)
- [Puzzle Instructions for Part 2](./PUZZLE-PART-2.md)

## Build and Test

See [Instructions in the parent folder](../README.md).

## Run the Application

From this folder, run the following command to execute the application:

```shell
# Get help
dotnet run --project Day08TreetopTreeHouse -- --help

# Solve part 1
dotnet run --project Day08TreetopTreeHouse -- --part 1 --file Day08TreetopTreeHouse/input.txt

# Solve part 2
dotnet run --project Day08TreetopTreeHouse -- --part 2 --file Day08TreetopTreeHouse/input.txt
```

ATTENTION:

This application differs from the previous solutions in the way the command line
arguments are handled. As a consequence you must specify the `--file` option
explicitly.

## Documentation of System.CommandLine.DragonFruit

- 