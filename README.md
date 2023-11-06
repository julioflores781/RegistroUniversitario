# README - Proyecto Registro Universitario

Este repositorio contiene un proyecto ASP.NET que proporciona una aplicación web para la gestión del Registro Universitario y una seria de apis.

## Contenido del Proyecto

El proyecto se organiza de la siguiente manera:

- **Carpeta "sql"**: Contiene scripts SQL relacionados con la base de datos de la aplicación y un .bak ya con la base configurada y con datos.

- **Carpeta "RegistroUniversitario"**: Contiene tres proyectos:

  - **Proyecto "Datos"**: Contiene la lógica de acceso a la base de datos, incluyendo modelos y contextos de base de datos.

  - **Proyecto "Controladores"**: Contiene controladores de la aplicación que manejan las solicitudes HTTP y las interacciones con los modelos de datos.

  - **Proyecto "Web de Registro Universitario"**: Representa la parte web de la aplicación que los usuarios finales pueden acceder a través de un navegador web.

## Configuración de la Base de Datos

### Scripts SQL

La carpeta "sql" contiene scripts SQL que se pueden utilizar para configurar la base de datos de la aplicación. Puede ejecutar estos scripts en su servidor SQL Server para crear la estructura de la base de datos y cargar datos iniciales.

### Restauración de un Backup

Si prefiere restaurar una copia de seguridad de la base de datos, encontrará un archivo de respaldo en la carpeta "sql" con el nombre "registrouniversitario.bak". Puede utilizar este archivo de respaldo para restaurar la base de datos en su servidor SQL Server.

Si trabajas con docker podrias utilizar la version (FROM mcr.microsoft.com/mssql/server:2022-RTM-GDR1-ubuntu-20.04) de sql server para que no tengas problemas al momento de restaurar el .bak

## API Externa

Además de la interfaz web, el proyecto también expone una serie de API con la siguiente nomenclatura:

- `api/Profesor/Obtener`: Esta API permite obtener información sobre los profesores.
- `api/Materias/Obtener`: Esta API permite obtener información sobre las Materias.
- `api/HorariosMaterias/Obtener`: Esta API permite obtener información sobre los HorariosMaterias.
- `api/Inscripciones/Obtener`: Esta API permite obtener información sobre las Inscripciones.
- `api/Calificaciones/Obtener`: Esta API permite obtener información sobre las Calificaciones.
- `api/Estudiantes/Obtener`: Esta API permite obtener información sobre los Estudiantes.

## Requisitos y Configuración

Para ejecutar la aplicación y utilizar las API, asegúrese de tener los siguientes requisitos en su entorno:

- Microsoft Visual Studio (2015 en adelante).
- SQL Server Management Studio (FROM mcr.microsoft.com/mssql/server:2022-RTM-GDR1-ubuntu-20.04)
- .NET Framework.

## Instrucciones de Uso

1. Clone este repositorio en su entorno local.
2. Utilice los scripts SQL en la carpeta "sql" para configurar la base de datos en su servidor SQL Server, o restaure una copia de seguridad usando el archivo "registrouniversitario.bak".
3. Abra el proyecto en Visual Studio.
4. Configure la cadena de conexión a la base de datos en el archivo de configuración de la aplicación (por lo general, en el archivo "Web.config" o "appsettings.json").
5. Compile y ejecute la aplicación desde Visual Studio.

## Contribuciones

Si desea contribuir al proyecto o informar sobre problemas, no dude en abrir un problema o enviar una solicitud de extracción.

¡Gracias por utilizar la aplicación Registro Universitario!