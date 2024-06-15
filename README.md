# FoiFitness

## Opis domene
Aplikacija će primarno biti namjenjena za fitnes entuzijaste i početnike u fitnesu. Aplikacija će omogućavati generiranje te izmjenu plana treninga i kreiranje vlastitog plana treninga. Omogućiti će računanje potrebnog dnevnog unosa kalorija za korisnikov fitnes cilj te praćenje korisnikovog napretka uz grafičke prikaze istog.

## Specifikacija projekta

Oznaka | Naziv | Kratki opis | Odgovorni član tima
------ | ----- | ----------- | -------------------
F01 | Prijava i registracija korisnika | Sustav će omogućiti registraciju i prijavu korisnika što će omogućiti aplikaciji da kasnije personalizira korisnikov doživljaj u aplikaciji, te da samo on ima pristup svojim podacima | Tim Juić
F02 | Unos tjelesnih podataka i fitnes planova | Nakon registracije, sustav će tražiti unos podataka kao što su tjelesna težina, visina, tjelesna aktivnost te fitnes ciljevi | Tim Juić
F03 | Pregled postojećih fitnes vježbi | Sustav će omogućiti pregled velikog broja fitnes vježbi koje postoje, za svaku od kojih će se prikazivati naslov, slika ili poveznica na video te opis vježbe | Matija Tomašić
F04 | Dodavanje vlastitih vježbi | Aplikacija će omogućiti korisniku dodavanje vlastitih vježbi na serversku bazu podataka  | Matija Kljaić
F05 | Ručno kreiranje vlastitog plana treninga | Korisnik će moći ručno izraditi vlastiti tjedni plan treninga dodavajući postojeće fitnes vježbe u aplikaciji ili kreiranjem vlastite/nove vježbe i sustav će generirati PDF i poslati korisniku na mail | Matija Kljaić
F06 | Automatsko generiranje personaliziranog plana treninga | Aplikacija će imati i mogućnost automatskog generiranja plana treninga za korisnika baziranog na njegovim fitnes ciljevima, tjelesnoj težini ili preferencijama. Generirani plan se može spremiti u MS Word format. Omogućiti će se slanje plana treninga na korisnikov mail ovisno o postavci želi li korisnik primati na mail ili ne | Tim Juić
F07 | Prikaz napretka u obliku grafikona | Sustav će imati mogućnost generirati grafičke prikaze napredka korisnika s obzirom na unesene podatke na prošlim treninzima. Grafički prikazi sadržavali bi napredak s obzirom na snagu, prikaz gubitka / dobivanja na tjelesnoj težini kroz određeno vrijeme | Matija Tomašić
F08 | Kalkulator Bazalne stope metabolizma | Aplikacija će imati mogućnost računanja bazalne stope metabolizma (Potrebnog unosa kalorija s obzirom na visinu, težinu, tjelesnu aktivnost i fitness ciljeve) | Ivo Rošić
F09 | Unos konzumiranih kalorija u danu | Aplikacija će korisniku omogućiti unos koliko je kalorija konzumirao u danu, dodatno, moći će se i unositi konzumirane namirnice i njihova količina, na temelju čega će aplikacija izračunati broj unesenih kalorija | Ivo Rošić
F10 | Kalendar s danima treniranja | Aplikacija će prikazivati kalendar sa danima treniranja / odmaranja, vježbama koje su zakazane / napravljene taj dan, te unesenih kalorija | Ivo Rošić
F11 | Mogućnost izmjene korisničkih podataka i uređivanje profila | Sustav će omogućavati izmjenu korisničkih podataka napisanih tokom registracije kao što su lozinka profila, korisničko ime, profil slika | Matija Kljaić
F12 | Slanje podsjetnika na email | Aplikacija će imati mogućnost slanja povremenih podsjetnika na trening, podsjetnik o preostalom unosu kalorija, obavijesti o napretku u treniranju, ova funkcionalnost će biti implementirana u sklopu Windows servisa, pokreće se kako je korisnik definirao.  | Matija Tomašić


## Tehnologije i oprema

Tehnologije koje će se koristiti u izgradnji aplikacije biti će primarno .NET Framework. Za bazu podataka bit će korišten Microsoft SQL Server Management Studio. Za verzioniranje softwarea koristit će se program Git i GitHub, Te GitHub wiki za pisanje tehničke i projektne dokumentacije
