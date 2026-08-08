# Fehlerbehebung (FAQ)

## Erkennung des Simulators

??? question "MSFS wird nicht erkannt"
    MFSAppsControl überwacht die Prozesse `FlightSimulator2024.exe` (MSFS 2024)
    und `FlightSimulator.exe` (MSFS 2020). Vergewissern Sie sich, dass der Simulator wirklich läuft.<br>
    Der Wechsel auf „Sim läuft“ dauert nach dem Start von MSFS einige Sekunden.

??? question "Ich habe MFSAppsControl gestartet, während MSFS bereits lief, und es passiert nichts"
    Das ist **so gewollt**. Wenn der Simulator beim Start der Anwendung bereits
    läuft, wird die Sequenz nicht ausgelöst: Sonst würde ein Öffnen von
    MFSAppsControl mitten im Flug ungewollt Anwendungen nachstarten.

    Sie wird beim nächsten Start automatisch scharf geschaltet. In der Zwischenzeit
    können Sie eine Anwendung über das Menü **⋯** ihrer Karte von Hand starten.

??? question "Der SimConnect-Punkt bleibt grau, obwohl MSFS läuft"
    MFSAppsControl versucht die Verbindung **nur, während der Simulator läuft**,
    und wiederholt den Versuch anschließend regelmäßig. Einige Sekunden Wartezeit
    sind beim Start von MSFS ganz normal.

    Wenn er lange grau bleibt:

    - prüfen Sie, ob der Simulator fertig gestartet ist (SimConnect ist erst
      verfügbar, wenn der Simulator wirklich initialisiert ist, und während des Ladebildschirms);
    - prüfen Sie, ob ein Virenscanner oder eine Firewall MFSAppsControl blockiert;

    Bleibt die Verbindung sehr lange aus, obwohl MSFS läuft, wechselt der Punkt auf
    **rot** („SimConnect nicht verfügbar“) und weist so auf das Problem hin.

    Ohne SimConnect funktioniert der Auslöser „Startbereit“ nicht.

## Start der Anwendungen

??? question "Eine Anwendung startet nicht"
    - Prüfen Sie, ob ihre Karte im **Fehlerzustand** ist (fahren Sie über den Badge, um die Fehlermeldung zu lesen).
    - Prüfen Sie, ob ein **Auslöser** aktiv ist (:material-play: oder :material-airplane:). Ist keiner von beiden aktiv, wird die Anwendung nie automatisch gestartet.
    - Lautet der Auslöser **Startbereit**, startet die Anwendung erst ab dem Bildschirm „Startbereit“ — und nur, wenn **SimConnect verbunden** ist.
    - Zeigt die Anwendung ein **Schild** :material-shield-alert:, benötigt sie Administratorrechte (siehe unten).
    - Verwenden Sie **Testen**, um die Sequenz ohne MSFS erneut abzuspielen und den Status jeder Karte zu beobachten.

??? question "Die „Startbereit“-Anwendungen starten nie"

    Der Reihe nach:

    1. Ist der Punkt **SimConnect verbunden** während des Fluges grün?
    2. Ist auf der Karte wirklich die Schaltfläche :material-airplane: aktiv (und nicht :material-play:)?
    3. Sind Sie in dieser Sitzung bereits geflogen? Die „Startbereit“-Anwendungen starten **nur einmal pro Simulator-Sitzung** — sie werden zwischen zwei Flügen nicht erneut gestartet.

    Um alles ohne Flug zu überprüfen, verwenden Sie die Schaltfläche **Testen**: Sie simuliert SimConnect nach 10 Sekunden.

??? question "Meine „Startbereit“-Anwendungen starten zu früh"
    Das ist das erwartete Verhalten. Ausgelöst wird, sobald nach dem Laden der Bildschirm „Startbereit“ erscheint.

    Setzen Sie auf der Karte eine **Verzögerung**, um den Start um entsprechend viele Sekunden nach hinten zu schieben.

??? question "Die Anwendung verlangt Administratorrechte (UAC)"
    Manche Anwendungen (Active Sky, REX Atmos…) verlangen Administratorrechte. Um sie
    zu starten — und um sie zu **beenden** — muss MFSAppsControl erhöht laufen. Wenn ein
    solches Addon im aktiven Profil enthalten ist, startet die Anwendung
    automatisch als Administrator neu (**eine einzige** UAC-Abfrage).

    **Die übrigen Anwendungen erben diese Rechte nicht**: Jede startet mit den
    Rechten, die ihre eigene ausführbare Datei verlangt. vPilot oder Navigraph laufen
    als normaler Benutzer, auch wenn MFSAppsControl erhöht ist.

    Wenn Sie die Abfrage ablehnen, funktioniert alles Übrige weiter, aber genau diese
    Anwendungen schlagen mit dem Fehler „MFSAppsControl muss als Administrator
    ausgeführt werden“ fehl.

??? question "Eine Anwendung startet vor dem Simulator in den Vordergrund"
    Aktivieren Sie auf ihrer Karte **Minimiert starten** :material-arrow-collapse:: Sie
    wird dann in einem minimierten Fenster gestartet, ohne sich vor MSFS zu schieben.
    MFSAppsControl verfolgt dabei auch die Fenster der **Unterprozesse** der Anwendung
    (manche, wie FS2Crew, öffnen ihre Oberfläche über einen anderen Prozess).

    Einige wenige Programme mit eigener Fensterdarstellung holen ihr Fenster trotzdem
    in den Vordergrund. Manchmal gibt es dafür eine Einstellung in der Anwendung selbst,
    manchmal ist es ein internes Verhalten der Anwendung, das sich nicht umgehen lässt.

