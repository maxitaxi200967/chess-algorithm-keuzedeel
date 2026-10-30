using System;

namespace Schaakspel
{
    public enum Kleur
    {
        Geen,
        Wit,
        Zwart
    }

    public enum StukType
    {
        Geen,
        Pion,
        Paard,
        Loper,
        Toren,
        Dame,
        Koning
    }

    public class SchaakStuk
    {
        public Kleur Kleur { get; set; }
        public StukType Type { get; set; }

        public SchaakStuk(Kleur kleur, StukType type)
        {
            Kleur = kleur;
            Type = type;
        }

        // Waarde van het stuk (onmisbaar voor je algoritme)
        public int Waarde
        {
            get
            {
                switch (Type)
                {
                    case StukType.Pion: return 100;
                    case StukType.Paard: return 320;
                    case StukType.Loper: return 330;
                    case StukType.Toren: return 500;
                    case StukType.Dame: return 900;
                    case StukType.Koning: return 20000;
                    default: return 0;
                }
            }
        }

        // Unicode schaakstuk symbolen voor weergave op de knoppen
        public string Symbool
        {
            get
            {
                if (Kleur == Kleur.Wit)
                {
                    switch (Type)
                    {
                        case StukType.Koning: return "♔";
                        case StukType.Dame: return "♕";
                        case StukType.Toren: return "♖";
                        case StukType.Loper: return "♗";
                        case StukType.Paard: return "♘";
                        case StukType.Pion: return "♙";
                        default: return "";
                    }
                }
                else if (Kleur == Kleur.Zwart)
                {
                    switch (Type)
                    {
                        case StukType.Koning: return "♚";
                        case StukType.Dame: return "♛";
                        case StukType.Toren: return "♜";
                        case StukType.Loper: return "♝";
                        case StukType.Paard: return "♞";
                        case StukType.Pion: return "♟";
                        default: return "";
                    }
                }
                return "";
            }
        }
    }
}
