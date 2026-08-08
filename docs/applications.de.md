# Anwendungen & Sequenz

Jede Anwendung Ihres Profils wird als **Karte** dargestellt.<br>
Diese Seite beschreibt, wie Sie Anwendungen hinzufügen, wie Sie sie konfigurieren und wie Sie die **Startsequenz** lesen.

---

## Eine Anwendung hinzufügen

Klicken Sie im Raster auf **Anwendung hinzufügen**. Es gibt zwei Modi:

=== "Installierte Anwendungen"

    Listet die bereits installierten Programme auf (über die Windows-Registrierung).<br>
    Suchen Sie die Anwendung und wählen Sie sie aus: Name, Symbol und Pfad werden automatisch übernommen.

    ![Modus „Installierte Anwendungen“](assets/add-app-installed.png)

    !!! note "Die Liste ist bewusst gefiltert"
        Damit sie übersichtlich bleibt, blendet die Liste Programme ohne Bezug zur
        Fliegerei aus (Treiber und Systemwerkzeuge, Browser, Spiele, Launcher usw.)
        und verbirgt Anwendungen, die **bereits im aktiven Profil enthalten** sind.
        Eine ganz normal installierte Anwendung, die dort nicht auftaucht – oder ein
        **portables** Programm – lässt sich immer über den Tab **Durchsuchen**
        hinzufügen.

=== "Durchsuchen"

    Geben Sie den Pfad einer `.exe` an oder klicken Sie auf **Durchsuchen…**, um sie auszuwählen: Name und Symbol werden automatisch übernommen.

    ![Modus „Durchsuchen“](assets/add-app-browse.png)

    !!! note "Verwendung"
        Dieser Modus ist für **portable** (nicht installierte) oder nicht erkannte Anwendungen gedacht, die nicht in der Windows-Registrierung stehen.

Der Hinzufügen-Dialog enthält anschließend die **Startargumente**, den **Auslöser**, die **Verzögerung** und die Option **Minimiert starten** – alles auch nach dem Hinzufügen noch änderbar.

---

## Aufbau einer Karte

![Karte einer Anwendung](assets/app-card.png)

**Oben** finden Sie die Informationen zur Anwendung:

- das Symbol der Anwendung
- ihren **Namen**
- ihren **Pfad**
- ihre **Argumente** (unter dem Pfad, sofern definiert).

Rechts der **Status-Badge** (sichtbar während der Ausführung) und das Menü **:material-dots-horizontal:**.

**Unten die Steuerungsleiste**, mit einem Klick erreichbar:

| Steuerung                                       | Funktion                                                                                                       |
| ----------------------------------------------- | ---------------------------------------------------------------------------------------------------------------- |
| :material-play: **Simstart**                    | Startet beim Start des Simulators.                                                                             |
| :material-airplane: **Startbereit**             | Startet, sobald der Bildschirm **Startbereit** angezeigt wird.                                                 |
| :material-arrow-collapse: **Minimiert starten** | Startet die Anwendung in einem minimierten Fenster.<br>*Nur sichtbar, wenn ein Autostart gewählt ist*          |
| :material-square: **Autostopp**                 | Schließt die Anwendung, wenn der Simulator beendet wird.<br>*Automatisch aktiviert und gesperrt beim Start „Startbereit“* |
| :material-minus::material-plus: **Verzögerung** | Wartezeit vor dem Start dieser Anwendung, abhängig vom Startmodus.                                             |

Dieselben Einstellungen finden Sie auch im Bearbeiten-Dialog.

### Die beiden Start-Auslöser

Das ist die nützlichste Einstellung von MFSAppsControl.<br>
Die beiden linken Schaltflächen (:material-play: und :material-airplane:) bilden eine **Entweder-oder-Auswahl**: Wenn Sie die eine aktivieren, wird die andere deaktiviert, und ein erneuter Klick auf die aktive Schaltfläche **schaltet den automatischen Start ganz ab**.

|                          | :material-play: **Simstart**                | :material-airplane: **Startbereit**            |
| ------------------------ | ------------------------------------------- | ---------------------------------------------- |
| **Wird ausgelöst**       | wenn der **Prozess** von MSFS erkannt wird  | wenn Ihr **Flugzeug in der Welt erscheint**    |
| **Erkennung**            | durch **Prozessüberwachung**                | über **SimConnect**                            |
| **Die Verzögerung läuft ab** | dem Start des Simulators                | dem Bildschirm „Startbereit“                   |
| **Typischerweise für**   | Navigraph, vPilot, ein Hardware-Werkzeug    | REX Atmos, FS2Crew, Flugzeug-Tools             |

