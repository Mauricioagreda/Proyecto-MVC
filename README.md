<!-- Completa abajo cambiando ET12DE1Computacion a tu user|organización y template a tu repo, te recomiendo usar el Find & Replace de tu editor -->
![main build.NET5](https://github.com/ET12DE1Computacion/simpleTemplateCSharp/workflows/main-build.NET5/badge.svg?branch=main) ![main test.NET5](https://github.com/ET12DE1Computacion/simpleTemplateCSharp/workflows/main-test.NET5/badge.svg?branch=main)
![dev build.NET5](https://github.com/ET12DE1Computacion/simpleTemplateCSharp/workflows/dev-build.NET5/badge.svg?branch=dev) ![dev test.NET5](https://github.com/ET12DE1Computacion/simpleTemplateCSharp/workflows/dev-test.NET5/badge.svg?branch=dev)
[![Abrir en Visual Studio Code](https://open.vscode.dev/badges/open-in-vscode.svg)](https://open.vscode.dev/ET12DE1Computacion/simpleTemplateCSharp)
<!-- Borra este comentario y linea después haber cambiado arriba las ocurrencias de tu usuario/repo -->

<h1 align="center">E.T. Nº12 D.E. 1º "Libertador Gral. José de San Martín"</h1>
<p align="center">
  <img src="https://et12.edu.ar/imgs/et12.png">
</p>

## Computación 2021

**Asignatura**: Programacion Sobre Redes

**Nombre TP**: Proyecto-MVC

**Apellido y nombre Alumno**: Agreda Mauricio

**Curso**: 6° 7°

# MusicaMVC

Es un Proyecto que sigue el patron de diceño MVC, en el cual se es capaz de editar, eliminar, agregar y seleccionar (CRUD) registros  segun lo que el usuario desee.

## Comenzando 🚀

Clonar el repositorio github, desde Github Desktop o ejecutar en la terminal o CMD:
```
git clone (https://github.com/Mauricioagreda/Proyecto-MVC)
```

### Pre-requisitos 📋

- .NET 8.0 (SDK .NET 8.0) [Descargar](https://dotnet.microsoft.com/download/dotnet/8.0)

## Despliegue 📦

- Agregar Paquetes NuGet.
microsoft.entityframeworkcore.sqlserver\8.0.4\
microsoft.entityframeworkcore.tools\8.0.4\

- Editar la cadena de conexion en caso de que se haya modificado el Nombre defaul del server.
MusicaMVC -> appsettings.json -> "CadenaSQL": "Data Source=(local)\\NOMBRE MODIFICADO DE TU SERVER;Initial Catalog=DBCrud; Integrated Security=True; Trusted_Connection=True; -TrustServerCertificate=True;"

- Crear La Base de Datos.
Herramientas -> Administrador de paquetes NuGet -> Consola de Administrador de paquetes -> Tipear en la consola: Update-DAtabase

## Construido con 🛠️

_Menciona las herramientas y versiones que utilizaste para crear tu proyecto_

* [Visual Studio Code](https://code.visualstudio.com/#alt-downloads) - Editor de código.

## Versionado 📌

Usamos [SemVer](http://semver.org/) para el versionado. Para todas las versiones disponibles, mira los [tags en este repositorio](https://github.com/tuUser/tuRepo/tags).

## Autores ✒️

Mauricio Agreda - Desarrollo - [MauricioAgreda](https://github.com/Mauricioagreda)
Max Power - Desarrollo - [Maxpower](https://github.com/maxpower)
Cosme Fulanito - Documentación - [Cosmefulanito](#Cosmefulanito)

## Licencia 📄

Este proyecto está bajo la Licencia (Tu Licencia) - mira el archivo [LICENSE.md](LICENSE.md) para detalles.
