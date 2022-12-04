using AdventOfCode202201;

var filename = args[0];
var fileContents = File.ReadAllLines(filename);
var sumCalories = Parser.Process(1, fileContents);
Console.WriteLine(sumCalories);
