# Primeros pasos

MFSAppsControl se basa en una sola idea:<br>
Gestionar las aplicaciones que hay que iniciar y/o detener con tu simulador sin tener que pensar en ello.

---

## La pantalla principal

![La pantalla principal de MFSAppsControl](assets/main-screen-numbers.png)

### 1. La barra de título

A la izquierda, el logotipo con el nombre de la aplicación.<br>
A la derecha, de izquierda a derecha:

- la **versión** (vX.Y.Z),
- el idioma (:flag_gb:),
- el **tema** (:material-weather-sunny:),
- la **ayuda** (:material-help-circle:),
- las **opciones** (:material-cog:),
- y los botones de gestión de la ventana (:material-window-minimize:, :material-window-maximize:, :material-window-close:).

Cuando hay una nueva versión disponible, aparece una **insignia** junto a la versión. Un clic en ella inicia la descarga y la instalación.

### 2. El panel de estado y secuencia

Es la representación visual de:
- el estado del simulador y de la conexión SimConnect,
- la secuencia de inicio de las aplicaciones,
- el botón de prueba de la secuencia.

![Secuencia de aplicaciones - Estados](assets/app-sequence-status.png)


**A la izquierda, los estados** — MFS y SimConnect.<br>

- Estado de MFS

  | Punto                                            | Etiqueta                             | Descripción                                 |
  | ------------------------------------------------ | ------------------------------------ | ------------------------------------------- |
  | :material-circle:{ style="color:#8a8f98" } gris  | **MSFS detenido**                    | El simulador no está iniciado ni detectado. |
  | :material-circle:{ style="color:#4a9eff" } azul  | **Iniciando los addons…**            | Se ha detectado el proceso del simulador.   |
  | :material-circle:{ style="color:#3ecf8e" } verde | `FlightSimulator2024.exe · PID 1234` | Se ha recuperado la información del proceso. |

- Estado de SimConnect

  | Punto                                            | Etiqueta                     | Descripción                                          |
  | ------------------------------------------------ | ---------------------------- | ---------------------------------------------------- |
  | :material-circle:{ style="color:#8a8f98" } gris  | **SimConnect desconectado**  | A la espera de que se inicie el simulador.           |
  | :material-circle:{ style="color:#3ecf8e" } verde | **SimConnect conectado**     | Conexión establecida, sistema listo.                 |
  | :material-circle:{ style="color:#ff5c5c" } rojo  | **SimConnect no disponible** | SimConnect no responde (consulta la [FAQ](faq.md)). |


**En el centro, la secuencia de inicio**<br>
La línea de tiempo de tus aplicaciones, representadas por sus iconos sobre sus retardos de inicio (visible solo si hay al menos una aplicación configurada). → [El detalle de la línea de tiempo](applications.md#la-linea-de-tiempo)


**A la derecha, el botón Probar/Detener**<br>
Permite simular el inicio y el cierre de MFS para probar las secuencias sin lanzar MFS.<br>
Durante un vuelo o una prueba, pasa a ser **Detener**. → [Probar la secuencia](applications.md#probar-la-secuencia)

### 3. Los perfiles

Muestra todos tus perfiles disponibles, con el perfil activo resaltado.

![Aplicación - Perfiles](assets/app-profiles.png)

Un botón para **crear** un nuevo perfil.<br>
Puedes reordenarlos arrastrando las pestañas.<br>
El menú **:material-dots-horizontal:** permite renombrarlos, duplicarlos o eliminarlos. → [Perfiles](profiles.md)


### 4. Los filtros

Muestra el número de aplicaciones y permite filtrar y ordenar las aplicaciones de la lista.

![Aplicación - Filtros](assets/app-filters.png)

- **Filtrar**: Todas / Inicio de MSFS / Cierre de MSFS / Listo para volar
- **Ordenar**: Nombre / Retardo

Estos ajustes solo afectan a la visualización.


### 5. Las aplicaciones

Se representan mediante **tarjetas**, una por cada aplicación configurada.

![Aplicación - Tarjeta](assets/app-card.png)

Una **tarjeta** muestra la información de la aplicación y su configuración. → [Anatomía de una tarjeta](applications.md#anatomia-de-una-tarjeta)


---

## Tu primera configuración

### 1. El perfil predeterminado

En el primer inicio te espera un **perfil predeterminado**, vacío.<br>
Úsalo tal cual, renómbralo y crea otros según tus necesidades. → [Perfiles](profiles.md)

### 2. Añade una aplicación

Haz clic en la tarjeta **Añadir una aplicación**.<br>
Elige la aplicación → [Añadir una aplicación](applications.md#anadir-una-aplicacion):

- En la lista de **Aplicaciones instaladas**
- O mediante la ruta de su `.exe` con **Examinar…**

### 3. Define sus opciones de control

Es el ajuste más importante. En la ventana de añadir, la línea **Disparador** ofrece:

- **Inicio del sim** :material-play: para iniciarla con el simulador (MobiFlight, Navigraph…).
- **Listo para volar** :material-airplane: para iniciarla ya dentro del avión (REX Atmos, vPilot…).

Ninguno de los dos es obligatorio; el botón **Cierre auto** :material-stop: cerrará la aplicación junto con el simulador. (Se activa automáticamente si la aplicación se inicia en modo «Listo para volar»)

### 4. Ajusta el retardo

El **retardo** permite retrasar el inicio a partir del disparador elegido. → [El retardo](applications.md#el-retardo)

### 5. Pruébalo

Haz clic en **Probar**: la secuencia se desarrolla como si el simulador estuviera arrancando.<br>
Una cuenta atrás **«Listo para volar en 10 s…»** simula la conexión de SimConnect al cabo de 10 s.

Haz clic en **Detener** para terminar la prueba y cerrar las aplicaciones que tengan configurada la opción.

## El desarrollo de un vuelo

| Momento                                             | Lo que hace MFSAppsControl                                                                                                                                     |
| --------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Inicias **MFS**                                     | El estado de MFS pasa a azul.                                                                                                                                  |
| El simulador carga                                  | El estado de MFS pasa a verde, el estado de SimConnect pasa a verde en cuanto está disponible y las aplicaciones de inicio del sim arrancan según su retardo. |
| Llegas a la pantalla **Listo para volar** de un vuelo | La secuencia **Listo para volar** arranca a su vez, con sus propios retardos.                                                                                  |
| Cambias de vuelo                                    | Las aplicaciones **no se reinician**, siguen activas.                                                                                                          |
| Sales de **MFS**                                    | Todas las aplicaciones configuradas en **Cierre auto** (incluidas las del modo «Listo para volar») se cierran correctamente.                                   |

!!! info "Si MFS ya está iniciado antes que MFSAppsControl"
    La secuencia **no se dispara**. Se armará en el próximo inicio de MFS.<br>
    Es un caso complejo en el que no se puede garantizar un lanzamiento correcto sin problemas.<br>
    Las aplicaciones ya iniciadas se detectarán y se cerrarán correctamente al cerrar el simulador si la opción está activada.<br><br>
    **Consejo**: siempre puedes iniciar una aplicación manualmente desde el menú **:material-dots-horizontal:** de su tarjeta o desde fuera.

---

## Siempre listo

Activa **Iniciar al arrancar Windows** e **Iniciar minimizado en la bandeja del sistema** en las [Opciones](options.md).<br>
Puedes olvidarte de la aplicación o simplemente abrirla para cambiar de perfil antes de tu vuelo.

![El icono en el área de notificación](assets/tray.png)
