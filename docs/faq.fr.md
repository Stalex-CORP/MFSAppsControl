# Dépannage (FAQ)

## Détection du simulateur

??? question "MFS n'est pas détecté"
    MFSAppsControl surveille les processus `FlightSimulator2024.exe` (MFS 2024)
    et `FlightSimulator.exe` (MFS 2020). Assurez-vous que le simulateur est bien lancé.<br>
    Le passage à « en cours d'exécution » prend quelques secondes après le démarrage de MFS.

??? question "J'ai lancé MFSAppsControl alors que MFS tournait déjà, et rien ne se passe"
    C'est **volontaire**. Si le simulateur est déjà là au démarrage de
    l'application, la séquence n'est pas déclenchée : sinon, ouvrir
    MFSAppsControl en plein vol relancerait des applications non voulus.

    Elle s'armera automatiquement au prochain lancement. En attendant, vous
    pouvez lancer une application à la main via le menu **⋯** de sa carte.

??? question "La pastille SimConnect reste grise alors que MFS tourne"
    MFSAppsControl ne tente la connexion **que lorsque le simulateur est lancé**,
    et réessaie ensuite régulièrement. Quelques secondes d'attente sont normales
    au démarrage de MFS.

    Si elle reste grise longtemps :

    - vérifiez que le simulateur a fini de démarrer (SimConnect n'est disponible
      qu'une fois le simulateur réellement initialisé et pendant l'écran de chargement) ;
    - vérifiez qu'aucun antivirus ou pare-feu ne bloque MFSAppsControl ;

    Après un long moment sans connexion alors que MFS tourne, la pastille passe au
    **rouge** (« SimConnect indisponible ») pour signaler le problème.

    Sans SimConnect, le déclencheur « prêt à voler » ne fonctionne pas.

## Lancement des applications

??? question "Une application ne se lance pas"
    - Vérifiez que sa carte n'est pas en **erreur** (Survolez le badge pour vérifier le message d'erreur).
    - Vérifiez qu'un **déclencheur** est bien actif (:material-play: ou :material-airplane:). Si aucun des deux n'est allumé, l'application n'est jamais lancée automatiquement.
    - Si le déclencheur est **Prêt à voler**, l'application ne partira qu'à partir de l'écran "Prêt à voler" — et seulement si **SimConnect est connecté**.
    - Si l'application affiche un **bouclier** :material-shield-alert:, elle nécessite les droits administrateur (voir ci-dessous).
    - Utilisez **Tester** pour rejouer la séquence sans lancer MFS et observer le statut de chaque carte.

??? question "Les applications « prêt à voler » ne se lancent jamais"
    
    Dans l'ordre :

    1. La pastille **SimConnect connecté** est-elle verte pendant le vol ?
    2. Le bouton :material-airplane: est-il bien actif sur la carte (et pas :material-play:) ?
    3. Avez-vous déjà volé dans cette session ? Les applications « prêt à voler » ne se lancent **qu'une fois par session de simulateur** — elles ne se relancent pas entre deux vols.

    Pour tout revalider sans voler, utilisez le bouton **Tester** : il simule simconnect après 10 secondes.

??? question "Mes applications « prêt à voler » démarrent trop tôt"
    C'est le comportement attendu. Le déclenchement se produit dès l'écran "Prêt à voler" apparaît, après le chargement.

    Ajoutez un **délai** sur la carte pour repousser son lancement d'autant de secondes après ce moment.

??? question "L'application demande les droits administrateur (UAC)"
    Certains applications (Active Sky, REX Atmos…) exigent l'administrateur. Pour les
    lancer — et pour les **arrêter** — MFSAppsControl doit être élevé. Quand un
    tel addon est présent dans le profil actif, l'application redémarre
    automatiquement en administrateur (**une seule** invite UAC).

    **Les autres applications n'héritent pas de ces droits** : chacune démarre avec
    ceux que son propre exécutable réclame. vPilot ou Navigraph tournent en
    utilisateur normal même quand MFSAppsControl est élevé.

    Si vous refusez l'invite, tout le reste continue de fonctionner, mais ces
    applications-là échoueront avec l'erreur « nécessite les droits
    administrateur ».

??? question "Une application se lance devant le simulateur"
    Activez **Démarrer réduit** :material-arrow-collapse: sur sa carte : elle
    sera lancée en fenêtre réduite, sans passer devant MFS. MFSAppsControl suit
    aussi les fenêtres des **sous-process** de l'application (certaines, comme
    FS2Crew, ouvrent leur interface via un autre processus).

    Quelques rares logiciels à fenêtre personnalisée forcent malgré tout leur fenêtre
    au premier plan. Il s'agit parfois d'une option disponible dans l'application elle-même, parfois d'un comportement interne de l'application qui ne peut pas être contourné.

