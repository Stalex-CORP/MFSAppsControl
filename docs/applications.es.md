# Aplicaciones y secuencia

Cada aplicación de tu perfil se muestra en forma de **tarjeta**.<br>
Esta página detalla cómo añadirlas, cómo configurarlas y cómo leer la **secuencia de inicio**.

---

## Añadir una aplicación

Haz clic en **Añadir una aplicación** en la cuadrícula. Hay dos modos:

=== "Aplicaciones instaladas"

    Lista los programas ya instalados (a través del registro de Windows).<br>
    Búscala y selecciónala: el nombre, el icono y la ruta se recuperan automáticamente.

    ![Modo aplicaciones instaladas](assets/add-app-installed.png)

    !!! note "La lista está filtrada a propósito"
        Para que siga siendo legible, la lista descarta los programas sin relación
        con el vuelo (controladores y utilidades del sistema, navegadores, juegos,
        lanzadores, etc.) y oculta las aplicaciones **ya presentes en el perfil
        activo**. Una aplicación instalada de forma clásica que no aparezca — o un
        programa **portable** — siempre se puede añadir desde la pestaña
        **Examinar**.

=== "Examinar"

    Indica la ruta de un `.exe`, o haz clic en **Examinar…** para seleccionarlo: el nombre y el icono se recuperan automáticamente.

    ![Modo examinar](assets/add-app-browse.png)

    !!! note "Uso"
        Este modo está pensado para las aplicaciones **portables** (no instaladas) o las que no se detectan porque no aparecen en el registro de Windows.

La ventana de añadir contiene después los **argumentos de inicio**, el **disparador**, el **retardo** y la opción **Iniciar minimizada**, todos modificables después de añadir la aplicación.

---

## Anatomía de una tarjeta

![Tarjeta de una aplicación](assets/app-card.png)

**Arriba** encuentras la información de la aplicación:

- El icono de la aplicación
- Su **nombre**
- Su **ruta**
- Sus **argumentos** (bajo la ruta, cuando están definidos).

A la derecha, la **insignia de estado** (visible durante la ejecución) y el menú **:material-dots-horizontal:**.

**Abajo, la barra de controles**, accesibles con un solo clic:

| Control                                        | Función                                                                                                            |
| ---------------------------------------------- | -------------------------------------------------------------------------------------------------------------------- |
| :material-play: **Inicio del sim**             | Arranca cuando se inicia el simulador.                                                                             |
| :material-airplane: **Listo para volar**       | Arranca cuando se muestra la pantalla **Listo para volar**.                                                        |
| :material-arrow-collapse: **Iniciar minimizada** | Inicia la aplicación con la ventana minimizada.<br>*Solo visible si se elige un inicio automático*                 |
| :material-square: **Cierre auto**              | Cierra la aplicación cuando se detiene el simulador.<br>*Se activa y se bloquea automáticamente con el inicio «Listo para volar»* |
| :material-minus::material-plus: **Retardo**    | Tiempo de espera antes de iniciar esta aplicación, según el modo de inicio.                                        |

Estos ajustes también están presentes en la ventana de modificación.

### Los dos disparadores de inicio

Es el ajuste más útil de MFSAppsControl.<br>
Los dos botones de la izquierda (:material-play: y :material-airplane:) forman una **elección única**: activar uno desactiva el otro, y volver a hacer clic en el que está activo **desactiva el inicio automático**.

|                        | :material-play: **Inicio del sim**            | :material-airplane: **Listo para volar**      |
| ---------------------- | --------------------------------------------- | --------------------------------------------- |
| **Se dispara**         | Cuando se detecta el **proceso** de MFS       | Cuando tu **avión aparece en el mundo**       |
| **Detección**          | Por **vigilancia del proceso**                | Mediante **SimConnect**                       |
| **El retardo cuenta**  | Desde el inicio del simulador                 | Desde la pantalla «Listo para volar»          |
| **Normalmente para**   | Navigraph, vPilot, una utilidad de hardware   | REX Atmos, FS2Crew, herramientas del avión    |

!!! tip "¿Cómo elegir?"
    Hazte las preguntas adecuadas:<br>
    *«¿Esta aplicación tiene que estar lista y disponible antes de que empiece a volar?»*<br>
    *«¿Esta aplicación funciona sin el simulador?»*<br>
    *«¿Esta aplicación no molesta al funcionamiento de mi simulador?»*<br>

    - **Sí** → Inicio del sim. Tiene que estar lista antes de que empiece el vuelo.
    - **No** → Listo para volar. No sirve de nada tenerla en marcha antes de estar en el vuelo.

**Lo que hay que saber sobre el inicio «Listo para volar»**

!!! info "El cierre auto está bloqueado"
    Una aplicación «listo para volar» se cierra **siempre** con el simulador: el botón :material-square: queda bloqueado en posición activa.<br>
    Una aplicación lanzada para el vuelo no tiene ninguna razón para sobrevivir al simulador.

