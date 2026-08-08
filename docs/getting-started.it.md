# Per iniziare

MFSAppsControl si basa su una sola idea:<br>
Gestire le applicazioni da avviare e/o arrestare insieme al tuo simulatore senza doverci pensare.

---

## La schermata principale

![La schermata principale di MFSAppsControl](assets/main-screen-numbers.png)

### 1. La barra del titolo

A sinistra, il logo con il nome dell'applicazione.<br>
A destra, da sinistra a destra:

- la **versione** (vX.Y.Z),
- la lingua (:flag_gb:),
- il **tema** (:material-weather-sunny:),
- l'**aiuto** (:material-help-circle:),
- le **opzioni** (:material-cog:),
- e i pulsanti di gestione della finestra (:material-window-minimize:, :material-window-maximize:, :material-window-close:).

Quando è disponibile una nuova versione, accanto alla versione compare un **badge**. Un clic avvia il download e l'installazione.

### 2. Il banner di stato e sequenza

È la rappresentazione visiva di:

- lo stato del simulatore e della connessione SimConnect,
- la sequenza di avvio delle applicazioni,
- il pulsante di prova della sequenza.

![Sequenza applicazioni - Stati](assets/app-sequence-status.png)


**A sinistra, gli stati** — MSFS e SimConnect.<br>

- Stato MSFS

  | Indicatore                                       | Etichetta                            | Descrizione                                    |
  | ------------------------------------------------ | ------------------------------------ | ---------------------------------------------- |
  | :material-circle:{ style="color:#8a8f98" } grigio | **MSFS non attivo**                  | Il simulatore non è avviato/rilevato.          |
  | :material-circle:{ style="color:#4a9eff" } blu   | **Avvio degli addon…**               | Il processo del simulatore è stato rilevato.   |
  | :material-circle:{ style="color:#3ecf8e" } verde | `FlightSimulator2024.exe · PID 1234` | Le informazioni del processo sono recuperate.  |

- Stato SimConnect

  | Indicatore                                       | Etichetta                     | Descrizione                                        |
  | ------------------------------------------------ | ----------------------------- | -------------------------------------------------- |
  | :material-circle:{ style="color:#8a8f98" } grigio | **SimConnect disconnesso**    | In attesa dell'avvio del simulatore.               |
  | :material-circle:{ style="color:#3ecf8e" } verde | **SimConnect connesso**       | Connessione stabilita, sistema pronto.             |
  | :material-circle:{ style="color:#ff5c5c" } rosso | **SimConnect non disponibile** | SimConnect non risponde (vedi le [FAQ](faq.md)).  |


