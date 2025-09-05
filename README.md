# API - Card Saver

## Descripción

Esta es la **API de Card Saver**, construida con **.NET Core 10** en **Visual Studio**.  
Se encarga de manejar la lógica del backend para las tarjetas de crédito/debitop: **crear, listar, actualizar y almacenar tarjetas**.  
Está diseñada para integrarse fácilmente con el front-end desarrollado en React.se almacena la informacion en un json file.

---

## Estructura del proyecto

Caze.Api/
├─ Controllers/
│ └─ CardController.cs # Maneja los endpoints para tarjetas
├─ Models/
│ └─ Card.cs # Define la estructura de la tarjeta
├─ Services/
│ └─ CardService.cs # Lógica para guardar, actualizar, delete y obtener tarjetas
├─ cards.json # json donde se almacenan las tarjetas
├─ Program.cs # Configuración del servidor y servicios
└─ appsettings.json # Configuración de la aplicación

## Endpoints principales

| Método | Ruta         | Descripción              |
| ------ | ------------ | ------------------------ |
| GET    | `/api/cards` | Lista todas las tarjetas |
| POST   | `/api/cards` | Crea una nueva tarjeta   |

### Ejemplo de request (POST `/api/cards`)

```json
{
  "cardNumber": "1234567891234567",
  "ownerName": "Ezequiel Garcia",
  "expirationDate": "12/30",
  "cvv": "123"
}
```

## Cómo correr la API

1. Abrir Visual Studio y cargar el proyecto Caze.Api.sln.

2. Seleccionar Caze.Api como proyecto de inicio.

3. Presionar F5 o Ctrl + F5 para ejecutar la API.

La API correrá por defecto en http://localhost:5167

## Detalles de la lógica del Card

Card:
Modelo que define la estructura de cada tarjeta (número, titular, CVV y fecha de expiración).

CardController:
Controlador principal que expone los endpoints para interactuar con las tarjetas.

CardService:
Contiene la lógica para validar, agregar y obtener tarjetas.
Permite separar la lógica del controlador, manteniendo el código limpio y escalable.

CardRepository:
Maneja el almacenamiento de los datos. Puede ser en memoria para pruebas o conectado a una base de datos real.

## Enlaces de repositorios

Front-End: https://github.com/ezequielgm25/card-saver-front-end
Back-End: https://github.com/ezequielgm25/card-saver-back-end
