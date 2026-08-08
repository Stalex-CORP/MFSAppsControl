# Perfiles

Un **perfil** agrupa un conjunto de aplicaciones con sus ajustes.<br>
Crea varios según tus usos (vuelo en línea IFR, VFR, A320, A380…) y cambia de uno a otro con un clic.

![Los perfiles](assets/profiles.png)

!!! info "El perfil activo es el que dirige la secuencia"
    El perfil **mostrado** es el que MFSAppsControl ejecuta para la secuencia.<br>
    El perfil en uso cuando el simulador está iniciado se señala con un **:material-lock:{ style="color:#3ecf8e" }**.

## Crear un perfil

Haz clic en el botón **:material-plus-circle-outline:** a la derecha de las pestañas.<br>
Se crea un nuevo perfil vacío y se te pide que le pongas nombre.

![Crear un perfil](assets/profiles-create.gif)

!!! note "Nombre único y cancelación"
    Dos perfiles no pueden llamarse **igual**.<br>
    Mientras el nombre introducido ya esté en uso, el campo se vuelve <span style="color:red;">**rojo**</span> y la validación queda bloqueada.<br>
    Para **cancelar**, haz clic en la cruz **:material-close-circle:** o pulsa **Esc**.

## Menú contextual

Cada insignia de perfil tiene un menú accesible con **:material-dots-horizontal:** o con **clic derecho**.
Este menú permite **renombrar**, **eliminar** o **duplicar** el perfil.

![Menú contextual de los perfiles](assets/profiles-menu.png)

### Duplicar un perfil

Para partir de un perfil existente sin tener que reconfigurarlo todo.
Se crea una copia, con **todas sus aplicaciones y sus ajustes**, llamada «*nombre del perfil* (copia)», que hay que renombrar con un nombre único.

![Duplicar un perfil](assets/profiles-duplicate.gif)

### Renombrar un perfil

Al renombrar, el nombre debe ser **único**; mientras no lo sea, la validación quedará bloqueada.

![Renombrar o eliminar un perfil](assets/profiles-rename.gif)


### Eliminar un perfil

Eliminar un perfil es **irreversible** y borra **todas las aplicaciones y ajustes** que contiene.<br>
No se puede eliminar el último perfil disponible.

![Eliminar un perfil](assets/profiles-delete.gif)

### Reordenar

**Arrastra y suelta** las insignias para cambiar su orden.
Es algo puramente visual, para que encuentres más fácilmente tus perfiles favoritos.

![Reordenar los perfiles](assets/profiles-reorder.gif)

## Bloqueo automático

Los perfiles quedan **bloqueados** (aparece un :material-lock:{ style="color:#3ecf8e" } en el perfil activo) para evitar cualquier cambio durante la ejecución.
