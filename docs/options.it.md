# Opzioni

Apri le opzioni con l'icona a forma di **ingranaggio** :material-cog: della barra del titolo,
oppure dal menu dell'icona nell'area di notifica.

![La finestra Opzioni](assets/options.png)

Tutte le impostazioni vengono **salvate immediatamente** — non c'è alcun pulsante
«Applica».

## Generale

| Opzione                                       | Effetto                                                                                              |
| --------------------------------------------- | ------------------------------------------------------------------------------------------------------ |
| **Avvia all'avvio di Windows**                | Si avvia automaticamente con la tua sessione di Windows.                                             |
| **Riduci nell'area di notifica**              | Riduce la finestra nell'area di notifica (tray) invece di lasciarla nella barra delle applicazioni.  |
| **La chiusura riduce nell'area di notifica**  | La chiusura riduce la finestra nell'area di notifica (tray) invece di chiudere l'applicazione.       |
| **Avvia ridotto nell'area di notifica**       | Si avvia direttamente nel tray, con la finestra nascosta.                                            |

!!! info "Come chiudere davvero l'applicazione se la chiusura la riduce nell'area di notifica?"
    Se **La chiusura riduce nell'area di notifica** è attiva, la croce non chiude più l'applicazione.<br>
    Usa **Esci** nel menu dell'icona dell'area di notifica (clic destro).

## Aspetto

### Tema dell'applicazione

*Sistema* (segue lo stile di Windows), *Chiaro* o *Scuro*.<br>
Anche il pulsante :material-weather-sunny:/:material-weather-night: della barra del titolo cambia rapidamente il tema.

### Stile della sequenza

Sceglie la rappresentazione della [sequenza](applications.md#la-timeline):

- **Doppio** — Due piste indipendenti, una per ciascuna sequenza.
- **Mono** — Una sola pista divisa a metà, una parte per ciascuna sequenza.

### Lingua dell'interfaccia

Traduzione completa in: francese, inglese, tedesco, spagnolo, italiano, portoghese.<br>
Applicata immediatamente, senza bisogno di riavviare, e salvata nella configurazione.<br>
Disponibile anche nella barra del titolo, con la bandiera della lingua in uso.<br>

!!! info
    Impostata automaticamente in base alla lingua di Windows al primo avvio, ma modificabile in qualsiasi momento.

## Aggiornamenti

- **Verifica automaticamente gli aggiornamenti** — attiva il controllo automatico ogni giorno.
- **Verifica ora** — avvia una ricerca immediata. Il risultato compare sotto l'etichetta (aggiornato / nuova versione disponibile).

!!! info
    Quando è disponibile un aggiornamento, nella barra del titolo compare un **badge**; un clic avvia il download e l'installazione.

## Debug

### Livello di log

Determina il dettaglio scritto nei file di log. La modifica si applica **immediatamente**, senza riavviare l'applicazione.

| Livello                  | Contenuto                                                        | Quando usarlo               |
| ------------------------ | ---------------------------------------------------------------- | --------------------------- |
| **Errore** *(predefinito)* | Solo errori e avvisi.                                          | Nell'uso normale.           |
| **Debug**                | + lo svolgimento delle operazioni (rilevamenti, avvii, arresti…). | Su richiesta del supporto.  |
| **Trace**                | + il dettaglio dei valori interni. Molto pesante.                | Su richiesta del supporto.  |

Ogni giorno viene creato un nuovo file, e i log più vecchi di **7 giorni** vengono eliminati automaticamente.

!!! tip
    Ricordati di **rimettere il livello su Errore** una volta segnalato il tuo problema: i livelli Debug e Trace sono molto pesanti.

### Esportare

Crea un file **`zip`** contenente tutti i tuoi log **e** la tua configurazione, necessari a fini di supporto.

### Reimpostare l'applicazione

Cancella **tutti i tuoi profili e le tue impostazioni** e riparte da zero come al momento dell'installazione.<br>
**Viene chiesta una conferma esplicita.**

!!! danger "Azione irreversibile"
    Dopo una reimpostazione non si recupera più nulla.<br>

## Informazioni

Mostra il dettaglio dell'applicazione e i collegamenti rapidi a **Discord**/**Flightsim.to**.
