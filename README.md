# Puzzles of Advent of Code '22

[![.NET Build Status Badge](https://github.com/wonderbirds-katas/AdventOfCode2022/workflows/.NET/badge.svg)](https://github.com/wonderbirds-katas/AdventOfCode2022/actions?query=workflow%3A%22.NET%22)
[![Lua Tests Status Badge](https://github.com/wonderbirds-katas/AdventOfCode2022/workflows/Lua/badge.svg)](https://github.com/wonderbirds-katas/AdventOfCode2022/actions?query=workflow%3A%22Lua%22)

This repository contains C# and Lua solutions for the [Advent of Code 2022](https://adventofcode.com/2022/) puzzles.

## Thanks

Many thanks to [JetBrains](https://www.jetbrains.com/?from=dotnet-starter) who provide
an [Open Source License](https://www.jetbrains.com/community/opensource/) for this project ❤️.

## Build and Test all C# Puzzles

Most puzzle solutions are implemented as C# console programs writing the result to the standard
output. Each puzzle has its dedicated folder.

To build and run tests for all C# puzzles at once, type

```sh
dotnet build
dotnet test
```

## Run the Application for a Single Puzzle

Instructions to run each puzzle are contained in the corresponding subfolder.

- C# [Day 1: Calorie Counting](./Day01CountCalories)
- C# [Day 2: Rock Paper Scissors](./Day02RockPaperScissors)
- C# [Day 3: Rucksack Reorganization](./Day03RucksackReorganization)
- C# [Day 4: Camp Cleanup](./Day04CampCleanup)
- C# [Day 5: Supply Stacks](./Day05SupplyStacks)
- C# [Day 6: Tuning Trouble](./Day06TuningTrouble)
- Lua [Day 7: No Space Left on Device](./Day07NoSpaceLeftOnDevice)
- C# [Day 8: Treetop Tree House](./Day08TreetopTreeHouse)

## Implement the Next Puzzle in C#

1. Run [./generate-projects.sh](./generate-projects.sh) to create new project from the [TemplateProjects](./TemplateProjects) folder
2. Copy the name of the new folder to the clipboard - you'll need it several times
3. In the section above create a link for the new folder
4. Add a solution folder with the same name as the new folder
5. Add the existing projects and the README.md to the solution folder
6. Fix the namespace names in the `.cs` files of the projects
7. Edit the `.csproj` of the test project and fix the dependency to the console application project
8. Run the tests
9. Update README.md for the new project (adopt the README.md from an existing puzzle solution)
10. Update the associated build pipeline in [.github/workflows](./.github/workflows)
11. Remember to exclude the new directory from builds for other languages.
