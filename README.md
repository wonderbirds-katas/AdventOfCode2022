# Puzzles of Advent of Code '22

[![Build Status Badge](https://github.com/wonderbirds-katas/AdventOfCode2022/workflows/.NET/badge.svg)](https://github.com/wonderbirds-katas/AdventOfCode2022/actions?query=workflow%3A%22.NET%22)

This repository contains C# solutions for the [Advent of Code 2022](https://adventofcode.com/2022/) puzzles.

## Thanks

Many thanks to [JetBrains](https://www.jetbrains.com/?from=dotnet-starter) who provide
an [Open Source License](https://www.jetbrains.com/community/opensource/) for this project ❤️.

## Build and Test all Puzzles

The puzzle solutions are implemented as console programs writing the result to the standard
output. Each puzzle has its dedicated folder.

To build everything and run all tests at once, type

```sh
dotnet build
dotnet test
```

## Run the Application for a Single Puzzle

Instructions to run each puzzle are contained in the corresponding subfolder.

- [Day 1: Calorie Counting](./Day01CountCalories)
- [Day 2: Rock Paper Scissors](./Day02RockPaperScissors)
- [Day 3: Rucksack Reorganization](./Day03RucksackReorganization)

## Implement the Next Puzzle

1. Copy an existing folder like `cp -av Day02RockPaperScissors Day03RucksackReorganization`
2. Copy the name of the new folder to the clipboard - you'll need it several times
3. In the section above create a link for the new folder
4. Rename the subfolders and the `.csproj` files so that they match the new project name
5. Add a solution folder with the same name as the new folder
6. Add the existing projects to the solution folder
7. Fix the namespace names in the `.cs` files of the projects
8. Edit the `.csproj` of the test project and fix the dependency to the console application project
9. Run the tests
