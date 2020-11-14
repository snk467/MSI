srednia(A, B, C, D, E, F, G, H, I, J, Z) :- Z is ((A + B + C + D + E + F + G + H + I + J)/10).

choroba(covid, Nasilenie) :-
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
srednia(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Nasilenie).

choroba(gruzlica,Nasilenie) :-
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
srednia(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Nasilenie).

sprawdzchorobe(Choroba, Nasilenie) :- 
choroba(Choroba, Nasilenie), !.