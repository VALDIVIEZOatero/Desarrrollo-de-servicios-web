API de Gestión de Citas Médicas - Sistema APICITAS
Este proyecto es una API RESTful desarrollada con .NET Core para la gestión eficiente de citas médicas en una clínica privada. La solución reemplaza los registros manuales por un sistema digitalizado que permite centralizar la información de pacientes, médicos y especialidades.

🛠️ Tecnologías y Herramientas
Lenguaje: C#

Framework: .NET Core 10.0 (o la versión que estés usando)

Arquitectura: Basada en capas (Controllers, Services, Models)

Persistencia: Datos en memoria (List<T>) para simulación de base de datos.

Pruebas: Postman para validación de Endpoints.

📂 Estructura del Proyecto
Basado en las mejores prácticas de desarrollo, el código se organiza de la siguiente manera:

Controllers: Manejan las peticiones HTTP y definen las rutas de la API (Cita, Medico, Paciente, Especialidad).

Services: Contienen la lógica de negocio y manipulan las colecciones de datos.

Models: Definen las entidades y estructuras de datos (Clases Cita, Medico, etc.).

Program.cs: Configuración del pipeline de la aplicación y servicios.