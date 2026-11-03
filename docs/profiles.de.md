# Profile

Ein **Profil** fasst eine Reihe von Anwendungen samt ihren Einstellungen zusammen.<br>
Legen Sie mehrere davon nach Einsatzzweck an (Online-IFR-Flug, VFR, A320, A380…) und wechseln Sie mit einem Klick zwischen ihnen.

![Die Profile](assets/profiles.png)

!!! info "Das aktive Profil steuert die Sequenz"
    Die Sequenz führt die Anwendungen des Profils **Gemeinsam** und die des **angezeigten** Profils aus.<br>
    Solange der Simulator läuft, ist das verwendete Profil **grün** umrandet.

## Ein Profil erstellen

Klicken Sie rechts neben den Tabs auf die Schaltfläche **:material-plus-circle-outline:**.<br>
Ein neues, leeres Profil wird angelegt und Sie werden aufgefordert, es zu benennen.

![Ein Profil erstellen](assets/profiles-create.gif)

!!! note "Eindeutiger Name und Abbrechen"
    Zwei Profile dürfen nicht **denselben Namen** tragen.<br>
    Solange der eingegebene Name bereits vergeben ist, wird das Feld <span style="color:red;">**rot**</span> und die Bestätigung ist blockiert.<br>
    Zum **Abbrechen** klicken Sie auf das Kreuz **:material-close-circle:** oder drücken **Esc**.

## Kontextmenü

