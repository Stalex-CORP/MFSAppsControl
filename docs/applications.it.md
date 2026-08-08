# Applicazioni e sequenza

Ogni applicazione del tuo profilo è mostrata sotto forma di **scheda**.<br>
Questa pagina spiega come aggiungerle, come configurarle e come leggere la **sequenza di avvio**.

---

## Aggiungere un'applicazione

Fai clic su **Aggiungi un'applicazione** nella griglia. Due modalità:

=== "Applicazioni installate"

    Elenca i software già installati (tramite il registro di Windows).<br>
    Cercala e selezionala: nome, icona e percorso vengono recuperati automaticamente.

    ![Modalità applicazioni installate](assets/add-app-installed.png)

    !!! note "L'elenco è filtrato di proposito"
        Per restare leggibile, l'elenco esclude i software estranei al volo
        (driver e utilità di sistema, browser, giochi, launcher, ecc.) e
        nasconde le applicazioni **già presenti nel profilo attivo**. Un'applicazione
        installata normalmente che non dovesse comparire — o un software
        **portatile** — si aggiunge sempre dalla scheda **Sfoglia**.

=== "Sfoglia"

    Indica il percorso di un `.exe`, oppure fai clic su **Sfoglia** per selezionarlo: nome e icona vengono recuperati automaticamente.

    ![Modalità sfoglia](assets/add-app-browse.png)

    !!! note "Quando usarla"
        Questa modalità serve per le applicazioni **portatili** (non installate) o non rilevate, che non compaiono nel registro di Windows.

La finestra di aggiunta contiene poi gli **argomenti di avvio**, l'**attivazione**, il **ritardo** e l'opzione **Avvia ridotta**, tutti modificabili dopo l'aggiunta.

---

## Anatomia di una scheda

