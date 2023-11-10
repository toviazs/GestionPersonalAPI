# API de Gestión de Empleados

Esta API proporciona servicios para la gestión de empleados, roles, sectores, historial de roles y historial de sectores en una organización.

## Empleados

### Listar todos los empleados
`GET /Empleado`

### Obtener información de un empleado específico
`GET /Empleado/{legajoEmp:int}`

### Listar detalles de todos los empleados (con objeto rol y sector)
`GET /Empleado/Detalle`

### Obtener detalles de un empleado específico (con objeto rol y sector)
`GET /Empleado/Detalle/{legajoEmp:int}`

### Crear un nuevo empleado
`POST /Empleado`

#### Estructura del cuerpo de la solicitud:
```json
{
  "nombreEmpleado": "string",
  "apellidoEmpleado": "string",
  "fechaNacimiento": "2023-11-06T21:28:26",
  "genero": "string",
  "direccion": "string",
  "telefono": "string",
  "correo": "string",
  "fechaContratacion": "2023-11-06T21:28:26",
  "cuil": 0,
  "legajoSupervisor": 0,
  "rolIdRol": 0,
  "sectorIdSector": 0
}
```

### Actualizar información de un empleado existente
`PUT /Empleado/{legajoEmp:int}`

#### Estructura del cuerpo de la solicitud:
```json
{
  "legajoEmpleado": 0,
  "nombreEmpleado": "string",
  "apellidoEmpleado": "string",
  "fechaNacimiento": "2023-11-06T21:28:46.543Z",
  "genero": "string",
  "direccion": "string",
  "telefono": "string",
  "correo": "string",
  "fechaContratacion": "2023-11-06T21:28:46",
  "cuil": 0,
  "fechaFinContrato": "2023-11-06T21:28:46",
  "legajoSupervisor": 0,
  "rolIdRol": 0,
  "sectorIdSector": 0
}
```

### Borrar un empleado (borrado lógico)
`DELETE /Empleado/{legajoEmp:int}`

## Roles

### Listar todos los roles
`GET /Rol`

### Obtener información de un rol específico
`GET /Rol/{idRol:int}`

## Sectores

### Listar todos los sectores
`GET /Sector`

### Obtener información de un sector específico
`GET /Sector/{idSector:int}`

## Historial de Roles

### Obtener historial de roles de un empleado específico
`GET /HistorialRol/{legajoEmp:int}`

## Historial de Sectores

### Obtener historial de sectores de un empleado específico
`GET /HistorialSector/{legajoEmp:int}`

**Nota:** Asegúrese de reemplazar los valores de ejemplo en las solicitudes con datos reales antes de realizar cualquier operación.