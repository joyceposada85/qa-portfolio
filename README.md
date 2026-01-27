# Pruebas con JMeter – Login

## Objetivo
Validar el flujo de autenticación de una aplicación web mediante pruebas automatizadas con Apache JMeter.

## Flujo probado
1. GET /Login  
   - Obtiene la página de login
   - Extrae el token antiforgery (_RequestVerificationToken)

2. POST /Login  
   - Envía usuario y contraseña desde CSV
   - Envía token antiforgery
   - Mantiene sesión mediante cookies

3. GET /Home  
   - Verifica que la sesión esté activa
   - Confirma login exitoso si no redirige a /Login

## Datos de prueba
Los usuarios se cargan desde un archivo CSV con credenciales ficticias.

## Validaciones
- Código HTTP 200
- Sesión activa
- Manejo correcto de cookies y tokens

## Herramientas
- Apache JMeter
- CSV Data Set Config
- Regular Expression Extractor
- HTTP Cookie Manager