!!! tip "Wie wählen Sie richtig?"
    Stellen Sie sich die richtigen Fragen:<br>
    *„Muss diese Anwendung bereitstehen, bevor ich mit dem Fliegen beginne?“*<br>
    *„Funktioniert diese Anwendung auch ohne den Simulator?“*<br>
    *„Stört diese Anwendung den Betrieb meines Simulators nicht?“*<br>

    - **Ja** → Simstart. Sie muss bereitstehen, bevor der Flug beginnt.
    - **Nein** → Startbereit. Es bringt nichts, sie schon vor dem Flug laufen zu lassen.

**Was Sie zum Start „Startbereit“ wissen sollten**

!!! info "Der Autostopp ist gesperrt"
    Eine „Startbereit“-Anwendung schließt sich **immer** mit dem Simulator: Die Schaltfläche :material-square: ist in aktiver Stellung gesperrt.<br>
    Eine Anwendung, die für den Flug gestartet wurde, hat keinen Grund, den Simulator zu überleben.

!!! info "Ausgelöst wird auf dem Bildschirm „Startbereit“"
    Konkret geschieht das direkt nach dem Laden eines Fluges, sobald der Bildschirm „Startbereit“ angezeigt wird.
    Es ist die einzige zuverlässige Möglichkeit, einen Flug „sauber“ zu erkennen.

!!! warning "SimConnect muss verbunden sein"
    **Dieser Auslöser beruht auf SimConnect.**<br>
    Wenn der SimConnect-Status nicht **grün** ist (SimConnect verbunden), starten die „Startbereit“-Anwendungen nicht.<br>
    Bleibt die Verbindung längere Zeit aus, wechselt der Status auf **rot** („SimConnect nicht verfügbar“). → [Fehlerbehebung](faq.md)

### Der automatische Stopp

Die Schaltfläche :material-square: **Autostopp** schließt die Anwendung, wenn der Simulator beendet wird.<br>
Sie ist **unabhängig** vom Start: Sie können also eine Anwendung von Hand oder auf anderem Weg starten und sie trotzdem von MFSAppsControl mit dem Simulator schließen lassen.

Das Schließen erfolgt **sauber**: MFSAppsControl versucht zuerst, die Anwendung so zu schließen, als würden Sie auf das Kreuz klicken, lässt ihr einige Sekunden Zeit, ihre Sitzung zu beenden, und erzwingt das Beenden erst als letztes Mittel.<br>
Anwendungen, die sich sauber abmelden müssen (zum Beispiel Active Sky), werden so korrekt behandelt.

### Minimiert starten

Die Option :material-arrow-collapse: **Minimiert starten** startet die Anwendung in einem **minimierten Fenster** – praktisch, wenn sie nicht im Vordergrund angezeigt werden muss.

Die Schaltfläche erscheint nur, wenn ein **automatischer Start** gewählt ist.

!!! note
    Manche Anwendungen holen ihr Fenster einige Sekunden nach dem Start selbst in den Vordergrund.<br>
    MFSAppsControl versucht mehrere Sekunden lang, sie zu minimieren, doch einige wenige Programme widersetzen sich.

### Die Verzögerung

Die **Verzögerung** ist die Wartezeit vor dem Start der Anwendung, **ab ihrem Auslöser**. Damit können Sie die Starts **zeitlich entzerren**.

- Einstellbar von **0 bis 600 Sekunden** (10 Minuten)
- Die Schaltflächen **−** / **+** ändern den Wert in Schritten von **5 s**; Sie können den Wert auch direkt **eingeben**
- Die Verzögerung ist **ausgegraut**, wenn kein automatischer Start gewählt ist
- Während eines Fluges zeigt sie ein **Schloss** :material-lock: – die Konfiguration ist gesperrt

!!! tip "Jeder Auslöser hat seine eigene Sequenz"
    30 s Verzögerung bei einer „Simstart“-Anwendung = 30 s nach dem Start von MSFS. <br>
    30 s Verzögerung bei einer „Startbereit“-Anwendung = 30 s nach dem Erscheinen des Bildschirms „Startbereit“.

### Die Startargumente

