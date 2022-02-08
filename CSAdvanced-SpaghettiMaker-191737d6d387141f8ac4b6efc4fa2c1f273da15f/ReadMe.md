Lernzielkontrolle:
------

**Überprüfung der Lerninhalte:** 
- Die Programmierkonzepte **async** und **await** anwenden können.
- Die Anwendung von Task.WhenAny(...) anwenden können.
- Die Anwendung von Task.WhenAll(...) anwenden können.

## Spaghetti Kochen
### Grundsystem

**SpaghettiMaker** Erstellen Sie die Projektstruktur von *SpaghettiMaker* und fassen Sie die einzelnen Projekte zu einer Solution zusammen. Die Struktur besteht aus den Projekten:

|Name|Beschreibung|
|---|---|
|SpaghettiMaker.Common|In diesem Projekt sind die gemeinsamen Klassen wie Pot, Water, Redwine usw. implementiert.|
|SpaghettiMaker.Logic|In diesem Projekt befinden sich die Klasse Spaghetti für die asynchrone Zubereitung des Essens.|
|SpaghettiMaker.ConApp|Eine Konsolen-Anwendung zum Starten für dei Zubereitung der Spaghetti.|

Verbinden Sie die Abhängigkeiten der einzelnen Projekte untereinander.

**Zubereitung der Spaghetti** 

In der folgenden Tabelle sind die einzelnen Schritte für die Zubereitung des Abendessens (350g Spaghetti und 200g Tomatensauce) beschrieben. Beachten Sie folgende Rahmenbedingungen:

* In einem Kochtopf können zu einem Zeitpunkt nicht mehr als 200g Spaghetti zubereitet (Kochzeit 20 sec.) werden.
* In einem Kochtopf können zu einem Zeitpunkt nicht mehr als 150g Tomatensauce zubereitet (Kochzeit 15 sec.) werden.
* Es stehen max. 3 gleiche Kochtöpfe zur Verfügung.  
* Es steht ein Kochfeld mit 4  einzelnen Feldern zur Verfügung.  

|Nr.|Name|Beschreibung|Ausgabe|Anmerkung|
|---|---|---|---|---|
|1.|*Task&lt;Redwine&gt; PourRedwineAsync()*|Gießt den Rotwein in ein Glas ein.|Pouring redwine...Redwine is already|1 sec.|
|2.|*Task&lt;Pot&gt; HeatThePotAsync()*|Erhitzt einen Topf.|Heating pop...Pot is already|10 sec.|
|3.|*Task&lt;Spaghetti&gt; CookSpaghettiAsync(Pot pot, int amount)*|Kochen der Spaghetti. 'amount' gibt die Menge in g an.|Cook spaghetti...Spaghetti are already|max. 200g|
|4.|*Task&lt;TomatoSauce&gt; CookTomatosauceAsync(Pot pot, int amount)*|Kochen der Sauce. 'amount' gibt die Menge in g an..|Cook sauce...Sauce are already|max. 150g|
|5.|*Task&lt;Toast[]&gt; ToastBreadAsync(int count)*|Toasten von Brot z.B.: 2|Toasting bread...Breads are already|10 sec. pro Toastbrot|
|6.|*Task&lt;Water&gt; PourWaterAsync()*|Gießt das Wasser in ein Glas ein.|Pouring water...Water is already|1 sec.|

**Asynchrone Zubereitung des Abendessens** 

Simulieren Sie nun in einem Programm die asynchrone Zubereitung des Essens und geben Sie die benötigte Zeit in Sekunden an. Die Zubereitungsfolge können Sie aus der Nummerierung ableiten.

## Hilfsmitteln
-   keine

## Abgabe
-   Termin: 50 min. nach der Vorbereitung

-   Klasse:

-   Name:

## Quellen
-  keine

# 
<center><strong>Viel Erfolg!</strong></center>
