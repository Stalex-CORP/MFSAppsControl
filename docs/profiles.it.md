# Profili

Un **profilo** raggruppa un insieme di applicazioni con le loro impostazioni.<br>
Creane diversi in base ai tuoi usi (volo online IFR, VFR, A320, A380…) e passa dall'uno all'altro con un clic.

![I profili](assets/profiles.png)

!!! info "Il profilo attivo è quello che comanda la sequenza"
    Il profilo **mostrato** è quello che MFSAppsControl esegue per la sequenza.<br>
    Il profilo in uso quando il simulatore è avviato è indicato da un **:material-lock:{ style="color:#3ecf8e" }**.

## Creare un profilo

Fai clic sul pulsante **:material-plus-circle-outline:** a destra delle schede.<br>
Viene creato un nuovo profilo vuoto e ti viene chiesto di assegnargli un nome.

![Creare un profilo](assets/profiles-create.gif)

!!! note "Nome univoco e annullamento"
    Due profili non possono avere lo **stesso nome**.<br>
    Finché il nome inserito è già in uso, il campo diventa <span style="color:red;">**rosso**</span> e la conferma è bloccata.<br>
    Per **annullare**, fai clic sulla croce **:material-close-circle:** oppure premi **Esc**.

## Menu contestuale

Su ogni badge di profilo è disponibile un menu tramite **:material-dots-horizontal:** o un **clic destro**.
Questo menu permette di **rinominare**, **eliminare** o **duplicare** il profilo.

![Menu contestuale dei profili](assets/profiles-menu.png)

### Duplicare un profilo

Per ripartire da un profilo esistente senza dover riconfigurare tutto.
Viene creata una copia, con **tutte le sue applicazioni e le loro impostazioni**, chiamata « *nome del profilo* (copia) », da rinominare con un nome univoco.

![Duplicare un profilo](assets/profiles-duplicate.gif)

### Rinominare un profilo

Anche al momento della rinomina il nome deve essere **univoco**: finché non lo è, la conferma resta bloccata.

![Rinominare o eliminare un profilo](assets/profiles-rename.gif)


### Eliminare un profilo

L'eliminazione di un profilo è **irreversibile** ed elimina **tutte le applicazioni e le impostazioni** che contiene.<br>
Non è possibile eliminare l'ultimo profilo rimasto.

![Eliminare un profilo](assets/profiles-delete.gif)

### Riordinare

**Trascina** i badge per cambiarne l'ordine.
È puramente visivo e serve a ritrovare più facilmente i tuoi profili preferiti.

![Riordinare i profili](assets/profiles-reorder.gif)

## Blocco automatico

I profili diventano **bloccati** (sul profilo attivo compare un :material-lock:{ style="color:#3ecf8e" }) per evitare qualsiasi modifica durante l'esecuzione.
