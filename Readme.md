# README

## Creando a base de datos

```sql
create database ControlPlazas

use ControlPlazas

create table Plaza (
    Id UNIQUEIDENTIFIER not null,
    CodPago int not null,
    Unidad int not null,
    SubUnidad int not null,
    CatPuesto varchar(7) not null,
    Horas decimal (4,1) not null,
    ConsPlaza int not null,
    PlazaOrigen UNIQUEIDENTIFIER null,
    PRIMARY KEY (id),
    FOREIGN KEY (PlazaOrigen) REFERENCES Plaza(Id)
)

```

## Carga de datos de ejemplo

```sql
insert into Plaza values('2df4ec2e-80db-4751-a423-35d9ff9a02da',7,1,1,'E0281',0.0,123456,NULL);
insert into Plaza values('0b573b67-5c29-4581-a2d7-4932cae30a5f',7,1,1,'E0281',0.0,345678,NULL);
insert into Plaza values('1ba4de3f-0af0-4cf1-ba1d-8248dd400c7f',7,1,1,'E0281',0.0,234567,'2df4ec2e-80db-4751-a423-35d9ff9a02da');
insert into Plaza values('4ed0fd8a-471c-4e0e-a8d1-970057c8af4a',7,1,1,'A01803',0.0,456789,'0b573b67-5c29-4581-a2d7-4932cae30a5f');
insert into Plaza values('b720395c-71ae-477e-b5ca-a24f6e823ac6',7,1,1,'A01807',0.0,678901,'4ed0fd8a-471c-4e0e-a8d1-970057c8af4a');
insert into Plaza values('ebbd98ab-8c9c-4b62-a812-f769e35e160c',7,1,1,'A01803',0.0,567890,NULL);
```

## Notas

Copiar el archivo AppExample.json a App.json y modificar de acuerdo a la cadena de conexión requerida para la base de datos mssql

```
{
    "ConnectionString": "Server=servidorIp;Database=nombreBD;User Id=usuarioBD;Password=passwordBD"
}
```
El comando para el scaffolding es 

```bash
dotnet ef dbcontext scaffold "Server=servidorIp;Database=ControlPlazas;User Id=usuarioBD;Password=password" Microsoft.EntityFrameworkCore.SqlServer
```

La entidad obtenida por ingeniería inversa se encuentra en Entities/Plaza.cs. El dbContext se encuentra en ControlPlazasContext.cs.

Al dbContext se le modificó la cadena de conexión para que la tome a través de HelperConfiguration.GetAppConfiguration() una vez generada por ingeniería inversa.

Se forza la carga de entidades recursivas mediante Explicit Load en la clase RecursiveTest.DAL.ControlPlazaRepository. 

```C#
    public Plaza? RetrievePlazaById(Guid Id)
    {
        Plaza? plaza = context.Plazas
            .Single(p => p.Id == Id);
        //Se indica la carga explícita de las plazas de origen
        var plazasOrigen = context.Plazas.ToList();
        return plaza;
    }
```