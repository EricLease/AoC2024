using System.Text;
using Utilities;

/*  
MAP: MxN matrix of values [0-9]

PATH: longest contiguous set of steps in the range [0-9], 
      increasing in value by 1 at each step, where a step 
      is vertical or horizontal (not diagonal!)

ROOT: any position that starts one or more paths 

ROOT SCORE: number of paths completed starting from a given root

Root score 1:
    0123
    1234
    8765
    9876

Root score of 2: 
    ...0...
    ...1...
    ...2...
    6543456
    7.....7
    8.....8
    9.....9

Root score 4:
    ..90..9
    ...1.98
    ...2..7
    6543456
    765.987
    876....
    987....

2 roots; root at (1, 0) has a score of 1, root at (5, 6) has score 2:
    10..9..
    2...8..
    3...7..
    4567654
    ...8..3
    ...9..2
    .....01

This map contains 9 roots:
    89010123    ..0.0...    ..0101..    ..01012.    ..010123    ..010123
    78121874    ........    ..1.1...    ..121...    ..121...    ..121..4
    87430965    ....0...    ....0...    ....0...    ...30...    ..430...
    96549874    ........    ........    ........    ........    ........
    45678903    ......0.    ......0.    ......0.    ......03    ......03
    32019012    ..0..0..    ..01.01.    .201.012    3201.012    3201.012
    01329801    0.....0.    01....01    01.2..01    0132..01    0132..01
    10456732    .0......    X0......    X0.....2    X0....32    X0....32
In reading order, their root scores are: 5, 6, 5, 3, 1, 3, 5, 3, 5
Adding these scores together, the sum of the scores of all roots is 36.

Write a program that will find the sume of all root scores in any map.

traverse original map, find highest, lowers, all range of actual values

for lowest # = 0, lowest # < highest, lowest #++) 
// actually, for each value in range values from above, could be gaps
{
    create a copy (draft) of original map with only the lowest # positions populated from original
    
    for(var pathStep = lowest + 1; pathSte++ pathStep < 9; pathStep++)
    {
        fill copy from previous with all pathStep values from original IF...
            -they would have a (pathStep-1) value either above, below, left or right in the current draft
        
            -they have at least 1 free square left/right/up/down (prob have to do this on a 2nd pass) 
             after filling in all of the current pathStep values, eg... 03330   0...0   0...0   0...0   03330
                                                                        12321   .....   1...1   12.21   12321
                                                                        43334   .....   .....   .....   .333.
                at this point we could prune some 3's...
                0XXX0
                12X21
                .3X3.
                because we know those positions can't lead to a 4

                we could also prune any locations with (pathStep-1) that don't have an adjacent value of pathStep because 
                we know they are deadends at that point, and not paths (if there are any pathStep values remaining in the map)
                -> actually yes, would want to check that there is at least 1 pathStep values remaining in the map before
                   pruning pathStep-1 nodes that don't have adjacent pathstep, because they would actaully be the max pathstep
                   for the current lowest #, and... increment lowest # to pathStep if this occurs, can short circuit at this point
                   if that would only allow for a length < current longest path length.  or... if (max - pathStep < longestPathLen) done

                could we have two paths of equal length but different values?!  It's defined as the "longest continguous run of numbers in [0-9]"
                so runs of 0-3, and 4-8 could theoertically both be paths in the same map if there were no paths 5+.  Really any number of paths size 4
                could exist... maybe they address some fo these concerns in the examples, ahve to work through those fully

                NOTE: looking at the input, there is at least 1 full path [0-9], so I don't need to worry about the outer loop or that complexity
    }
}
 */

// Solvd, 778.
// Was hung up on 785 until I realized left/right had to be tested against relative row bounds,
// whereas up/down had to be tested against absolute bounds.
const bool _debug = false;
var _config = Map.GenConfig;

if (_debug)
{
#pragma warning disable CS0162 // Unreachable code detected
    _config[Map.MasterDebugKey] = true;
    _config[Map.DataDebugKey] = true;
    _config[Map.MasterPauseDebugKey] = true;
    _config[Map.RootPauseDebugKey] = true;
    _config[Map.PathPauseDebugKey] = true;
#pragma warning restore CS0162 // Unreachable code detected
}

new Map(_config).Evaluate();

internal record struct Map
{
    #region Debug Related
    // Expect 36: (5 + 6 + 5 + 3 + 1 + 3 + 5 + 3 + 5)
    const string _puzzleInputDebug =
        """
    89010123
    78121874
    87430965
    96549874
    45678903
    32019012
    01329801
    10456732
    """;

    internal const int MasterDebugKey = 0;
    internal const int DataDebugKey = 1;
    internal const int MasterPauseDebugKey = 2;
    internal const int RootPauseDebugKey = 3;
    internal const int PathPauseDebugKey = 4;
    private const int _configKeysCount = 5;
    internal static bool[] GenConfig => new bool[_configKeysCount];

