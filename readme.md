<div align="center">

  <h1>🏥 APICITAS</h1>
  <h3>API RESTful de Gestión de Citas Médicas</h3>

  <p>
    Sistema digital sencillo y eficiente para clínicas privadas que elimina agendas físicas y centraliza la gestión de pacientes, médicos, especialidades y citas.
  </p>

  <!-- Badges -->
  <p>
    <img src="https://img.shields.io/badge/.NET_Core-10.0-512BD4?style=for-the-badge&logo=.net&logoColor=white" alt=".NET Core 10" />
    <img src="https://img.shields.io/badge/C%23-12.0-blue?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
    <img src="https://img.shields.io/badge/Status-Entrega final-yellow?style=for-the-badge" alt="Estado" />
    <img src="https://img.shields.io/badge/License-MIT-green?style=for-the-badge" alt="MIT License" />
  </p>

</div>

<br/>

## 📖 Contexto del proyecto

La clínica manejaba citas mediante **agendas físicas**, lo que generaba:

- Pérdida frecuente de información  
- Dificultad para consultar historial  
- Sobrecarga administrativa  
- Errores en programación de citas  

**APICITAS** nace para solucionar estos problemas mediante una API RESTful que permite:

- Registrar, consultar, modificar y cancelar citas de forma ordenada  
- Gestionar médicos y sus especialidades  
- Mantener un registro centralizado de pacientes  
- Validar automáticamente los datos ingresados  

<br/>

## 🛠️ Tecnologías utilizadas

| Categoría        | Tecnología              | Versión / Uso                          |
|------------------|-------------------------|----------------------------------------|
| Lenguaje         | C#                      |                      C# 12            |
| Framework        | .NET                     | 10.0                                    |
| Arquitectura     | Capas limpias           | Controllers → Services → Models        |
| Persistencia     | En memoria              | `List<T>` (simulación – fácil migrar a EF Core) |
| Testing manual   | Postman                 | Colección con todos los endpoints      |
| Validaciones     | Data Annotations        | `[Required]`, `[StringLength]`, `[DataType]` |

<br/>
## 📂 Estructura del proyecto

```text
APICITAS/
├── Controllers/
│   ├── CitaController.cs
│   ├── MedicoController.cs
│   ├── PacienteController.cs
│   └── EspecialidadController.cs
├── Services/
│   ├── CitaService.cs
│   ├── MedicoService.cs
│   ├── PacienteService.cs
│   └── EspecialidadService.cs
├── Models/
│   ├── Cita.cs
│   ├── Medico.cs
│   ├── Paciente.cs
│   └── Especialidad.cs
├── Program.cs
├── APICITAS.csproj
├── Properties/
│   └── launchSettings.json
└── README.md


## 🚀 Instalación y ejecución (paso a paso)


# 1. Clonar el repositorio
git clone https://github.com/VALDIVIEZOatero/Desarrrollo-de-servicios-web.git

# 2. Entrar a la carpeta del proyecto
cd APICITAS

# 3. Restaurar paquetes NuGet
dotnet restore

# 4. Compilar y ejecutar
dotnet run
```
## 🛣️ Endpoints principales

| Método | Endpoint              | Descripción                              |
|--------|-----------------------|------------------------------------------|
| GET    | `/api/Cita`           | Lista todas las citas                    |
| POST   | `/api/Cita`           | Crea una nueva cita                      |
| GET    | `/api/Cita/{id}`      | Obtiene una cita por ID                  |
| PUT    | `/api/Cita/{id}`      | Actualiza una cita                       |
| DELETE | `/api/Cita/{id}`      | Cancela o elimina una cita               |
| GET    | `/api/Medico`         | Lista todos los médicos                  |
| GET    | `/api/Paciente`       | Lista todos los pacientes                |
| GET    | `/api/Especialidad`   | Lista todas las especialidades           |



## ✅ Validaciones implementadas

| Tipo de validación          | Anotación / Lugar                  | Descripción principal                                      |
|-----------------------------|------------------------------------|------------------------------------------------------------|
| Obligatoriedad              | `[Required]`                       | Campos esenciales no pueden estar vacíos                   |
| Longitud de texto           | `[StringLength(150, MinimumLength = 2)]` | Nombres y apellidos razonables (2–150 caracteres)         |
| Formato fecha/hora          | `[DataType(DataType.DateTime)]`    | Asegura fechas y horas válidas                             |
| Formato teléfono            | `[Phone]`                          | Valida números telefónicos (si se usa)                     |
| Formato email               | `[EmailAddress]`                   | Verifica correos electrónicos correctos (si se usa)        |
| Reglas de negocio           | En los Services                    | Citas futuras, sin duplicados, existencia de entidades     |

## 👥 Equipo de Desarrollo
**Grupo 3**

| # | Nombres                              | 
|---|-------------------------------------|
| 1 | Siri Vergara María Alejandra        | 
| 2 | Santisteban Manrique Adrián         | 
| 3 | Valdiviezo Atero Yoli Jhunior       | 
| 4 | Zurita Rimaicuna Abner Stih         | 
| 5 | Villasante Contreras Jean Paul      | 



Markdown![APICITAS Banner](https://capsule-render.vercel.app/api?type=slice&color=gradient&height=180&section=header&text=APICITAS&fontSize=60&fontAlignY=70&animation=twinkling&fontColor=white)


