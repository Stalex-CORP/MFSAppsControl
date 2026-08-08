# Risoluzione dei problemi (FAQ)

## Rilevamento del simulatore

??? question "MSFS non viene rilevato"
    MFSAppsControl monitora i processi `FlightSimulator2024.exe` (MSFS 2024)
    e `FlightSimulator.exe` (MSFS 2020). Assicurati che il simulatore sia effettivamente avviato.<br>
    Il passaggio a «in esecuzione» richiede qualche secondo dopo l'avvio di MSFS.

??? question "Ho avviato MFSAppsControl mentre MSFS era già in esecuzione e non succede nulla"
    È **voluto**. Se il simulatore è già presente all'avvio
    dell'applicazione, la sequenza non viene attivata: altrimenti, aprire
    MFSAppsControl in pieno volo riavvierebbe applicazioni indesiderate.

    Si armerà automaticamente al prossimo avvio. Nel frattempo puoi
    avviare un'applicazione a mano dal menu **⋯** della sua scheda.

??? question "L'indicatore SimConnect resta grigio anche se MSFS è in esecuzione"
    MFSAppsControl tenta la connessione **solo quando il simulatore è avviato**,
    e poi riprova regolarmente. Qualche secondo di attesa è normale
    all'avvio di MSFS.

    Se resta grigio a lungo:

    - verifica che il simulatore abbia finito di avviarsi (SimConnect è disponibile
      solo quando il simulatore è realmente inizializzato e durante la schermata di caricamento);
    - verifica che nessun antivirus o firewall stia bloccando MFSAppsControl;

    Dopo molto tempo senza connessione mentre MSFS è in esecuzione, l'indicatore passa al
    **rosso** («SimConnect non disponibile») per segnalare il problema.

    Senza SimConnect, l'attivatore «pronto al volo» non funziona.

## Avvio delle applicazioni

??? question "Un'applicazione non si avvia"
    - Verifica che la sua scheda non sia in **errore** (passa il mouse sul badge per leggere il messaggio di errore).
    - Verifica che sia attivo un **attivatore** (:material-play: o :material-airplane:). Se nessuno dei due è acceso, l'applicazione non viene mai avviata automaticamente.
    - Se l'attivatore è **Pronto al volo**, l'applicazione partirà solo a partire dalla schermata «Pronto al volo» — e solo se **SimConnect è connesso**.
    - Se l'applicazione mostra uno **scudo** :material-shield-alert:, richiede i diritti di amministratore (vedi sotto).
    - Usa **Prova** per riprodurre la sequenza senza avviare MSFS e osservare lo stato di ogni scheda.

??? question "Le applicazioni «pronto al volo» non si avviano mai"

    Nell'ordine:

    1. L'indicatore **SimConnect connesso** è verde durante il volo?
    2. Il pulsante :material-airplane: è effettivamente attivo sulla scheda (e non :material-play:)?
    3. Hai già volato in questa sessione? Le applicazioni «pronto al volo» si avviano **una sola volta per sessione di simulatore** — non vengono riavviate tra un volo e l'altro.

    Per verificare tutto senza volare, usa il pulsante **Prova**: simula SimConnect dopo 10 secondi.

??? question "Le mie applicazioni «pronto al volo» partono troppo presto"
    È il comportamento previsto. L'attivazione avviene non appena compare la schermata «Pronto al volo», dopo il caricamento.

    Aggiungi un **ritardo** sulla scheda per posticiparne l'avvio di altrettanti secondi dopo quel momento.

??? question "L'applicazione richiede i diritti di amministratore (UAC)"
    Alcune applicazioni (Active Sky, REX Atmos…) richiedono l'amministratore. Per
    avviarle — e per **arrestarle** — MFSAppsControl deve essere elevato. Quando un
    add-on di questo tipo è presente nel profilo attivo, l'applicazione si riavvia
    automaticamente come amministratore (**una sola** richiesta UAC).

    **Le altre applicazioni non ereditano quei diritti**: ognuna parte con
    quelli che richiede il suo stesso eseguibile. vPilot o Navigraph girano da
    utente normale anche quando MFSAppsControl è elevato.

    Se rifiuti la richiesta, tutto il resto continua a funzionare, ma quelle
    applicazioni non partiranno, con l'errore «MFSAppsControl deve essere eseguito
    come amministratore».

??? question "Un'applicazione si apre davanti al simulatore"
    Attiva **Avvia ridotta** :material-arrow-collapse: sulla sua scheda: verrà
    avviata in una finestra ridotta, senza passare davanti a MSFS. MFSAppsControl segue
    anche le finestre dei **sotto-processi** dell'applicazione (alcune, come
    FS2Crew, aprono la loro interfaccia tramite un altro processo).

    Qualche raro software con finestra personalizzata forza comunque la propria finestra
    in primo piano. A volte si tratta di un'opzione disponibile nell'applicazione stessa, a volte di un comportamento interno dell'applicazione che non può essere aggirato.

