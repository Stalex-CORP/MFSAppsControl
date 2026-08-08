# Solución de problemas (FAQ)

## Detección del simulador

??? question "No se detecta MFS"
    MFSAppsControl vigila los procesos `FlightSimulator2024.exe` (MFS 2024)
    y `FlightSimulator.exe` (MFS 2020). Asegúrate de que el simulador esté realmente iniciado.<br>
    El paso a «en ejecución» tarda unos segundos tras el arranque de MFS.

??? question "He abierto MFSAppsControl con MFS ya en marcha y no pasa nada"
    Es **intencionado**. Si el simulador ya está ahí cuando arranca la
    aplicación, la secuencia no se dispara: de lo contrario, abrir
    MFSAppsControl en pleno vuelo relanzaría aplicaciones no deseadas.

    Se armará automáticamente en el próximo inicio. Mientras tanto, puedes
    iniciar una aplicación a mano desde el menú **⋯** de su tarjeta.

??? question "El punto de SimConnect sigue en gris aunque MFS esté en marcha"
    MFSAppsControl solo intenta la conexión **cuando el simulador está iniciado**,
    y después vuelve a intentarlo con regularidad. Es normal esperar unos segundos
    al arrancar MFS.

    Si sigue en gris mucho tiempo:

    - comprueba que el simulador haya terminado de arrancar (SimConnect solo está
      disponible una vez que el simulador se ha inicializado realmente, y durante la pantalla de carga);
    - comprueba que ningún antivirus ni cortafuegos esté bloqueando MFSAppsControl;

    Tras mucho tiempo sin conexión con MFS en marcha, el punto pasa a
    **rojo** («SimConnect no disponible») para señalar el problema.

    Sin SimConnect, el disparador «listo para volar» no funciona.

## Inicio de las aplicaciones

??? question "Una aplicación no se inicia"
    - Comprueba que su tarjeta no esté en **error** (pasa el cursor por la insignia para ver el mensaje de error).
    - Comprueba que haya un **disparador** activo (:material-play: o :material-airplane:). Si ninguno de los dos está encendido, la aplicación nunca se inicia automáticamente.
    - Si el disparador es **Listo para volar**, la aplicación solo arrancará a partir de la pantalla «Listo para volar» — y únicamente si **SimConnect está conectado**.
    - Si la aplicación muestra un **escudo** :material-shield-alert:, necesita permisos de administrador (ver más abajo).
    - Usa **Probar** para reproducir la secuencia sin iniciar MFS y observar el estado de cada tarjeta.

??? question "Las aplicaciones «listo para volar» no se inician nunca"

    Por orden:

    1. ¿El punto **SimConnect conectado** está en verde durante el vuelo?
    2. ¿El botón :material-airplane: está realmente activo en la tarjeta (y no :material-play:)?
    3. ¿Ya has volado en esta sesión? Las aplicaciones «listo para volar» solo se inician **una vez por sesión de simulador**: no se relanzan entre dos vuelos.

    Para revalidarlo todo sin volar, usa el botón **Probar**: simula SimConnect y la pantalla «Listo para volar» al cabo de 10 segundos.

??? question "Mis aplicaciones «listo para volar» arrancan demasiado pronto"
    Es el comportamiento previsto. El disparo se produce en cuanto aparece la pantalla «Listo para volar», después de la carga.

    Añade un **retardo** en la tarjeta para retrasar su inicio esos segundos a partir de ese momento.

??? question "La aplicación pide permisos de administrador (UAC)"
    Algunas aplicaciones (Active Sky, REX Atmos…) exigen administrador. Para
    iniciarlas — y para **detenerlas** — MFSAppsControl debe estar elevado. Cuando
    uno de estos addons está presente en el perfil activo, la aplicación se reinicia
    automáticamente como administrador (**una sola** solicitud UAC).

    **Las demás aplicaciones no heredan esos permisos**: cada una arranca con los
    que reclama su propio ejecutable. vPilot o Navigraph se ejecutan como
    usuario normal aunque MFSAppsControl esté elevado.

    Si rechazas la solicitud, todo lo demás sigue funcionando, pero esas
    aplicaciones fallarán con el error «MFSAppsControl debe ejecutarse como
    administrador».

??? question "Una aplicación se abre delante del simulador"
    Activa **Iniciar minimizada** :material-arrow-collapse: en su tarjeta: se
    iniciará con la ventana minimizada, sin ponerse delante de MFS. MFSAppsControl también
    sigue las ventanas de los **subprocesos** de la aplicación (algunas, como
    FS2Crew, abren su interfaz mediante otro proceso).

    Algunos programas poco frecuentes con ventana personalizada fuerzan aun así su ventana
    al primer plano. A veces es una opción disponible en la propia aplicación, y a veces un comportamiento interno de la aplicación que no se puede evitar.

