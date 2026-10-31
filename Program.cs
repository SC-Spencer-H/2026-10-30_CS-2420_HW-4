public class Program
{
    public static void Main(string[] args)
    {
        // ======================= TESTS (do not change) =======================
        Console.Clear();

        Console.WriteLine("== A2 Summarize ==");
        var s = Summarize(new[] { 84, 62, 98, 75, 90 });
        Console.WriteLine($"{s.Min} {s.Max} {s.Average}");
        var (low, high, avg) = Summarize(new[] { 50 });
        Console.WriteLine($"{low} {high} {avg}");
        Console.WriteLine();

        Console.WriteLine("== B2 HashTable ==");
        var ht = new HashTable();
        ht.Set("nails", 100); ht.Set("tile", 50); ht.Set("lumber", 80);
        ht.Set("bolts", 0); ht.Set("screws", 140);
        Console.WriteLine(ht.ContainsKey("lumber"));
        Console.WriteLine(ht.ContainsKey("glue"));
        Console.WriteLine(ht.TryGet("bolts", out int v1) + " " + v1);
        Console.WriteLine(ht.TryGet("glue", out int v2) + " " + v2);
        Console.WriteLine();

        Console.WriteLine("== B3 MostFrequentWord ==");
        Console.WriteLine(MostFrequentWord("the cat and the hat and the bat"));
        Console.WriteLine(MostFrequentWord("Red blue RED green red"));
        Console.WriteLine();

        Console.WriteLine("== B3 CommonNames ==");
        var both = CommonNames(new[] { "Ava", "Leo", "Maya", "Sam" },
        new[] { "Leo", "Sam", "Zoe" });
        var list = new List<string>(both);
        list.Sort(); // sort only so the output is the same every time
        Console.WriteLine(string.Join(", ", list));
        Console.WriteLine();
    }

    // ======================= PART A: TUPLES =======================
    // A2: Return the smallest score, the biggest score and the average.
    // Use only ONE loop.
    static (int Min, int Max, double Average) Summarize(int[] scores)
    {
        if (scores.Length < 1)
            return (0, 0, 0);

        int min = scores[0];
        int max = scores[0];
        int total = scores[0];

        for (int i = 1; i < scores.Length; i++)
        {
            if (scores[i] < min)
                min = scores[i];
            if (scores[i] > max)
                max = scores[i];
            total += scores[i];
        }

        double average = total / (double)(scores.Length);

        return (min, max, average);
    }

    // ======================= PART B: HASH MAPS =======================
    // B3: Return the word that shows up the most, and how many times.
    // Treat upper and lower case as the same. Return the word in lowercase.
    static (string Word, int Count) MostFrequentWord(string text)
    {
        string[] words = text.ToLower().Split(' ');
        // TODO: count each word with a Dictionary<string, int>, then find the biggest count
        return ("", 0);
    }

    // B3: Return the names that are on BOTH lists. Use a HashSet.
    static HashSet<string> CommonNames(string[] first, string[] second)
    {
        // TODO
        return new HashSet<string>();
    }
}

// B2: our hash table from class. Add the two TODO methods at the bottom.
public class HashTable
{
    private class Node
    {
        public string Key;
        public int Value;
        public Node? Next;
        public Node(string key, int value) { Key = key; Value = value; }
    }

    private readonly int size = 7;
    private Node?[] dataMap;
    public HashTable() { dataMap = new Node?[size]; }

    private int Hash(string key)
    {
        int hash = 0;
        foreach (char c in key)
            hash = (hash + c * 23) % dataMap.Length;
        return hash;
    }

    public void Set(string key, int value)
    {
        int index = Hash(key);
        Node? temp = dataMap[index];
        if (temp == null) { dataMap[index] = new Node(key, value); return; }
        while (true)
        {
            if (temp.Key.Equals(key)) { temp.Value = value; return; }
            if (temp.Next == null) break;
            temp = temp.Next;
        }
        temp.Next = new Node(key, value);
    }

    public int Get(string key)
    {
        Node? temp = dataMap[Hash(key)];
        while (temp != null)
        {
            if (temp.Key.Equals(key)) return temp.Value;
            temp = temp.Next;
        }
        return 0;
    }

    // TODO: return true if the key is in the table, false if not.
    public bool ContainsKey(string key)
    {
        return false;
    }

    // TODO: if the key is found, put its value in "value" and return true.
    // If not found, set value = 0 and return false.
    public bool TryGet(string key, out int value)
    {
        value = 0;
        return false;
    }
}

/* ======================= A1: PREDICT THE OUTPUT =======================
Write what each line prints BEFORE you run the code.
Line 1: 77
Line 2: 88
Line 3: true
Line 4: "Lab"
Line 5: 3
Why do Line 4 and Line 5 act differently? (2 or 3 sentences)
- Because the List in the second field is a reference type. When e is made as a copy of d, the list is not copied,
  only the reference to it. Changing elements of the list is reflected in both tuples since they point to the same one.
*/

/* ======================= B1: HASH TABLE BY HAND =======================
(a) Chaining. Example: 3: apple -> plum -> null
0: melon -> null
1: null
2: null
3: apple -> plum -> null
4: kiwi -> null
5: null
6: lime -> null
(b) Linear probing. Write the key in each slot, or "empty".
slot 0: melon
slot 1: empty
slot 2: empty
slot 3: apple
slot 4: plum
slot 5: kiwi
slot 6: lime
*/