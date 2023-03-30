<a name="readme-top"></a>
<div align="center">
    <img src="https://gitlab.com/legalt-group/lagalt-front-end/uploads/81662aed7406d8bbdb88f1b6450d3ba5/lagalt-logo.png" alt="Logo" width="80" height="80">

<h3 align="center">Lagalt API</h3>
</div>


<!-- TABLE OF CONTENTS --> ========> COMPLETE WHEN README IS FINISHED
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#description">Description</a>
      <ul>
        <li><a href="#Project's-backround">Project's backround</a></li>
        <li><a href="#Purpose">Purpose</a></li>
      </ul>
    </li>
    <li>
      <a href="#project-status">Project status</a>
      <ul>
        <li><a href="#lagalt-api-1.0">Lagalt API 1.0</a></li>
        <li><a href="#missing-requirements">Missing Requirements</a></li>
      </ul>
    </li>
    <li>
       <a href="#usage">Usage</a>
        <ul>
          <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#technology-stack">Technology stack</a></li>
    <li><a href="#contributors">Contributors</a></li>
    <li><a href="#conclusion">Conclusion</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>


## Description
This manual will show you how to set up the Lagalt Web API and its dependencies.

### Project's backround
### Purpose

## Project status
### Lagalt API 1.0
All of the functionality that is required for the API to be fully usable is implemented. All of the endpoints will be listed later.

### Missing requirements
* Authentication on Controllers
* ?Skills Match Algorithm (sorting)?

<p align="right">(<a href="#readme-top">back to top</a>)</p>
## Usage
### Installation
1. Install an IDE
2. Clone this repository: https://gitlab.com/legalt-group/lagalt-web-api.git
3. Install the following packages: 
 * AspNetCoreRateLimit (5.0.0), 
 * AutoMapper.Extensions.Microsoft.DependencyInjection (12.0.0)
 * Microsoft.AspNetCore.Authentication.JwtBearer (6.0.14)
 * Microsoft.AspNetCore.SignalR.Client (6.0.14)
 * Microsoft.EntityFrameworkCore.Design (6.0.14)
 * Microsoft.EntityFrameworkCore.SqlServer (6.0.14)
 * Microsoft.EntityFrameworkCore.Tools (6.0.14)
 * Microsoft.VisualStudio.Web.CodeGeneration.Design (6.0.12)
 * Swashbuckle.AspNetCore (6.5.0)

4. Then add the connection string to your appsetting.json file.
5. To set the user secrets for keycloak run these commands:  
                               <-------------------------------Noen som kan kommandoene?                         

6. As for the database creation, run the following commands in the nuget package manager console:
 * add-migration <name-of-the-initial-migration>
 * update-database

##Technology stack
* [![C#][C#]][C#-url]
* [![ASP .NET Core 6][ASP.NETCore6]][ASP-.NET-Core-6-url]
* [![EF 6][EF6]][EF-6-url]
* [![Azure][Azure.com]][Azure-url]
* [![VS2022][VS2022.com]][VSC2022-url]
* [![SQLServer][SQLServer.com]][SQLServer-url]
* <a href="https://www.keycloak.org/"> 🔑 Keycloak </a>
* <a href="https://www.cloud-iam.com/"> ☁ Cloud Iam </a> 

## Eventuell figur???


## Contributors
* <a href="https://www.linkedin.com/in/jarand-larsen-58852a257/">Jarand Larsen</a>
* <a href="https://www.linkedin.com/in/paulius-aleksandravicius-a12a01233/">Paulius Aleksandravicius</a>
* <a href="https://www.linkedin.com/in/fredrik-christensen-a33451159/">Fredrik Christensen</a>
* <a href="https://www.linkedin.com/in/ida-huun-michelsen/">Ida Huun Michelsen</a>
* <a href="https://www.linkedin.com/in/erik-aardal/">Erik Aardal</a>

## Conclusion

<!-- LICENSE -->
## License

Distributed under the MIT License.
<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[ASP.NETCore6]: https://img.shields.io/badge/ASP .NET Core 6-000000?style=for-the-badge&logo=ASP&logoColor=white
[ASP-.NET-Core-6-url]: https://dotnet.microsoft.com/en-us/download/dotnet/6.0

[EF6]: https://img.shields.io/badge/ef 6-000000?style=for-the-badge&logo=ef -6&logoColor=white
[EF-6-url]: https://learn.microsoft.com/en-us/ef/ef6/

[C#]: https://img.shields.io/badge/csharp-000000?style=for-the-badge&logo=csharp&logoColor=white
[C#-url]: https://dotnet.microsoft.com/en-us/learn/csharp

[VS2022.com]: https://img.shields.io/badge/VS2022-0078D4?style=for-the-badge&logo=vs2022&logoColor=white
[VS2022-url]: https://visualstudio.microsoft.com/vs/

[SQLServer.com]: https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white
[SQLServer-url]: https://www.microsoft.com/en-us/sql-server/sql-server-downloads

[Azure.com]: https://img.shields.io/badge/microsoft%20azure-0089D6?style=for-the-badge&logo=microsoft-azure&logoColor=white
[Azure-url]: https://azure.microsoft.com/en-us

<p align="right">(<a href="#readme-top">back to top</a>)</p>