Optionales Feld: die Kommandozeilenparameter, die an die ausführbare Datei übergeben werden, durch Leerzeichen getrennt (z. B. `--auto`).<br>
Sie werden auf der Karte unter dem Pfad angezeigt.

Die Anwendung wird immer aus **ihrem eigenen Installationsordner** heraus gestartet.

---

## Die Zeitleiste

Die Mitte des Bandes zeigt die **Startsequenz**: welche Anwendung zu welchem Zeitpunkt startet.<br>
Sie erscheint, sobald mindestens eine Anwendung auf automatischen Start gestellt ist.

![Die Zeitleiste der Startsequenz](assets/timeline-dual.png)

Jeder Block steht für einen Startzeitpunkt und enthält die Symbole der betroffenen Anwendungen.<br>
Fahren Sie mit der Maus über einen Block, um die Namen und ihren Status zu sehen.

Da die beiden Auslöser voneinander unabhängig sind, zeigt die Zeitleiste **zwei Spuren**:

- eine Spur für „Simstart“
- eine Spur für „Startbereit“.

### Zwei mögliche Anzeigestile

Unter [Optionen](options.md) → **Darstellung** → **Sequenzstil** wählen Sie die Darstellung, die Ihnen am meisten zusagt:

- **Doppelt** — zwei getrennte Spuren, eine je Sequenz
- **Mono** — eine einzige Spur, in der Mitte in die beiden Sequenzen geteilt

## Die Statusanzeigen einer Karte

Der **Rahmen** der Karte und ihr **Badge** zeigen den Zustand der Anwendung an.

|                     Badge                     | Rahmen | Bedeutung                                                             |
| :-------------------------------------------: | :----: | ---------------------------------------------------------------------- |
| ![Badge Countdown](assets/badge-countdown.png) |  blau  | Die Verzögerung läuft.<br>Der Badge zeigt die verbleibenden Sekunden. |
|   ![Badge Läuft](assets/badge-running.png)     |  grün  | Der Prozess ist gestartet.                                            |
|   ![Badge Fehler](assets/badge-error.png)      |  rot   | Der Start ist fehlgeschlagen.                                         |
|                 *kein Badge*                  |        | Anwendung gestoppt/inaktiv.                                           |

**Fahren Sie mit der Maus über einen Badge**, um mehr zu erfahren: Der Fehler-Badge nennt die Ursache (ausführbare Datei nicht gefunden, Administratorrechte erforderlich…), und der grüne Badge zeigt die **PID** des Prozesses.

### Einen Start abbrechen

Während eines Countdowns erscheint neben dem Badge ein Kreuz **✕**. Damit brechen Sie **den Start dieser einen Anwendung** ab. Alle anderen setzen ihre Sequenz normal fort.

### Außerhalb des Programms gestartete Anwendungen

MFSAppsControl prüft regelmäßig, welche Prozesse tatsächlich laufen.<br>
Wenn Sie eine konfigurierte Anwendung selbst starten (oder schließen), aktualisiert sich ihre Karte.<br>
Sie wechselt auf **LÄUFT grün**, ohne dass MFSAppsControl sie gestartet hätte.

In diesem Fall zeigt der Tooltip des Badges die **PID** des übernommenen Prozesses:

```
Prozess aktiv
PID 24680
```

## Eine Anwendung bearbeiten oder steuern

Öffnen Sie das Menü **:material-dots-horizontal:** der Karte oder klicken Sie mit der **rechten Maustaste**:

| Eintrag                                       | Wirkung                                                     |
| --------------------------------------------- | ------------------------------------------------------------- |
| :material-square-edit-outline: **Bearbeiten** | Öffnet den Einstellungsdialog erneut, bereits ausgefüllt.   |
| :material-play: **Jetzt starten**             | Startet die Anwendung sofort, ohne Verzögerung.             |
| :material-stop-circle: **Stoppen**            | Beendet den laufenden Prozess (ersetzt „Jetzt starten“).    |
| :material-delete: **Aus der Liste entfernen** | Entfernt die Anwendung aus dem Profil.                      |

![Eine Anwendung bearbeiten](assets/app-editmenu.png)

## Filtern und sortieren

Die Leiste über dem Raster bietet zwei Menüs:

- **Filtern** — *Alle*, *MSFS-Start* (Anwendungen mit automatischem Start),
  *MSFS-Stopp* (Anwendungen mit automatischem Stopp), *Startbereit* (Anwendungen
  mit SimConnect-Auslöser).
