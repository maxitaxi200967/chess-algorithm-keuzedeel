using System;
using System.Collections.Generic;

namespace Schaakspel
{
    public class SchaakBord
    {
        public SchaakStuk[,] Veld { get; private set; }
        private readonly Stack<Zet> _geschiedenis = new Stack<Zet>();

        public Kleur AanDeBeurt { get; private set; }

        public SchaakBord()
        {
            Veld = new SchaakStuk[8, 8];
            ResetBord();
        }

        public void ResetBord()
        {
            for (int r = 0; r < 8; r++)
                for (int k = 0; k < 8; k++)
                    Veld[r, k] = null;

            // Zwart (bovenkant bord, rijen 0 en 1)
            Veld[0, 0] = new SchaakStuk(Kleur.Zwart, StukType.Toren);
            Veld[0, 1] = new SchaakStuk(Kleur.Zwart, StukType.Paard);
            Veld[0, 2] = new SchaakStuk(Kleur.Zwart, StukType.Loper);
            Veld[0, 3] = new SchaakStuk(Kleur.Zwart, StukType.Dame);
            Veld[0, 4] = new SchaakStuk(Kleur.Zwart, StukType.Koning);
            Veld[0, 5] = new SchaakStuk(Kleur.Zwart, StukType.Loper);
            Veld[0, 6] = new SchaakStuk(Kleur.Zwart, StukType.Paard);
            Veld[0, 7] = new SchaakStuk(Kleur.Zwart, StukType.Toren);

            for (int k = 0; k < 8; k++)
                Veld[1, k] = new SchaakStuk(Kleur.Zwart, StukType.Pion);

            // Wit (onderkant bord, rijen 6 en 7)
            for (int k = 0; k < 8; k++)
                Veld[6, k] = new SchaakStuk(Kleur.Wit, StukType.Pion);

            Veld[7, 0] = new SchaakStuk(Kleur.Wit, StukType.Toren);
            Veld[7, 1] = new SchaakStuk(Kleur.Wit, StukType.Paard);
            Veld[7, 2] = new SchaakStuk(Kleur.Wit, StukType.Loper);
            Veld[7, 3] = new SchaakStuk(Kleur.Wit, StukType.Dame);
            Veld[7, 4] = new SchaakStuk(Kleur.Wit, StukType.Koning);
            Veld[7, 5] = new SchaakStuk(Kleur.Wit, StukType.Loper);
            Veld[7, 6] = new SchaakStuk(Kleur.Wit, StukType.Paard);
            Veld[7, 7] = new SchaakStuk(Kleur.Wit, StukType.Toren);

            AanDeBeurt = Kleur.Wit;
            _geschiedenis.Clear();
        }

        // ==========================================
        // ZETTEN UITVOEREN EN TERUGDRAAIEN
        // ==========================================

        public void DoeZet(Zet zet)
        {
            Veld[zet.VanRij, zet.VanKolom] = null;

            if (zet.IsPromotie)
            {
                Veld[zet.NaarRij, zet.NaarKolom] = new SchaakStuk(zet.VerplaatstStuk.Kleur, StukType.Dame);
            }
            else
            {
                Veld[zet.NaarRij, zet.NaarKolom] = zet.VerplaatstStuk;
            }

            _geschiedenis.Push(zet);
            AanDeBeurt = (AanDeBeurt == Kleur.Wit) ? Kleur.Zwart : Kleur.Wit;
        }

        public bool MaakZetOngedaan()
        {
            if (_geschiedenis.Count == 0) return false;

            Zet laatsteZet = _geschiedenis.Pop();
            Veld[laatsteZet.VanRij, laatsteZet.VanKolom] = laatsteZet.VerplaatstStuk;
            Veld[laatsteZet.NaarRij, laatsteZet.NaarKolom] = laatsteZet.GeslagenStuk;

            AanDeBeurt = (AanDeBeurt == Kleur.Wit) ? Kleur.Zwart : Kleur.Wit;
            return true;
        }

        public SchaakBord Kloon()
        {
            SchaakBord kopie = new SchaakBord();
            for (int r = 0; r < 8; r++)
                for (int k = 0; k < 8; k++)
                    kopie.Veld[r, k] = Veld[r, k];

            kopie.AanDeBeurt = AanDeBeurt;
            return kopie;
        }

        // ==========================================
        // BORD EVALUATIE (VOOR JOUW ALGORITME)
        // ==========================================

        public int Evalueer()
        {
            int score = 0;
            for (int r = 0; r < 8; r++)
            {
                for (int k = 0; k < 8; k++)
                {
                    SchaakStuk stuk = Veld[r, k];
                    if (stuk == null) continue;

                    if (stuk.Kleur == Kleur.Wit)
                        score += stuk.Waarde;
                    else
                        score -= stuk.Waarde;
                }
            }
            return score;
        }