!!! info "El disparo se produce en la pantalla «Listo para volar»"
    En la práctica, ocurre justo después de la carga de un vuelo, en cuanto se muestra la pantalla «Listo para volar».
    Es la única detección fiable para reconocer un vuelo «limpiamente».

!!! warning "SimConnect debe estar conectado"
    **Este disparador depende de SimConnect**.<br>
    Si el estado de SimConnect no está en **verde** (SimConnect conectado), las aplicaciones «listo para volar» no se iniciarán.<br>
    Si pasa mucho tiempo sin conectarse, pasa a **rojo** («SimConnect no disponible»). → [Solución de problemas](faq.md)

### El cierre automático

El botón :material-square: **Cierre auto** cierra la aplicación cuando se detiene el simulador.<br>
Es **independiente** del inicio: puedes tener una aplicación que lanzas a mano o por otro medio, pero que MFSAppsControl cierra junto con el simulador.

El cierre es **limpio**: MFSAppsControl intenta primero cerrar la aplicación como si hicieras clic en la cruz, le deja unos segundos para terminar su sesión y solo fuerza el cierre como último recurso.<br>
Así, las aplicaciones que necesitan desconectarse correctamente (por ejemplo Active Sky) se tratan como corresponde.

### Iniciar minimizada

La opción :material-arrow-collapse: **Iniciar minimizada** lanza la aplicación con la **ventana minimizada**, útil cuando no necesita mostrarse en primer plano.

El botón solo aparece si se ha elegido un **inicio automático**.

!!! note
    Algunas aplicaciones fuerzan su ventana al primer plano unos segundos después de arrancar.<br>
    MFSAppsControl insiste durante unos segundos para minimizarlas, pero algunos programas poco frecuentes pueden resistirse.

### El retardo

El **retardo** es el tiempo de espera antes de iniciar la aplicación, **a partir de su disparador**. Sirve para **espaciar** los arranques.

- Ajustable de **0 a 600 segundos** (10 minutos)
- Los botones **−** / **+** cambian el valor en tramos de **5 s**; también puedes **escribir** directamente el valor
- El retardo aparece **atenuado** si no se ha elegido ningún inicio automático
- Durante un vuelo muestra un **candado** :material-lock: — la configuración está bloqueada

!!! tip "Cada disparador tiene su propia secuencia"
    Un retardo de 30 s en una aplicación «inicio del sim» = 30 s después de iniciar MFS.<br>
    Un retardo de 30 s en una aplicación «listo para volar» = 30 s después de que aparezca la pantalla «Listo para volar».

### Los argumentos de inicio

Campo opcional: los parámetros de línea de comandos que se pasan al ejecutable, separados por espacios (p. ej. `--auto`).<br>
Se muestran en la tarjeta, bajo la ruta.

La aplicación siempre se inicia desde **su propia carpeta de instalación**.

---

## La línea de tiempo

El centro del panel muestra la **secuencia de inicio**: qué aplicación arranca en qué momento.<br>
Aparece en cuanto hay al menos una aplicación con inicio automático.

![La línea de tiempo de la secuencia de inicio](assets/timeline-dual.png)

Cada bloque representa un instante de arranque, con los iconos de las aplicaciones implicadas.<br>
Pasa el cursor por un bloque para ver los nombres y su estado.

Como los dos disparadores son independientes, la línea de tiempo muestra **dos pistas**:

- Una pista para «inicio del sim»
- Una pista para «listo para volar».

### Dos estilos de visualización posibles

En las [Opciones](options.md) → **Apariencia** → **Estilo de la secuencia** puedes elegir la representación que más te convenga:

- **Doble** — Dos pistas individuales, una para cada secuencia
- **Mono** — Una sola pista dividida en dos por el centro, una mitad para cada secuencia

## Los estados de una tarjeta

El **contorno** de la tarjeta y su **insignia** indican el estado de la aplicación

|                      Insignia                      | Contorno | Significado                                                            |
| :------------------------------------------------: | :------: | ---------------------------------------------------------------------- |
| ![Insignia de cuenta atrás](assets/badge-countdown.png) |   azul   | El retardo está en curso.<br>La insignia muestra los segundos restantes. |
|    ![Insignia en curso](assets/badge-running.png)     |  verde   | El proceso está iniciado.                                              |
|     ![Insignia de error](assets/badge-error.png)      |   rojo   | El inicio ha fallado.                                                  |
|                  *sin insignia*                     |          | Aplicación detenida o inactiva.                                        |

**Pasa el cursor por una insignia** para obtener más detalles: la insignia de error indica la causa (ejecutable no encontrado, permisos de administrador necesarios…) y la insignia verde muestra el **PID** del proceso.

### Cancelar un inicio

Durante una cuenta atrás aparece una cruz **✕** junto a la insignia. Permite **cancelar el inicio** únicamente de esa aplicación. Las demás siguen su secuencia con normalidad.

### Aplicaciones iniciadas fuera del programa

