class Program
{
    // Possible moves of a knight in chess
    static readonly int[,] moves = new int[,]
    {
        { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 },
        { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }
    };

    static void Main()
    {
        Console.Write("Ingrese ubicación de los caballos (Ejemplp: B7,C5,E2,H7,G5,F6): ");
        string input = Console.ReadLine()!;

        string[] knights = input.Split(',');
        Dictionary<string, (int x, int y)> positions = new Dictionary<string, (int, int)>();

        // Convert algebraic notation to coordinates (A=1,...H=8 / 1-8)
        foreach (string knight in knights)
        {
            string pos = knight.Trim().ToUpper();
            int x = pos[0] - 'A' + 1;       // Column
            int y = int.Parse(pos[1].ToString()); // Row
            positions[pos] = (x, y);
        }

        // Analyze conflicts
        foreach (var knight in positions)
        {
            string name = knight.Key;
            var (x, y) = knight.Value;
            List<string> conflicts = new List<string>();

            // Check every possible move
            for (int i = 0; i < moves.GetLength(0); i++)
            {
                int newX = x + moves[i, 0];
                int newY = y + moves[i, 1];

                // Check if there is another knight in that position
                foreach (var other in positions)
                {
                    if (other.Key != name && other.Value.x == newX && other.Value.y == newY)
                    {
                        conflicts.Add(other.Key);
                    }
                }
            }

            Console.Write($"Analizando Caballo en {name} => ");
            if (conflicts.Count == 0)
                Console.WriteLine(" ");
            else
                Console.WriteLine("Conflicto con " + string.Join("  Conflicto con ", conflicts));
        }
    }
}
