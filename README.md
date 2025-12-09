# 🌐 Manejo de HTTP Request: Body y Headers

Este proyecto demuestra cómo recibir y procesar solicitudes HTTP en una API REST construida con ASP.NET Core. El objetivo principal es entender la diferencia entre los datos que viajan en el **Cuerpo (Body)** de la solicitud y los metadatos que viajan en los **Encabezados (Headers)**.

## 🛠️ Herramientas
* **Lenguaje:** C# (.NET)
* **Pruebas:** Postman (para enviar peticiones personalizadas).

## 📂 Análisis del Código (`OpController`)

El controlador expone 4 métodos correspondientes a los verbos HTTP principales para realizar operaciones matemáticas básicas.

### 1. 📨 El Cuerpo de la Solicitud (Request Body)
En el método `POST`, recibimos datos complejos (un objeto JSON) que el usuario envía.

* **Clase Modelo:** Se utiliza la clase `Numbers` para "mapear" automáticamente el JSON recibido a un objeto de C#.

``` CSharp
public class Numbers
{
    public decimal a { get; set; }
    public decimal b { get; set; }
}
```

### 2. 🏷️ Los Encabezados (Request Headers)
Los headers transportan información extra sobre la petición (autenticación, tipo de contenido, metadatos del cliente). En C#, usamos el atributo `[FromHeader]` para capturarlos.

**Puntos clave del código:**
* **Captura directa:** `[FromHeader] string Host` captura el header estándar "Host".
* **Mapeo de nombres:** Como en C# las variables no pueden tener guiones (`-`), pero los headers sí (ej: `Content-Length`), usamos `Name` para vincularlos.

``` CSharp
[FromHeader(Name = \"Content-Length\")] string ContentLength
```

* **Headers Personalizados:** También podemos capturar headers inventados por nosotros, como `X-Some`.

 

## 🚀 Guía de Pruebas con Postman

Para probar este código, abre Postman y configura una nueva petición **POST** de la siguiente manera:

### A. Configuración de la URL
* **Verbo:** POST
* **URL:** `https://localhost:{TU_PUERTO}/api/Op`

### B. Configuración del Body (Datos)
Ve a la pestaña **Body** -> selecciona **raw** -> selecciona **JSON**.
Pega el siguiente objeto:

```JSON
{
    \"a\": 20,
    \"b\": 5
}
```

### C. Configuración de Headers (Metadatos)
Ve a la pestaña **Headers** y agrega uno personalizado para ver cómo el código lo captura:

| Key | Value | Descripción |
| :--- | :--- | :--- |
| `X-Some` | `Hola Mundo` | Header personalizado |

### D. Resultado Esperado
1.  **Response:** Deberías recibir `15` (el resultado de `20 - 5`).
2.  **Consola del Servidor:** En la terminal donde corre tu API, verás impresos los valores:
    * El Host (ej: `localhost:7159`).
    * El tamaño del contenido (`Content-Length`).
    * Tu mensaje personalizado (`Hola Mundo`).

---

## 📝 Resumen de Endpoints

| Verbo | Acción | Operación | Origen de Datos |
| :--- | :--- | :--- | :--- |
| `GET` | Get | Suma (`a + b`) | Query Params (URL) |
| `POST` | Add | Resta (`a - b`) | **Body (JSON) + Headers** |
| `PUT` | Edit | Multiplicación | Query Params |
| `DELETE` | Delete | División | Query Params |

---
*🎓 Ejercicio de clase sobre estructura HTTP.*

# 🌐 Ademas incluiremos, Tipos de respuestas especificas, ActionResult, IActionResutl

## 🛠️ En constriccion
