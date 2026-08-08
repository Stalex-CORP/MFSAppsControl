# Prise en main

MFSAppsControl repose sur une seule idée :<br>
Gérer les applications à démarrer et/ou arrêter avec votre simulateur sans devoir y penser.

---

## L'écran principal

![L'écran principal de MFSAppsControl](assets/main-screen-numbers.png)

### 1. La barre de titre

A gauche, le logo avec le nom de l'application.<br>
A droite de gauche à droite : 

- la **version** (vX.Y.Z),
- la langue (:flag_gb:),
- le **thème** (:material-weather-sunny:),
- l'**aide** (:material-help-circle:),
- les **options** (:material-cog:),
- et les boutons de gestion de la fenêtre (:material-window-minimize:, :material-window-maximize:, :material-window-close:).

Quand une nouvelle version est disponible, un **badge** apparaît à côté de la version. Un clic dessus lance le téléchargement et l'installation.

### 2. Le bandeau de statut & séquence

C'est l'affichage visuel de :

- l'état du simulateur et de la connexion SimConnect,
- la séquence de lancement des applications,
- le bouton de test de la séquence.

![App Sequence - Statuts](assets/app-sequence-status.png)


**À gauche, les statuts** — MFS et SimConnect.<br>

- Statut MFS

  | Bulle                                            | Libellé                              | Description                                    |
  | ------------------------------------------------ | ------------------------------------ | ---------------------------------------------- |
  | :material-circle:{ style="color:#8a8f98" } grise | **MFS arrêté**                       | Le simulateur n'est pas lancé/détecté.         |
  | :material-circle:{ style="color:#4a9eff" } bleue | **Lancement des applications…**      | Le processus du simulateur est détecté.        |
  | :material-circle:{ style="color:#3ecf8e" } verte | `FlightSimulator2024.exe · PID 1234` | Les informations du processus sont récupérées. |

- Statut SimConnect

  | Bulle                                            | Libellé                     | Description                                       |
  | ------------------------------------------------ | --------------------------- | ------------------------------------------------- |
  | :material-circle:{ style="color:#8a8f98" } grise | **SimConnect déconnecté**   | En attente de lancement du simulateur.            |
  | :material-circle:{ style="color:#3ecf8e" } verte | **SimConnect connecté**     | Connexion établie, système prêt.                  |
  | :material-circle:{ style="color:#ff5c5c" } rouge | **SimConnect indisponible** | SimConnect ne répond pas (voir la [FAQ](faq.md)). |


**Au centre, la séquence de lancement**<br>
La timeline de vos applications représentées par leurs icônes, sur les délais de démarrage (visible uniquement si au moins une application est configurée). → [Le détail de la timeline](applications.md#la-timeline)


**À droite, le bouton Tester/Arrêter**<br>
Permet de simuler le lancement/arrêt de MFS pour tester les séquences sans lancer MFS.<br>
Pendant un vol ou un test, il devient **Arrêter**. → [Tester la séquence](applications.md#tester-la-sequence)

### 3. Les profils

Affiche l'ensemble de vos profils disponibles, avec le profil actif mis en évidence.

![App - Profils](assets/app-profiles.png)

Un bouton pour **créer** un nouveau profil.<br>
Ils peuvent être réorganisés en glissant les onglets.<br>
Le menu **:material-dots-horizontal:** permet de les renommer/dupliquer/supprimer. → [Profils](profiles.md)


### 4. Les filtres

Affiche le nombre d'applications et permet de filtrer et trier les applications de la liste.

![App - Filters](assets/app-filters.png)

- **Filtrer** : Toutes / Démarrage MFS / Arrêt MFS / Prêt à voler
- **Trier** Nom / Délai

Ces réglages n'affectent que l'affichage.


### 5. Les applications

Représentées par des **cartes** pour chaque application configurée.

![App - Carte](assets/app-card.png)

Une **carte** affiche les informations de l'application et sa configuration. → [Anatomie d'une carte](applications.md#anatomie-dune-carte)


---

## Votre première configuration

### 1. Le profil par défaut

Au premier lancement, un **profil par défaut** vous attend, vide.<br>
Utilisez-le tel quel, renommez-le, et créez-en d'autres selon vos besoins. → [Profils](profiles.md)

### 2. Ajoutez une application

Cliquez sur la carte **Ajouter une application**.<br>
Choisissez l'application→ [Ajouter une application](applications.md#ajouter-une-application) :

- Dans la liste des **applications installées**
- Ou par le chemin de son `.exe` via **Parcourir**

### 3. Définissez ses options de contrôle

C'est le réglage le plus important. Dans la fenêtre d'ajout, la ligne **Déclencheur** propose :

- **Démarrage sim** :material-play: pour la lancer avec le simulateur (MobiFlight, Navigraph…).
- **Prêt à voler** :material-airplane: pour la lancer en étant dans l'avion. (REX Atmos, vPilot…).

Aucun des deux n'est obligatoire, le bouton **Arrêter** :material-stop: arrêtera l'application avec le simulateur. (Automatiquement activée si l'application est lancée en mode "Prêt à voler")

### 4. Réglez le délai

Le **délai** permet de retarder le démarrage, sur le déclencheur choisi. → [Le délai](applications.md#le-delai)

### 5. Testez

Cliquez sur **Tester** : la séquence se déroule comme si le simulateur démarrait. <br>
Un compte à rebours **« Prêt à voler dans 10 s… »** simule la connexion SimConnect après 10s.

Cliquez sur **Arrêter** pour arrêter le test et fermer les applications configurées avec l'option.

## Le déroulé d'un vol

| Moment                                             | Ce que fait MFSAppsControl                                                                                                                          |
| -------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| Vous lancez **MFS**                                | Le statut MFS passe au bleu.                                                                                                                        |
| Le simulateur charge                               | Le statut MFS passe au vert, le statut SimConnect passe au vert dès que disponible et les applications démarrage sim sont lancées selon leur délai. |
| Vous arrivez sur l'écran **Prêt à voler** d'un vol | La séquence **Prêt à voler** démarre à son tour, avec ses propres délais.                                                                           |
| Vous changez de vol                                | Les applications **ne se relancent pas**, elles restent actives.                                                                                    |
| Vous quittez **MFS**                               | Toutes les applications configurées en **Arrêt auto** (incluant celles liées au mode "Prêt à voler") sont fermées proprement.                       |

!!! info "Si MFS est déjà démarré avant MFSAppsControl"
    La séquence **ne se déclenche pas** ! Elle s'armera au prochain lancement de MFS.<br>
    Ce cas est complexe qui ne peut garantir un lancement correct sans problème.<br>
    Les applications déjà lancées seront détectées et seront fermer proprement à la fermeture du simulateur si l'option est activée.<br><br>
    **Astuce** : Vous pouvez toujours lancer une application manuellement via le menu **:material-dots-horizontal:** de sa carte ou en dehors.

---

## Toujours prêt

Activez **Lancer au démarrage de Windows** et **Démarrer réduit dans la barre système** dans les [Options](options.md).<br>
Vous pouvez l'oublier ou simplement l'ouvrir pour changer de profil avant votre vol.

![L'icône dans la zone de notification](assets/tray.png)
