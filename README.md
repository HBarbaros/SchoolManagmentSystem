**--------------** HOGWARTS MAGISKA SKOLHANTERINGSSYSTEM **--------------**

Målet med detta projekt är att utveckla ett skolhanteringssystem som passar de unika behoven hos Hogwarts School of Witchcraft and Wizardry. Systemet kommer att hantera elevinformation, kurser, lärare, huspoäng, och betyg. Systemet är enbart tänkt att användas av skolpersonal.

**--------------** SYSTEMET SKA KORTFATTAT KUNNA **--------------**
Registrera elever och lärare.
Hantera elevkurser och tilldela schema till elever.
Administrera betyg och huspoäng.
Visa elevprofiler.
Visa ett enkelt användargränssnitt i konsolen där funktionaliteten kan användas.
Systemet är enbart tänkt att användas av skolpersonal.

**--------------** FUNKTIONSKRAV **--------------**
[x] Registrera ny elev (med namn, ålder och hus) P
[x] Elev: Id, namn, ålder, hus P
[x] Visa lista över alla elever och deras hus P
[x] Registrera ny lärare och tilldela ämne P
[x] Lärare: Id, namn, ämne P
[x] Visa lista över alla lärare och deras ämnen P
[x] Skapa nya kurser (t.ex. Trolldrycker, Försvar mot svartkonst) P
[x] Registrera betyg för elever i kurser P
[x] Visa elevprofiler med fullständig information (namn, ålder, hus, kurser, betyg, poäng) P
[x] Ge och dra av huspoäng P
[x] Visa aktuell husställning och totalpoäng för varje hus P
[x] Programmet skall hantera felaktig inmatning så att det inte kan krascha på grund av användarfel P
[x] Filterfunktion för att snabbt hitta elever och lärare. P
[x] Visa lärare och elevinformation med en egen override av ToString()-metoden 

**--------------** REGLER **--------------**
[] Det skall inte gå att registrera en elev i samma kurs två gånger P
[] En elev får inte gå mer än 5 kurser samtidigt P
[] En elev som erhåller mer än 500 poäng för sitt hus belönas automatiskt P
[x] Minst 11 år gammal för att skrivas in i skolan. P