??? question "Mes applications ne se ferment pas quand je quitte MFS"
    Vérifiez que le bouton **Arrêt auto** :material-square: est actif sur leur
    carte — il est **indépendant** du démarrage automatique et que votre MFS est bien fermé (Gestionnaire de tâches).

    MFSAppsControl demande d'abord une **fermeture propre**, puis **force l'arrêt**
    des processus qui resteraient actifs — y compris certaines applications qui laissent tourner en arrière-plan après avoir fermé leur fenêtre.

    Si l'application nécessite les droits administrateur, MFSAppsControl doit aussi être élevé pour pouvoir l'arrêter (voir plus haut).

??? question "Une application apparaît « EN COURS » alors que je ne l'ai pas lancée depuis MFSAppsControl"
    C'est normal : MFSAppsControl vérifie régulièrement quels processus tournent
    réellement, et **adopte** ceux qui correspondent à vos applications configurées. Cela permet à l'affichage de rester fidèle, que vous lanciez vos
    applications depuis MFSAppsControl ou à la main.

    Survolez le badge pour voir le **PID** du processus concerné.

## Interface

??? question "Pourquoi le délai est-il grisé ?"
    Parce qu'aucun **démarrage automatique** n'est choisi pour cette application. Activez :material-play: ou :material-airplane: et il redevient réglable.

??? question "Pourquoi le cadenas et les boutons grisés pendant le vol ?"
    Dès que le simulateur est détecté, la configuration des cartes et les profils sont **verrouillées** : modifier une séquence pendant son déroulement
    (ou changer de profil en plein vol) seraient complexe à gérer.

    Le menu **⋯** reste disponible pour lancer ou arrêter une application manuellement.

??? question "Pourquoi je ne peux pas désactiver l'arrêt auto sur une application « prêt à voler » ?"
    Une application lancée pour le vol n'a aucune raison de survivre au simulateur : l'arrêt automatique est donc **verrouillé en position active** pour ce déclencheur.<br>
    Repassez la carte en **Démarrage sim** si vous voulez la garder ouverte après le vol.

??? question "Comment quitter réellement l'application quand elle est dans la zone de notification ?"
    Si l'option **La fermeture réduit dans la barre système** est activée, la croix masque la fenêtre au lieu de quitter.<br>
    Faites un **clic droit sur l'icône** dans la zone de notification → **Quitter**.<br>
    Sinon utilisez simplement la croix de la fenêtre pour fermer l'application.

??? question "La fenêtre s'est ouverte hors de l'écran / trop petite"
    MFSAppsControl mémorise la position de la fenêtre. En cas de souci d'affichage (par exemple après un changement d'écran), déplacez ou redimensionnez la fenêtre : la nouvelle position sera mémorisée.<br><br>
    **Astuce pratique**<br>
    Utilisez " ++windows++ + flèche de gauche " ou " ++windows++ + flèche de droite " pour la déplacer sur les zones des écrans.

## Données et maintenance

??? question "Où sont enregistrés mes profils et réglages ?"
    Dans un fichier unique :
    `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\settings.json`<br>
    (soit `C:\Users\<vous>\AppData\Local\Stalex CORP\MFSAppsControl\`).

    Ce fichier est **chiffré** : il n'est pas modifiable directement.

??? question "Où sont les journaux (logs) ?"
    Dans `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\logs`. (Un fichier par jour, conservés **7 jours**).<br>
    **Pour les transmettre au support :**<br>
    **Options → Débogage → Exporter les logs**, qui produit un `.zip` complet (journaux + configuration). → [Support](support.md)

??? question "Comment repartir de zéro ?"
    **Options → Débogage → Réinitialiser l'application** efface tous et remet l'application dans son état d'installation.<br>
    **Cette action est irréversible** — copiez votre `settings.json` avant si besoin.

??? question "Puis-je utiliser MFSAppsControl avec MFS 2020 ?"
    Oui, les deux versions (2024 et 2020) sont prises en charge, y compris la
    détection « prêt à voler ». Un même profil fonctionne quel que soit la version.

??? question "Comment mettre à jour l'application ?"
    Quand une mise à jour est disponible, un **badge** apparaît dans la barre de
    titre. Cliquez dessus pour télécharger et installer la nouvelle version.<br>
    Vos profils et réglages sont conservés.

!!! info "Toujours bloqué ?"
    Posez votre question sur le [**Discord**](support.md), dans le salon dédié
    **#mfsappscontrol** — en joignant votre zip exporté.
