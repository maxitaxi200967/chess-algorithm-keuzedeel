using System;

namespace Schaakspel
{
    public class Zet
    {
        public int VanRij { get; set; }
        public int VanKolom { get; set; }
        public int NaarRij { get; set; }
        public int NaarKolom { get; set; }
        public SchaakStuk VerplaatstStuk { get; set; }
        public SchaakStuk GeslagenStuk { get; set; }
        public bool IsPromotie { get; set; }

        public Zet(int vanRij, int vanKolom, int naarRij, int naarKolom, SchaakStuk verplaatst, SchaakStuk geslagen = null, bool isPromotie = false)
        {
            VanRij = vanRij;
            VanKolom = vanKolom;
            NaarRij = naarRij;
            NaarKolom = naarKolom;
            VerplaatstStuk = verplaatst;
            GeslagenStuk = geslagen;
            IsPromotie = isPromotie;
        }

        public override string ToString()
        {
            char vanKolomLetter = (char)('a' + VanKolom);
            int vanRijCijfer = 8 - VanRij;
            char naarKolomLetter = (char)('a' + NaarKolom);
            int naarRijCijfer = 8 - NaarRij;

            string slagTekst = GeslagenStuk != null ? "x" : "-";
            return $"{vanKolomLetter}{vanRijCijfer}{slagTekst}{naarKolomLetter}{naarRijCijfer}";
        }

        public bool IsZelfde(int vanR, int vanK, int naarR, int naarK)
        {
            return VanRij == vanR && VanKolom == vanK && NaarRij == naarR && NaarKolom == naarK;
        }
    }
}
