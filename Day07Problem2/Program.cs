using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

/*          
 Day 7:
    
    Ex. Input:

        190: 10 19
        3267: 81 40 27
        83: 17 5
        156: 15 6
        7290: 6 8 6 15
        161011: 16 10 13
        192: 17 8 14
        21037: 9 7 18 13
        292: 11 6 16 20 

    Each line represents a single equation. 
    The total value appears before the colon, and the operands follow.
    Determine if numbers can be combined to produce the test value.
    Operators are evaluated left-to-right, not according to precedence rules. 
    Numbers in the equations cannot be rearranged. 
    
    Operators: add (+) and multiply (*)
    
    Ex. Solution:

                            X 83: 17 5              -> fail
                            X 156: 15 6             -> fail
                            X 7290: 6 8 6 15        -> fail
                            X 161011: 16 10 13      -> fail
                            X 192: 17 8 14          -> fail
                            X 21037: 9 7 18 13      -> fail
             190: 10 19                             -> pass, 10 * 19 = 190
            3267: 81 40 27                          -> pass, 81 + 40 * 27 and 81 * 40 + 27 both equal 3267
        +    292: 11 6 16 20                        -> pass, 11 + 6 * 16 + 20 = 292
    -------------
    Total:  3749
*/

const string _puzzleInput =
    """
    190: 10 19
    3267: 81 40 27
    83: 17 5
    156: 15 6
    7290: 6 8 6 15
    161011: 16 10 13
    192: 17 8 14
    21037: 9 7 18 13
    292: 11 6 16 20 
    """;

#region Main
Console.WriteLine(new Puzzle(_puzzleInput).Evaluate);
#endregion Main

internal partial class Program
{
    internal static readonly StringSplitOptions StringSplitOptions
        = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;
}

internal readonly record struct Puzzle(string Input)
{
    internal readonly int Evaluate
    {
        get
        {
            var lines = Input.GetLines().Select(l => new PuzzleLine(l));

            return lines.Count();
        }
    }
}

internal readonly record struct PuzzleLine
{
    private const char EqualityDelimiter = ':';

    private const int TotalIndex = 0;
    private const int OperandsIndex = 1;

    internal readonly string Raw { get; }

    internal readonly bool? Evaluation { get; } = default;

    private readonly int Total { get; } = 0;

    private readonly IReadOnlyCollection<int> Operands { get; } = [];

    private readonly Permutations Permutations { get; } = new();

    public PuzzleLine(string raw)
    {
        var initModel = Parse(raw);

        Raw = raw;
        Total = initModel.Total;
        Permutations = initModel.Permutations;
    }

    private PuzzleLineInit Parse(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw)) throw new Exception("Malformed input: null or empty");

        var rawParts = raw.Split(EqualityDelimiter, Program.StringSplitOptions);

        if (rawParts.Length != 2) throw new Exception("Malformed input: expected LHS and RHS");

        if (!int.TryParse(rawParts[TotalIndex], out var total)) throw new Exception("Malformed input: Invalid total");

        return new(total, new(rawParts[OperandsIndex]));
    }

    private readonly record struct PuzzleLineInit(int Total, Permutations Permutations);
}

