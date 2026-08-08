# Optionen

Öffnen Sie die Optionen über das **Zahnrad**-Symbol :material-cog: in der Titelleiste
oder über das Menü des Symbols im Infobereich.

![Das Fenster Optionen](assets/options.png)

Alle Einstellungen werden **sofort gespeichert** — es gibt keine Schaltfläche
„Übernehmen“.

## Allgemein

| Option                                              | Wirkung                                                                                                     |
| --------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| **Beim Windows-Start ausführen**                    | Startet automatisch mit Ihrer Windows-Sitzung.                                                              |
| **In den Infobereich minimieren**                   | Minimiert das Fenster in den Infobereich (Tray), statt es in der Taskleiste zu belassen.                    |
| **Beim Schließen in den Infobereich minimieren**    | Das Schließen minimiert das Fenster in den Infobereich (Tray), statt die Anwendung zu beenden.              |
| **Minimiert im Infobereich starten**                | Startet direkt im Infobereich, mit ausgeblendetem Fenster.                                                  |

!!! info "Wie beende ich die Anwendung wirklich, wenn das Schließen sie in den Infobereich minimiert?"
    Wenn **Beim Schließen in den Infobereich minimieren** aktiviert ist, beendet das Kreuz die Anwendung nicht mehr.<br>
    Verwenden Sie **Beenden** im Menü des Symbols im Infobereich (Rechtsklick).

## Darstellung

### Design der Anwendung

*System* (folgt dem Windows-Design), *Hell* oder *Dunkel*.<br>
Die Schaltfläche :material-weather-sunny:/:material-weather-night: in der Titelleiste wechselt das Design ebenfalls im Handumdrehen.

### Sequenzstil

Legt die Darstellung der [Sequenz](applications.md#die-zeitleiste) fest:

- **Doppelt** — zwei unabhängige Spuren, die jede Sequenz getrennt anzeigen.
- **Mono** — eine einzige Spur, in der Mitte für die beiden Sequenzen geteilt.

### Sprache der Oberfläche

Vollständig übersetzt in: Französisch, Englisch, Deutsch, Spanisch, Italienisch, Portugiesisch.<br>
Wird sofort angewendet, ohne Neustart, und in der Konfiguration gespeichert. <br>
Ebenfalls in der Titelleiste verfügbar, mit der Flagge der aktuellen Sprache.<br>

!!! info
    Wird beim ersten Start automatisch nach der Windows-Sprache festgelegt, lässt sich aber jederzeit ändern.

## Updates

- **Automatisch nach Updates suchen** — aktiviert die tägliche automatische Prüfung.
- **Jetzt prüfen** — startet eine sofortige Suche. Das Ergebnis erscheint unter der Beschriftung (aktuell / neue Version verfügbar).

!!! info
    Sobald ein Update verfügbar ist, erscheint ein **Badge** in der Titelleiste; ein Klick darauf startet den Download und die Installation.

## Fehlersuche

### Protokollstufe

Legt fest, wie ausführlich in die Protokolldateien geschrieben wird. Die Änderung gilt **sofort**, ohne Neustart der Anwendung.

| Stufe                 | Inhalt                                                            | Wann verwenden               |
| --------------------- | ------------------------------------------------------------------ | ---------------------------- |
| **Fehler** *(Standard)* | Nur Fehler und Warnungen.                                        | Im normalen Betrieb.         |
| **Debug**             | + den Ablauf der Vorgänge (Erkennungen, Starts, Stopps…).          | Auf Anfrage des Supports.    |
| **Trace**             | + die Einzelheiten der internen Werte. Sehr umfangreich.           | Auf Anfrage des Supports.    |

**Jeden Tag** wird eine neue Datei angelegt, und Protokolle, die älter als **7 Tage** sind, werden automatisch gelöscht.

!!! tip
    Denken Sie daran, die Stufe **wieder auf Fehler zu stellen**, sobald Ihr Problem eingereicht ist: Die Stufen Debug und Trace sind sehr umfangreich.

### Exportieren

Erstellt eine **`zip`**-Datei mit allen Ihren Protokollen **und** Ihrer Konfiguration, wie sie für den Support benötigt wird.

### Anwendung zurücksetzen

Löscht **alle Ihre Profile und Einstellungen** und beginnt wieder bei null, wie nach der Installation.<br>
**Eine ausdrückliche Bestätigung wird verlangt.**

!!! danger "Nicht umkehrbare Aktion"
    Nach einem Zurücksetzen lässt sich nichts wiederherstellen.<br>

## Über

Zeigt die Details der Anwendung und die Schnellzugriffe auf **Discord**/**Flightsim.to**.
