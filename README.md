![](https://raw.githubusercontent.com/krenky/Tusbi-Boys/83768adbfca0a0b4748f09015ce4825d24eb7b5b/src/img/WebLogo.png)

# Population Mobility Monitor

Placeholder

## Requirements
.Net 5 or higher

PostgreSQL 10 or higher

C# 9 or higher

EntityFramworkCore 5.0.12 or higher

Use the package manager [NuGet](https://www.nuget.org/) to install EntityFramworkCore.

```bash
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```


## Usage
After installing the packages, edit the line
```
"DefaultConnection": "Host=localhost;Port=5432;Database=ShopDb;Username=postgres;Password=pass"
```
```
 "SecretKey": "jdsfhajkldfhasjkdf",
```
in the appsettings.json file.

Use the package manager [NuGet](https://www.nuget.org/) to create database
```
Update-database
```

Start building the project.

## Troubleshooting
If the run failed, recreate the database, make the changes needed and rerun build project. If you already combined the files then you dont need to create them again.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.


## Anime

.
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠋⠉⠉⠛⠻⢿⣿⠿⠛⠋⠁⠈⠙
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠴⣿⠟⠉⠄⠄⠈⡀⠄⠄⠄⠄⠄⠄
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠄⣾⣿⣿⣿⣿⣿⠿⠿⠿⠛⠛⠉⠉⠄⠄⠄⠄⠄⠄⠄⠉⢁⠄⠄⠈⠄⠄⠄⠄⢀⡇⠄⠄⠄⠄⠄⠄
⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠄⠄⣀⣿⠿⠛⠉⠁⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢠⡀⠄⠄⠄⢀⣠⣾⣿⠄⠄⠐⢦⡀⠄
⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⣠⡾⠋⠁⠄⠄⠄⠄⠄⠄⠄⠄⣤⣤⣄⣀⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⠛⠻⠿⠿⠟⠛⠋⢷⣄⠄⠄⠹⣦
⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠁⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⡟⠛⠛⠛⠛⠯⠶⣤⣀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠻⣷⣤⡀⠘
⣿⣿⣿⣿⣿⣿⣿⡿⠃⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⡇⠄⠄⠄⠄⠄⠄⠄⠉⠑⠢⣀⠈⠢⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠙⣿⣿⣷
⣿⣿⣿⣿⣿⣿⠏⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢰⠄⠄⡇⠄⠄⠄⣀⠄⠒⠄⠄⠄⠄⠄⠑⠢⡙⡳⣄⠄⠄⠄⠈⠄⠄⠄⠄⠈⠻⣿
⣿⣿⣿⣿⡿⠃⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢸⡆⠄⠃⢀⡴⠚⠁⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⠱⠈⠳⡄⠄⠄⠄⢂⠄⠄⠄⠄⠘
⣿⣿⣿⡿⠁⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⣾⡀⢐⠉⠄⠄⠄⠄⠄⠄⠄⠄⠄⢀⣀⣀⣴⡀⠁⠄⠙⢦⠄⠄⠈⣧⡀⠄⠄⠄
⣿⣿⣿⠃⠄⠄⠄⡇⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⡏⠳⡈⡀⠄⠄⠄⠄⠄⢀⣤⣶⣿⡿⠿⠽⠿⠿⣿⣷⣶⣌⡳⡀⠄⢹⣷⡄⠄⠄
⣿⡟⠁⠄⠄⠄⠄⣷⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢸⠄⠑⢥⠄⠄⡾⠋⣰⡿⡟⠊⠄⠚⣿⣿⣿⣶⣄⠄⠉⢹⠄⢳⠄⢸⣿⣿⡄⠄
⣿⠇⠄⠄⠄⠄⠄⢹⣇⠄⠄⠄⠂⠄⠄⠄⠄⠄⠄⠄⠘⡄⠄⠈⠄⠈⠄⠰⢻⠋⠄⣀⣀⣠⣿⣿⣿⣿⣿⣇⠄⠈⠄⠄⢃⢘⡏⢿⣿⡄
⡿⠄⠄⠄⠄⠄⠄⣿⠈⠣⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢃⠄⠄⠄⠄⠄⠄⠋⠄⠄⢿⣿⣿⣿⣿⣿⡿⠟⠁⠄⠄⠄⠄⠘⣼⡇⠈⢿⣿
⡇⠄⠄⠄⠄⡆⠄⣿⠄⠄⡨⠂⠄⡀⠄⠄⠄⠠⣀⠄⠄⠘⡄⠄⠄⠄⠄⠄⠄⠄⠄⠈⠙⠻⠿⠛⠁⠄⠄⠄⠄⠄⠄⠄⠄⣿⠄⠄⠈⣿
⡇⠄⠄⠄⠄⠄⠄⢸⠄⣐⠊⠄⠄⠄⢉⠶⠶⢂⠈⠙⠒⠂⠠⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠇⠄⠄⠄⠸
⠄⣀⠂⢣⡀⠄⠄⠘⣠⠃⠄⠄⠄⠄⣠⣴⣾⠷⠤⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⡀⡙⠄⠈⢧⠄⠡⡀⢉⠄⠄⠄⠄⣴⣿⡫⣋⣥⣤⣀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⡗⠃⠐⠄⠈⣷⡀⢳⡄⠂⠄⠄⣸⣿⡛⠑⠛⢿⣿⣿⣷⡄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⡇⡀⠂⡀⠄⣸⢱⡈⠇⠐⠄⡠⣿⡟⠁⠄⠄⣸⣿⣿⣿⡟⠄⠄⠄⠄⠈⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⣿⡐⡀⠄⢠⠏⠄⢳⡘⡄⠈⠄⢿⡿⠄⢻⣿⣿⣿⡿⠋⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⣿⣧⠐⢀⡏⠄⠄⠄⢳⡴⡀⠄⢸⣿⡄⠄⠉⠛⠋⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣶⣶⣶⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⣿⣿⣆⠄⠐⡀⠄⠄⠄⢻⣷⡀⠄⠃⠙⠂⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢿⣿⣿⣿⣄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⣿⣿⣿⣆⠄⠙⣄⠄⠄⠄⠱⣕⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠻⣿⣿⣿⣦⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣴
⣿⣿⣿⣿⣧⡀⠘⢦⡀⠄⠄⠈⢢⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠘⠿⣿⣿⣇⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣠⣾⣿
⣿⣿⣿⣿⣿⣷⢄⠈⠻⣆⠄⠄⠄⠑⢄⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⠛⠿⠄⠄⠄⠄⠄⠄⠄⠄⢀⣴⣾⣿⣿⣿