- **Sortieren** — nach *Name* (alphabetisch) oder nach *Verzögerung* (aufsteigend).

Diese Einstellungen ändern **nur die Anzeige** und wirken sich weder auf die Startsequenz noch auf das Profil aus.

![Filtern und sortieren](assets/app-filters.png)

## Während des Fluges ist die Konfiguration gesperrt

Sobald der Simulator erkannt wird, sind das Profil und die Anwendungen **gesperrt** (Schloss :material-lock:{ style="color:#3ecf8e" }).<br>

Eine Anwendung können Sie weiterhin über das Menü **:material-dots-horizontal:** von Hand **starten** oder **stoppen**.

## Anwendungen, die Administratorrechte erfordern

Manche Anwendungen verlangen **Administratorrechte** (zum Beispiel Active Sky, REX Atmos).<br>
Sie zeigen neben ihrem Namen ein **Schild** <span style="color:red;">:material-shield-alert:</span>.

Sobald eine solche Anwendung im aktiven Profil enthalten ist, werden Sie beim Start oder beim Hinzufügen gebeten, **als Administrator neu zu starten** – über **eine einzige** UAC-Abfrage.

!!! info "Nur die Anwendungen, die es verlangen, werden erhöht"
    Auch wenn MFSAppsControl als Administrator läuft, gibt es diese Rechte **nicht** an alles weiter, was es startet.<br>
    Jede Anwendung startet mit den Rechten, die **ihre eigene ausführbare Datei** verlangt; nur wer wirklich Administratorrechte braucht, bekommt sie.

!!! tip "Wenn Sie die Erhöhung ablehnen"
    MFSAppsControl arbeitet normal weiter, aber die Administrator-Anwendungen **werden nicht gestartet**.<br>
    Ihre Karte zeigt den Fehler „MFSAppsControl muss als Administrator ausgeführt werden“.<br>
    Ebenso wenig kann MFSAppsControl sie beim Beenden des Simulators schließen.

## Ungültiger Pfad / Startfehler

Wenn die ausführbare Datei einer Anwendung **nicht gefunden** wird (verschoben/deinstalliert) oder bei der Ausführung ein Fehler auftritt, wechselt ihre Karte in den **roten Fehlerzustand**, mit den Einzelheiten in den Informationen des Badges.

Diese Anwendung wird dann:

- **von der Startsequenz übergangen** (es wird kein Startversuch unternommen);
- **von der Prozesserkennung ausgeschlossen**.

## Die Sequenz testen

Die Schaltfläche **Testen** spielt die **gesamte** Sequenz ab, ohne den Simulator zu starten.<br>
Es wird nur der Start und das Beenden des Simulators simuliert: Ihre Anwendungen werden wirklich gestartet.

Der Ablauf ist folgender:

1. Der Status wechselt in den blauen Zustand „Simulator erkannt“.
2. Nach **5 s** wechselt der Status auf „läuft“, und die Sequenz **Simstart** läuft gemäß den eingestellten Verzögerungen an, mit **SimConnect verbunden** – wie in einer echten Sitzung, in der SimConnect während des Ladens aktiv wird.
3. Ein Countdown **„Startklar in 10s…“\*** erscheint unter der Schaltfläche: Das ist die simulierte Zeit bis zum Bildschirm „Startbereit“.<br> **\*** Der Countdown erscheint nur, wenn Ihr Profil mindestens eine gültige **Startbereit**-Anwendung enthält.
4. Am Ende dieser Zeitspanne läuft die Sequenz **Startbereit** ihrerseits gemäß den eingestellten Verzögerungen an.

Die Schaltfläche wird von Anfang an zu **Stoppen**: Klicken Sie darauf, um den Test zu beenden und alle bereits gestarteten Anwendungen mit Autostopp zu schließen.<br>
Sie ist während des Schließens **gesperrt** – manche Anwendungen brauchen einige Sekunden, um sich sauber zu beenden – und wird danach wieder zu **Testen**.

!!! note
    Achtung: Anwendungen, die schon vor dem Test liefen, werden ebenfalls **geschlossen**, wenn für sie der automatische Stopp konfiguriert ist. Der Test unterscheidet nicht zwischen Anwendungen, die MFSAppsControl gestartet hat, und solchen, die Sie von Hand gestartet haben.
