# Profile

Ein **Profil** fasst eine Reihe von Anwendungen samt ihren Einstellungen zusammen.<br>
Legen Sie mehrere davon nach Einsatzzweck an (Online-IFR-Flug, VFR, A320, A380…) und wechseln Sie mit einem Klick zwischen ihnen.

![Die Profile](assets/profiles.png)

!!! info "Das aktive Profil steuert die Sequenz"
    Das **angezeigte** Profil ist dasjenige, das MFSAppsControl für die Sequenz ausführt.<br>
    Das Profil, das beim Start des Simulators gerade verwendet wird, ist mit einem **:material-lock:{ style="color:#3ecf8e" }** gekennzeichnet.

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
Darüber können Sie das Profil **umbenennen**, **löschen** oder **duplizieren**.

![Kontextmenü der Profile](assets/profiles-menu.png)

### Ein Profil duplizieren

Um von einem bestehenden Profil auszugehen, ohne alles neu einrichten zu müssen.
Es wird eine Kopie mit **allen Anwendungen und deren Einstellungen** erstellt, benannt als „*Profilname* (Kopie)“, die Sie auf einen eindeutigen Namen umbenennen.

![Ein Profil duplizieren](assets/profiles-duplicate.gif)

### Ein Profil umbenennen

Auch beim Umbenennen muss der Name **eindeutig** sein; andernfalls bleibt die Bestätigung blockiert.

![Ein Profil umbenennen oder löschen](assets/profiles-rename.gif)


### Ein Profil löschen

Das Löschen eines Profils ist **unwiderruflich** und entfernt **alle darin enthaltenen Anwendungen und Einstellungen**.<br>
Das letzte verbleibende Profil lässt sich nicht löschen.

![Ein Profil löschen](assets/profiles-delete.gif)

### Neu anordnen

**Ziehen Sie die Badges** per Drag-and-drop, um ihre Reihenfolge zu ändern.
Das ist rein optisch und hilft Ihnen, Ihre bevorzugten Profile schneller wiederzufinden.

![Die Profile neu anordnen](assets/profiles-reorder.gif)

## Automatische Sperre

Die Profile werden **gesperrt** (auf dem aktiven Profil erscheint ein :material-lock:{ style="color:#3ecf8e" }), damit während der Ausführung nichts geändert werden kann.
