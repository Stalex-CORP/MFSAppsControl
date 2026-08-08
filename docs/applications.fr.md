# Applications & séquence

Chaque application de votre profil s'affiche sous forme de **carte**.<br>
Cette page détaille comment les ajouter, comment les configurer, et comment lire la **séquence de lancement**.

---

## Ajouter une application

Cliquez sur **Ajouter une application** dans la grille. Deux modes :

=== "Applications installées"

    Liste les logiciels déjà installés (via le registre Windows).<br>
    Recherchez la et sélectionnez-la : le nom, l'icône et le chemin sont récupérés automatiquement.

    ![Mode applications installées](assets/add-app-installed.png)

    !!! note "La liste est volontairement filtrée"
        Pour rester lisible, la liste écarte les logiciels sans rapport avec le vol
        (pilotes et utilitaires système, navigateurs, jeux, lanceurs, etc.) et
        masque les applications **déjà présentes dans le profil actif**. Une
        application installée classiquement qui n'apparaîtrait pas — ou un logiciel
        **portable** — s'ajoute toujours via l'onglet **Parcourir**.

=== "Parcourir"

    Définissez le chemin d'un `.exe`, ou cliquez sur **Parcourir** pour la sélectionner: le nom et l'icône sont récupérés automatiquement.

    ![Mode parcourir](assets/add-app-browse.png)

    !!! note "Utilisation"
        Ce mode est pour les applications **portables** (non installées) ou non détectées qui n'apparaissent pas dans le registre Windows.

La fenêtre d'ajout contient ensuite les **arguments de lancement**, le **déclencheur**, le **délai** et l'option **Démarrer réduit**, tous modifiables après l'ajout.

---

## Anatomie d'une carte

