# MFSAppsControl

## Beschreibung

**MFSAppsControl** ist eine Anwendung, mit der Sie Programme von Drittanbietern **starten und/oder beenden** können, indem der Zustand von Microsoft Flight Simulator 2024/2020 überwacht wird.<br>
Sie müssen Ihre Anwendungen nicht mehr vor jedem Flug einzeln starten: einmal einrichten, um den Rest kümmert sich MFSAppsControl.

![Der Hauptbildschirm von MFSAppsControl](assets/main-screen.png)

## So funktioniert es

MFSAppsControl begleitet Ihren Flug von Anfang bis Ende, in **drei Schritten**:

::timeline::

- title: Start des Simulators
  content: Die auf **Simstart** gestellten Anwendungen starten, sobald der Simulator gestartet wird, jeweils nach ihrer eingestellten Verzögerung.
  icon: ' :material-numeric-1: '

- title: Bildschirm „Startbereit“
  content: Die auf **Startbereit** gestellten Anwendungen starten, sobald die Schaltfläche „Startbereit“ erscheint, jeweils nach ihrer eingestellten Verzögerung.
  icon: ' :material-numeric-2: '

- title: Beenden des Simulators
  content: Die auf **Autostopp** gestellten Anwendungen werden sauber geschlossen, wenn der Simulator beendet wird.
  icon: ' :material-numeric-3: '

::/timeline::


**Der Unterschied zwischen den beiden Startarten ist das Herzstück der Anwendung:**<br>
Manche Anwendungen können:

- **direkt beim Start** des Simulators gestartet werden (z. B. Navigraph, Volanta…)
- Einschränkungen haben oder erst **während eines Fluges** nützlich sein (z. B. REX Atmos, FS2Crew…)

Sie entscheiden, was am besten zur jeweiligen Anwendung passt. → [Anwendungen & Sequenz](applications.md#die-beiden-start-ausloser)

## Die Funktionen

<div class="grid cards" markdown>

- <span style="color: var(--md-accent-fg-color)">:material-rocket-launch: **Automatische Sequenz**</span><br>
  Jede Anwendung startet gemäß ihrem Auslöser nach der eingestellten Verzögerung – die Startreihenfolge sehen Sie direkt auf der Zeitleiste.

- <span style="color: var(--md-accent-fg-color)">:material-folder-multiple: **Profile**</span><br>
  Fassen Sie Ihre Anwendungen nach Einsatzzweck zusammen (A320, VFR, Cargo…) und wechseln Sie mit einem Klick. Das angezeigte Profil ist das aktive Profil.

- <span style="color: var(--md-accent-fg-color)">:material-tray-arrow-down: **Unauffällig**</span><br>
  Lässt sich in den Infobereich minimieren und mit Windows starten, damit für Ihre nächsten Flüge alles bereit ist, ohne dass Sie daran denken müssen.

- <span style="color: var(--md-accent-fg-color)">:material-translate: **Vollständig mehrsprachige Oberfläche**</span><br>
  Komplett übersetzt in Französisch, Englisch, Deutsch, Spanisch, Italienisch und Portugiesisch, mit sofortigem Wechsel und Speicherung in der Konfiguration.

- <span style="color: var(--md-accent-fg-color)">:material-shield-check: **Anwendungen mit Administratorrechten**</span><br>
  Werden beim Hinzufügen automatisch erkannt, mit einer Windows-Abfrage. Nur Anwendungen, die tatsächlich Administratorrechte benötigen, laufen im Administratormodus.

- <span style="color: var(--md-accent-fg-color)">:material-flask: **Testmodus**</span><br>
  Spielen Sie die gesamte Sequenz ab (einschließlich des Auslösers „Startbereit“), ohne den Simulator zu starten, und prüfen Sie so Ihre Profile.

</div>

## Wo fange ich an?

1. [**Installation**](installation.md) — die Anwendung herunterladen und installieren.
2. [**Erste Schritte**](getting-started.md) — richten Sie Ihre erste Sequenz ein.
3. [**Anwendungen & Sequenz**](applications.md) — die einzelnen Bereiche der Anwendung im Detail.
4. [**Profile**](profiles.md) und [**Optionen**](options.md) — verwalten Sie Ihre Profile und Einstellungen.
5. [**FAQ**](faq.md) — die häufigsten Fragen.
6. [**Support**](support.md) — wenn Sie Hilfe benötigen.