??? question "Mis aplicaciones no se cierran cuando salgo de MFS"
    Comprueba que el botón **Cierre auto** :material-square: esté activo en su
    tarjeta — es **independiente** del inicio automático — y que MFS esté realmente cerrado (Administrador de tareas).

    MFSAppsControl solicita primero un **cierre limpio** y después **fuerza la detención**
    de los procesos que sigan activos — incluidas algunas aplicaciones que siguen en segundo plano tras cerrar su ventana.

    Si la aplicación necesita permisos de administrador, MFSAppsControl también debe estar elevado para poder detenerla (ver más arriba).

??? question "Una aplicación aparece «EN CURSO» aunque no la haya iniciado desde MFSAppsControl"
    Es normal: MFSAppsControl comprueba con regularidad qué procesos están realmente
    en marcha y **adopta** los que corresponden a tus aplicaciones configuradas. Así la pantalla se mantiene fiel, tanto si inicias tus
    aplicaciones desde MFSAppsControl como si lo haces a mano.

    Pasa el cursor por la insignia para ver el **PID** del proceso en cuestión.

## Interfaz

??? question "¿Por qué el retardo aparece atenuado?"
    Porque no se ha elegido ningún **inicio automático** para esa aplicación. Activa :material-play: o :material-airplane: y volverá a ser ajustable.

??? question "¿Por qué aparecen el candado y los botones atenuados durante el vuelo?"
    En cuanto se detecta el simulador, la configuración de las tarjetas y los perfiles quedan **bloqueados**: modificar una secuencia mientras se desarrolla
    (o cambiar de perfil en pleno vuelo) sería complicado de gestionar.

    El menú **⋯** sigue disponible para iniciar o detener una aplicación manualmente.

??? question "¿Por qué no puedo desactivar el cierre auto en una aplicación «listo para volar»?"
    Una aplicación lanzada para el vuelo no tiene ninguna razón para sobrevivir al simulador: por eso el cierre automático queda **bloqueado en posición activa** para ese disparador.<br>
    Vuelve a poner la tarjeta en **Inicio del sim** si quieres mantenerla abierta después del vuelo.

??? question "¿Cómo salgo de verdad de la aplicación cuando está en el área de notificación?"
    Si la opción **Al cerrar se minimiza en la bandeja del sistema** está activada, la cruz oculta la ventana en lugar de salir.<br>
    Haz **clic derecho en el icono** del área de notificación → **Salir**.<br>
    Si no, basta con usar la cruz de la ventana para cerrar la aplicación.

??? question "La ventana se ha abierto fuera de la pantalla o demasiado pequeña"
    MFSAppsControl recuerda la posición de la ventana. Si hay algún problema de visualización (por ejemplo, tras un cambio de pantalla), mueve o redimensiona la ventana: la nueva posición quedará memorizada.<br><br>
    **Consejo práctico**<br>
    Usa " ++windows++ + flecha izquierda " o " ++windows++ + flecha derecha " para moverla entre las zonas de las pantallas.

## Datos y mantenimiento

??? question "¿Dónde se guardan mis perfiles y ajustes?"
    En un único archivo:
    `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\settings.json`<br>
    (es decir, `C:\Users\<tú>\AppData\Local\Stalex CORP\MFSAppsControl\`).

    Este archivo está **cifrado**: no se puede modificar directamente. Para
    hacer una copia de seguridad, cópialo tal cual.
    → [Perfiles](profiles.md)

??? question "¿Dónde están los registros (logs)?"
    En `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\logs`. (Un archivo por día, conservados **7 días**).<br>
    **Para enviarlos al soporte:**<br>
    **Opciones → Depuración → Exportar registros**, que genera un `.zip` completo (registros + configuración). → [Soporte](support.md)

??? question "¿Cómo empiezo de cero?"
    **Opciones → Depuración → Restablecer la aplicación** borra todo y devuelve la aplicación a su estado de instalación.<br>
    **Esta acción es irreversible** — copia antes tu `settings.json` si lo necesitas.

??? question "¿Puedo usar MFSAppsControl con MFS 2020?"
    Sí, las dos versiones (2024 y 2020) son compatibles, incluida la
    detección «listo para volar». Un mismo perfil funciona con cualquiera de las dos versiones.

??? question "¿Cómo actualizo la aplicación?"
    Cuando hay una actualización disponible, aparece una **insignia** en la barra de
    título. Haz clic en ella para descargar e instalar la nueva versión.<br>
    Tus perfiles y ajustes se conservan.

!!! info "¿Sigues bloqueado?"
    Haz tu pregunta en el [**Discord**](support.md), en el canal dedicado
    **#mfsappscontrol** — adjuntando tu zip exportado.
