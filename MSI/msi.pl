wartoscsymptomu(brak, 0).
wartoscsymptomu(slaby, 0.25).
wartoscsymptomu(sredni, 0.5).
wartoscsymptomu(silny, 0.75).
wartoscsymptomu(bardzosilny, 1).

zapytaj_katar :- writeln('Jaki masz katar?'), read(A), wartoscsymptomu(A, X), asserta(katar(X)).
zapytaj_kaszel :- writeln('Jaki masz kaszel?'), read(A), wartoscsymptomu(A, X), asserta(kaszel(X)).
zapytaj_goraczka :- writeln('Jaka masz goraczke?'), read(A), wartoscsymptomu(A, X), asserta(goraczka(X)).
zapytaj_dreszcze :- writeln('Jakie masz dreszcze?'), read(A), wartoscsymptomu(A, X), asserta(dreszcze(X)).
zapytaj_bol_glowy :- writeln('Jaki masz bol glowy?'), read(A), wartoscsymptomu(A, X), asserta(bol_glowy(X)).
zapytaj_bol_miesni :- writeln('Jaki masz bol miesni?'), read(A), wartoscsymptomu(A, X), asserta(bol_miesni(X)).
zapytaj_pocenie :- writeln('Jakie masz pocenie?'), read(A), wartoscsymptomu(A, X), asserta(pocenie(X)).
zapytaj_brak_apetytu :- writeln('Jaki masz brak apetytu?'), read(A), wartoscsymptomu(A, X), asserta(brak_apetytu(X)).
zapytaj_wymioty :- writeln('Jakie masz wymioty?'), read(A), wartoscsymptomu(A, X), asserta(wymioty(X)).
zapytaj_zaburzenia_wechu :- writeln('Jakie masz zaburzenia wechu?'), read(A), wartoscsymptomu(A, X), asserta(zaburzenia_wechu(X)).

srednia(A, B, C, D, E, F, G, H, I, J, Z) :- Z = ((A + B + C + D + E + F + G + H + I + J)/10).

choroba(covid) :-
katar(Katar), Katar =:= 0,
kaszel(Kaszel), Kaszel >= 0.75,
goraczka(Goraczka), Goraczka >= 0.5, 
dreszcze(Dreszcze), Dreszcze >= 0.8,
bol_glowy(BolGlowy), BolGlowy >= 0.8,
bol_miesni(BolMiesni), BolMiesni >= 0.8,
pocenie(Pocenie), Pocenie =:= 0,
brak_apetytu(BrakApetytu), BrakApetytu >= 0.6,
wymioty(Wymioty), Wymioty >= 0.9,
zaburzenia_wechu(ZaburzeniaWechu), ZaburzeniaWechu >= 0.6,
srednia(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Nasilenie),
(Nasilenie >= 0.8 -> writeln('Masz silny covid') ; writeln('Masz slaby covid.')).

choroba(gruzlica) :-
katar(Katar), Katar =:= 0,
kaszel(Kaszel), Kaszel >= 0.9,
goraczka(Goraczka), Goraczka >= 0.75, 
dreszcze(Dreszcze), Dreszcze >= 0.5,
bol_glowy(BolGlowy), BolGlowy >= 0.4,
bol_miesni(BolMiesni), BolMiesni >= 0.2,
pocenie(Pocenie), Pocenie >= 0.6,
brak_apetytu(BrakApetytu), BrakApetytu >= 0.6,
wymioty(Wymioty), Wymioty =:= 0,
zaburzenia_wechu(ZaburzeniaWechu), ZaburzeniaWechu =:= 0,
srednia(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Nasilenie),
(Nasilenie >= 0.5 -> writeln('Masz silna gruzlice') ; writeln('Masz slaba gruzlice.')).

sprawdzchorobe(X) :- 
zapytaj_katar,
zapytaj_kaszel,
zapytaj_goraczka,
zapytaj_dreszcze,
zapytaj_bol_glowy,
zapytaj_bol_miesni,
zapytaj_pocenie,
zapytaj_brak_apetytu, 
zapytaj_wymioty,
zapytaj_zaburzenia_wechu,
choroba(X), !.