??? question "Le mie applicazioni non si chiudono quando esco da MSFS"
    Verifica che il pulsante **Arresto auto** :material-square: sia attivo sulla loro
    scheda — è **indipendente** dall'avvio automatico — e che MSFS sia effettivamente chiuso (Gestione attività).

    MFSAppsControl chiede prima una **chiusura pulita**, poi **forza l'arresto**
    dei processi che dovessero restare attivi — comprese alcune applicazioni che continuano a girare in background dopo aver chiuso la loro finestra.

    Se l'applicazione richiede i diritti di amministratore, anche MFSAppsControl deve essere elevato per poterla arrestare (vedi sopra).

??? question "Un'applicazione risulta «IN CORSO» anche se non l'ho avviata da MFSAppsControl"
    È normale: MFSAppsControl verifica regolarmente quali processi sono realmente
    in esecuzione e **adotta** quelli che corrispondono alle applicazioni configurate. Così la visualizzazione resta fedele alla realtà, sia che tu avvii le tue
    applicazioni da MFSAppsControl sia che tu lo faccia a mano.

    Passa il mouse sul badge per vedere il **PID** del processo interessato.

## Interfaccia

??? question "Perché il ritardo è in grigio?"
    Perché per questa applicazione non è scelto alcun **avvio automatico**. Attiva :material-play: o :material-airplane: e torna regolabile.

??? question "Perché durante il volo compaiono il lucchetto e i pulsanti in grigio?"
    Non appena il simulatore viene rilevato, la configurazione delle schede e i profili sono **bloccati**: modificare una sequenza mentre è in corso
    (o cambiare profilo in pieno volo) sarebbe complesso da gestire.

    Il menu **⋯** resta disponibile per avviare o arrestare un'applicazione manualmente.

??? question "Perché non posso disattivare l'arresto auto su un'applicazione «pronto al volo»?"
    Un'applicazione avviata per il volo non ha alcun motivo di sopravvivere al simulatore: per questo attivatore l'arresto automatico è quindi **bloccato in posizione attiva**.<br>
    Rimetti la scheda su **Avvio sim** se vuoi tenerla aperta dopo il volo.

??? question "Come esco davvero dall'applicazione quando è nell'area di notifica?"
    Se l'opzione **La chiusura riduce nell'area di notifica** è attiva, la croce nasconde la finestra invece di uscire.<br>
    Fai **clic destro sull'icona** nell'area di notifica → **Esci**.<br>
    Altrimenti usa semplicemente la croce della finestra per chiudere l'applicazione.

??? question "La finestra si è aperta fuori dallo schermo / troppo piccola"
    MFSAppsControl memorizza la posizione della finestra. In caso di problemi di visualizzazione (ad esempio dopo un cambio di schermo), sposta o ridimensiona la finestra: la nuova posizione verrà memorizzata.<br><br>
    **Suggerimento pratico**<br>
    Usa " ++windows++ + freccia sinistra " o " ++windows++ + freccia destra " per spostarla tra le aree degli schermi.

## Dati e manutenzione

??? question "Dove vengono salvati i miei profili e le mie impostazioni?"
    In un unico file:
    `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\settings.json`<br>
    (cioè `C:\Users\<tu>\AppData\Local\Stalex CORP\MFSAppsControl\`).

    Questo file è **cifrato**: non è modificabile direttamente. Per
    salvarlo, copialo così com'è.
    → [Profili](profiles.md)

??? question "Dove sono i log?"
    In `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\logs`. (Un file al giorno, conservati **7 giorni**).<br>
    **Per trasmetterli al supporto:**<br>
    **Opzioni → Debug → Esporta i log**, che produce uno `.zip` completo (log + configurazione). → [Supporto](support.md)

??? question "Come riparto da zero?"
    **Opzioni → Debug → Reimposta l'applicazione** cancella tutto e riporta l'applicazione allo stato dell'installazione.<br>
    **Questa azione è irreversibile** — copia prima il tuo `settings.json` se ti serve.

??? question "Posso usare MFSAppsControl con MSFS 2020?"
    Sì, entrambe le versioni (2024 e 2020) sono supportate, incluso il
    rilevamento «pronto al volo». Uno stesso profilo funziona con qualsiasi versione.

??? question "Come aggiorno l'applicazione?"
    Quando è disponibile un aggiornamento, nella barra del titolo compare un
    **badge**. Fai clic per scaricare e installare la nuova versione.<br>
    I tuoi profili e le tue impostazioni vengono conservati.

!!! info "Ancora bloccato?"
    Fai la tua domanda sul [**Discord**](support.md), nel canale dedicato
    **#mfsappscontrol** — allegando lo zip esportato.
