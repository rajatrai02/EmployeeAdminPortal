# 🌐 ASP.NET Core Web API with Swagger + Cloud Database Integration

## 📋 Overview
This project is a fully deployed ASP.NET Core Web API hosted on [SmarterASP.NET](https://www.smarterasp.net), featuring:
- Automatic redirect to Swagger UI
- Live cloud database integration for full CRUD functionality

---

## 🚀 Live Demo
Access the API documentation here:  
👉 [Swagger UI](http://kratosrj02-001-site1.ntempurl.com/swagger/index.html)

---

## 🛠 Technologies Used
- ASP.NET Core (.NET 6/7)
- Entity Framework Core
- SQL Server (Cloud-hosted)
- Swagger for API documentation

---

## ⚙️ Features
- 🔄 Redirects base URL `/` to Swagger UI for usability
- ✅ CRUD operations tied to live cloud database
- 🧪 Interactive API testing via Swagger

---

## 📦 How to Publish
1. Build your project in Visual Studio
2. Use **Web Deploy** to publish to SmarterASP.NET
3. Ensure all views, DLLs, and configs are included

---

## 🔧 Configuration Notes

### Redirect Root URL
Add the following to `Program.cs`:
```csharp
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
        return;
    }
    await next();
});
