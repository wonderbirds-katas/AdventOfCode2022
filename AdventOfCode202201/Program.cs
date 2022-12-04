using AdventOfCode202201;

var numberOfElves = int.Parse(args[0]);
var filename = args[1];
var fileContents = File.ReadAllLines(filename);
var sumCalories = Processor.Process(numberOfElves, fileContents);
Console.WriteLine(sumCalories);
