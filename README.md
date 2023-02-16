<h1 align="center">Welcome to Portfolio 👋</h1>
<p>
 <img alt="Version" src="https://img.shields.io/badge/version-1.0.0-blue.svg?cacheSeconds=2592000" />
  <img src="https://img.shields.io/badge/SQL%20Server-2019-yellow" />
  <img src="https://img.shields.io/badge/ASP.Net-4.7.2-%23790c91" />
  <a target="_blank">
    <img alt="Documentation" src="https://img.shields.io/badge/documentation-no-brightgreen.svg" />
  </a>
  <a href="https://github.com/JoeGitHubPro/Portfolio](https://github.com/JoeGitHubPro/Portfolio)" target="_blank">
    <img alt="Maintenance" src="https://img.shields.io/badge/Maintained%3F-yes-green.svg" />
  </a>
  <a href="https://github.com/kefranabg/readme-md-generator/blob/master/LICENSE" target="_blank">
    <img alt="License: ASP.Net" src="https://img.shields.io/github/license/JoeGitHubPro/TravelAgancyPro" />
  </a>
</p>

> This is a portfolio management system, which is a web-based application that allows users to manage their portfolios and shares.

The system has a full dashboard that allows users to view all the information on the site. Users can also use this dashboard to manage their portfolios and shares. The system has full pages that are designed for investors who want to see all of their information in one place. Finally, it also has an application programming interface (API) so that third parties can integrate with it.
### 🏠 [Homepage](https://github.com/JoeGitHubPro/Portfolio)
## Prerequisites

- windows OS 
- .Net Framework 
- SQL Server
## Deploy DataBase

```sh
Run SQL file at this location [https://github.com/JoeGitHubPro/Portfolio/blob/main/PortfolioSQLQuery.sql] on database server
```

## Deploy

```sh
Go to  Web.config file , then change connectionStrings 
1- put database server name in "Data Source" 
2- put database name in "Initial Catalog"
3- put server site username in "User Id"
4- put server site password in "password"

do those steps twice for "DefaultConnection" and "PortfolioEntities"
```



## Web.config edition part

```sh

<add name="DefaultConnection" connectionString="Data Source=database server name;Initial Catalog=database name ;User Id=username;Password= password;Integrated Security=True" providerName="System.Data.SqlClient" />
    <add name="PortfolioEntities" connectionString="metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=database server name;Initial Catalog=database name ;User Id=username;Password= password;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
	  
	
```
## Author

👤 **Youssef Mohamed Ali**

* Website: https://joegithubpro.github.io/Profile/
* Twitter: [@https:\/\/twitter.com\/Y\_mohamed\_Ali?t=uW04TUW-iDrdq0u9GFRm9g&s=09](https://twitter.com/https:\/\/twitter.com\/Y\_mohamed\_Ali?t=uW04TUW-iDrdq0u9GFRm9g&s=09)
* Github: [@JoeGitHubPro](https://github.com/JoeGitHubPro)
* LinkedIn: [@https:\/\/www.linkedin.com\/in\/youssef-mohamed-71a368217](https://linkedin.com/in/https:\/\/www.linkedin.com\/in\/youssef-mohamed-71a368217)

## Show your support

Give a ⭐️ if this project helped you!

## 📝 License

Copyright © 2023 [Youssef Mohamed Ali](https://github.com/JoeGitHubPro).<br />
This project is ASP.Net licensed.



