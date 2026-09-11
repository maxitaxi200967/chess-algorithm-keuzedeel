# User Stories — Keuzedeel Verdieping Software (VS_PF1_D1-K1)

Dit document bevat de officiële User Stories voor het project **Schaakalgoritme Prototype & Leertraject**. Deze User Stories staan ook als taken op [GitHub Issues](https://github.com/maxitaxi200967/chess-algorithm-keuzedeel/issues).

---

## 📌 Fase 1: Vóór het coderen (Onderzoek & Planning)

### [US-01] Onderzoek en Softwarekeuze (Opdracht 1)
* **Als** student / beginnend softwareontwikkelaar,  
* **Wil ik** softwarepakketten en programmeertalen (bijv. Python vs C# vs C++) vergelijken op basis van criteria,  
* **Zodat ik** een beargumenteerde keuze kan maken die aansluit op mijn toekomstige beroep.  
* **Acceptatiecriteria:**
  - [ ] Beroepsbeeld beschreven (bijv. Software Developer / AI Developer).
  - [ ] Minimaal 3 criteria opgesteld (leersnelheid, performance, documentatie/community).
  - [ ] Vergelijkingstabel van minstens 2 tot 3 opties.
  - [ ] Beargumenteerde definitieve keuze vastgelegd in een verslag.
* **GitHub Issue:** [#6](https://github.com/maxitaxi200967/chess-algorithm-keuzedeel/issues/6)

### [US-02] Goedkeuring Opdrachtgever & Gespreksverslag (Opdracht 2)
* **Als** ontwikkelaar,  
* **Wil ik** mijn gekozen software voorleggen aan mijn leidinggevende/docent,  
* **Zodat ik** formele goedkeuring en draagvlak heb voor mijn leertraject.  
* **Acceptatiecriteria:**
  - [ ] Korte pitch gehouden met argumenten voor de gekozen taal/technologie.
  - [ ] Gespreksverslag geschreven met reactie en akkoord van de leidinggevende/docent.
  - [ ] Bewijsstuk (getekend verslag of opname) toegevoegd aan portfolio.
* **GitHub Issue:** [#1](https://github.com/maxitaxi200967/chess-algorithm-keuzedeel/issues/1)

### [US-03] Leertraject, Nulmeting en Geaccordeerde Planning (Opdracht 3)
* **Als** lerende ontwikkelaar,  
* **Wil ik** een nulmeting doen, concrete SMART-leerdoelen bepalen en een weekplanning maken,  
* **Zodat ik** gestructureerd en meetbaar nieuwe kennis opdoe.  
* **Acceptatiecriteria:**
  - [ ] Nulmeting gedaan (wat kan ik al, wat is nieuw, wat is mijn leerstijl).
  - [ ] 3 tot 5 SMART-leerdoelen opgesteld met bronvermelding.
  - [ ] Chronologische weekplanning gemaakt inclusief ureninschatting.
  - [ ] **Officiële handtekening/akkoord** van de docent/begeleider op de planning gezet.
* **GitHub Issue:** [#7](https://github.com/maxitaxi200967/chess-algorithm-keuzedeel/issues/7)

---

## 📌 Fase 2: Tijdens het coderen (Prototype & Procesbewijs)

### [US-04] Prototype Voorstel en Datastructuur Schaakbord (Opdracht 4 - Basis)
* **Als** gebruiker / ontwikkelaar,  
* **Wil ik** een 8x8 schaakbord zien met de beginopstelling van de stukken,  
* **Zodat** het spelbord duidelijk en speelbaar is.  
* **Acceptatiecriteria:**
  - [ ] Prototype-voorstel geschreven en goedgekeurd vóór de bouw.
  - [ ] Datastructuur (bijv. 2D array / matrix) die 64 velden representeert.
  - [ ] Beginopstelling van witte en zwarte stukken correct ingeladen.
  - [ ] Weergave in console of eenvoudige UI.
* **GitHub Issue:** [#8](https://github.com/maxitaxi200967/chess-algorithm-keuzedeel/issues/8)

### [US-05] Legale zetten genereren voor stukken (Opdracht 4 - Spelregels)
* **Als** speler,  
* **Wil ik** dat het programma valideert of een zet volgens de schaakregels legaal is,  
* **Zodat** er geen ongeldige zetten gedaan kunnen worden.  
* **Acceptatiecriteria:**
  - [ ] Genereren van geldige zetten voor geselecteerde stukken (pion, toren, loper, paard, dame, koning).
  - [ ] Validatie dat stukken niet over elkaar heen springen (m.u.v. paard) of buiten het bord gaan.
  - [ ] Speler kan een zet invoeren en het bord update correct.
* **GitHub Issue:** [#2](https://github.com/maxitaxi200967/chess-algorithm-keuzedeel/issues/2)

### [US-06] Schaakalgoritme - Minimax Beslissingslogica (Opdracht 4 - Het Algoritme)
* **Als** speler,  
* **Wil ik** tegen een geautomatiseerde tegenstander spelen die zelfstandig een zet berekent en uitvoert,  
* **Zodat** ik het prototype kan testen tegen een computer.  
* **Acceptatiecriteria:**
  - [ ] Evaluatiefunctie die bordwaarde/materiaal berekent (Pion=1, Paard=3, Loper=3, Toren=5, Dame=9).
  - [ ] Minimax-algoritme dat minimaal 1 tot 2 zetten diep zoekt.
  - [ ] Computer selecteert automatisch de zet met de hoogste score en voert deze uit.
* **GitHub Issue:** [#3](https://github.com/maxitaxi200967/chess-algorithm-keuzedeel/issues/3)

### [US-07] Wekelijks Logboek & Bewijslast verzamelen (Opdracht 3 & 4 - Proces)
* **Als** examenkandidaat,  
* **Wil ik** wekelijks mijn voortgang, foutoplossingen en bewijslast vastleggen,  
* **Zodat ik** kan aantonen dat ik zelfstandig heb gewerkt en planningen kan bijsturen.  
* **Acceptatiecriteria:**
  - [ ] Wekelijkse logboek-entries (uren, wat gedaan, wat geleerd, knelpunten).
  - [ ] Screenshots van code, errors en werkende onderdelen toegevoegd.
  - [ ] Eventuele planningswijzigingen (oude vs. nieuwe planning) gedocumenteerd.
* **GitHub Issue:** [#4](https://github.com/maxitaxi200967/chess-algorithm-keuzedeel/issues/4)

---

## 📌 Fase 3: Na het coderen (Oplevering & Examen)

### [US-08] Prototype Demo Screencast & Examenportfolio (Afronding & Examen)
* **Als** examenkandidaat,  
* **Wil ik** een video-demonstratie maken en alle documenten bundelen in een portfolio,  
* **Zodat** de examinatoren mijn resultaat kunnen beoordelen voor het STARRT-eindgesprek.  
* **Acceptatiecriteria:**
  - [ ] Screencast (3-5 min) opgenomen van het werkende prototype en toelichting op code.
  - [ ] Alle bewijsstukken voor Opdracht 1 t/m 4 geordend in het portfolio.
  - [ ] STARRT-vragen voorbereid voor de mondelinge verdediging.
* **GitHub Issue:** [#5](https://github.com/maxitaxi200967/chess-algorithm-keuzedeel/issues/5)