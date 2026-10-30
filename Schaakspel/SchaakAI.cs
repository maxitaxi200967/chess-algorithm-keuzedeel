using System;
using System.Collections.Generic;

namespace Schaakspel
{
    /// <summary>
    /// Hier bouw jij jouw eigen schaakalgoritme!
    /// </summary>
    public static class SchaakAI
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Deze functie kiest de beste zet voor de computer.
        /// Hier kun jij later jouw Minimax-algoritme aanroepen!
        /// </summary>
        public static Zet KiesZet(SchaakBord bord)
        {
            List<Zet> legaleZetten = bord.GeefLegaleZetten();

            if (legaleZetten.Count == 0)
            {
                return null;
            }

            // =========================================================================
            // HIER KUN JE STRAKS JOUW EIGEN MINIMAX INSTELLEN:
            // return ZoekBesteZetMetMinimax(bord, diepte: 3);
            // =========================================================================

            // SIMPELE START-VERSIE:
            // 1. Kan de computer een stuk slaan? Dan doet hij dat direct!
            List<Zet> slagZetten = legaleZetten.FindAll(z => z.GeslagenStuk != null);
            if (slagZetten.Count > 0)
            {
                return slagZetten[_random.Next(slagZetten.Count)];
            }

            // 2. Anders kiest hij een willekeurige legale zet
            return legaleZetten[_random.Next(legaleZetten.Count)];
        }

        // =============================================================================
        // TEMPLATE VOOR JOUW MINIMAX ALGORITME (VOOR STRAKS IN DE PLANNING)
        // =============================================================================
        /*
        public static Zet ZoekBesteZetMetMinimax(SchaakBord bord, int diepte)
        {
            Zet besteZet = null;
            int besteScore = int.MaxValue; // Zwart wil minimaliseren (negatieve score)

            foreach (Zet zet in bord.GeefLegaleZetten())
            {
                bord.DoeZet(zet);
                int score = Minimax(bord, diepte - 1, true);
                bord.MaakZetOngedaan();

                if (score < besteScore)
                {
                    besteScore = score;
                    besteZet = zet;
                }
            }

            return besteZet;
        }

        private static int Minimax(SchaakBord bord, int diepte, bool isWitAanDeBeurt)
        {
            if (diepte == 0 || bord.GeefLegaleZetten().Count == 0)
            {
                return bord.Evalueer();
            }

            if (isWitAanDeBeurt)
            {
                int maxScore = int.MinValue;
                foreach (Zet zet in bord.GeefLegaleZetten())
                {
                    bord.DoeZet(zet);
                    int eval = Minimax(bord, diepte - 1, false);
                    bord.MaakZetOngedaan();
                    maxScore = Math.Max(maxScore, eval);
                }
                return maxScore;
            }
            else
            {
                int minScore = int.MaxValue;
                foreach (Zet zet in bord.GeefLegaleZetten())
                {
                    bord.DoeZet(zet);
                    int eval = Minimax(bord, diepte - 1, true);
                    bord.MaakZetOngedaan();
                    minScore = Math.Min(minScore, eval);
                }
                return minScore;
            }
        }
        */
    }
}