        // ==========================================
        // LEGALE ZETTEN BEPALEN
        // ==========================================

        public List<Zet> GeefLegaleZetten()
        {
            List<Zet> kandidaatZetten = GeefKandidaatZetten(AanDeBeurt);
            List<Zet> legaleZetten = new List<Zet>();

            foreach (Zet zet in kandidaatZetten)
            {
                Kleur speler = zet.VerplaatstStuk.Kleur;
                DoeZet(zet);

                // Een zet is alleen legaal als je eigen koning daarna niet schaak staat
                if (!StaatSchaak(speler))
                {
                    legaleZetten.Add(zet);
                }

                MaakZetOngedaan();
            }

            return legaleZetten;
        }

        public bool StaatSchaak(Kleur kleur)
        {
            int koningRij = -1, koningKolom = -1;

            for (int r = 0; r < 8; r++)
            {
                for (int k = 0; k < 8; k++)
                {
                    SchaakStuk stuk = Veld[r, k];
                    if (stuk != null && stuk.Type == StukType.Koning && stuk.Kleur == kleur)
                    {
                        koningRij = r;
                        koningKolom = k;
                        break;
                    }
                }
                if (koningRij != -1) break;
            }

            if (koningRij == -1) return false;

            Kleur tegenstander = (kleur == Kleur.Wit) ? Kleur.Zwart : Kleur.Wit;
            return IsVeldAangevallen(koningRij, koningKolom, tegenstander);
        }

        public bool IsSchaakmat()
        {
            return StaatSchaak(AanDeBeurt) && GeefLegaleZetten().Count == 0;
        }

        public bool IsPat()
        {
            return !StaatSchaak(AanDeBeurt) && GeefLegaleZetten().Count == 0;
        }

        private bool IsVeldAangevallen(int doelRij, int doelKolom, Kleur doorKleur)
        {
            // 1. Pion
            int pionRij = (doorKleur == Kleur.Wit) ? doelRij + 1 : doelRij - 1;
            if (pionRij >= 0 && pionRij < 8)
            {
                if (doelKolom - 1 >= 0)
                {
                    SchaakStuk p = Veld[pionRij, doelKolom - 1];
                    if (p != null && p.Type == StukType.Pion && p.Kleur == doorKleur) return true;
                }
                if (doelKolom + 1 < 8)
                {
                    SchaakStuk p = Veld[pionRij, doelKolom + 1];
                    if (p != null && p.Type == StukType.Pion && p.Kleur == doorKleur) return true;
                }
            }

            // 2. Paard
            int[] pRij = { -2, -2, -1, -1, 1, 1, 2, 2 };
            int[] pKolom = { -1, 1, -2, 2, -2, 2, -1, 1 };
            for (int i = 0; i < 8; i++)
            {
                int r = doelRij + pRij[i];
                int k = doelKolom + pKolom[i];
                if (IsBinnenBord(r, k))
                {
                    SchaakStuk p = Veld[r, k];
                    if (p != null && p.Type == StukType.Paard && p.Kleur == doorKleur) return true;
                }
            }

            // 3. Rechte lijnen (Toren of Dame)
            int[] rechtR = { -1, 1, 0, 0 };
            int[] rechtK = { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int r = doelRij + rechtR[i];
                int k = doelKolom + rechtK[i];
                while (IsBinnenBord(r, k))
                {
                    SchaakStuk p = Veld[r, k];
                    if (p != null)
                    {
                        if (p.Kleur == doorKleur && (p.Type == StukType.Toren || p.Type == StukType.Dame)) return true;
                        break;
                    }
                    r += rechtR[i];
                    k += rechtK[i];
                }
            }

            // 4. Diagonale lijnen (Loper of Dame)
            int[] diagR = { -1, -1, 1, 1 };
            int[] diagK = { -1, 1, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int r = doelRij + diagR[i];
                int k = doelKolom + diagK[i];
                while (IsBinnenBord(r, k))
                {
                    SchaakStuk p = Veld[r, k];
                    if (p != null)
                    {
                        if (p.Kleur == doorKleur && (p.Type == StukType.Loper || p.Type == StukType.Dame)) return true;
                        break;
                    }
                    r += diagR[i];
                    k += diagK[i];
                }
            }

            // 5. Koning
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dk = -1; dk <= 1; dk++)
                {
                    if (dr == 0 && dk == 0) continue;
                    int r = doelRij + dr;
                    int k = doelKolom + dk;
                    if (IsBinnenBord(r, k))
                    {
                        SchaakStuk p = Veld[r, k];
                        if (p != null && p.Type == StukType.Koning && p.Kleur == doorKleur) return true;
                    }
                }
            }

