# Selenium UI Automation – Login Smoke Test (VB.NET + NUnit)

## Objetivo
Automatizar el flujo de inicio de sesión (Login) de una aplicación web y validar que el usuario accede correctamente a la página de inicio (`/Home`).

## Caso de prueba
**Login_Deberia_Entrar_A_Home**
- Abre el navegador (Chrome) con Selenium WebDriver
- Navega a `/Login`
- Escribe usuario y contraseña
- Presiona “Iniciar sesión”
- Valida que la URL contiene `/Home`

##  Tecnologías
- Selenium WebDriver
- NUnit 3
- WebDriverManager (gestión automática del ChromeDriver)
- Visual Basic .NET
- Visual Studio 2022

## Seguridad (sin credenciales en el código)
El test NO contiene usuarios ni contraseñas.
Las credenciales se cargan desde variables de entorno:

- `ESTUDIANTES_BASE_URL` (ej: `http://localhost:00000`)
- `ESTUDIANTES_USER`
- `ESTUDIANTES_PASS`

Si no existen, el test marca **Inconclusive**.

## Cómo ejecutar (local)
1. Tener la aplicación web corriendo en local.
2. Configurar variables de entorno.
3. En Visual Studio: **Prueba → Ejecutar todas las pruebas**.

### Ejemplo (Windows PowerShell)
```powershell
setx ESTUDIANTES_BASE_URL "http://localhost:00000"
setx ESTUDIANTES_USER "usuario_prueba"
setx ESTUDIANTES_PASS "password_prueba"