![Carte d'une application](assets/app-card.png)

**En haut** vous retrouvez les informations de l'application :

- L'icône de l'application
- Son **nom**
- Son **chemin**
- Ses **arguments** (sous le chemin lorsque défini).
  
À droite, le **badge de statut** (visible lors de l'exécution) et le menu **:material-dots-horizontal:**.

**En bas, la barre de contrôle** accessibles en un clic :

| Contrôle                                      | Rôle                                                                                                              |
| --------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| :material-play: **Démarrage sim**             | Démarre lors du lancement du simulateur.                                                                          |
| :material-airplane: **Prêt à voler**          | Démarre quand l'écran **Prêt à voler** est affiché.                                                               |
| :material-arrow-collapse: **Démarrer réduit** | Lance l'application en fenêtre réduite.<br>*Visible seulement si un démarrage auto est choisi*                    |
| :material-square: **Arrêt auto**              | Ferme l'application quand le simulateur s'arrête.<br>*Auto activé et verrouillé avec le lancement "Prêt à voler"* |
| :material-minus::material-plus: **Délai**     | Temps d'attente avant le lancement de cette application selon le mode de démarrage.                               |

Ces réglages sont présents également dans la fenêtre de modification.

### Les deux déclencheurs de démarrage

C'est le réglage le plus utile de MFSAppsControl.<br>
Les deux boutons de gauche (:material-play: et :material-airplane:) forment un **choix unique** : activer l'un désactive l'autre, et recliquer sur celui qui est actif **désactive le démarrage automatique**.

|                      | :material-play: **Démarrage sim**         | :material-airplane: **Prêt à voler**         |
| -------------------- | ----------------------------------------- | -------------------------------------------- |
| **Se déclenche**     | Quand le **processus** de MFS est détecté | Quand votre **avion apparaît dans le monde** |
| **Détection**        | Par **surveillance du processus**         | Via **SimConnect**                           |
| **Le délai part**    | Du lancement du simulateur                | A partir de l'écran "Prêt à voler"           |
| **Typiquement pour** | Navigraph, vPilot, un utilitaire matériel | Rex Atmos, FS2Crew, outils avion             |

!!! tip "Comment choisir ?"
    Posez-vous les bonnes questions :<br>
    *« Cette application doit-elle être en place/disponible avant que je commence à voler ? »*<br>
    *« Cette application fonctionne-t-elle sans le simulateur ? »*<br>
    *« Cette application ne gène pas le fonctionnement de mon simulateur ? »*<br>

    - **Oui** → Démarrage sim. Elle doit être en place avant que le vol commence.
    - **Non** → Prêt à voler. Inutile de la faire tourner avant d'être dans le vol.

**Ce qu'il faut savoir sur le démarrage « Prêt à voler »**

!!! info "L'arrêt auto est verrouillé"
    Une application « prêt à voler » se ferme **toujours** avec le simulateur : le bouton :material-square: est verrouillé en position active.<br>
    Une application lancée pour le vol n'a aucune raison de survivre au simulateur.

!!! info "Le déclenchement se fait sur l'écran \"**Prêt à voler**\""
    Concrètement, cela arrive juste après le chargement d'un vol dès que l'écran "Prêt à voler" est affiché.
    C'est la seule détection sécurisée possible pour détecter un vol "proprement".

!!! warning "SimConnect doit être connecté"
    **Ce déclencheur repose sur SimConnect**.<br>
    Si le statut SimConnect n'est pas **vert** (SimConnect connecté), les applications « prêt à voler » ne se lanceront pas.<br>
    Si elle reste longtemps sans se connecter, il passe au **rouge** (« SimConnect indisponible »). → [Dépannage](faq.md)

### L'arrêt automatique

Le bouton :material-square: **Arrêt auto** ferme l'application quand le simulateur s'arrête.<br>
Il est **indépendant** du démarrage : vous pouvez avoir une application que vous lancez à la main ou par un autre moyen, mais que MFSAppsControl ferme avec le simulateur.

La fermeture est **propre** : MFSAppsControl essaye d'abord de fermer l'application comme si vous cliquiez sur la croix, lui laisse quelques secondes pour terminer sa session, et ne force la fermeture qu'en dernier recours.<br>
Les applications qui doivent se déconnecter proprement (exemple Active Sky) sont ainsi traités correctement.

### Démarrer réduit

L'option :material-arrow-collapse: **Démarrer réduit** lance l'application en **fenêtre réduite**, utile lorsque celle-ci ne nécessite pas d'être affichée au premier plan.

Le bouton n'apparaît que si un **démarrage automatique** est choisi.

!!! note
    Certaines applications forcent leur fenêtre au premier plan quelques secondes après leur démarrage.<br>
    MFSAppsControl essaye pendant quelques secondes pour les réduire, mais quelques rares logiciels peuvent résister.

### Le délai

Le **délai** est le temps d'attente avant le lancement de l'application, **à partir de son déclencheur**. Il permet d'**espacer** les démarrages.

- Réglable de **0 à 600 secondes** (10 minutes)
- Les boutons **−** / **+** change par tranche de **5 s**, vous pouvez aussi **saisir** directement la valeur
- Le délai est **grisé** si aucun démarrage automatique n'est choisi
- Pendant un vol, il affiche un **cadenas** :material-lock: — la configuration est verrouillée

!!! tip "Les deux déclencheurs ont leur propre séquence"
    Un délai de 30 s sur une application « démarrage sim » = 30 s après le lancement de MFS. <br>
    Un délai de 30 s sur une application « prêt à voler » = 30 s après l'apparition de l'écran "Prêt à voler".

### Les arguments de lancement

Champ optionnel : les paramètres de ligne de commande passés à l'exécutable, séparés par des espaces (ex. `--auto`).<br>
Ils s'affichent sur la carte, sous le chemin.

L'application est toujours lancée depuis **son propre dossier d'installation**.

---

## La timeline

Le centre du bandeau affiche la **séquence de lancement** : quelle application démarre à quel moment.<br>
Elle apparaît dès qu'au moins une application est en démarrage automatique.

![La timeline de la séquence de lancement](assets/timeline-dual.png)

Chaque bloc représente un instant de départ, avec les icônes des applications concernées.<br>
Survolez un bloc pour voir les noms et leur statut.

Comme les deux déclencheurs sont indépendants, la timeline montre **deux pistes** :

- Une piste pour « démarrage sim »
- Une piste pour « prêt à voler ». 

### Deux styles d'affichage possibles

Dans les [Options](options.md) → **Apparence** → **Style de la séquence**, vous pouvez choisir la représentation qui vous parle le plus :

- **Double** — Deux pistes individuelles pour chaque séquence
- **Mono** — Une seule piste découpées en deux au milieu pour chaque séquence

## Les statuts d'une carte

Le **contour** de la carte et son **badge** indiquent l'état de l'application

|                     Badge                     | Contour | Signification                                                      |
| :-------------------------------------------: | :-----: | ------------------------------------------------------------------ |
| ![Badge décompte](assets/badge-countdown.png) |  bleu   | Le délai est en cours.<br>Le badge affiche les secondes restantes. |
|  ![Badge en cours](assets/badge-running.png)  |  vert   | Le processus est démarré.                                          |
|    ![Badge erreur](assets/badge-error.png)    |  rouge  | Le lancement a échoué.                                             |
|                 *aucun badge*                 |         | Application arrêtée/inactive.                                      |

**Survolez un badge** pour avoir plus de détails : le badge d'erreur indique la cause (exécutable introuvable, droits administrateur requis…), et le badge vert affiche le **PID** du processus.

### Annuler un lancement

Pendant un décompte, une croix **✕** apparaît à côté du badge. Elle permet **d'annuler le lancement** de cette application uniquement. Les autres poursuivent leur séquence normalement.

### Applications lancées en dehors du programme

MFSAppsControl vérifie régulièrement quels processus tournent réellement.<br>
Si vous lancez vous-même une application configurée (ou si vous la fermez), sa carte se met à jour.<br>
Elle passe en **EN COURS verte** sans que MFSAppsControl ne l'ait lancée.

Dans ce cas, l'infobulle du badge affiche le **PID** du processus adopté :

```
Processus actif
PID 24680
```

## Modifier ou agir sur une application

Ouvrez le menu **:material-dots-horizontal:** de la carte, ou faites un **clic droit** :

| Entrée                                      | Effet                                                          |
| ------------------------------------------- | -------------------------------------------------------------- |
| :material-square-edit-outline: **Modifier** | Rouvre la fenêtre de réglages, pré-remplie.                    |
| :material-play: **Lancer maintenant**       | Démarre l'application immédiatement sans délai.                |
| :material-stop-circle: **Arrêter**          | Arrête le processus en cours (remplace « Lancer maintenant »). |
| :material-delete: **Retirer de la liste**   | Supprime l'application du profil.                              |

![Modifier une application](assets/app-editmenu.png)

## Filtrer et trier

La barre au-dessus de la grille propose deux menus :

- **Filtrer** — *Toutes*, *Démarrage MFS* (applications en démarrage auto),
  *Arrêt MFS* (applications en arrêt auto), *Prêt à voler* (applications au
  déclencheur SimConnect).
- **Trier** — par *Nom* (alphabétique) ou par *Délai* (croissant).

Ces réglages ne changent **que l'affichage** et n'impacte pas la séquence de lancement ni le profil.

![Filtrer et trier](assets/app-filters.png)

## Pendant le vol, la configuration est verrouillée

Dès que le simulateur est détecté, le profil et les applications sont **verrouillés** (cadenas :material-lock:{ style="color:#3ecf8e" }).<br>

Vous pouvez toujours **lancer** ou **arrêter** une application à la main via le menu **:material-dots-horizontal:**.

## Applications nécessitant l'administrateur

Certains applications exigent les **droits administrateur** (par exemple Active Sky,REX Atmos).<br>
Elles affichent un **bouclier** <span style="color:red;">:material-shield-alert:</span> à côté de leur nom.

Lorsqu'une application de ce type est présent dans le profil actif, il vous sera demandé de **redémarrer en administrateur** au lancement ou lors de l'ajout via **une seule** invite UAC.

!!! info "Seules les applications qui l'exigent sont élevées"
    Même quand MFSAppsControl tourne en administrateur, il ne transmet **pas** ces droits à tout ce qu'il lance.<br>
    Chaque application démarre avec les droits que **son propre exécutable** réclame, seules celles qui exigent réellement l'administrateur le reçoivent.

!!! tip "Si vous refusez l'élévation"
    MFSAppsControl continue de fonctionner normalement, mais les applications administrateur **ne seront pas lancées**.<br>
    Leur carte affichera une erreur « nécessite les droits administrateur ».<br>
    Il ne pourra pas non plus les fermer à l'arrêt du simulateur.

## Chemin invalide/Erreur de lancement

Si l'exécutable d'une application est **introuvable** (déplacé/désinstallé), ou qu'une erreur à l'exécution se produit, sa carte passe en **erreur rouge** avec le détail de l'erreur dans les informations du badge.

Cette application est alors :

- **ignorée par la séquence de lancement** (aucune tentative de démarrage) ;
- **exclue de la détection de processus**.

## Tester la séquence

Le bouton **Tester** lance **toute** la séquence sans lancer le simulateur.<br>
Il ne s'agit que d'une simulation du lancement/arrêt du simulateur : vos applications sont réellement lancées.

Le déroulé est le suivant :

1. Le statut bascule en état « simulateur détecté » bleu.
2. Au bout de **5 s**, le statut passe en « en cours », La séquence **Démarrage sim** se déclenche selon les délais configurés avec **SimConnect   connecté**, comme dans une vraie session, où SimConnect s'active pendant le chargement.
3. Un compte à rebours **« Prêt à voler dans 10 s… »\*** s'affiche sous le bouton : c'est le temps simulé pour arriver sur l'écran « Prêt à voler ».<br> **\*** Le compte à rebours n'apparaît que si votre profil contient au moins une application **Prêt à voler** valide.
4. À la fin de ce délai, la séquence **Prêt à voler** se déclenche à son tour selon les délais configurés.

Le bouton devient **Arrêter** dès le départ : cliquez dessus pour terminer le test et fermer toutes les applications en arrêt auto qui sont déjà lancées.<br>
Il se **verrouille** pendant la fermeture — certaines applications mettent quelques secondes à se fermer proprement — puis redevient **Tester**.

!!! note
    Attention, les applications déjà lancées avant le test seront également **fermées** si elles sont configurées pour l'arrêt automatique. Le test ne fait pas de distinction entre les applications lancées par MFSAppsControl et celles lancées manuellement.
