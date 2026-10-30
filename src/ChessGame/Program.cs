using System;
using ChessGame;

try { Console.Title = "Schaakalgoritme Keuzedeel"; } catch { }

Console.WriteLine("==================================================");
Console.WriteLine("   Welkom bij het Schaakalgoritme Prototype!      ");
Console.WriteLine("==================================================");
Console.WriteLine("Kies spelmodus:");
Console.WriteLine("  1. Speler tegen Computer (Jij bent Wit)");
Console.WriteLine("  2. Twee Spelers (Lokaal)");
Console.Write("Maak een keuze (1 of 2): ");

string? modeInput = Console.ReadLine();
bool vsAi = modeInput != "2";

Board board = new Board();

try { if (!Console.IsOutputRedirected) Console.Clear(); } catch { }
Console.WriteLine("Het spel begint! Typ je zetten zoals: e2e4 of e2 e4.");
Console.WriteLine("Typ 'moves' voor alle legale zetten of 'exit' om te stoppen.");

while (true)
{
    board.Display();

    // Controleer op mat of pat
    if (board.IsCheckmate())
    {
        PieceColor winner = (board.Turn == PieceColor.White) ? PieceColor.Black : PieceColor.White;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nSCHAAKMAT! Speler {winner} heeft gewonnen!");
        Console.ResetColor();
        break;
    }

    if (board.IsStalemate())
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nPAT (Remise)! Er zijn geen legale zetten meer.");
        Console.ResetColor();
        break;
    }

    if (board.IsInCheck(board.Turn))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Let op: {board.Turn} staat SCHAAK!");
        Console.ResetColor();
    }

    // Evaluatiescore printen (handig om te zien wat je algoritme straks "denkt")
    int eval = board.Evaluate();
    string evalStr = eval > 0 ? $"+{eval}" : $"{eval}";
    Console.WriteLine($"Aan de beurt: {board.Turn} | Bordwaarde: {evalStr} (Positief = Wit voor, Negatief = Zwart voor)");

    // AI Beurt
    if (vsAi && board.Turn == PieceColor.Black)
    {
        Console.WriteLine("\nDe computer berekent een zet...");
        System.Threading.Thread.Sleep(500); // Korte pauze voor realisme

        Move aiMove = ChessAI.ChooseMove(board);
        if (aiMove.Equals(default))
        {
            Console.WriteLine("Computer kan geen zet meer doen!");
            break;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Computer speelt: {aiMove}");
        Console.ResetColor();

        board.MakeMove(aiMove);
        continue;
    }

    // Speler Beurt
    Console.Write($"\nJouw zet ({board.Turn}): ");
    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input.Trim().ToLower() == "exit")
    {
        Console.WriteLine("Spel afgebroken.");
        break;
    }

    if (input.Trim().ToLower() == "moves")
    {
        Console.WriteLine("Legale zetten:");
        var moves = board.GetLegalMoves();
        for (int i = 0; i < moves.Count; i++)
        {
            Console.Write($"{moves[i]}  ");
            if ((i + 1) % 8 == 0) Console.WriteLine();
        }
        Console.WriteLine();
        continue;
    }

    if (board.TryParseMove(input, out Move playerMove))
    {
        board.MakeMove(playerMove);
        try { if (!Console.IsOutputRedirected) Console.Clear(); } catch { }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ongeldige zet! Probeer bijvoorbeeld 'e2e4' of typ 'moves'.");
        Console.ResetColor();
    }
}

Console.WriteLine("\nDruk op Enter om af te sluiten...");
Console.ReadLine();
