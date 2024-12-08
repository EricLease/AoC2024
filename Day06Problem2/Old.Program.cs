/*
using System.Drawing;
using System.Text;

// Solution: 1831
   TLDR:
   TODO: clean up algorithm implementation
   1. Find the unobstructed path
   2. Iterate through distinct positions in original path that are not the starting position
      a. Clone orginal map data with an additional obstruction (distinct path pos)
      b. DoWork on map clone
         - if a map boundary is reached
           -> return failure, not a valid obstruction point for loop
         - if a non-distinct Step* is reached
           -> return success, indicates a loop has been completed
         - throw - what other possibility is there besides a SO
                   (this might be the halting problem, feels like it)
                   there are a limited number of routes
      c. If work was failure, continue with next iteration of loop (2a.)
      d. Add the point to a [Hash]Set of interference points found that lead to loops
   TODO: Rework this whole solution to just...
   * non-distinct Step can occur due to brand new sub-path(s) stemming from
     the test obstruction, these can be partial loops, complementing portions of
     other partial loops in the original path, or they can contain/form complete loops
     in themselves; they can be created from a tangential extension of the orginal path;
     so these points need to be checked for uniqueness on each iteration, just as with
     the orginal points.
  
   If we ever have the same [x, y, d] we can quit, that's a loop.
   ------------------------------------------------------------------------------------
   The key was recognizing there is, at most, 1 possibility that needs to be tested
   for each step in the original path.  That set can be initialized as the path itself, 
   but any crossover points only need to be tested once... OMFG... that means all you
   need to do actually, if you can get all the distinct points in the path the first time
   is find the distinct positions visited in an unobstructed path, and then iterate through
   them, cloning a copy of the original map and adding an addtional obstruction pertaining
   to the current iteration's test point.  Then just run the guard for the iteration and
   see if they either: a. hit a boundary or b. create a loop (repeated Step [x, y, d]).
   
   I realize I was initially hung up on the idea that the obstruction could be placed as
   a guard was moving, i.e. blocking a path they had already crossed, which might change
   what would happen if they then crossed that point later.  But if we assume the new
   obstruction must be placed BEFORE the guard ever reaches that point then it simplifies
   the problem.  There's probably a way to calculate this with matrix manipulations
   in a few steps if you know the path and obstructions.  They are basically different
   identity matrices at that point.  There are probably transforms you can apply to
   determine if there are... not sure how you would do it.
const string _puzzleInput =
    """
    .....................#................#...#.....#.................................................#...........#...................
    .............#....#.#.................................#....................................................#.........#............
    ...........................................#...................................................................#......#...........
    ....................................................#................#.......#.............#......................................
    ..........................................#...##.#....................................#....#.........#............................
    ....................................#.............................................#.......#................#.......###............
    ..##.......#......................#..#........................................................#...................#...............
    .....#...........#..................................#..............#...........#..................................................
    ..........#..#......#.....#..#........#..................#.............................#...........................##............#
    ..............................#....#..........#...................................................................................
    .......#.#..........................#.........#...##..........................................................#.#....#...#.#......
    ..............................................................................................................#.........#.........
    ....................#......#.....#...............................#..#.........#........................#.#.....#..................
    ......................................##.................#.....................#............#.#.#..............#...............#..
    #...........................#..................#.....#..#..#.............#......#.........#........#........#.#.#.................
    .......#.............#....................#.................#...#.........#.......#................#......#................#....#.
    ...............#.................................................#................#..................#..................#.........
    .........#....................#..............................#..............#..............#.......#....................#......#..
    ....................................##.............................................................................#.#............
    .....................................................................#...#.#........................#....#....#......#............
    .....#...........................#.........#.............................................................................#........
    ...............#.#.........#...............##..............................................#............#.........................
    #..............#....##....#............#...#.#............................#...................................#..#..............#.
    ........#.........#...........................................................#..............................................#....
    .........................................................................................#.......#................................
    ................................#.........#..........#..#.......................................#..............................#..
    ........................#.................................................................................##........#.............
    .....#.....................#.....................#...#...........#.........................#......................................
    ....................................................................................................#.............................
    .........#...................................#...#................................................................................
    ..............#............##......#..............#......................................................#.....................#..
    ..#.......#............................................................................#...#.....................#................
    ..................#.....................##..#.................#..........#.....#........#.............#............#...........#..
    ...................................#.....#..............#..#.............................................#.....#......#....#......
    ......#....#.....................................................#................#...............................#...............
    ..#.#..................#.......#......#.............#.......#.....................................................................
    ......##...........................#.................#.....#........................................#.............................
    ...#......................#...............##......#.......................#..........#.................#.......#.......#..........
    ...........................#.............................................................#.#................#......#..#...........
    ..#.............#.....#.........................................................#..........#......................................
    ...........#.........#..........................................................................#..............#..................
    .#.......................................................#.#.......#............................................#.#...............
    ..........................#....#...............#............................................................#.........#...........
    .........................##.........#^.....................................................#......................................
    ........#.......#.................................................................................................#.......#.......
    ..........#..................................##..#.......................#.................#....................................#.
    ...................................#..#.....#.#.............#.....#.................##..............#.............................
    ...........................................................#.........................................................#......#.....
    ............#.........................#.........#.................................................................................
    ................#.........................#...............................#.......................................................
    .....................#.......#.................#.#..............#...............#.................................................
    ...#......................#...............................#.......#.......#..........................................#............
    .........#..#............................................................................................#........................
    ..............................................................................................#.#...........#.........#...........
    ..#..............#...............#.................................................................#.....#........................
    ................#..........#.......##..............#..............................#.##......#.....................................
    .........#....#.#..................................................................#...................#..........................
    #...#............#...............................................................................................................#
    ........#.....#.#................#.........................#.........#...........................##........................#.#....
    ......#...#.....................................................................#...........................#.....................
    ........#.........#.....................#............................................................................#..........#.
    .................................................................#....................#.........#..#...#.##.......................
    ..........#...........................##.......#...................................................................#.#............
    .......................................................................................#.................#..#.#...................
    ............................................................................................#.............#.......................
    ........................#........................#.................#..........................#...........................#.......
    .....................................#......#.................................#..........#........................................
    ....#...............................#........#............................#............................#..........................
    ..........#................#.#....................................................................................................
    #........................................................................#..........................................#.....#.......
    .#....................................#.........#..#.#...................................................#........................
    ...................#....................#..............#..................#.................................................#.....
    .........................................................................#..........................#............#................
    ........................................................#.................................................................#.......
    #...........................................#..............#............................................................#..#......
    ...............#..............#...............#............................#.......#.............#....#...........................
    ......#............#.#...........................................................................................#................
    ..................#..#.......#..............................#.............................#........#.......#.........#...........#
    ...............#.....................................#......#....................................#..........#................#....
    .............................................#...............#...........#........#.............#...#.......................##....
    .....#..................#...........#..............#.............#....................................#.........#.................
    ........................#.......................................................................#...........#.....................
    .............................#.....................................................#........##....................................
    ...........#.................................................................................#.........#....#....#.....#..........
    .....#..................................................................................#.....#.............................#....#
    ..#........#...............#.........................................................#.......#........................#.........#.
    ..............................................#....................##..............................#..........#.......#.#......#..
    .......................#......................................................#........#..........................................
    ..#.........................................#...........#.........................................................#...............
    ..........................#.......#...............................................................................................
    .........#.....................#..............................................#...............#...................................
    ..............................................#.........#..........#....#..............#..........................................
    ......................................#.........#............#........................................................#...#.......
    ...........................................#.....#..................#.....#..........#...............#...#........................
    .......................#........#..........................................................#.......#.........#............#....#..
    ..........#.....................................................................#...#.......#.......#.........#.....#.............
    .............................#..#...............................#....#.................................................#..#.......
    .#.............#................##......................................#...#..............................#............#.........
    ....#.........#....#..................................................................................#...............#.....#.....
    ......#................................................#.....#.#.......#.......#....................#.............#...............
    ...............................#..........#........................#.......................................................#.....#
    ...............#.......................................................................................#......#.......#..#.#.#....
    ..#....#.........................................................................#...................#....................##......
    ...........................#......#.................#...#..........................#..............................................
    ......#..........#...#............#....#..........................................................................................
    .......................#......#...............#..#......................#......#........................#........................#
    .#............#................................#............#....................#.................................#..............
    ................#.........#.................###............#..#...............#..............................#...#................
    ......#..........................#....#............#.................#...................................................#........
    ..........................#...#.............#........#......................#......................#.#.............#............#.
    ............................#................#....................#....##.......................#........#..........##.....#......
    ..............#.#...................#.#.............................................#..........#......#...........................
    .....#.........................#...........#...#......................................#......#..........#.#....#.##...............
    .............##.##....................................................................#.#..............#.......#.....#..#...#.....
    #.......#..................#.........#...................#................#..##...............##...............#..................
    ..............#....#........#.....#.................................#....#....#...#.......................................#.......
    ...........................#......#..............................#......................#.........................................
    .................#.#..........##................#...#..................................#..............#.....#.................#...
    ..........................#..............#..#......................#.......................#...........##.........................
    ..#...................#..........#.......#..........#...............................#.....................#.......................
    ............#......................#................#....#......................#.................................................
    ...........................................#........#.........#..........#..................#....#.........#....##................
    ..........#........................#.#...............#............................................#........#...#.....#............
    ...............#..........#..........#...#.....#........................#..............#..#.....................##................
    ...#.......................##.....................#................................................#..#............#..............
    ....#........#..#...#.#............................#................#................#............................................
    ...........#....................#.....#.........................#....................#.............#....#.........#...#........##.
    .#.....#.................##............#...............................#...............#.......................##.................
    ..............................#................................#.............................#................#.#.................
    ............##..............#........#.......#...................#..........................#.............###..#...#............#.
    """;

/* 
    #: obstruction
    ^: guard facing "up" (from the perspective of the map)

    Rule: move forward unless obstructed, then turn right 90
    Find the number of unobstructed positions, that are not the starting point,
    where a single obstruction could be placed to cause the guard to enter an
    infinite loop.

    Ex. from starting input

    ....#.....
    .........#
    ..........
    ..#.......
    .......#..
    ..........
    .#..^.....
    ........#.
    #.........
    ......#...
    
    ------------------------ #1

    ....#.....
    ....+---+#
    ....|...|.
    ..#.|...|.
    ....|..#|.
    ....|...|.
    .#.O^---+.
    ........#.
    #.........
    ......#...
    
    ------------------------ #2

    ....#.....
    ....+---+#
    ....|...|.
    ..#.|...|.
    ..+-+-+#|.
    ..|.|.|.|.
    .#+-^-+-+.
    ......O.#.
    #.........
    ......#...
    
    ------------------------ #3

    ....#.....
    ....+---+#
    ....|...|.
    ..#.|...|.
    ..+-+-+#|.
    ..|.|.|.|.
    .#+-^-+-+.
    .+----+O#.
    #+----+...
    ......#...

    ------------------------ #4

    ....#.....
    ....+---+#
    ....|...|.
    ..#.|...|.
    ..+-+-+#|.
    ..|.|.|.|.
    .#+-^-+-+.
    ..|...|.#.
    #O+---+...
    ......#...

    ------------------------ #5

    ....#.....
    ....+---+#
    ....|...|.
    ..#.|...|.
    ..+-+-+#|.
    ..|.|.|.|.
    .#+-^-+-+.
    ....|.|.#.
    #..O+-+...
    ......#...

    ------------------------ #6

    ....#.....
    ....+---+#
    ....|...|.
    ..#.|...|.
    ..+-+-+#|.
    ..|.|.|.|.
    .#+-^-+-+.
    .+----++#.
    #+----++..
    ......#O..

    Having traversed 41 distinct positions (45 total positions):

    ....#.....
    ....XXXXX#
    ....X...X.
    ..#.X...X.
    ..XXXXX#X.
    ..X.X.X.X.
    .#XXXXXXX.
    .XXXXXXX#.
    #XXXXXXX..
    ......#X..

    6 is the answer to the puzzle.

    Notice that 4 (#1-4) of these come a point just beyond an overlap points, 
    where the overlap point completes a quadralateral path.  These are
    trivial to identify as a distinct set of positions that are visited
    2+ times. 

    However, the other 2 are trickier to find.  A general purpose algorithm for
    finding these might be something like... at each step, test if unobstructed in the
    direction the guard is moving, would turning right once lead to the completion of
    a loop before an obstruction or map edge is reached?  This seems to be an 
    oversimplification though, and likely there is more complexity... maybe it's something
    like, if you can turn right and go straight to hit an overlap then continue to see 
    if you can hit another overlap/turn, etc. until you arrive back where you start (success)
    or hit an obstruction/map edge, otherwise rewind back to previous overlap/turn, continue
    straight along that route (recursive alogrithm) performing same checks, repeat until
    loop completed or obstuction/map edge hit on initial test route (right turn from current
    guard position)... this kind of makes sense. You can place one barrel, and you turn right
    once when it happens, so you're not concerned with the barrle, but testing what a right 
    turn would do at each juncture.

    It should be noted that a loop doesn't have to be a rectangle, and much
    more complicated loops (seemingly infinite complexity) can be created, however
    the puzzle may not required that level of detail, and that feels essentially the
    same as the halting problem, which means it may be undecideable and require some
    sort of heuristic/threshold.

    Alternatively, you could create lines.  To find the path initially treat it as 
    current point (a) to next obstruction-1 (b) in terms of a->b vector...but you'd
    still need to have the discreet points along that path, maybe you could find existing
    lines in the current path and try to predict what locations would create a line that
    would complete a loop.  That feels really messy, but I have a gut instinct there
    is an elegant solution buried there somewhere.  Probably better analysis of
    the path and obstructions alone, eg. drawing all possible lines between obstructions, 
    finding all paths that lead off the map and tracing those back, doing a bunch
    of MxN operations, which could concieveably be done in O(n*log(n)) instead of O(n^2).

    So chaining those together you might be able to create masks that could overlap to
    find non-unique (crossover points between masks) in an additive fashion, keeping
    the execution complexity sub O(n^2).
*//*

// Expect 6
const string _debugPuzzleInput =
    """
    ....#.....
    .........#
    ..........
    ..#.......
    .......#..
    ..........
    .#..^.....
    ........#.
    #.........
    ......#...
    """;

static List<string> GetLines(bool debug = false)
    => [..(debug ? _debugPuzzleInput : _puzzleInput).Split(
        Environment.NewLine,
        StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)];

static MapData ParseInput(bool debug = false)
{
    var lines = GetLines(debug);
    var height = lines.Count;
    var width = lines[0].Length;
    var obstructions = new HashSet<Point>();
    Point startPosition = default;
    MapDirection startDirection = default;

    for (var row = 0; row < height; row++)
    {
        var line = lines[row];

        for (var col = 0; col < width; col++)
        {
            var isStart = false;

            switch (line[col])
            {
                case '#':
                    obstructions.Add(new(col, row));
                    break;

                case '^':
                    isStart = true;
                    break;

                case '>':
                    isStart = true;
                    startDirection = MapDirection.Right;
                    break;

                case 'v':
                    isStart = true;
                    startDirection = MapDirection.Down;
                    break;

                case '<':
                    isStart = true;
                    startDirection = MapDirection.Left;
                    break;
            }

            if (isStart) startPosition = new Point(col, row);
        }
    }

    if (startPosition == default || width == 0 || height == 0 ||
        lines.Any(l => l.Length != width)) throw new Exception("Malformed input");

    return new MapData(width, height, obstructions,
        new Guard(new Step(startPosition, startDirection)));
}

static bool PositionValid(MapData map, Point position)
    => position.X >= 0 && position.Y >= 0
    && position.X < map.Width && position.Y < map.Height;

static Step AboutFace(Step step) => step.ChangeDirection().ChangeDirection();

static Step Rewind(Step step) => AboutFace(AboutFace(step).Next);

static void PrintMap(
    MapData data, int secondPassOffset = -1, bool full = false,
    bool debug = false, bool debugPause = false, bool trace = true)
{
    if (!trace && secondPassOffset > -1) return;
    if (!full && data.AllSteps[^1].IsVertical) return;
    if (!full && trace &&
        data.AllSteps.Count > 1 &&
        data.AllSteps[^1].Direction != data.AllSteps[^2].Direction) Console.Clear();

    const int PortionSize = 25;

    Console.CursorVisible = false;
    DefaultBgColor = Console.ForegroundColor;

    var origFgColor = DefaultBgColor;
    var origBgColor = Console.BackgroundColor;
    var guard = data.Guard;
    var minRow = full ? 0 : Math.Max(0, guard.CurrentStep!.Value.Position.Y - PortionSize);
    var maxRow = full
        ? data.Height - 1
        : Math.Min(data.Height - 1, PortionSize + Math.Max(PortionSize, guard.CurrentStep!.Value.Position.Y));
    var printInstructions = new List<PrintInstruction>(
        data.Obstructions
            .Where(o => o.Y >= minRow && o.Y <= maxRow)
            .Select(o => new PrintInstruction(
                o, ObstructionIcon, ObstructionFgColor, ObstructionBgColor)));
    var isSecondPass = false;
    Step currStep;

    for (var i = 0; i < guard.Steps.Count; i++)
    {
        isSecondPass = secondPassOffset > -1 && i >= secondPassOffset;

        currStep = guard.Steps[i];

        var isStart = currStep == guard.StartingStep;

        if (data.InterferencePoints.Contains(currStep.Position))
        {
            printInstructions.Add(new(currStep.Position,
                PossibleObstructionIcon, PossibleObstructionFgColor,
                isStart
                    ? isSecondPass ? SecondPassStartBgColor : StartBgColor
                    : isSecondPass ? PossibleObstructionSecondPassBgColor : PossibleObstructionBgColor));
            continue;
        }

        var repeated = guard.Steps.Take(i).Where(s => s.Position == currStep.Position).ToList();
        var currDirectionIndex = (int)currStep.Direction % 2;

        if (repeated.Count == 0)
        {
            printInstructions.Add(new(currStep.Position,
                VisitedLocationIcons[currDirectionIndex],
                isSecondPass ? VisitedLocationSecondPassFgColor : VisitedLocationFgColor,
                isStart
                    ? isSecondPass ? SecondPassStartBgColor : StartBgColor
                    : isSecondPass ? VisitedLocationSecondPassBgColor : VisitedLocationBgColor));
            continue;
        }

        if (!debug && !isSecondPass)
            printInstructions.RemoveAll(pi => pi.Position == currStep.Position);

        printInstructions.Add(new(currStep.Position,
            VisitedLocationIcons[repeated.Any(
                r => (int)r.Direction % 2 != currDirectionIndex) ? 2 : currDirectionIndex],
            isStart
                ? isSecondPass ? SecondPassStartFgColor : StartFgColor
                : isSecondPass ? VisitedLocationSecondPassFgColor : VisitedLocationFgColor,
            isStart
                ? isSecondPass ? SecondPassStartBgColor : StartBgColor
                : isSecondPass ? RepeatedLocationSecondPassBgColor : RepeatedLocationBgColor));
    }

    currStep = guard.CurrentStep!.Value;

    var inBounds =
        currStep.Position.X >= 0 && currStep.Position.X < data.Width &&
        currStep.Position.Y >= 0 && currStep.Position.Y < data.Height;
    ConsoleColor guardFore, guardBack;

    if (data.InterferencePoints.Contains(currStep.Position))
    {
        guardFore = inBounds
            ? isSecondPass ? GuardSecondPassFgColor : GuardFgColor
            : isSecondPass ? GuardSecondPassFgColorCompleted : GuardFgColorCompleted;
        guardBack = isSecondPass ? PossibleObstructionSecondPassBgColor : PossibleObstructionBgColor;
    }
    else if (!inBounds)
    {
        currStep = Rewind(currStep);

        var rewoundToPossibleObstructionPosition = data.InterferencePoints.Contains(currStep.Position);

        guardFore = isSecondPass
            ? rewoundToPossibleObstructionPosition ? GuardObstructionSecondPassFgColorCompleted : GuardSecondPassFgColorCompleted
            : rewoundToPossibleObstructionPosition ? GuardObstructionBgColorCompleted : GuardFgColorCompleted;
        guardBack = isSecondPass
            ? rewoundToPossibleObstructionPosition ? GuardObstructionSecondPassBgColorCompleted : GuardSecondPassBgColorCompleted
            : rewoundToPossibleObstructionPosition ? GuardObstructionBgColorCompleted : GuardBgColorCompleted;
    }
    else
    {
        guardFore = isSecondPass ? GuardSecondPassFgColor : GuardFgColor;
        guardBack = isSecondPass ? GuardSecondPassBgColor : GuardBgColor;
    }

    if (!debug && !isSecondPass)
        printInstructions.RemoveAll(pi => pi.Position == currStep.Position);

    printInstructions.Add(new(
        currStep.Position, GuardIcons[(int)currStep.Direction], guardFore, guardBack));

    for (var row = -1; row < data.Height + 1; row++)
    {
        var rowShouldPrint = row == -1 || row == data.Height;

        for (var col = -1; col < data.Width + 1; col++)
        {
            if (!rowShouldPrint && col > -1 && col < data.Width) continue;

            printInstructions.Add(new(new(row, col), BorderIcon,
                isSecondPass ? BorderSecondPassFgColor : BorderFgColor,
                isSecondPass ? BorderSecondPassBgColor : BorderBgColor));
        }
    }

    // TODO: Double buffer
    var orderedInstructions = printInstructions
        .OrderBy(pi => pi.Position.Y)
        .ThenBy(pi => pi.Position.X)
        .SkipWhile(pi => pi.Position.Y < minRow - 1)
        .TakeWhile(pi => pi.Position.Y <= maxRow + 1)
        .ToList();

    if (full ||
        data.Height > PortionSize * 2 &&
         guard.PreviousStep.HasValue &&
         guard.PreviousStep.Value.Position.Y !=
            guard.CurrentStep.Value.Position.Y) Console.Clear();

    foreach (var instruction in orderedInstructions)
    {
        Console.BackgroundColor = instruction.BackColor;
        Console.ForegroundColor = instruction.ForeColor;
        Console.CursorLeft = instruction.Position.X + 1;
        Console.CursorTop = instruction.Position.Y - minRow + 1;
        Console.Write(instruction.Value);
    }

    Console.BackgroundColor = origBgColor;
    Console.ForegroundColor = origFgColor;
    Console.CursorVisible = true;

    if (debug && (PauseRequested || debugPause))
        while (!ContinueRequested) Thread.Sleep(20);
}

static void DebugDisplay(bool debug, MapData data, int secondPassOfset = -1, bool trace = true)
{
    if (!debug) { return; }

    PrintMap(data, secondPassOfset, full: false, debug: true, trace: trace);
}

static MapData? DoWork(
    MapData? data = null, int secondPassOffset = -1,
    bool debug = false, bool debugPause = false, bool debugData = false,
    bool trace = true)
{
    var firstPass = data == null;
    var mapData = data ?? ParseInput(debugData);
    var guard = mapData.Guard;

    Console.BackgroundColor = ConsoleColor.Black;

    while (PositionValid(mapData, guard.CurrentStep!.Value.Position))
    {
        if (firstPass)
        {
            secondPassOffset = -1;

            if (debug && !debugPause && trace) Console.Clear();
        }

        if (mapData.LoopPresent)
        {
            if (firstPass)
            {
                throw new Exception("Malformed input, duplicate step encountered on first pass.");
            }

            return mapData;
        }

        var testStep = guard.NextStep;

        DebugDisplay(debug && (firstPass || trace), mapData, secondPassOffset, trace);

        var directionsTested = 0;

        do
        {
            if (!mapData.Obstructions.Contains(testStep.Position)) break;

            guard.ChangeDirection();
            testStep = guard.NextStep;
            directionsTested++;
        } while (directionsTested < MaxDirectionalChanges);

        // Test obstruction at testStep
        if (firstPass &&
            directionsTested < MaxDirectionalChanges &&
            PositionValid(mapData, testStep.Position) &&
            testStep.Position != guard.StartingStep!.Value.Position &&
            !mapData.DistinctPositions.Contains(testStep.Position))
        {
            var testGuard = new Guard(mapData.Guard.Steps);

            testGuard.ChangeDirection();

            var testMapData = new MapData(
                mapData.Width, mapData.Height,
                [.. mapData.Obstructions, testStep.Position],
                testGuard);
            var found = DoWork(testMapData, guard.Steps.Count - 1,
                debug, debugPause, debugData, trace);

            if (found != null) mapData.InterferencePoints.Add(testStep.Position);
        }

        mapData.RecordStep(testStep, true);
    }

    if (firstPass) mapData.Back();

    return firstPass ? mapData : null;
}

static void ShowResults(MapData mapData, bool debug)
{
    PrintMap(mapData, secondPassOffset: -1, full: true, debug: true, debugPause: debug, trace: false);

    if (!debug)
    {
        Console.WriteLine("--------- Final Render ---------");
        Console.WriteLine("Press Any Key to display results.");
        Console.ReadKey();
    }

    Console.Clear();
    Console.WriteLine($"Total Steps: {mapData.AllPositions.Count}");
    Console.WriteLine($"Distinct Steps: {mapData.DistinctSteps.Count}");
    Console.WriteLine($"Repeated Steps: {mapData.AllSteps.Count - mapData.DistinctSteps.Count}");
    Console.WriteLine($"Distinct Positions: {mapData.DistinctPositions.Count}");
    Console.WriteLine($"Repeated Positions: {mapData.AllPositions.Count - mapData.DistinctPositions.Count}");
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine($"Possible Obstruction Positions (that would create loops): {mapData.InterferencePoints.Count}");
    Console.WriteLine("-----------------------------------------------------------------");

    while (!ContinueRequested) Thread.Sleep(20);

    Console.WriteLine(mapData.AllSteps
        .Aggregate(
            new StringBuilder(),
            (sb, step) => sb.AppendLine($@"{(sb.Length > 0 ? " -> " : "")}({step.Position.X}, {step.Position.Y}) {step.Direction.ToString()}"))
        .ToString());
}

const bool debug = true;
const bool debugData = true;
const bool debugPause = false;
const bool trace = true;

ShowResults(
    DoWork(debug: debug, debugPause: debugPause, debugData: debugData, trace: trace)
        ?? throw new Exception("Malformed input."),
    debug);

internal enum MapDirection
{
    // In this order to mirror clockwise rotation
    Up,
    Right,
    Down,
    Left
}

internal interface IMobileEntity
{
    Step? StartingStep { get; }

    Step? CurrentStep { get; }

    Step? PreviousStep { get; }

    Step NextStep { get; }

    IReadOnlyList<Step> Steps { get; }

    void Move(Step step);

    void Back();

    void ChangeDirection();
}

internal readonly record struct Guard : IMobileEntity
{
    public Guard() : this([]) { }

    public Guard(Step startingPosition) : this([startingPosition]) { }

    public Guard(IReadOnlyList<Step> steps) => steps.ToList().ForEach(Move);

    public readonly Step? StartingStep => steps.Count != 0 ? steps[0] : default;

    public readonly Step? CurrentStep => steps.Count != 0 ? steps[^1] : default;

    public readonly Step? PreviousStep => steps.Count > 1 ? steps[^2] : default;

    public readonly Step NextStep => CurrentStep.HasValue
        ? CurrentStep.Value.Next
        : throw new Exception("No current step, can't get next");

    private readonly List<Step> steps = [];
    public readonly IReadOnlyList<Step> Steps => [.. steps];

    public readonly void Move(Step step) => steps.Add(step);

    public readonly void Back() => steps.Remove(steps[^1]);

    public readonly void ChangeDirection()
        => steps[^1] = steps[^1] with { Direction = steps[^1].Direction.TurnRight() };
}

internal readonly record struct MapData
{
    public MapData(int width, int height, IReadOnlyCollection<Point> obstructions, IMobileEntity guard)
    {
        Width = width;
        Height = height;
        Obstructions = new HashSet<Point>(obstructions);
        Guard = guard;
        RecordPath();

        // TODO: Valiate initial state: dimensions consistent, obstructions all within bounds
        //       guard path doesn't pass through obstructions. etc
    }

    internal readonly int Width { get; init; }
    internal readonly int Height { get; init; }
    internal readonly IReadOnlyCollection<Point> Obstructions { get; init; }

    // TODO: IEnumerable<IEntity> Entities -> set of guards
    internal readonly IMobileEntity Guard { get; init; }

    internal readonly HashSet<Point> InterferencePoints { get; init; } = [];

    private readonly List<Point> allPositions = [];
    internal readonly IReadOnlyList<Point> AllPositions => [.. allPositions];

    private readonly HashSet<Point> distinctPositions = [];
    internal readonly IReadOnlyList<Point> DistinctPositions => [.. distinctPositions];

    private readonly List<Step> allSteps = [];
    internal readonly IReadOnlyList<Step> AllSteps => [.. allSteps];

    private readonly HashSet<Step> distinctSteps = [];
    internal readonly IReadOnlyList<Step> DistinctSteps => [.. distinctSteps];

    internal readonly bool LoopPresent => DistinctSteps.Count < AllSteps.Count;

    internal readonly void Back()
    {
        var currStep = Guard.CurrentStep;

        if (!currStep.HasValue) return;

        allSteps.Remove(allSteps.Last());
        distinctSteps.Remove(currStep.Value);

        var lastPos = allPositions.Last();

        allPositions.Remove(lastPos);

        if (!allPositions.Any(pos =>
            pos.X == currStep.Value.Position.X &&
            pos.Y == currStep.Value.Position.Y))
        {
            distinctPositions.Remove(lastPos);
        }

        Guard.Back();
    }

    internal readonly void RecordStep(Step step, bool setCurrent)
    {
        if (setCurrent) Guard.Move(step);

        allSteps.Add(step);
        distinctSteps.Add(step);
        allPositions.Add(step.Position);
        distinctPositions.Add(step.Position);
    }

    private readonly void RecordStep(Step step) => RecordStep(step, false);

    private readonly void RecordPath() => Guard.Steps.ToList().ForEach(RecordStep);
}

internal record struct Step(Point Position, MapDirection Direction = MapDirection.Up)
{
    internal readonly Step Next =>
        new(Direction switch
        {
            MapDirection.Up => new Point(Position.X, Position.Y - 1),
            MapDirection.Right => new Point(Position.X + 1, Position.Y),
            MapDirection.Down => new Point(Position.X, Position.Y + 1),
            MapDirection.Left => new Point(Position.X - 1, Position.Y),
            _ => throw new NotImplementedException(),
        }, Direction);

    internal readonly Step ChangeDirection() => this with { Direction = Direction.TurnRight() };

    internal readonly bool IsHorizontal => Direction.IsHorizontal();

    internal readonly bool IsVertical => Direction.IsVertical();
}

internal record struct PrintInstruction(Point Position, char Value, ConsoleColor ForeColor, ConsoleColor BackColor);

internal static class Extensions
{
    internal static MapDirection TurnRight(this MapDirection direction) => (MapDirection)(((int)direction + 1) % 4);

    internal static bool IsHorizontal(this MapDirection direction) => (int)direction % 2 == 1;

    internal static bool IsVertical(this MapDirection direction) => (int)direction % 2 == 0;
}

internal static partial class Program
{
    private const char BorderIcon = '*';
    private const char ObstructionIcon = '#';
    private const char PossibleObstructionIcon = 'O';

    private static readonly char[] GuardIcons = ['^', '>', 'v', '<'];
    private static readonly char[] VisitedLocationIcons = ['|', '-', '+'];

    private static ConsoleColor DefaultBgColor { get; set; }

    private static readonly ConsoleColor BorderFgColor = ConsoleColor.Magenta;
    private static readonly ConsoleColor BorderBgColor = ConsoleColor.Gray;
    private static readonly ConsoleColor BorderSecondPassFgColor = BorderBgColor;
    private static readonly ConsoleColor BorderSecondPassBgColor = BorderFgColor;

    private static readonly ConsoleColor StartFgColor = ConsoleColor.DarkGreen;
    private static readonly ConsoleColor StartBgColor = ConsoleColor.White;
    private static readonly ConsoleColor SecondPassStartFgColor = StartBgColor;
    private static readonly ConsoleColor SecondPassStartBgColor = ConsoleColor.DarkRed;

    private static readonly ConsoleColor ObstructionFgColor = ConsoleColor.Red;
    private static readonly ConsoleColor ObstructionBgColor = DefaultBgColor;

    private static readonly ConsoleColor PossibleObstructionFgColor = ObstructionFgColor;
    private static readonly ConsoleColor PossibleObstructionBgColor = ConsoleColor.Yellow;
    private static readonly ConsoleColor PossibleObstructionSecondPassBgColor = GuardSecondPassFgColor;

    private static readonly ConsoleColor GuardFgColor = ConsoleColor.Green;
    private static readonly ConsoleColor GuardBgColor = DefaultBgColor;
    private static readonly ConsoleColor GuardSecondPassFgColor = ConsoleColor.Blue;
    private static readonly ConsoleColor GuardSecondPassBgColor = ConsoleColor.White;
    private static readonly ConsoleColor GuardFgColorCompleted = GuardBgColor;
    private static readonly ConsoleColor GuardBgColorCompleted = GuardFgColor;
    private static readonly ConsoleColor GuardSecondPassFgColorCompleted = GuardSecondPassBgColor;
    private static readonly ConsoleColor GuardSecondPassBgColorCompleted = GuardSecondPassFgColor;

    private static readonly ConsoleColor GuardObstructionBgColorCompleted = PossibleObstructionSecondPassBgColor;
    private static readonly ConsoleColor GuardObstructionSecondPassFgColorCompleted = ObstructionFgColor;
    private static readonly ConsoleColor GuardObstructionSecondPassBgColorCompleted = PossibleObstructionBgColor;

    private static readonly ConsoleColor VisitedLocationFgColor = GuardBgColor;
    private static readonly ConsoleColor VisitedLocationBgColor = GuardFgColor;
    private static readonly ConsoleColor VisitedLocationSecondPassFgColor = GuardSecondPassBgColor;
    private static readonly ConsoleColor VisitedLocationSecondPassBgColor = GuardSecondPassFgColor;
    private static readonly ConsoleColor RepeatedLocationBgColor = ConsoleColor.DarkGreen;
    private static readonly ConsoleColor RepeatedLocationSecondPassBgColor = ConsoleColor.DarkBlue;

    private static readonly int MaxDirectionalChanges = Enum.GetValues<MapDirection>().Length / 2;

    private static readonly ConsoleKey PauseKey = ConsoleKey.P;
    private static readonly ConsoleKey ContinueKey = ConsoleKey.C;

    private static bool OperationRequested(ConsoleKey targetKey)
    {
        var requested = false;

        if (!Console.KeyAvailable) return requested;

        while (Console.KeyAvailable)
        {
            var key = Console.ReadKey().Key;

            if (requested) continue;

            requested = key == targetKey;
        }

        return requested;
    }

    private static bool PauseRequested => OperationRequested(PauseKey);

    private static bool ContinueRequested => OperationRequested(ContinueKey);
}
*/