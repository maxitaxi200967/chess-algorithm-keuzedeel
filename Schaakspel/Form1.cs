using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Schaakspel
{
    public partial class Form1 : Form
    {
        private readonly Button[,] _knoppen = new Button[8, 8];
        private readonly SchaakBord _bord = new SchaakBord();

        private int _geselecteerdeRij = -1;
        private int _geselecteerdeKolom = -1;
        private List<Zet> _beschikbareZetten = new List<Zet>();

        // Kleuren voor het schaakbord
        private readonly Color _kleurLicht = Color.FromArgb(240, 217, 181);
        private readonly Color _kleurDonker = Color.FromArgb(181, 136, 99);
        private readonly Color _kleurSelectie = Color.FromArgb(186, 202, 68);
        private readonly Color _kleurOptie = Color.FromArgb(129, 182, 76);
        private readonly Color _kleurSchaak = Color.FromArgb(235, 97, 80);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaakBordKnoppen();
            UpdateBordWeergave();
        }

        private void MaakBordKnoppen()
        {
            pnlBord.Controls.Clear();
            int knopGrootte = 60; // 8 * 60 = 480 pixels

            for (int r = 0; r < 8; r++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(knopGrootte, knopGrootte),
                        Location = new Point(k * knopGrootte, r * knopGrootte),
                        Font = new Font("Segoe UI Symbol", 24F, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat,
                        Margin = new Padding(0),
                        Tag = new Point(r, k)
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += VeldKnop_Click;

                    _knoppen[r, k] = btn;
                    pnlBord.Controls.Add(btn);
                }
            }
        }

        private void VeldKnop_Click(object sender, EventArgs e)
        {
            if (timerComputer.Enabled) return; // Computer denkt nog na

            Button geklikteKnop = (Button)sender;
            Point punt = (Point)geklikteKnop.Tag;
            int r = punt.X;
            int k = punt.Y;

            SchaakStuk gekliktStuk = _bord.Veld[r, k];

            // 1. Er was al een stuk geselecteerd: kijken of we hiernaartoe kunnen zetten
            if (_geselecteerdeRij != -1)
            {
                Zet gekozenZet = _beschikbareZetten.Find(z => z.NaarRij == r && z.NaarKolom == k);

                if (gekozenZet != null)
                {
                    // Geldige zet uitvoeren!
                    VoerZetUit(gekozenZet);
                    Deselecteer();
                    return;
                }
                else if (gekliktStuk != null && gekliktStuk.Kleur == _bord.AanDeBeurt)
                {
                    // Klikken op een ander eigen stuk: wissel selectie
                    SelecteerStuk(r, k);
                    return;
                }
                else
                {
                    // Klikken op een leeg veld of ongeldig veld: deselecteer
                    Deselecteer();
                    return;
                }
            }

            // 2. Er was nog niks geselecteerd: selecteer als het een eigen stuk is
            if (gekliktStuk != null && gekliktStuk.Kleur == _bord.AanDeBeurt)
            {
                SelecteerStuk(r, k);
            }
        }

        private void SelecteerStuk(int r, int k)
        {
            _geselecteerdeRij = r;
            _geselecteerdeKolom = k;

            // Zoek alle legale zetten voor specifiek dit geselecteerde stuk
            List<Zet> alleLegale = _bord.GeefLegaleZetten();
            _beschikbareZetten = alleLegale.FindAll(z => z.VanRij == r && z.VanKolom == k);

            UpdateBordWeergave();
        }

        private void Deselecteer()
        {
            _geselecteerdeRij = -1;
            _geselecteerdeKolom = -1;
            _beschikbareZetten.Clear();
            UpdateBordWeergave();
        }

        private void VoerZetUit(Zet zet)
        {
            _bord.DoeZet(zet);
            lstGeschiedenis.Items.Add($"{lstGeschiedenis.Items.Count + 1}. {zet}");
            lstGeschiedenis.TopIndex = lstGeschiedenis.Items.Count - 1;

            UpdateBordWeergave();
            ControleerSpelstatus();

            // Als we tegen de computer spelen en Zwart is aan de beurt, start de AI timer
            if (rbVsComputer.Checked && _bord.AanDeBeurt == Kleur.Zwart && !_bord.IsSchaakmat() && !_bord.IsPat())
            {
                lblStatus.Text = "Computer berekent zet...";
                timerComputer.Start();
            }
        }

        private void timerComputer_Tick(object sender, EventArgs e)
        {
            timerComputer.Stop();

            Zet aiZet = SchaakAI.KiesZet(_bord);
            if (aiZet != null)
            {
                VoerZetUit(aiZet);
            }
        }

        private void UpdateBordWeergave()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Button btn = _knoppen[r, k];
                    SchaakStuk stuk = _bord.Veld[r, k];

                    // Basiskleur van het veld (schaakbord patroon)
                    bool isLicht = (r + k) % 2 == 0;
                    btn.BackColor = isLicht ? _kleurLicht : _kleurDonker;

                    // Stuk symbool en tekstkleur
                    if (stuk != null)
                    {
                        btn.Text = stuk.Symbool;
                        btn.ForeColor = (stuk.Kleur == Kleur.Wit) ? Color.White : Color.Black;
                    }
                    else
                    {
                        btn.Text = "";
                    }

                    // Highlight voor geselecteerd stuk
                    if (r == _geselecteerdeRij && k == _geselecteerdeKolom)
                    {
                        btn.BackColor = _kleurSelectie;
                    }

                    // Highlight voor mogelijke zet-bestemmingen
                    if (_beschikbareZetten.Exists(z => z.NaarRij == r && z.NaarKolom == k))
                    {
                        btn.BackColor = _kleurOptie;
                    }

                    // Schaak highlight op de koning
                    if (stuk != null && stuk.Type == StukType.Koning && stuk.Kleur == _bord.AanDeBeurt && _bord.StaatSchaak(_bord.AanDeBeurt))
                    {
                        btn.BackColor = _kleurSchaak;
                    }
                }
            }

            // Labels bijwerken
            string spelerTekst = _bord.AanDeBeurt == Kleur.Wit ? "Wit" : "Zwart";
            if (rbVsComputer.Checked)
            {
                spelerTekst += (_bord.AanDeBeurt == Kleur.Wit) ? " (Jij)" : " (Computer)";
            }
            lblBeurt.Text = $"Beurt: {spelerTekst}";

            int score = _bord.Evalueer();
            string scoreTekst = score > 0 ? $"+{score}" : $"{score}";
            lblScore.Text = $"Materiaal score: {scoreTekst}";
        }

        private void ControleerSpelstatus()
        {
            if (_bord.IsSchaakmat())
            {
                Kleur winnaar = (_bord.AanDeBeurt == Kleur.Wit) ? Kleur.Zwart : Kleur.Wit;
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = $"SCHAAKMAT! {winnaar} wint!";
                MessageBox.Show($"Schaakmat! {winnaar} heeft gewonnen.", "Spel Afgelopen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_bord.IsPat())
            {
                lblStatus.ForeColor = Color.Orange;
                lblStatus.Text = "PAT (Remise)!";
                MessageBox.Show("Remise door pat. Er zijn geen legale zetten meer.", "Remise", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_bord.StaatSchaak(_bord.AanDeBeurt))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = $"{_bord.AanDeBeurt} staat SCHAAK!";
            }
            else
            {
                lblStatus.ForeColor = Color.DarkGreen;
                lblStatus.Text = "Spel bezig";
            }
        }

        private void btnNieuwSpel_Click(object sender, EventArgs e)
        {
            timerComputer.Stop();
            _bord.ResetBord();
            _geselecteerdeRij = -1;
            _geselecteerdeKolom = -1;
            _beschikbareZetten.Clear();
            lstGeschiedenis.Items.Clear();
            lblStatus.ForeColor = Color.DarkGreen;
            lblStatus.Text = "Nieuw spel gestart";
            UpdateBordWeergave();
        }

        private void btnOngedaanMaken_Click(object sender, EventArgs e)
        {
            if (timerComputer.Enabled) return;

            // Als we tegen computer spelen, draaien we 2 zetten terug (computer + speler)
            if (rbVsComputer.Checked)
            {
                _bord.MaakZetOngedaan();
                if (lstGeschiedenis.Items.Count > 0) lstGeschiedenis.Items.RemoveAt(lstGeschiedenis.Items.Count - 1);

                _bord.MaakZetOngedaan();
                if (lstGeschiedenis.Items.Count > 0) lstGeschiedenis.Items.RemoveAt(lstGeschiedenis.Items.Count - 1);
            }
            else
            {
                _bord.MaakZetOngedaan();
                if (lstGeschiedenis.Items.Count > 0) lstGeschiedenis.Items.RemoveAt(lstGeschiedenis.Items.Count - 1);
            }

            Deselecteer();
        }
    }
}
