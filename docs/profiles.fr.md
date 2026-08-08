# Profils

Un **profil** regroupe un ensemble d'applications avec leurs réglages.<br>
Créez-en plusieurs selon vos usages (vol en ligne IFR, VFR, A320, A380…) et basculez de l'un à l'autre en un clic.

![Les profils](assets/profiles.png)

!!! info "Le profil actif est celui qui pilote la séquence"
    Le profil **affiché** est celui que MFSAppsControl exécute pour la séquence.<br>
    Le profil en cours d'utilisation lorsque le simulateur est lancé est indiqué par un **:material-lock:{ style="color:#3ecf8e" }**.

## Créer un profil

Cliquez sur le bouton **:material-plus-circle-outline:** à droite des onglets.<br>
Un nouveau profil vierge est créé et vous demande de le nommer.

![Créer un profil](assets/profiles-create.gif)

!!! note "Nom unique et annulation"
    Deux profils ne peuvent pas porter le **même nom**.<br>
    Tant que le nom saisi est déjà utilisé, le champ devient <span style="color:red;">**rouge**</span> et la validation est bloquée.<br>
    Pour **annuler**, cliquez sur la croix **:material-close-circle:** ou appuyez sur **Échap**.

## Menu contextuel

Un menu est accessible sur chaque badge de profil via **:material-dots-horizontal:** ou un **clic droit**.
Ce menu permet de **renommer**, **supprimer** ou **dupliquer** le profil.

![Menu contextuel des profils](assets/profiles-menu.png)

### Dupliquer un profil

Pour repartir d'un profil existant sans devoir tout reconfigurer.
Une copie est créée, avec **toutes ses applications et leurs réglages**, nommée « *nom du profil* (dupliqué) » à renommer par un nom unique.

![Dupliquer un profil](assets/profiles-duplicate.gif)

### Renommer un profil

Au renommage, le nom doit être **unique** et bloquera la validation tant que ce n'est pas le cas.

![Renommer ou supprimer un profil](assets/profiles-rename.gif)
    

### Supprimer un profil

La suppression d'un profil est **irréversible** et supprime **toutes les applications et réglages** qu'il contient.<br>
Il n'est pas possible de supprimer le dernier profil disponible.

![Supprimer un profil](assets/profiles-delete.gif)

### Réorganiser

**Glissez-déposez** les badges pour changer leur ordre.
Cela est purement visuel pour vous permettre de retrouver vos profils favoris plus facilement.

![Réorganiser les profils](assets/profiles-reorder.gif)

## Vérrouillage automatique

Les profils deviennent **verrouillée** (un :material-lock:{ style="color:#3ecf8e" } apparaît sur le profil actif) pour éviter tout changement pendant l'exécution.