MFSAppsControl comprueba con regularidad qué procesos están realmente en marcha.<br>
Si inicias tú mismo una aplicación configurada (o si la cierras), su tarjeta se actualiza.<br>
Pasa a **EN CURSO verde** sin que MFSAppsControl la haya iniciado.

En ese caso, la información de la insignia muestra el **PID** del proceso adoptado:

```
Proceso activo
PID 24680
```

## Modificar una aplicación o actuar sobre ella

Abre el menú **:material-dots-horizontal:** de la tarjeta, o haz **clic derecho**:

| Entrada                                      | Efecto                                                       |
| -------------------------------------------- | -------------------------------------------------------------- |
| :material-square-edit-outline: **Modificar** | Vuelve a abrir la ventana de ajustes, ya rellenada.          |
| :material-play: **Iniciar ahora**            | Inicia la aplicación inmediatamente, sin retardo.            |
| :material-stop-circle: **Detener**           | Detiene el proceso en curso (sustituye a «Iniciar ahora»).   |
| :material-delete: **Quitar de la lista**     | Elimina la aplicación del perfil.                            |

![Modificar una aplicación](assets/app-editmenu.png)

## Filtrar y ordenar

La barra situada encima de la cuadrícula ofrece dos menús:

- **Filtrar** — *Todas*, *Inicio de MSFS* (aplicaciones con inicio automático),
  *Cierre de MSFS* (aplicaciones con cierre automático), *Listo para volar*
  (aplicaciones con el disparador de SimConnect).
- **Ordenar** — por *Nombre* (alfabético) o por *Retardo* (ascendente).

Estos ajustes solo cambian **la visualización** y no afectan ni a la secuencia de inicio ni al perfil.

![Filtrar y ordenar](assets/app-filters.png)

## Durante el vuelo, la configuración está bloqueada

En cuanto se detecta el simulador, el perfil y las aplicaciones quedan **bloqueados** (candado :material-lock:{ style="color:#3ecf8e" }).<br>

Siempre puedes **iniciar** o **detener** una aplicación a mano desde el menú **:material-dots-horizontal:**.

## Aplicaciones que requieren administrador

Algunas aplicaciones exigen **permisos de administrador** (por ejemplo Active Sky, REX Atmos).<br>
Muestran un **escudo** <span style="color:red;">:material-shield-alert:</span> junto a su nombre.

Cuando hay una aplicación de este tipo en el perfil activo, se te pedirá **reiniciar como administrador** al arrancar o al añadirla, mediante **una sola** solicitud UAC.

!!! info "Solo se elevan las aplicaciones que lo exigen"
    Aunque MFSAppsControl se ejecute como administrador, **no** transmite esos permisos a todo lo que inicia.<br>
    Cada aplicación arranca con los permisos que reclama **su propio ejecutable**; solo las que realmente exigen administrador los reciben.

!!! tip "Si rechazas la elevación"
    MFSAppsControl sigue funcionando con normalidad, pero las aplicaciones de administrador **no se iniciarán**.<br>
    Su tarjeta mostrará el error «MFSAppsControl debe ejecutarse como administrador».<br>
    Tampoco podrá cerrarlas cuando se detenga el simulador.

## Ruta no válida o error de inicio

Si el ejecutable de una aplicación **no se encuentra** (movido o desinstalado), o si se produce un error durante la ejecución, su tarjeta pasa a **error rojo** con el detalle del error en la información de la insignia.

Esa aplicación queda entonces:

- **ignorada por la secuencia de inicio** (no se intenta arrancarla);
- **excluida de la detección de procesos**.

## Probar la secuencia

El botón **Probar** lanza **toda** la secuencia sin iniciar el simulador.<br>
Solo se simula el inicio y el cierre del simulador: tus aplicaciones se inician de verdad.

El desarrollo es el siguiente:

1. El estado cambia a «simulador detectado», en azul.
2. Al cabo de **5 s**, el estado pasa a «en ejecución» y la secuencia **Inicio del sim** se dispara según los retardos configurados, con **SimConnect conectado**, como en una sesión real, donde SimConnect se activa durante la carga.
3. Una cuenta atrás **«Listo para volar en 10 s…»\*** aparece bajo el botón: es el tiempo simulado para llegar a la pantalla «Listo para volar».<br> **\*** La cuenta atrás solo aparece si tu perfil contiene al menos una aplicación **Listo para volar** válida.
4. Al final de ese plazo, la secuencia **Listo para volar** se dispara a su vez según los retardos configurados.

El botón pasa a ser **Detener** desde el principio: haz clic en él para terminar la prueba y cerrar todas las aplicaciones con cierre auto que ya estén iniciadas.<br>
Se **bloquea** durante el cierre — algunas aplicaciones tardan unos segundos en cerrarse correctamente — y después vuelve a ser **Probar**.

!!! note
    Atención: las aplicaciones que ya estuvieran iniciadas antes de la prueba también se **cerrarán** si están configuradas con el cierre automático. La prueba no distingue entre las aplicaciones iniciadas por MFSAppsControl y las iniciadas manualmente.