Auf jedem Profil-Badge erreichen Sie über **:material-dots-horizontal:** oder einen **Rechtsklick** ein Menü.
Darüber können Sie das Profil **umbenennen**, **löschen** oder **duplizieren** und seine **verknüpften Flugzeuge** wählen. → [Mit Flugzeugen verknüpfte Profile](#mit-flugzeugen-verknupfte-profile)

![Kontextmenü der Profile](assets/profiles-menu.png)

### Ein Profil duplizieren

Um von einem bestehenden Profil auszugehen, ohne alles neu einrichten zu müssen.
Es wird eine Kopie mit **allen Anwendungen und deren Einstellungen** erstellt, benannt als „*Profilname* (Kopie)“, die Sie auf einen eindeutigen Namen umbenennen.

Seine **verknüpften Flugzeuge** werden nicht kopiert: Ein Flugzeug gehört zu genau einem Profil.

![Ein Profil duplizieren](assets/profiles-duplicate.gif)

### Ein Profil umbenennen

Auch beim Umbenennen muss der Name **eindeutig** sein; andernfalls bleibt die Bestätigung blockiert.

![Ein Profil umbenennen oder löschen](assets/profiles-rename.gif)


### Ein Profil löschen

Das Löschen eines Profils ist **unwiderruflich** und entfernt **alle darin enthaltenen Anwendungen und Einstellungen**.<br>
Das letzte verbleibende Profil lässt sich nicht löschen.

Seine Verknüpfungen mit Flugzeugen werden mit ihm entfernt.

![Ein Profil löschen](assets/profiles-delete.gif)

### Neu anordnen

**Ziehen Sie die Badges** per Drag-and-drop, um ihre Reihenfolge zu ändern.
Das ist rein optisch und hilft Ihnen, Ihre bevorzugten Profile schneller wiederzufinden.

![Die Profile neu anordnen](assets/profiles-reorder.gif)

## Das Profil Gemeinsam

Der Tab **Gemeinsam**, immer an erster Stelle, enthält die Anwendungen, die Sie mit **jedem Flugzeug** nutzen — Volanta, Navigraph, vPilot…<br>
Sie werden einmal eingerichtet, starten mit jedem aktiven Profil und erscheinen auf derselben Zeitleiste.

- Es kann weder umbenannt, dupliziert, gelöscht noch verschoben werden.
- Wird es allein ausgewählt, laufen nur seine Anwendungen.
- Eine Anwendung ist entweder in Gemeinsam oder in Profilen, nie in beiden: Der Hinzufügen-Dialog erklärt den Grund, wenn Sie es versuchen.

## In Gemeinsam zusammenführen

MFSAppsControl bietet an, die Anwendungen, die mehrere Profile gemeinsam haben, nach Gemeinsam zu verschieben. Es **tut das nie von selbst**: Ein Fenster listet sie auf, alle angehakt, und nur was angehakt bleibt, wird verschoben.

Das Angebot erscheint:

- **einmal, nach dem Update auf 2.1**, für die Anwendungen, die in allen Ihren Profilen vorhanden sind;
- wenn Sie eine Anwendung **hinzufügen**, die ein anderes Profil bereits enthält;
- über **Nach Gemeinsam verschieben** im Menü **:material-dots-horizontal:** einer Karte, wann immer Sie möchten;
- wenn Sie zu Gemeinsam eine Anwendung hinzufügen, die Profile bereits enthalten.

Zwei Einträge sind dieselbe Anwendung, wenn sie **denselben Pfad und dieselben Argumente** haben. Sind sich die Profile über ihre Einstellungen uneinig, werden die häufigsten übernommen; die übernommene Verzögerung wird vor dem Bestätigen angezeigt.

## Mit Flugzeugen verknüpfte Profile

Ein Profil kann mit **einem oder mehreren Flugzeugen verknüpft** werden: Wird ein Flug mit einem davon geladen, wird dieses Profil von selbst aktiv — der Wechsel vom A380 zur 737 erfordert keinen Profilwechsel von Hand mehr.

**Ein Flugzeug verknüpfen**

- **Im Band**: Sobald der Simulator das geladene Flugzeug meldet, klicken Sie auf seinen Namen und wählen das Profil.
- **Im Profilmenü → Verknüpfte Flugzeuge…**: die Liste Ihrer installierten Flugzeuge (Community und Marketplace) mit Suchfeld, nutzbar mit oder ohne laufenden Simulator. Die bereits mit dem Profil verknüpften Flugzeuge stehen oben; ein anderswo verknüpftes Flugzeug zeigt, welches Profil es hat, und das Anhaken verschiebt es hierher.

Ein verknüpftes Profil zeigt ein Symbol :material-link-variant: auf seinem Badge; fahren Sie darüber, um seine Flugzeuge zu sehen.

**Gut zu wissen**

- **Varianten und Lackierungen** eines Flugzeugs zählen als ein einziges Flugzeug.
- Ein Flugzeug gehört zu **genau einem Profil**, und Gemeinsam kann nicht verknüpft werden.
- Der Wechsel erfolgt **beim Laden des Flugs**, nie während Sie im Hauptmenü Flugzeuge durchsehen, und nur bei eingeschalteter **automatischer Sequenz**.
- Ein deinstalliertes Flugzeug bleibt in der Liste, solange es verknüpft ist, damit Sie die Verknüpfung lösen können.

## Profil während einer Sitzung wechseln

Nichts wird mehr gesperrt: Profile und Anwendungen lassen sich jederzeit bearbeiten, auch im Flug. Nur eine Karte, deren Verzögerung gerade herunterzählt, bleibt gesperrt, bis der Countdown endet oder Sie ihn abbrechen.

Wenn Sie das Profil wechseln — von Hand oder über ein verknüpftes Flugzeug —, **passiert im Moment nichts**. Beim **Laden des nächsten Flugs**:

- werden die Anwendungen des vorherigen Profils, die das neue nicht enthält, **geschlossen**;
- **starten** die **Simstart**-Anwendungen des neuen Profils **sofort**, ohne ihre Verzögerung;
- starten seine **Startbereit**-Anwendungen beim Bildschirm Startbereit, mit ihrer Verzögerung.

Die Anwendungen, die beide Profile gemeinsam haben, und die von Gemeinsam laufen weiter.