    private static readonly ConsoleColor SkipColor = ConsoleColor.DarkGray;
    private static readonly ConsoleColor TodoColor = ConsoleColor.Gray;
    private static readonly List<ConsoleColor> PathColors =
    [
        ConsoleColor.DarkMagenta,
        ConsoleColor.Magenta,
        ConsoleColor.DarkBlue,
        ConsoleColor.Blue,
        ConsoleColor.Yellow,
        ConsoleColor.DarkYellow,
        ConsoleColor.Cyan,
        ConsoleColor.DarkCyan,
        ConsoleColor.Green,
        ConsoleColor.DarkGreen
    ];

    private readonly List<bool> Config { get; }

    private readonly bool MasterDebug => TestFlag(MasterDebugKey);
    private readonly bool DebugData => TestFlag(DataDebugKey);
    private readonly bool MasterPause => TestFlag(MasterPauseDebugKey);
    private readonly bool RootPause => TestFlag(RootPauseDebugKey);
    private readonly bool PathPause => TestFlag(PathPauseDebugKey);

    private readonly bool TestFlag(int key) => Config.Count > key && Config[key];

    private readonly string Tabs(int count)
    {
        if (MasterPause) return "";

        var tabs = new StringBuilder("\t");

        for (var i = 0; i < count; i++) tabs.Append('\t');

        return tabs.ToString();
    }
    #endregion Debug Related

    const string _puzzleInput =
        """
    212345410210987621217890789890121034565442100125671056710
    200176761223670130306721698761210125471233693234982567891
    129289872334543245405432547654300276980344780126783456432
    038378969455698236912301238963211080187655693210695432569
    347432358766780147872898347876102391995040544589543521278
    456521243765469056321783210985989452876121235674512670569
    569010342894378765430654781234676543105431230123601789432
    878765401345219878345101698104569689298760345678765698901
    987871211216706789236782567665438776387654876659834217876
    856980100301893472121893432674321065410148987789323109845
    341213221298742345090898321789812764321039845654010256730
    210304378345651016782127100698903854523128734503765340321
    305445469098578727890036234567814923014509658712894321434
    416996954107689656781245898410345017877612549603401234323
    787887873256210545672012367321276676968233438556510965412
    696788980341011234543032456210987589859142123467656876701
    012697891232567849432141045108765412348054010198987655832
    763546321063458938543256036789012309878767198767810765910
    854435417654367867600167127678101210769898185656521894321
    945421308743216543214328998543232125658121034343433443212
    836710769034202398765011056760187034341030128765012534301
    327897854123101450127652347891298743210345689434547643212
    010898943030210763238943219782345646556776776521898756101
    898701034321347894567652308763201237649889889430189657810
    787652122134956238765641207454100348532794324321054346921
    896343043045840149454100012389019659431245010198761234430
    743214104556729450363267823478328760120356521082120123445
    125905234676518761278954954565405892102347436781034016596
    034876546787609687634543069676216743401958945698765407687
    345954434894514598527652178985345434567867010789896328778
    216763320123223423418701201234987101109798123478787819669
    307812018983123010509010110125676432238787234567698904550
    898900867654004327696327898006512343445676543234367803341
    714321978103215018987436567217009854232785450145236512232
    105497869289346787676503454398123767101090367096145210103
    216786454376549894521012345687634998256981278987054334565
    323445210865034743432301478710545877347801209678981021076
    434134348992125623245696589329014566467874314567832987985
    985012349887610014132787103458123487216965423050013456234
    876123456766521165001696212367870198103876302141123442112
    765034300125433674300105123798965287212963218932033230003
    052343212334894789212234037897234378733454367898144101894
    141256103456763210698210548782110569123765454727655432785
    230987232345854324782345699654023457014894325410766745696
    678796341078983105691056789503432128985601216321899874587
    569569478876803234528945093412351012676876307839782103091
    454478569945012343217854112328945401068985410988789232110
    123387654035219445306543201007876312345698523421654378901
    003298743124308556789801123216981235430785654530565467432
    210109632265467643007652014567800896521238703691454876543
    341234501256787632118743112310712987450349812782363989692
    478981987123895678729652105425673456100456701432672176781
    569210896054396569434501876734980143291456012341089065760
    354321345465787454303410969803965234582387345456543254854
    210983230376610341212823457812874345673296216967632103923
    123672121287523200123981046922123216780125407878921212310
    034561012898430112345672345451034301691012398761010123421
    """;
        
    private const int MinValue = 0;
    private const int MaxValue = 9;

    private static readonly char MinValueChar = MinValue.ToString()[0];

    public Map(bool[]? config = null)
    {   
        Config = new(config ?? GenConfig);

        var lines = (DebugData
            ? _puzzleInputDebug 
            : _puzzleInput).GetLines();

        Data = [.. string.Join("", lines)
            .ToCharArray()
            .Select(c => c - MinValueChar)];
        MaxOffset = Data.Count;
        Width = lines[0].Length;
    }

    private readonly List<int> Data { get; }
    private readonly int Width { get; }
    private readonly int MaxOffset { get; }
    private int RootCount { get; set; }

