Imports NUnit.Framework
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports WebDriverManager
Imports WebDriverManager.DriverConfigs.Impl

Namespace Estudiantes.SeleniumTests

    Public Class Tests

        <Test>
        Public Sub Login_Deberia_Entrar_A_Home()

            Dim baseUrl = Environment.GetEnvironmentVariable("ESTUDIANTES_BASE_URL")
            Dim username = Environment.GetEnvironmentVariable("ESTUDIANTES_USER")
            Dim password = Environment.GetEnvironmentVariable("ESTUDIANTES_PASS")

            If String.IsNullOrEmpty(baseUrl) OrElse
               String.IsNullOrEmpty(username) OrElse
               String.IsNullOrEmpty(password) Then

                Assert.Inconclusive("Faltan variables de entorno para ejecutar el test")
            End If

            Dim manager As New DriverManager()
            manager.SetUpDriver(New ChromeConfig())

            Dim options As New ChromeOptions()
            options.AddArgument("--start-maximized")

            Dim driver As IWebDriver = New ChromeDriver(options)

            Try
                driver.Navigate().GoToUrl(baseUrl.TrimEnd("/"c) & "/Login")

                Dim wait As New WebDriverWait(driver, TimeSpan.FromSeconds(10))

                Dim txtUsuario = wait.Until(Function(d) d.FindElement(By.Id("autenticacion_usuario")))
                Dim txtPass = driver.FindElement(By.Id("autenticacion_contrase_a"))

                txtUsuario.Clear()
                txtUsuario.SendKeys(username)

                txtPass.Clear()
                txtPass.SendKeys(password)

                Dim btnLogin = driver.FindElement(By.Id("BTNLogin"))
                btnLogin.Click()

                wait.Until(Function(d) d.Url.Contains("/Home"))
                Assert.That(driver.Url, Does.Contain("/Home"))

            Finally
                driver.Quit()
            End Try

        End Sub

    End Class

End Namespace
