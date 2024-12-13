using System.Diagnostics;

/*  --- Day 11: Plutonian Pebbles ---
Every time you blink, the stones each simultaneously change according to the first applicable rule in this list:

If the stone is engraved with the number 0
    it is replaced by a stone engraved with the number 1

If the stone is engraved with a number that has an even number of digits
    it is replaced by two stones
        The left half of the digits are engraved on the new left stone
        the right half of the digits are engraved on the new right stone
        The new numbers don't keep extra leading zeroes: 1000 would become stones 10 and 0
Else
    the stone is replaced by a new stone
    the old stone's number multiplied by 2024 is engraved on the new stone

No matter how the stones change, their order is preserved, and they stay on their perfectly straight line.
How will the stones evolve if you keep blinking at them? 

Puzzle input represents stones in a line.

Ex. 1: Five stones: 0 1 10 99 999, after one iteration the stones will be transformed as follows:
0 becomes 1
1 is multiplied by 2024 to become 2024
10 is split into a 1 and 0
99 is split into two 9s
999 is multiplied by 2024 to become 2021976

or: { 1, 2024, 1, 0, 9, 9, 2021976 }

Ex. 2:
         Step (# terms)
       | 0 (2): 125 17
   +1  | 1 (3): 253000 1 7
   +1  | 2 (4): 253 0 2024 14168
   +1  | 3 (5): 512072 1 20 24 28676032
+3 +4  | 4 (9): 512 72 2024 2 0 2 4 2867 6032
   +4  | 5 (13): 1036288 7 2 20 24 4048 1 4048 8096 28 67 60 32
+5 +9  | 6 (22): 2097446912 14168 4048 2 0 2 4 40 48 2024 40 48 80 96 2 8 6 7 6 0 3 2
   +9  | 7 (31): 20974 46912 28676032 40 48 4048 1 4048 8096 4 0 4 8 20 24 4 0 4 8 8 0 9 6 4048 16192 12144 14168 12144 1 6072 4048

In this example, after six iterations, there would be 22 values
After 25 iterations there would be 55312 values
 */

// Expect: 55312
//const string _puzzleInput = "125 17";

const string _puzzleInput = "17639 47 3858 0 470624 9467423 5 188";

var inputNumbers = _puzzleInput.Trim().Split(' ').Select(int.Parse).ToList();
var depth25Leaves = new Dictionary<string, long>();
var cnt = inputNumbers.Count; 
var stopWatch = new Stopwatch();

stopWatch.Start();

foreach (var number in inputNumbers)
{
    DictionaryTraverse(number.ToString(), 0, 25, depth25Leaves);
}

var ts = stopWatch.Elapsed;

Console.WriteLine($"Problem 1 Solution: {depth25Leaves.Sum(kvp => kvp.Value)}");
Console.WriteLine(string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10));


var depth50Leaves = new Dictionary<string, long>();

foreach(var kvp in depth25Leaves)
{
    DictionaryTraverse(kvp.Key, 0, 25, depth50Leaves, kvp.Value);
}

var depth75Leaves = new Dictionary<string, long>();

foreach (var kvp in depth50Leaves)
{
    DictionaryTraverse(kvp.Key, 0, 25, depth75Leaves, kvp.Value);
}

stopWatch.Stop();
ts = stopWatch.Elapsed;

Console.WriteLine($"Problem 2 Solution: {depth75Leaves.Sum(kvp => kvp.Value)}");
Console.Write(string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10));

static void DictionaryTraverse(string number, int currDepth, int maxDepth, Dictionary<string, long> lookups, long multiplier = 1)
{
    if (currDepth == maxDepth)
    {
        if (number == "") number = "0";
        if (!lookups.TryAdd(number, multiplier)) lookups[number] += multiplier;
        return;
    }

    if (number == "" || number == "0")
    {
        DictionaryTraverse("1", currDepth + 1, maxDepth, lookups, multiplier);
        return;
    }

    if ((number.Length & 1) == 1)
    {
        DictionaryTraverse((long.Parse(number) * 2024).ToString(), currDepth + 1, maxDepth, lookups, multiplier);
        return;
    }

    var half = number.Length >> 1;
    DictionaryTraverse(number[..half], currDepth + 1, maxDepth, lookups, multiplier);
    DictionaryTraverse(number[half..].TrimStart('0'), currDepth + 1, maxDepth, lookups, multiplier);
}