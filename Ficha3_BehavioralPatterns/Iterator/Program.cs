
public static class Program
{
    public static double CheckAbove(IEnumerable<int> data, int threshold)
    {
        int countAbove = 0;
        int totalCount = 0;
        foreach (int i in data)
        {
            if (i > threshold)
            {
                countAbove++;
            }
            totalCount++;
        }

        return (double)countAbove / totalCount * 100;
    }
    public static void Main()
    {
        int[] a = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<int> lst = a.ToList();
        HashSet<int> set = new HashSet<int>(lst);
        Console.WriteLine("% in list is " + CheckAbove(lst, 5));
        Console.WriteLine("% in set is " + CheckAbove(set, 5));
    }
}
