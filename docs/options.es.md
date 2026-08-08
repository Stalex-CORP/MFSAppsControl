# Opciones

Abre las opciones con el icono de **engranaje** :material-cog: de la barra de título,
o desde el menú del icono del área de notificación.

![La ventana Opciones](assets/options.png)

Todos los ajustes se **guardan de inmediato** — no hay ningún botón
«Aplicar».

## General

| Opción                                              | Efecto                                                                                                     |
| --------------------------------------------------- | ------------------------------------------------------------------------------------------------------------ |
| **Iniciar al arrancar Windows**                     | Se inicia automáticamente con tu sesión de Windows.                                                        |
| **Minimizar en la bandeja del sistema**             | Minimiza la ventana en el área de notificación (bandeja) en lugar de dejarla en la barra de tareas.        |
| **Al cerrar se minimiza en la bandeja del sistema** | Cerrar minimiza la ventana en el área de notificación (bandeja) en lugar de cerrar la aplicación.          |
| **Iniciar minimizado en la bandeja del sistema**    | Arranca directamente en la bandeja, con la ventana oculta.                                                 |

!!! info "¿Cómo cerrar de verdad la aplicación si al cerrar se minimiza en el área de notificación?"
    Si **Al cerrar se minimiza en la bandeja del sistema** está activado, la cruz ya no cierra la aplicación.<br>
    Usa **Salir** en el menú del icono del área de notificación (clic derecho).

## Apariencia

### Tema de la aplicación

*Sistema* (sigue el estilo de Windows), *Claro* u *Oscuro*.<br>
El botón :material-weather-sunny:/:material-weather-night: de la barra de título también cambia el tema rápidamente.

### Estilo de la secuencia

Elige la representación de la [secuencia](applications.md#la-linea-de-tiempo):

- **Doble** — Dos pistas independientes que muestran cada secuencia.
- **Mono** — Una sola pista separada por el centro, una mitad para cada secuencia.

### Idioma de la interfaz

Traducción completa a: francés, inglés, alemán, español, italiano y portugués.<br>
Se aplica de inmediato, sin necesidad de reiniciar, y se guarda en la configuración.<br>
También está disponible en la barra de título, con la bandera del idioma en uso.<br>

!!! info
    Se define automáticamente según el idioma de Windows en el primer inicio, pero se puede cambiar en cualquier momento.

## Actualizaciones

- **Buscar actualizaciones automáticamente** — activa la comprobación automática cada día.
- **Buscar ahora** — lanza una búsqueda inmediata. El resultado se muestra bajo la etiqueta (actualizado / nueva versión disponible).

!!! info
    Cuando hay una actualización disponible, aparece una **insignia** en la barra de título; un clic en ella inicia la descarga y la instalación.

## Depuración

### Nivel de registro

Determina el detalle que se escribe en los archivos de registro. El cambio se aplica **de inmediato**, sin reiniciar la aplicación.

| Nivel                 | Contenido                                                       | Cuándo usarlo             |
| --------------------- | ---------------------------------------------------------------- | ------------------------- |
| **Error** *(predet.)* | Solo errores y advertencias.                                    | En uso normal.            |
| **Debug**             | + el desarrollo de las operaciones (detecciones, inicios, cierres…). | A petición del soporte.   |
| **Trace**             | + el detalle de los valores internos. Muy pesado.               | A petición del soporte.   |

Se crea un archivo nuevo **cada día**, y los registros de más de **7 días** se eliminan automáticamente.

!!! tip
    Acuérdate de **volver a poner el nivel en Error** una vez enviado tu problema: los niveles Debug y Trace son muy pesados.

### Exportar

Crea un archivo **`zip`** que contiene todos tus registros **y** tu configuración, necesarios para el soporte.

### Restablecer la aplicación

Borra **todos tus perfiles y ajustes** y vuelve a empezar de cero, como recién instalada.<br>
**Se pide una confirmación explícita.**

!!! danger "Acción irreversible"
    No se puede recuperar nada después de un restablecimiento.<br>

## Acerca de

Muestra el detalle de la aplicación y los enlaces rápidos a **Discord** y **Flightsim.to**.