            return false;
        }

        private List<Zet> GeefKandidaatZetten(Kleur kleur)
        {
            List<Zet> zetten = new List<Zet>();

            for (int r = 0; r < 8; r++)
            {
                for (int k = 0; k < 8; k++)
                {
                    SchaakStuk stuk = Veld[r, k];
                    if (stuk == null || stuk.Kleur != kleur) continue;

                    switch (stuk.Type)
                    {
                        case StukType.Pion:
                            GenereerPionZetten(r, k, stuk, zetten);
                            break;
                        case StukType.Paard:
                            GenereerPaardZetten(r, k, stuk, zetten);
                            break;
                        case StukType.Loper:
                            GenereerLijnZetten(r, k, stuk, zetten, new int[] { -1, -1, 1, 1 }, new int[] { -1, 1, -1, 1 });
                            break;
                        case StukType.Toren:
                            GenereerLijnZetten(r, k, stuk, zetten, new int[] { -1, 1, 0, 0 }, new int[] { 0, 0, -1, 1 });
                            break;
                        case StukType.Dame:
                            GenereerLijnZetten(r, k, stuk, zetten, new int[] { -1, 1, 0, 0, -1, -1, 1, 1 }, new int[] { 0, 0, -1, 1, -1, 1, -1, 1 });
                            break;
                        case StukType.Koning:
                            GenereerKoningZetten(r, k, stuk, zetten);
                            break;
                    }
                }
            }

            return zetten;
        }

        private void GenereerPionZetten(int r, int k, SchaakStuk stuk, List<Zet> zetten)
        {
            int vooruit = (stuk.Kleur == Kleur.Wit) ? -1 : 1;
            int startRij = (stuk.Kleur == Kleur.Wit) ? 6 : 1;
            int promotieRij = (stuk.Kleur == Kleur.Wit) ? 0 : 7;

            int volgendeRij = r + vooruit;
            if (IsBinnenBord(volgendeRij, k) && Veld[volgendeRij, k] == null)
            {
                bool isPromotie = (volgendeRij == promotieRij);
                zetten.Add(new Zet(r, k, volgendeRij, k, stuk, null, isPromotie));

                int dubbeleStap = r + (vooruit * 2);
                if (r == startRij && Veld[dubbeleStap, k] == null)
                {
                    zetten.Add(new Zet(r, k, dubbeleStap, k, stuk, null, false));
                }
            }

            int[] slagKolommen = { k - 1, k + 1 };
            foreach (int sk in slagKolommen)
            {
                if (IsBinnenBord(volgendeRij, sk))
                {
                    SchaakStuk doel = Veld[volgendeRij, sk];
                    if (doel != null && doel.Kleur != stuk.Kleur)
                    {
                        bool isPromotie = (volgendeRij == promotieRij);
                        zetten.Add(new Zet(r, k, volgendeRij, sk, stuk, doel, isPromotie));
                    }
                }
            }
        }

        private void GenereerPaardZetten(int r, int k, SchaakStuk stuk, List<Zet> zetten)
        {
            int[] dr = { -2, -2, -1, -1, 1, 1, 2, 2 };
            int[] dk = { -1, 1, -2, 2, -2, 2, -1, 1 };

            for (int i = 0; i < 8; i++)
            {
                int nr = r + dr[i];
                int nk = k + dk[i];
                if (IsBinnenBord(nr, nk))
                {
                    SchaakStuk doel = Veld[nr, nk];
                    if (doel == null || doel.Kleur != stuk.Kleur)
                    {
                        zetten.Add(new Zet(r, k, nr, nk, stuk, doel));
                    }
                }
            }
        }

        private void GenereerLijnZetten(int r, int k, SchaakStuk stuk, List<Zet> zetten, int[] dr, int[] dk)
        {
            for (int i = 0; i < dr.Length; i++)
            {
                int nr = r + dr[i];
                int nk = k + dk[i];

                while (IsBinnenBord(nr, nk))
                {
                    SchaakStuk doel = Veld[nr, nk];
                    if (doel == null)
                    {
                        zetten.Add(new Zet(r, k, nr, nk, stuk, null));
                    }
                    else
                    {
                        if (doel.Kleur != stuk.Kleur)
                        {
                            zetten.Add(new Zet(r, k, nr, nk, stuk, doel));
                        }
                        break;
                    }

                    nr += dr[i];
                    nk += dk[i];
                }
            }
        }

        private void GenereerKoningZetten(int r, int k, SchaakStuk stuk, List<Zet> zetten)
        {
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dk = -1; dk <= 1; dk++)
                {
                    if (dr == 0 && dk == 0) continue;
                    int nr = r + dr;
                    int nk = k + dk;
                    if (IsBinnenBord(nr, nk))
                    {
                        SchaakStuk doel = Veld[nr, nk];
                        if (doel == null || doel.Kleur != stuk.Kleur)
                        {
                            zetten.Add(new Zet(r, k, nr, nk, stuk, doel));
                        }
                    }
                }
            }
        }

        private static bool IsBinnenBord(int r, int k) => r >= 0 && r < 8 && k >= 0 && k < 8;
    }
}