    internal void Evaluate()
    {
        var totalRootScore = 0;

        for (var i = 0; i < MaxOffset; i++)
        {
            if (MasterDebug && MasterPause)
            {
                Console.Clear();

                for (var j = 0; j <= i; j++)
                {
                    var origColor = Console.ForegroundColor;

                    Console.ForegroundColor = Data[j] == MinValue ? PathColors[0] : SkipColor;
                    Console.Write(Data[j]);
                    Console.ForegroundColor = origColor;

                    if (j % Width == Width - 1) Console.WriteLine();
                }

                for (var j = i + 1; j < MaxOffset; j++)
                {
                    var origColor = Console.ForegroundColor;

                    Console.ForegroundColor = TodoColor;
                    Console.Write(Data[j]);
                    Console.ForegroundColor = origColor;

                    if (j % Width == Width - 1) Console.WriteLine();
                }
            }

            if (Data[i] == MinValue)
            {
                if (MasterDebug)
                {
                    var oldColor = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Walking possible root [{RootCount + 1}] at index {i}:");
                    Console.ForegroundColor = oldColor;

                    if (RootPause) Console.ReadKey();

                    var pathEnds = WalkPath(i, 0, [i]);

                    if (pathEnds.Count > 0)
                    {

                        totalRootScore += pathEnds.Count;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Root Path(s) Found ({pathEnds.Count}): [{string.Join(", ", pathEnds)}]");
                        Console.WriteLine($"Root Count: {++RootCount}");
                        Console.WriteLine($"Root Score Subtotal: {totalRootScore}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"\tComplete Path NOT Found");
                    }

                    Console.ForegroundColor = oldColor;

                    continue;
                }

                totalRootScore += WalkPath(i, 0, []).Count;
            }
            else if (MasterDebug)
            {
                var oldColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Skipping non-root at index {i}.");
                Console.ForegroundColor = oldColor;
            }
        }

        Console.WriteLine($"\nTotal Root Score: {totalRootScore}");
    }

    private HashSet<int> WalkPath(int offset, int currValue, List<int> currPath)
    {
        if (MasterDebug && MasterPause)
        {
            Console.Clear();

            for (var i = 0; i < MaxOffset; i++)
            {
                var origColor = Console.ForegroundColor;
                var pathIndex = currPath.IndexOf(i);

                Console.ForegroundColor = pathIndex > -1 ? PathColors[pathIndex] : SkipColor;
                Console.Write(Data[i]);
                Console.ForegroundColor = origColor;

                if (i % Width == Width - 1) Console.WriteLine();
            }

            if (PathPause) Console.ReadKey();
        }

        if (currValue == MaxValue)
        {
            if (MasterDebug)
            {
                var oldColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{Tabs(currValue)}Path completed at offset {offset}: [");

                for (var pIdx = 0; pIdx < currPath.Count; pIdx++)
                {
                    Console.ForegroundColor = PathColors[pIdx];
                    Console.Write($"{currPath[pIdx]}{(pIdx == currPath.Count - 1 ? "" : ", ")}");
                }

                Console.WriteLine("]");
                Console.ForegroundColor = oldColor;

                if (MasterPause) Console.ReadKey();
            }

            return [offset];
        }

        var pathEnds = new HashSet<int>();
        var nextNeighbors = FindNextNeighbors(offset, ++currValue, currPath);

        foreach (var neighbor in nextNeighbors)
        {
            pathEnds.UnionWith(WalkPath(neighbor, currValue, MasterDebug ? [.. currPath, neighbor] : []));

            if (MasterDebug)
            {
                var oldColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Tabs(currValue)}Child path ends: [{string.Join(", ", pathEnds)}]");
                Console.ForegroundColor = oldColor;
            }
        }

        return pathEnds;
    }

    private List<int> FindNextNeighbors(int currOffset, int targetValue, List<int> currPath)
    {
        List<int> neighbors = [];

        // Left
        var testOffset = currOffset - 1;
        var relativeOffset = (currOffset % Width) - 1;
        if (relativeOffset > -1 && Data[testOffset] == targetValue) neighbors.Add(testOffset);

        // Right
        testOffset = currOffset + 1;
        relativeOffset = (currOffset % Width) + 1;
        if (relativeOffset < Width && Data[testOffset] == targetValue) neighbors.Add(testOffset);

        // Up
        testOffset = currOffset - Width;
        if (testOffset > -1 && Data[testOffset] == targetValue) neighbors.Add(testOffset);

        // Down
        testOffset = currOffset + Width;
        if (testOffset < MaxOffset && Data[testOffset] == targetValue) neighbors.Add(testOffset);

        if (MasterDebug)
        {
            var oldColor = Console.ForegroundColor;

            if (neighbors.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Tabs(targetValue)}Found neighbors of index {currOffset} with target value ({targetValue}): [{string.Join(", ", neighbors)}]");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{Tabs(targetValue)}Dead end found at {currOffset}, max value ({targetValue - 1}): [");

                for (var pIdx = 0; pIdx < currPath.Count - 1; pIdx++)
                {
                    Console.ForegroundColor = PathColors[pIdx];
                    Console.Write($"{currPath[pIdx]}, ");
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(currOffset);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("]");

                if (MasterPause) Console.ReadKey();
            }

            Console.ForegroundColor = oldColor;
        }

        return neighbors;
    }
}