internal readonly record struct Permutations
{
    private const char OperandsDelimiter = ' ';

    private static readonly char[] OperatorValues = [..
        Enum.GetValues<Operator>().Select(op => op.GetDescription()[0])];
    private static readonly int OperatorCount = OperatorValues.Length;

    internal readonly string Raw { get; }

    private readonly IEnumerable<IEnumerable<int>> _rawList = [];

    public Permutations(string raw)
    {
        var initModel = Parse(raw);

        Raw = raw;
        _rawList = [.. initModel.Permutations];
    }

    private PermutationsInit Parse(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw)) throw new Exception("Malformed input: null or empty");

        var rawParts = raw.Split(OperandsDelimiter, Program.StringSplitOptions);

        if (rawParts.Length < 1) return new([]);

        var operands = ValidateOperands(rawParts);
        List<List<int>> all = [];

        ForAllPermutation(operands, p => HandlePermutation(p));

        var stringAllPerms = string.Join('\n', all.Select(s => $"\t{string.Join(' ', s)}"));
        Console.WriteLine($"Final set for input [{raw}]:\n{stringAllPerms}\n");

        return new([.. all.Select(p => p.ToArray())]);

        bool HandlePermutation(int[] permutation)
        {
            // TODO: Construct all distinct equations for the set
            all.Add(new List<int>(permutation));
            var stringPerm = string.Join(' ', permutation);
            Console.WriteLine($"Adding permutation to all: {stringPerm}");
            //Console.WriteLine($"All permutations:\n{string.Join('\n', vals)}\n");
            return false; // return false to continue
        }
    }

    private static int ValidateOperand(string operand)
        => !int.TryParse(operand, out var result)
        ? throw new Exception("Malformed input: non-integer value detected")
        : result;

    private static int[] ValidateOperands(IEnumerable<string> rawParts)
        => [.. rawParts.Select(ValidateOperand)];

    //private static PermutationsInit Permute(IEnumerable<string> rawParts)
    //    => new(PermuteSegments(rawParts));

    //private static IEnumerable<string> PermuteOperands(IEnumerable<string> operands)
    //    => operands.Select(ValidateOperand).SelectMany(PermuteOperand);

    //private static IEnumerable<string> PermuteOperand(int operand)
    //    => OperatorValues.Select(op => $" {operand} {op}");

    //private static IReadOnlyCollection<string> PermuteSegments(IEnumerable<string> segments)
    //{
    //    if(_canRearrangeOperands) throw new NotImplementedException("Rearrange Operands Not Implemented");

    //    if (segments.Count() == OperatorCount) 
    //        return [segments.First().TrimEnd(OperatorValues).Trim()];


    //}

    #region Heaps Algorithm Implementation
    /// <summary>
    /// Heap's algorithm to find all pmermutations. Non recursive, more efficient.
    /// </summary>
    /// <param name="items">Items to permute in each possible ways</param>
    /// <param name="funcExecuteAndTellIfShouldStop"></param>
    /// <returns>Return true if cancelled</returns> 
    /// <remarks>Credit: https://stackoverflow.com/a/36634935</remarks>
    private static bool ForAllPermutation<T>(T[] items, Func<T[], bool> funcExecuteAndTellIfShouldStop)
    {
        var countOfItem = items.Length;

        if (!(funcExecuteAndTellIfShouldStop(items) is var firstStopFlag) || countOfItem <= 1)
        {
            return firstStopFlag;
        }

        var indexes = new int[countOfItem];

        for (int i = 1; i < countOfItem;)
        {
            if (indexes[i] < i)
            {
                if ((i & 1) == 1)
                {
                    Swap(ref items[i], ref items[indexes[i]]);
                }
                else
                {
                    Swap(ref items[i], ref items[0]);
                }

                if (funcExecuteAndTellIfShouldStop(items))
                {
                    return true;
                }

                indexes[i]++;
                i = 1;
            }
            else
            {
                indexes[i++] = 0;
            }
        }

        return false;
    }

    /// <summary>
    /// Swap 2 elements of same type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="b"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Swap<T>(ref T a, ref T b) => (b, a) = (a, b);
    #endregion Heaps Algortihm Implementation

    private readonly record struct PermutationsInit(IReadOnlyCollection<int[]> Permutations);
}

internal readonly record struct Permutation
{

}

internal enum Operator
{
    // If Addition = 0, Multiplication = 1,
    // the `(int)<Operator>` value is the "identity value",
    // which can be applied with the operator AFTER ANY operand
    // to produce the original operand value.
    // This CANNOT be used to swap into the middle of permutations!
    // It can be used to create a tail though, which will always
    // yield the parent.  This *might* be useful, but can't hurt.

    [Description("+")]
    Addition = 0,       // Assignment not necessary here, just being explicit.
    [Description("*")]
    Multiplication = 1  // "                                                 "
}

internal static class Extensions
{
    private const bool _throwOnUndefined = true;

    internal static string GetDescription(this Enum e)
        => (e
            ?.GetType()
            .GetTypeInfo()
            .GetMember(e.ToString())
            .FirstOrDefault(m => m.MemberType == MemberTypes.Field)
            ?.GetCustomAttributes(typeof(DescriptionAttribute), false)
            .SingleOrDefault() as DescriptionAttribute)
            ?.Description ?? (
                _throwOnUndefined
                    ? throw new ArgumentException(
                        "Expected Enum value with Description attribute defined",
                        nameof(e))
                    : (e?.ToString() ?? "")
        ).Trim();

    internal static List<string> GetLines(this string input)
        => [..input.Split(
            Environment.NewLine,
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        ];
}