**Al centro, la sequenza di avvio**<br>
La timeline delle tue applicazioni, rappresentate dalle loro icone, sui rispettivi ritardi di avvio (visibile solo se è configurata almeno un'applicazione). → [Il dettaglio della timeline](applications.md#la-timeline)


**A destra, il pulsante Prova/Arresta**<br>
Permette di simulare l'avvio/arresto di MSFS per provare le sequenze senza avviare MSFS.<br>
Durante un volo o una prova diventa **Arresta**. → [Provare la sequenza](applications.md#provare-la-sequenza)

### 3. I profili

Mostra tutti i tuoi profili disponibili, con il profilo attivo in evidenza.

![App - Profili](assets/app-profiles.png)

Un pulsante per **creare** un nuovo profilo.<br>
Possono essere riordinati trascinando le schede.<br>
Il menu **:material-dots-horizontal:** permette di rinominarli/duplicarli/eliminarli. → [Profili](profiles.md)


### 4. I filtri

Mostra il numero di applicazioni e permette di filtrare e ordinare le applicazioni dell'elenco.

![App - Filtri](assets/app-filters.png)

- **Filtra**: Tutte / Avvio MSFS / Arresto MSFS / Pronto al volo
- **Ordina**: Nome / Ritardo

Queste impostazioni riguardano solo la visualizzazione.


### 5. Le applicazioni

Rappresentate da una **scheda** per ogni applicazione configurata.

![App - Scheda](assets/app-card.png)

Una **scheda** mostra le informazioni dell'applicazione e la sua configurazione. → [Anatomia di una scheda](applications.md#anatomia-di-una-scheda)


---

## La tua prima configurazione

### 1. Il profilo predefinito

Al primo avvio ti aspetta un **profilo predefinito**, vuoto.<br>
Usalo così com'è, rinominalo, e creane altri secondo le tue esigenze. → [Profili](profiles.md)

### 2. Aggiungi un'applicazione

Fai clic sulla scheda **Aggiungi un'applicazione**.<br>
Scegli l'applicazione → [Aggiungere un'applicazione](applications.md#aggiungere-unapplicazione):

- Nell'elenco delle **Applicazioni installate**
- Oppure tramite il percorso del suo `.exe` con **Sfoglia**

### 3. Definisci le sue opzioni di controllo

È l'impostazione più importante. Nella finestra di aggiunta, la riga **Attivazione** propone:

- **Avvio sim** :material-play: per avviarla insieme al simulatore (MobiFlight, Navigraph…).
- **Pronto al volo** :material-airplane: per avviarla quando sei già nell'aereo (REX Atmos, vPilot…).

Nessuna delle due è obbligatoria: il pulsante **Arresta** :material-stop: arresterà l'applicazione insieme al simulatore. (Attivato automaticamente se l'applicazione parte in modalità «Pronto al volo»)

### 4. Imposta il ritardo

Il **ritardo** permette di posticipare l'avvio, a partire dall'attivatore scelto. → [Il ritardo](applications.md#il-ritardo)

### 5. Prova

Fai clic su **Prova**: la sequenza si svolge come se il simulatore stesse partendo.<br>
Un conto alla rovescia **«Pronto al volo tra 10s…»** simula la connessione SimConnect dopo 10 s.

Fai clic su **Arresta** per fermare la prova e chiudere le applicazioni configurate con l'opzione.

## Lo svolgimento di un volo

| Momento                                              | Cosa fa MFSAppsControl                                                                                                                                          |
| ---------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Avvii **MSFS**                                       | Lo stato MSFS passa al blu.                                                                                                                                     |
| Il simulatore carica                                 | Lo stato MSFS passa al verde, lo stato SimConnect passa al verde appena disponibile e le applicazioni «avvio sim» partono secondo il loro ritardo.               |
| Arrivi sulla schermata **Pronto al volo** di un volo | La sequenza **Pronto al volo** parte a sua volta, con i propri ritardi.                                                                                         |
| Cambi volo                                           | Le applicazioni **non vengono riavviate**, restano attive.                                                                                                      |
| Esci da **MSFS**                                     | Tutte le applicazioni configurate su **Arresto auto** (comprese quelle legate alla modalità «Pronto al volo») vengono chiuse in modo pulito.                    |

!!! info "Se MSFS è già avviato prima di MFSAppsControl"
    La sequenza **non si attiva**! Si armerà al prossimo avvio di MSFS.<br>
    È un caso complesso, in cui non si può garantire un avvio corretto e senza problemi.<br>
    Le applicazioni già avviate vengono comunque rilevate e verranno chiuse in modo pulito alla chiusura del simulatore, se l'opzione è attiva.<br><br>
    **Suggerimento**: puoi sempre avviare un'applicazione manualmente dal menu **:material-dots-horizontal:** della sua scheda, o fuori dall'app.

---

## Sempre pronto

Attiva **Avvia all'avvio di Windows** e **Avvia ridotto nell'area di notifica** nelle [Opzioni](options.md).<br>
Puoi dimenticartene, oppure aprirlo semplicemente per cambiare profilo prima del volo.

![L'icona nell'area di notifica](assets/tray.png)
