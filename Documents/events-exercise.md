# 14 Events

## 1. class Persoon

Maak een class Persoon met een event dat geraised wordt als de leeftijd verandert.  
Gebruik (zoveel mogelijk) het [Standard .NET event pattern](https://learn.microsoft.com/en-us/dotnet/csharp/event-pattern).

Maak een class **Persoon** (in een nieuwe class library) met daarin:

- Properties:
  - `Naam` (get+set)
  - `Leeftijd` (get+set)
- Methods:
  - `Verjaar()`
- Events:
  - `LeeftijdChanged`

In de EventHandling methode moet de volgende data beschikbaar zijn:

- naam
- oude leeftijd
- nieuwe leeftijd

Test dat het event afgaat als de `Leeftijd` property gewijzigd wordt.
Test dat de juiste data beschikbaar komt. Bijvoorbeeld:
naam=Kees, oude leeftijd=50, nieuwe leeftijd=25

Test dat het event afgaat als de `Verjaar()` methode wordt aangeroepen.
Test dat de juiste data beschikbaar komt. Bijvoorbeeld:
naam=Kees, oude leeftijd=57, nieuwe leeftijd=58

_"Gefeliciteerd, Kees, je bent nu al 58, ik weet het nog goed dat je 57 was."_

<div style="font-size: 1.3em; font-weight: 600; padding: 0.4em; margin-bottom: 1em; border: 2px solid #cc0000; background: #ff6666; color: #cc0000;">Rode Piste (Ha)</div>

## 2 class Werknemer

Maak een class Werknemer (die afleidt van Persoon) met daarin:

- Properties:
  - Salaris

Zorg dat net **voordat** het leeftijdchanged event afgaat, ook het salaris wordt aangepast (met 1% per jaar verschil)

<div style="font-size: 1.3em; font-weight: 600; padding: 0.4em; margin-bottom: 1em; border: 2px solid #cc0000; background: #ff6666; color: #cc0000;">Rode Piste (Ha)</div>

## Zorg voor nette code

... maar misschien had je dit gelijk al goed gedaan:

1. Test dat de goede 'sender' wordt meegegeven aan het event.
2. Gebruik de protected virtual OnLeeftijdChanged(...) om het salaris aan te passen als de leeftijd verandert.
3. Gegeven een Salaris van € 1000,-
   Als Leeftijd +=3
   Dan is het Salaris € 1030,30
4. Zorg dat de Naam niet in de EventArgs zit – De Naam heeft niet direct met het LeeftijdChanged event te maken, maar in de EventHandling methode willen we wel de naam beschikbaar hebben.
5. Zorg dat het Salaris alleen in de class Werknemer aan te passen is (private set)
<div style="font-size: 1.3em; font-weight: 600; padding: 0.4em; margin-bottom: 1em; border: 2px solid #000a00; background: #b3b3b3; color: #000a00;">Zwarte Piste (Ri)</div>

## 3. class PersoonWatcher:

Maak een class PersoonWatcher met daarin:

- Constructor:
  - PersoonWatcher (Persoon toWatch, Action<int> callback)

Elke keer als de leeftijd van de persoon verandert, dan roept de Persoonwatcher zijn callbackfunctie aan met de nieuwe leeftijd.

```cs
// Arrange
Persoon evert = new Persoon("Evert 't Reve", 33);
bool callbackHasBeenCalled = false;
Action<int> callback = (leeftijd) => { callbackHasBeenCalled = true; }
PersoonWatcher peter = new PersoonWatcher(evert, callback);

// Act
evert.Verjaar();

// Assert
Assert.Istrue(callbackHasBeenCalled);
```

In de callback-functie is, via het int-argument, de nieuwe leeftijd beschikbaar.

In Sommige libraries zijn er bij een gebeurtenis twee events:

1. Het ..ing-event, bij voorbeeld het Switching event, of het LeeftijdChanging event
2. Het ..ed-event, bijvoorbeeld het Switched event, of het LeeftijdChanged event
   Het eerste event treedt op VOORdat de gebeurtenis plaats vindt, en het tweede NAdat de gebeurtenis heeft plaatsgevonden.
   Het idee daarbij is dat het event gecanceled kan worden d.m.v. het ..ing event. Je kunt je abonneren op het ..ing event en dan voorkomen dat het event daadwerkelijk plaats vindt.

Bedenk een manier om dit te implementeren.

- Wat moet je doen in de event source om dit mogelijk te maken?
- Wat moet je doen in de event listener om dit mogelijk te maken?