??? question "Meine Anwendungen schließen sich nicht, wenn ich MSFS beende"
    Prüfen Sie, ob auf ihrer Karte die Schaltfläche **Autostopp** :material-square: aktiv
    ist — sie ist **unabhängig** vom automatischen Start — und ob MSFS wirklich beendet ist (Task-Manager).

    MFSAppsControl fordert zuerst ein **sauberes Schließen** an und **erzwingt** dann das Beenden
    der Prozesse, die weiterhin aktiv sind — auch solcher Anwendungen, die nach dem Schließen ihres Fensters im Hintergrund weiterlaufen.

    Wenn die Anwendung Administratorrechte benötigt, muss auch MFSAppsControl erhöht sein, um sie beenden zu können (siehe oben).

??? question "Eine Anwendung erscheint als „LÄUFT“, obwohl ich sie nicht aus MFSAppsControl gestartet habe"
    Das ist normal: MFSAppsControl prüft regelmäßig, welche Prozesse tatsächlich
    laufen, und **übernimmt** diejenigen, die zu Ihren konfigurierten Anwendungen passen. So bleibt die Anzeige zuverlässig, ganz gleich ob Sie Ihre
    Anwendungen aus MFSAppsControl oder von Hand starten.

    Fahren Sie über den Badge, um die **PID** des betreffenden Prozesses zu sehen.

## Oberfläche

??? question "Warum ist die Verzögerung ausgegraut?"
    Weil für diese Anwendung kein **automatischer Start** gewählt ist. Aktivieren Sie :material-play: oder :material-airplane:, und sie lässt sich wieder einstellen.

??? question "Warum das Schloss und die ausgegrauten Schaltflächen während des Fluges?"
    Sobald der Simulator erkannt wird, sind die Konfiguration der Karten und die Profile **gesperrt**: Eine Sequenz während ihres Ablaufs zu ändern
    (oder mitten im Flug das Profil zu wechseln) wäre nur schwer beherrschbar.

    Das Menü **⋯** bleibt verfügbar, um eine Anwendung von Hand zu starten oder zu stoppen.

??? question "Warum kann ich den Autostopp bei einer „Startbereit“-Anwendung nicht deaktivieren?"
    Eine Anwendung, die für den Flug gestartet wurde, hat keinen Grund, den Simulator zu überleben: Der automatische Stopp ist bei diesem Auslöser deshalb **in aktiver Stellung gesperrt**.<br>
    Stellen Sie die Karte auf **Simstart** zurück, wenn Sie sie nach dem Flug geöffnet lassen möchten.

??? question "Wie beende ich die Anwendung wirklich, wenn sie im Infobereich liegt?"
    Wenn die Option **Beim Schließen in den Infobereich minimieren** aktiviert ist, blendet das Kreuz das Fenster aus, statt die Anwendung zu beenden.<br>
    Klicken Sie mit der **rechten Maustaste auf das Symbol** im Infobereich → **Beenden**.<br>
    Andernfalls schließen Sie die Anwendung einfach über das Kreuz des Fensters.

??? question "Das Fenster hat sich außerhalb des Bildschirms / zu klein geöffnet"
    MFSAppsControl merkt sich die Fensterposition. Bei Anzeigeproblemen (zum Beispiel nach einem Bildschirmwechsel) verschieben Sie das Fenster oder ändern seine Größe: Die neue Position wird gespeichert.<br><br>
    **Praktischer Tipp**<br>
    Verwenden Sie „ ++windows++ + Pfeiltaste links “ oder „ ++windows++ + Pfeiltaste rechts “, um es auf die Bereiche der Bildschirme zu verschieben.

## Daten und Wartung

??? question "Wo werden meine Profile und Einstellungen gespeichert?"
    In einer einzigen Datei:
    `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\settings.json`<br>
    (also `C:\Users\<Sie>\AppData\Local\Stalex CORP\MFSAppsControl\`).

    Diese Datei ist **verschlüsselt**: Sie lässt sich nicht direkt bearbeiten. Zum
    Sichern kopieren Sie sie einfach so, wie sie ist.
    → [Profile](profiles.md)

??? question "Wo sind die Protokolle (Logs)?"
    In `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\logs`. (Eine Datei pro Tag, **7 Tage** lang aufbewahrt.)<br>
    **Um sie an den Support zu übermitteln:**<br>
    **Optionen → Fehlersuche → Logs exportieren** erzeugt eine vollständige `.zip` (Protokolle + Konfiguration). → [Support](support.md)

??? question "Wie fange ich wieder bei null an?"
    **Optionen → Fehlersuche → Anwendung zurücksetzen** löscht alles und versetzt die Anwendung in den Zustand nach der Installation.<br>
    **Diese Aktion ist unwiderruflich** — kopieren Sie bei Bedarf vorher Ihre `settings.json`.

??? question "Kann ich MFSAppsControl mit MSFS 2020 verwenden?"
    Ja, beide Versionen (2024 und 2020) werden unterstützt, einschließlich der
    Erkennung „Startbereit“. Ein und dasselbe Profil funktioniert unabhängig von der Version.

??? question "Wie aktualisiere ich die Anwendung?"
    Sobald ein Update verfügbar ist, erscheint ein **Badge** in der
    Titelleiste. Klicken Sie darauf, um die neue Version herunterzuladen und zu installieren.<br>
    Ihre Profile und Einstellungen bleiben erhalten.

!!! info "Immer noch blockiert?"
    Stellen Sie Ihre Frage im [**Discord**](support.md), im dafür vorgesehenen Kanal
    **#mfsappscontrol** — und hängen Sie Ihre exportierte ZIP-Datei an.
