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
    3. ¿Ya has volado en esta sesión? Las aplicaciones «listo para volar» solo se inician **una vez por sesión de simulador**: no se relanzan entre dos vuelos, salvo si cambias de perfil.

    Se inician en cuanto aparece la pantalla «Listo para volar», después de la carga. Para iniciar una más tarde, añade un **retardo** en su tarjeta.

    Para revalidarlo todo sin volar, usa el botón **Probar**: simula SimConnect y la pantalla «Listo para volar» al cabo de 10 segundos.

??? question "La aplicación pide derechos de administrador (UAC)"
    Algunas aplicaciones (Active Sky, REX Atmos…) requieren administrador. Para
    iniciarlas — y para **detenerlas** — MFSAppsControl tiene que estar elevado. Cuando
    uno de esos complementos está en Compartido o en **cualquiera** de tus perfiles, la
    aplicación se reinicia como administrador al iniciarse (**una sola** solicitud UAC),
    para que cambiar de perfil nunca exija reiniciar en mitad de una sesión.

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

??? question "Ya no se inicia ni se detiene nada con el simulador"
    La **secuencia automática** probablemente está desactivada: el interruptor **Secuencia auto** encima de **Probar** está gris, y el icono del área de notificación muestra un punto **rojo**.<br>
    Vuelve a activarla desde el interruptor o desde el menú del icono. Desactivada, no se inicia ni se detiene nada con el simulador, y ningún avión activa un perfil.

??? question "Mi perfil no cambia con el avión"
    - Comprueba que el avión está **vinculado** al perfil: su nombre en el panel muestra un icono de vínculo verde.
    - El cambio se produce **al cargar el vuelo**, no mientras recorres los aviones en el menú principal.
    - La **secuencia automática** debe estar activada.
    - A veces el simulador carga un vuelo **sin el avión**: vuelve a cargar el vuelo y el cambio se producirá en esa carga.

??? question "Una aplicación de «Con MSFS cerrado» no se cierra o no se inicia"
    - La **secuencia automática** debe estar activada.
    - Comprueba que **Cerrar al iniciar** o **Iniciar al cerrar** esté activado en su tarjeta.
    - Se cierra cuando MSFS **se inicia** con MFSAppsControl ya en ejecución: no se cierra nada para un simulador que ya estaba en ejecución.
    - Se inicia cuando MSFS **se ha cerrado** y las aplicaciones de la sesión se han detenido, y luego tras su retardo: mientras tanto, su tarjeta muestra la cuenta atrás.

## Datos y mantenimiento

??? question "¿Cómo salgo de verdad de la aplicación cuando está en el área de notificación?"
    Si la opción **Al cerrar se minimiza en la bandeja del sistema** está activada, la cruz oculta la ventana en lugar de salir.<br>
    Haz **clic derecho en el icono** del área de notificación → **Salir**.<br>
    Si no, basta con usar la cruz de la ventana para cerrar la aplicación.

??? question "¿Dónde están los registros (logs)?"
    En `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\logs`. (Un archivo por día, conservados **7 días**).<br>
    **Para enviarlos al soporte:**<br>
    **Opciones → Depuración → Exportar registros**, que genera un `.zip` completo (registros + configuración). → [Soporte](support.md)

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
