![OAAD](logo.png)

### AVIOKOMPANIJA

#### Tim: OAAD

##### Članovi tima:

1. Haris Šestan
2. Anes Šero
3. Neira Krčalo

##### Opis teme:

Aviokompanija je uslužno preduzeće čiji je glavni zadatak transport putnika i robe. U jednoj takvoj kompaniji radi veliki broj ljudi koji su u dodiru s mnogo klijenata. Glavni problem korisnika je kupovina aviokarte. Svrha našeg sistema je olakšati komunikaciju između kompanije i klijenata te i između samih uposlenika kompanije. Zbog brzog načina života, korisniku je bitno da uštedi na vremenu što će mu naš sistem upravo i omogućiti. To ćemo realizovati putem desktop aplikacije pomoću koje će korisnik moći da kupi kartu te da svoje želje uskladi sa mogućnostima aviokompanije. 

##### Procesi:

- Kupac pomoću aplikacije započinje proces kupovine karte. Aplikacija se može pokrenuti ili online ili na aerodromu na šalteru aviokompanije uz pomoć uposlenika. Nakon pokretanja aplikacije, kupac bira polaznu i krajnju destinaciju, datum polaska i odlaska, klasu i tip karte (jednosmjerna ili povratna). Zatim se kupcu prikazuju svi letovi aviokompanije koji zadovaljavaju zahtjeve kupca. Nakon odabira leta, kupac popunjava formular s ličnim podacima (ime i prezime, mjesto stanovanja, e-mail adresa i broj telefona). Zatim se kupcu prikazuje e-karta sa svim postavkama koje je kupac do tada izabrao i cijena. Kupac onda na istom zaslonu bira koliko prtljaga želi ponijeti, jelo tokom leta, poziciju sjedišta u avionu i posebnu vrstu prtljaga (neobičajen prtljag). Ove opcije se pojavljuju samo ako su dostupne za određeni let. Na osnovu odabira ovih opcija mijenja se ukupna cijena karte. Nakon toga se kupcu prikazuje finalna e-karta sa svim opcijama koje je izabrao. Kupac zatim popunjava podatke o kreditnoj kartici i plaća kartu. Kupac u bilo kom momentu do tada može odustati od kupovine. Kupcu se po uspješnom plaćanju šalje mail sa e-kartom i podacima o letu. Ukoliko je kupac kupio kartu na šalteru odmah mu se izdaje karta.

- Administrator unutar aplikacije može dodavati i brisati letove, mijenjati specifikacije letova, vidjeti sve rezervacije karata, pratiti ispravnost podataka i odobravati zahtjeve za posebnu vrstu prtljaga.

##### Funkcionalnosti:

- mogućnost unosa krajnje i polazne destinacije, datum odlaska i polaska
- mogućnost odabira klase i tipa karte
- mogućnost odabira leta
- mogućnost unosa ličnih podataka
- mogućnost odabira dodatnih opcija
- mogućnost unosa podataka za plaćanje 
- mogućnost mijenjanja detalja o letovima
- mogućnost prihvatanja ili odbijanja posebnih zahtjeva
- mogućnost pregleda svih kupaca

##### Akteri:

**Kupac** - osoba koja kupuje aviokartu aviokompanije
**Uposlenik** - osoba koja komunicira sa kupcem i prosljeđuje informacije supervizoru
**Supervizor** - osoba koja nadgleda rad sistema, odobrava posebne zahtjeve, vrši update letova

##### Help (upute za korištenje aplikacije):

Moguć je login kao admin i kao uposlenik. Nakon logovanja kao admin, dolazi se na meni sa opcijama: Avioni, Letovi, Uposlenici. Biranjem stavke Avioni, otvara se novi prozor gdje se mogu dodavati novi avioni i brisati avioni. Odabirom stavke Uposlenici u meniju, otvara se novi prozor gdje se mogu dodavati i brisati uposlenici. Odabirom stavke Letovi u meniju, otvara se novi prozor, gdje se mogu dodavati i brisati letovi. Dodavanje leta podrazumijeva i dodavanje aviona letu, koje se vrši odabirom aviona sa ponuđene liste. Moguće je i odabrati datum i vrijeme polaska i dolaska. Ukoliko se korisnik loguje kao uposlenik, moguće je sa menija odabrati stavku Rezervacije. Otvara se novi prozor za dodavanje i brisanje rezervacija. Nakon unošenja mjesta polaska i dolaska, klikom na Dugme Osvježi, pojavljuju se svi dostupni letovi s tim destinacijama. Osim popunjavanja podataka o kupcu i biranju leta, moguće je i uračunati popust klikom na checkbox, kao i mijenjanje klase klikanjem na dugme "Mijenjaj klasu". Klikom na dugme Izračunaj, prikazuje se ukupna cijena rezervacije sa svim odabranim parametrima. Sva brisanja u svim menijima se uvijek vrše prethodnim odabirom stavke sa liste. Također, svaki prozor sadrži Nazad tipku, kojom se vraća na prethodni prozor.";

##### Zaključno:
* Validacije su ispoštovane u svim klasama. Neke od tih klasa su:
  * https://github.com/ooad-2015-2016/OAAD/blob/master/ProjekatAviokompanija/Aviokompanija/ViewModels/PocetnaViewModel.cs
  * https://github.com/ooad-2015-2016/OAAD/blob/master/ProjekatAviokompanija/Aviokompanija/ViewModels/AvioniViewModel.csž
  * https://github.com/ooad-2015-2016/OAAD/blob/master/ProjekatAviokompanija/Aviokompanija/ViewModels/AdminLetoviViewModel.cs
* Implementirano je prilagođavanje interfejsa na Windows Phone:
  * https://github.com/ooad-2015-2016/OAAD/blob/master/ProjekatAviokompanija/Aviokompanija/Views/AdministratorMeni.xaml (Napomena: Nije prakazano na klipu jer jer korišten Windows 10 Game Capture koji ne toleriše promjenu veličine prozora.)
* Nije korišten eksterni uređaj.
* Aplikacija koristi lokalnu SQLlite bazu.
* Video aplikacije:
  * https://www.dropbox.com/s/d4f4zag13mjto1z/Aviokompanija.mp4?dl=0