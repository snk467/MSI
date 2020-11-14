wartoscsymptomu(brak, 0).
wartoscsymptomu(slaby, 0.25).
wartoscsymptomu(sredni, 0.5).
wartoscsymptomu(silny, 0.75).
wartoscsymptomu(bardzosilny, 1).

objawy(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, covid) :-
wartoscsymptomu(Katar, A), A =:= 0,
wartoscsymptomu(Kaszel, B), B >= 0.8, 
wartoscsymptomu(Goraczka, C), C >= 0.5,
wartoscsymptomu(Dreszcze, D), D >= 0.8,
wartoscsymptomu(BolGlowy, E), E >= 0.8,
wartoscsymptomu(BolMiesni, F), F >= 0.8,
wartoscsymptomu(Pocenie, G), G =:= 0,
wartoscsymptomu(BrakApetytu, H), H >= 0.6,
wartoscsymptomu(Wymioty, I), I >= 0.9,
wartoscsymptomu(ZaburzeniaWechu, J), J >= 0.6.

objawy(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu,
Wymioty, ZaburzeniaWechu, gruzlica) :-
wartoscsymptomu(Katar, A), A =:= 0,
wartoscsymptomu(Kaszel, B), B >= 0.9, 
wartoscsymptomu(Goraczka, C), C >= 0.75,
wartoscsymptomu(Dreszcze, D), D >= 0.5,
wartoscsymptomu(BolGlowy, E), E >= 0.4,
wartoscsymptomu(BolMiesni, F), F >= 0.2,
wartoscsymptomu(Pocenie, G), G =:= 0.6,
wartoscsymptomu(BrakApetytu, H), H >= 0.6,
wartoscsymptomu(Wymioty, I), I =:= 0,
wartoscsymptomu(ZaburzeniaWechu, J), J =:= 0.

srednia_chorob(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu,
Wymioty, ZaburzeniaWechu, Z) :-
wartoscsymptomu(Katar, A),
wartoscsymptomu(Kaszel, B),
wartoscsymptomu(Goraczka, C),
wartoscsymptomu(Dreszcze, D),
wartoscsymptomu(BolGlowy, E),
wartoscsymptomu(BolMiesni, F),
wartoscsymptomu(Pocenie, G),
wartoscsymptomu(BrakApetytu, H),
wartoscsymptomu(Wymioty, I),
wartoscsymptomu(ZaburzeniaWechu, J),
srednia(A, B, C, D, E, F, G, H, I, J, K), Z = K.

srednia(A, B, C, D, E, F, G, H, I, J, Z) :-
Z = ((A + B + C + D + E + F + G + H + I + J)/10).

choroba(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, slabyCOVID) :- 
objawy(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Y),
Y =:= covid,
srednia_chorob(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Z),
Z < 0.8,
write('Masz slaby covid'), nl.

choroba(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu,
Wymioty, ZaburzeniaWechu, silnyCOVID) :- objawy(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Y), Y = COVID, srednia_chorob(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Z), Z >= 0.8, write('Masz silny covid'), nl.

choroba(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu,
Wymioty, ZaburzeniaWechu, slabaGruzlica) :- objawy(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Y), Y = Gruzlica, srednia_chorob(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Z), Z < 0.5, write('Masz slaba gruzlice'), nl.

choroba(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu,
Wymioty, ZaburzeniaWechu, silnaGruzlica) :- objawy(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Y), Y = Gruzlica, srednia_chorob(Katar, Kaszel, Goraczka, Dreszcze, BolGlowy, BolMiesni, Pocenie, BrakApetytu, Wymioty, ZaburzeniaWechu, Z), Z >= 0.5, write('Masz mocna gruzlice'), nl.