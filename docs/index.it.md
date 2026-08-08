# MFSAppsControl

## Descrizione

**MFSAppsControl** è un'applicazione che permette di **avviare e/o arrestare** le applicazioni di terze parti monitorando lo stato di Microsoft Flight Simulator 2024/2020.<br>
Non dovrai più avviare le tue applicazioni una per una prima di ogni volo: configurale una volta e MFSAppsControl pensa a tutto.

![La schermata principale di MFSAppsControl](assets/main-screen.png)

## Come funziona

MFSAppsControl segue il tuo volo dall'inizio alla fine, in **tre fasi**:

::timeline::

- title: Avvio del simulatore
  content: Le applicazioni impostate su **Avvio sim** partono non appena il simulatore viene avviato, secondo il ritardo definito.
  icon: ' :material-numeric-1: '

- title: Schermata «Pronto al volo»
  content: Le applicazioni impostate su **Pronto al volo** partono non appena compare il pulsante «Pronto al volo», secondo il ritardo definito.
  icon: ' :material-numeric-2: '

- title: Arresto del simulatore
  content: Le applicazioni impostate su **Arresto auto** si chiudono in modo pulito alla chiusura del simulatore.
  icon: ' :material-numeric-3: '

::/timeline::


**La differenza tra i due tipi di avvio è il cuore dell'applicazione:**<br>
Alcune applicazioni possono:

- Essere avviate **fin dall'avvio** del simulatore (es. Navigraph, Volanta…)
- Avere vincoli / essere utili solo **durante un volo** (es. REX Atmos, FS2Crew…)

Sta a te scegliere ciò che si adatta meglio all'applicazione. → [Applicazioni e sequenza](applications.md#i-due-attivatori-di-avvio)

## Le funzionalità

<div class="grid cards" markdown>

- <span style="color: var(--md-accent-fg-color)">:material-rocket-launch: **Sequenza automatica**</span><br>
  Ogni applicazione parte secondo il proprio attivatore dopo il ritardo definito, visualizzato direttamente sulla timeline per l'ordine di avvio.

- <span style="color: var(--md-accent-fg-color)">:material-folder-multiple: **Profili**</span><br>
  Raggruppa le tue applicazioni per uso (A320, VFR, cargo…) e cambia con un clic. Il profilo mostrato è il profilo attivo.

- <span style="color: var(--md-accent-fg-color)">:material-tray-arrow-down: **Discreto**</span><br>
  Può essere ridotto nell'area di notifica e avviarsi con Windows, per essere pronto in ogni momento ai tuoi prossimi voli senza pensarci.

- <span style="color: var(--md-accent-fg-color)">:material-translate: **Interfaccia completamente multilingue**</span><br>
  Tradotta interamente in francese, inglese, tedesco, spagnolo, italiano e portoghese, con cambio in tempo reale e salvataggio nella configurazione.

- <span style="color: var(--md-accent-fg-color)">:material-shield-check: **Applicazioni amministratore**</span><br>
  Rilevate automaticamente al momento dell'aggiunta, con una richiesta di Windows. Solo le applicazioni che necessitano di privilegi amministrativi useranno la modalità amministratore.

- <span style="color: var(--md-accent-fg-color)">:material-flask: **Modalità test**</span><br>
  Riproduci tutta la sequenza (attivatore «pronto al volo» incluso) senza avviare il simulatore, per verificare i tuoi profili.

</div>

## Da dove iniziare?

1. [**Installazione**](installation.md) — scaricare e installare l'applicazione.
2. [**Per iniziare**](getting-started.md) — configura la tua prima sequenza.
3. [**Applicazioni e sequenza**](applications.md) — il dettaglio delle varie parti dell'applicazione.
4. [**Profili**](profiles.md) e [**Opzioni**](options.md) — gestisci i tuoi profili e le tue impostazioni.
5. [**FAQ**](faq.md) — le domande più frequenti.
6. [**Supporto**](support.md) — per le richieste di assistenza.