![Scheda di un'applicazione](assets/app-card.png)

**In alto** trovi le informazioni dell'applicazione:

- L'icona dell'applicazione
- Il suo **nome**
- Il suo **percorso**
- I suoi **argomenti** (sotto il percorso, quando sono definiti).

A destra, il **badge di stato** (visibile durante l'esecuzione) e il menu **:material-dots-horizontal:**.

**In basso, la barra di controllo**, accessibile con un clic:

| Controllo                                     | Ruolo                                                                                                              |
| --------------------------------------------- | ------------------------------------------------------------------------------------------------------------------ |
| :material-play: **Avvio sim**                 | Si avvia all'avvio del simulatore.                                                                                 |
| :material-airplane: **Pronto al volo**        | Si avvia quando è mostrata la schermata **Pronto al volo**.                                                        |
| :material-arrow-collapse: **Avvia ridotta**   | Avvia l'applicazione in una finestra ridotta.<br>*Visibile solo se è scelto un avvio automatico*                  |
| :material-square: **Arresto auto**            | Chiude l'applicazione quando il simulatore si arresta.<br>*Attivato e bloccato automaticamente con «Pronto al volo»* |
| :material-minus::material-plus: **Ritardo**   | Tempo di attesa prima dell'avvio di questa applicazione, secondo la modalità di avvio.                             |

Queste impostazioni sono presenti anche nella finestra di modifica.

### I due attivatori di avvio

È l'impostazione più utile di MFSAppsControl.<br>
I due pulsanti di sinistra (:material-play: e :material-airplane:) formano una **scelta unica**: attivare l'uno disattiva l'altro, e ricliccare su quello attivo **disattiva l'avvio automatico**.

|                      | :material-play: **Avvio sim**               | :material-airplane: **Pronto al volo**       |
| -------------------- | ------------------------------------------- | -------------------------------------------- |
| **Si attiva**        | Quando il **processo** di MSFS viene rilevato | Quando il tuo **aereo appare nel mondo**     |
| **Rilevamento**      | Tramite **monitoraggio del processo**       | Tramite **SimConnect**                        |
| **Il ritardo parte** | Dall'avvio del simulatore                   | Dalla schermata «Pronto al volo»              |
| **Tipicamente per**  | Navigraph, vPilot, un'utilità hardware      | REX Atmos, FS2Crew, strumenti aereo           |

!!! tip "Come scegliere?"
    Poniti le domande giuste:<br>
    *«Questa applicazione deve essere pronta/disponibile prima che io inizi a volare?»*<br>
    *«Questa applicazione funziona senza il simulatore?»*<br>
    *«Questa applicazione non disturba il funzionamento del mio simulatore?»*<br>

    - **Sì** → Avvio sim. Deve essere pronta prima che il volo cominci.
    - **No** → Pronto al volo. Inutile tenerla in funzione prima di essere in volo.

**Cosa sapere sull'avvio «Pronto al volo»**

!!! info "L'arresto auto è bloccato"
    Un'applicazione «pronto al volo» si chiude **sempre** con il simulatore: il pulsante :material-square: è bloccato in posizione attiva.<br>
    Un'applicazione avviata per il volo non ha alcun motivo di sopravvivere al simulatore.

!!! info "L'attivazione avviene sulla schermata «Pronto al volo»"
    In concreto, ciò accade subito dopo il caricamento di un volo, non appena è mostrata la schermata «Pronto al volo».
    È l'unico rilevamento sicuro possibile per riconoscere un volo in modo «pulito».

!!! warning "SimConnect deve essere connesso"
    **Questo attivatore si basa su SimConnect**.<br>
    Se lo stato SimConnect non è **verde** (SimConnect connesso), le applicazioni «pronto al volo» non partiranno.<br>
    Se resta a lungo senza connettersi, passa al **rosso** («SimConnect non disponibile»). → [Risoluzione dei problemi](faq.md)

### L'arresto automatico

Il pulsante :material-square: **Arresto auto** chiude l'applicazione quando il simulatore si arresta.<br>
È **indipendente** dall'avvio: puoi avere un'applicazione che avvii a mano o in altro modo, ma che MFSAppsControl chiude insieme al simulatore.

La chiusura è **pulita**: MFSAppsControl prova prima a chiudere l'applicazione come se cliccassi sulla croce, le lascia qualche secondo per terminare la sua sessione, e forza la chiusura solo come ultima risorsa.<br>
Le applicazioni che devono disconnettersi correttamente (ad esempio Active Sky) vengono così gestite nel modo giusto.

### Avvia ridotta

L'opzione :material-arrow-collapse: **Avvia ridotta** avvia l'applicazione in una **finestra ridotta**, utile quando non ha bisogno di essere mostrata in primo piano.

Il pulsante compare solo se è scelto un **avvio automatico**.

!!! note
    Alcune applicazioni forzano la propria finestra in primo piano qualche secondo dopo l'avvio.<br>
    MFSAppsControl prova per qualche secondo a ridurle, ma qualche raro software può resistere.

### Il ritardo

Il **ritardo** è il tempo di attesa prima dell'avvio dell'applicazione, **a partire dal suo attivatore**. Permette di **distanziare** gli avvii.

- Regolabile da **0 a 600 secondi** (10 minuti)
- I pulsanti **−** / **+** procedono a passi di **5 s**; puoi anche **digitare** direttamente il valore
- Il ritardo è **in grigio** se non è scelto alcun avvio automatico
- Durante un volo mostra un **lucchetto** :material-lock: — la configurazione è bloccata

!!! tip "I due attivatori hanno la propria sequenza"
    Un ritardo di 30 s su un'applicazione «avvio sim» = 30 s dopo l'avvio di MSFS.<br>
    Un ritardo di 30 s su un'applicazione «pronto al volo» = 30 s dopo la comparsa della schermata «Pronto al volo».

### Gli argomenti di avvio

Campo facoltativo: i parametri della riga di comando passati all'eseguibile, separati da spazi (es. `--auto`).<br>
Vengono mostrati sulla scheda, sotto il percorso.

L'applicazione viene sempre avviata dalla **propria cartella di installazione**.

---

## La timeline

Il centro del banner mostra la **sequenza di avvio**: quale applicazione parte in quale momento.<br>
Compare non appena almeno un'applicazione ha un avvio automatico.

![La timeline della sequenza di avvio](assets/timeline-dual.png)

Ogni blocco rappresenta un istante di partenza, con le icone delle applicazioni interessate.<br>
Passa il mouse su un blocco per vederne i nomi e lo stato.

Poiché i due attivatori sono indipendenti, la timeline mostra **due piste**:

- Una pista per «avvio sim»
- Una pista per «pronto al volo».

### Due stili di visualizzazione possibili

Nelle [Opzioni](options.md) → **Aspetto** → **Stile della sequenza** puoi scegliere la rappresentazione che ti è più congeniale:

- **Doppio** — Due piste distinte, una per ciascuna sequenza
- **Mono** — Una sola pista divisa a metà, una parte per ciascuna sequenza

## Gli stati di una scheda

Il **contorno** della scheda e il suo **badge** indicano lo stato dell'applicazione

|                        Badge                        | Contorno | Significato                                                        |
| :-------------------------------------------------: | :------: | -------------------------------------------------------------------- |
| ![Badge conto alla rovescia](assets/badge-countdown.png) |   blu    | Il ritardo è in corso.<br>Il badge mostra i secondi rimanenti.     |
|      ![Badge in corso](assets/badge-running.png)    |  verde   | Il processo è avviato.                                             |
|       ![Badge errore](assets/badge-error.png)       |  rosso   | L'avvio non è riuscito.                                            |
|                   *nessun badge*                    |          | Applicazione arrestata/inattiva.                                   |

**Passa il mouse su un badge** per avere più dettagli: il badge di errore indica la causa (eseguibile non trovato, diritti di amministratore richiesti…), e il badge verde mostra il **PID** del processo.

### Annullare un avvio

Durante un conto alla rovescia, accanto al badge compare una croce **✕**. Permette di **annullare l'avvio** solo di quell'applicazione. Le altre proseguono normalmente la loro sequenza.

### Applicazioni avviate fuori dal programma

MFSAppsControl verifica regolarmente quali processi sono realmente in esecuzione.<br>
Se avvii tu stesso un'applicazione configurata (o la chiudi), la sua scheda si aggiorna.<br>
Passa a **IN CORSO verde** senza che MFSAppsControl l'abbia avviata.

In questo caso, il suggerimento del badge mostra il **PID** del processo adottato:

```
Processo attivo
PID 24680
```

## Modificare o agire su un'applicazione

Apri il menu **:material-dots-horizontal:** della scheda, oppure fai **clic destro**:

| Voce                                        | Effetto                                                        |
| ------------------------------------------- | ---------------------------------------------------------------- |
| :material-square-edit-outline: **Modifica** | Riapre la finestra delle impostazioni, precompilata.           |
| :material-play: **Avvia ora**               | Avvia l'applicazione immediatamente, senza ritardo.            |
| :material-stop-circle: **Arresta**          | Arresta il processo in corso (sostituisce «Avvia ora»).        |
| :material-delete: **Rimuovi dalla lista**   | Elimina l'applicazione dal profilo.                            |

![Modificare un'applicazione](assets/app-editmenu.png)

## Filtrare e ordinare

La barra sopra la griglia offre due menu:

- **Filtra** — *Tutte*, *Avvio MSFS* (applicazioni con avvio automatico),
  *Arresto MSFS* (applicazioni con arresto automatico), *Pronto al volo* (applicazioni con
  attivatore SimConnect).
- **Ordina** — per *Nome* (alfabetico) o per *Ritardo* (crescente).

Queste impostazioni cambiano **solo la visualizzazione** e non hanno effetto né sulla sequenza di avvio né sul profilo.

![Filtrare e ordinare](assets/app-filters.png)

## Durante il volo, la configurazione è bloccata

Non appena il simulatore viene rilevato, il profilo e le applicazioni sono **bloccati** (lucchetto :material-lock:{ style="color:#3ecf8e" }).<br>

Puoi comunque **avviare** o **arrestare** un'applicazione a mano dal menu **:material-dots-horizontal:**.

## Applicazioni che richiedono l'amministratore

Alcune applicazioni richiedono i **diritti di amministratore** (ad esempio Active Sky, REX Atmos).<br>
Mostrano uno **scudo** <span style="color:red;">:material-shield-alert:</span> accanto al loro nome.

Quando un'applicazione di questo tipo è presente nel profilo attivo, ti verrà chiesto di **riavviare come amministratore** all'avvio o al momento dell'aggiunta, tramite **una sola** richiesta UAC.

!!! info "Solo le applicazioni che lo richiedono vengono elevate"
    Anche quando MFSAppsControl gira come amministratore, **non** trasmette quei diritti a tutto ciò che avvia.<br>
    Ogni applicazione parte con i diritti che richiede **il suo stesso eseguibile**: solo quelle che hanno davvero bisogno dell'amministratore lo ricevono.

!!! tip "Se rifiuti l'elevazione"
    MFSAppsControl continua a funzionare normalmente, ma le applicazioni amministratore **non verranno avviate**.<br>
    La loro scheda mostrerà l'errore «MFSAppsControl deve essere eseguito come amministratore».<br>
    Non potrà nemmeno chiuderle all'arresto del simulatore.

## Percorso non valido / Errore di avvio

Se l'eseguibile di un'applicazione è **introvabile** (spostato/disinstallato), o se si verifica un errore durante l'esecuzione, la sua scheda passa in **errore rosso** con il dettaglio dell'errore nelle informazioni del badge.

Questa applicazione viene quindi:

- **ignorata dalla sequenza di avvio** (nessun tentativo di avvio);
- **esclusa dal rilevamento dei processi**.

## Provare la sequenza

Il pulsante **Prova** riproduce **tutta** la sequenza senza avviare il simulatore.<br>
Si tratta solo di una simulazione dell'avvio/arresto del simulatore: le tue applicazioni vengono realmente avviate.

Lo svolgimento è il seguente:

1. Lo stato passa a «simulatore rilevato», in blu.
2. Dopo **5 s**, lo stato passa a «in esecuzione». La sequenza **Avvio sim** si attiva secondo i ritardi configurati con **SimConnect connesso**, come in una sessione reale, dove SimConnect si attiva durante il caricamento.
3. Sotto il pulsante compare un conto alla rovescia **«Pronto al volo tra 10s…»\***: è il tempo simulato per arrivare alla schermata «Pronto al volo».<br> **\*** Il conto alla rovescia appare solo se il tuo profilo contiene almeno un'applicazione **Pronto al volo** valida.
4. Alla fine di questo intervallo, la sequenza **Pronto al volo** si attiva a sua volta, secondo i ritardi configurati.

Il pulsante diventa **Arresta** fin dall'inizio: cliccaci per terminare la prova e chiudere tutte le applicazioni con arresto automatico già avviate.<br>
Si **blocca** durante la chiusura — alcune applicazioni impiegano qualche secondo a chiudersi correttamente — poi torna a essere **Prova**.

!!! note
    Attenzione: anche le applicazioni già avviate prima della prova verranno **chiuse** se sono configurate per l'arresto automatico. La prova non fa distinzione tra le applicazioni avviate da MFSAppsControl e quelle avviate manualmente.
