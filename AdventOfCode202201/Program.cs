using AdventOfCode202201;

var filename = args[0];
var fileContents = File.ReadAllLines(filename);
var sumCalories = Parser.Parse(fileContents);
Console.WriteLine(sumCalories);
