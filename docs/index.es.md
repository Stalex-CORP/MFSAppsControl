# MFSAppsControl

## Descripción

**MFSAppsControl** es una aplicación que permite **iniciar y/o detener** aplicaciones de terceros vigilando el estado de Microsoft Flight Simulator 2024/2020.<br>
Se acabó lanzar tus aplicaciones una por una antes de cada vuelo: configúralas una vez y MFSAppsControl se encarga de todo.

![La pantalla principal de MFSAppsControl](assets/main-screen.png)

## Cómo funciona

MFSAppsControl acompaña tu vuelo de principio a fin, en **tres etapas**:

::timeline::

- title: Inicio del simulador
  content: Las aplicaciones configuradas en **Inicio del sim** arrancan en cuanto se inicia el simulador, respetando el retardo definido.
  icon: ' :material-numeric-1: '

- title: Pantalla «Listo para volar»
  content: Las aplicaciones configuradas en **Listo para volar** arrancan en cuanto aparece el botón «Listo para volar», respetando el retardo definido.
  icon: ' :material-numeric-2: '

- title: Cierre del simulador
  content: Las aplicaciones configuradas en **Cierre auto** se cierran correctamente cuando se cierra el simulador.
  icon: ' :material-numeric-3: '

::/timeline::


**La diferencia entre los dos tipos de inicio es el corazón de la aplicación:**<br>
Algunas aplicaciones pueden:

- Arrancar **en cuanto se inicia** el simulador (p. ej. Navigraph, Volanta…)
- Tener restricciones o ser útiles solo **durante un vuelo** (p. ej. REX Atmos, FS2Crew…)

Tú eliges lo que mejor le conviene a cada aplicación. → [Aplicaciones y secuencia](applications.md#los-dos-disparadores-de-inicio)

## Funcionalidades

<div class="grid cards" markdown>

- <span style="color: var(--md-accent-fg-color)">:material-rocket-launch: **Secuencia automática**</span><br>
  Cada aplicación arranca según su disparador tras el retardo definido, visualizado directamente en la línea de tiempo para ver el orden de lanzamiento.

- <span style="color: var(--md-accent-fg-color)">:material-folder-multiple: **Perfiles**</span><br>
  Agrupa tus aplicaciones por uso (A320, VFR, carga…) y cambia con un clic. El perfil mostrado es el perfil activo.

- <span style="color: var(--md-accent-fg-color)">:material-tray-arrow-down: **Discreto**</span><br>
  Puede minimizarse en el área de notificación y arrancar con Windows para estar listo en todo momento en tus próximos vuelos, sin pensarlo.

- <span style="color: var(--md-accent-fg-color)">:material-translate: **Interfaz completamente multilingüe**</span><br>
  Traducida íntegramente al francés, inglés, alemán, español, italiano y portugués, con cambio en directo y guardado en la configuración.

- <span style="color: var(--md-accent-fg-color)">:material-shield-check: **Aplicaciones de administrador**</span><br>
  Detectadas automáticamente al añadirlas, con una solicitud de Windows. Solo las aplicaciones que necesitan permisos de administrador usarán el modo administrador.

- <span style="color: var(--md-accent-fg-color)">:material-flask: **Modo de prueba**</span><br>
  Reproduce toda la secuencia (incluido el disparador «listo para volar») sin iniciar el simulador, para comprobar tus perfiles.

</div>

## ¿Por dónde empezar?

1. [**Instalación**](installation.md) — descargar e instalar la aplicación.
2. [**Primeros pasos**](getting-started.md) — configura tu primera secuencia.
3. [**Aplicaciones y secuencia**](applications.md) — el detalle de cada parte de la aplicación.
4. [**Perfiles**](profiles.md) y [**Opciones**](options.md) — gestiona tus perfiles y ajustes.
5. [**FAQ**](faq.md) — las preguntas más frecuentes.
6. [**Soporte**](support.md) — si necesitas ayuda.
