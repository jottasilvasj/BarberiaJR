# BarberiaJR

Aplicação web para apresentação de uma barbearia com landing page pública, autenticação de usuários e persistência em banco de dados MySQL. O repositório reúne uma página estática em HTML/CSS/JavaScript e uma solução ASP.NET Core MVC para a parte administrativa da aplicação.

## Visão geral

O projeto está organizado em dois componentes principais:

1. `index.html` na raiz: página pública de apresentação da barbearia, com serviços, diferenciais, dados de contato e links de WhatsApp/Instagram.
2. `Barbearia/`: aplicação ASP.NET Core MVC responsável por autenticação, rotas web e acesso ao banco de dados.

A solução usa MySQL como banco de dados, EF Core para acesso a dados e cookies para autenticação dos usuários. A estrutura também inclui containerização com Docker e Docker Compose para facilitar o ambiente de desenvolvimento e execução.

## Stack Tecnológica

- C# / ASP.NET Core MVC (`net10.0`)
- Entity Framework Core
- Pomelo.EntityFrameworkCore.MySql
- MySQL 8
- HTML, CSS e JavaScript
- Docker / Docker Compose

## Estrutura do repositório

```text
.
├── index.html                  # Landing page pública da barbearia
├── style/                     # Estilos da página estática (quando aplicáveis)
├── script/                    # Scripts da página estática (quando aplicáveis)
├── Dockerfile                 # Imagem da aplicação ASP.NET Core
├── docker-compose.yml         # Serviços da aplicação e do banco MySQL
├── Barbearia.slnx             # Solução .NET
├── .gitignore
├── README.md
└── Barbearia/
    ├── Barbearia.csproj      # Projeto ASP.NET Core MVC
    ├── Program.cs            # Registro de serviços, autenticação e rotas
    ├── Models/               # Entidades e modelos de domínio
    ├── ViewModels/           # Modelos para páginas e ações
    ├── Views/                # Views Razor do MVC
    ├── Migrations/           # Migrações do EF Core
    ├── Properties/           # Configurações do projeto
    └── wwwroot/              # Arquivos públicos estáticos da aplicação MVC
```

## Requisitos

- .NET SDK 10.0
- MySQL 8 ou Docker Desktop
- Git

## Executando com Docker Compose

O repositório já inclui um arquivo `docker-compose.yml` para subir o banco e a aplicação em containers.

```bash
docker compose up --build
```

A aplicação ficará disponível em:

- http://localhost:8080
- Banco MySQL em localhost:3307

O arquivo de composição já define:

- Serviço `db` com MySQL 8
- Serviço `app` com a API da aplicação ASP.NET Core
- Variável `ConnectionStrings__DefaultConnection` apontando para o banco interno do container

Para encerrar os serviços:

```bash
docker compose down
```

Se quiser remover também os dados persistidos do MySQL:

```bash
docker compose down -v
```

## Executando localmente sem Docker

A partir da raiz do repositório:

```bash
dotnet restore Barbearia.slnx
dotnet build Barbearia.slnx
```

Em seguida, configure a string de conexão do banco antes de iniciar a aplicação:

```bash
export ConnectionStrings__DefaultConnection="Server=localhost;Database=dbarbearia;User=SEU_USUARIO;Password=SUA_SENHA;"
```

Ou, se preferir, use User Secrets no projeto:

```bash
dotnet user-secrets init --project Barbearia/Barbearia.csproj
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=dbarbearia;User=SEU_USUARIO;Password=SUA_SENHA;" --project Barbearia/Barbearia.csproj
```

Depois:

```bash
dotnet run --project Barbearia/Barbearia.csproj
```

A URL local será exibida no terminal do ASP.NET Core.

## Configurações relevantes

- O projeto registra `AddControllersWithViews()` em `Barbearia/Program.cs`.
- A autenticação é feita via cookies com nome `Barbearia.AuthCookie`.
- A rota de login configurada é `/Account/Login`.
- A sessão expira após 8 horas por padrão.
- O aplicativo usa `UseForwardedHeaders()` para funcionar corretamente atrás de proxy ou túnel.
- O limite de tentativas de login é configurado com rate limiting por IP.

## Observações importantes

- A página estática `index.html` e a aplicação MVC são componentes distintos.
- A rota padrão da aplicação MVC é `Home/Index`.
- O `index.html` não é, por si só, a view principal do ASP.NET Core.
- Os links de WhatsApp, Instagram, preços e contatos devem ser revisados antes de publicação em produção.
- As credenciais do banco e demais valores sensíveis devem ser gerenciados por variáveis de ambiente ou secrets em ambientes reais.

## Como contribuir

1. Faça um fork do repositório.
2. Crie uma branch para sua funcionalidade ou correção.
3. Faça as alterações.
4. Valide a aplicação com build ou docker compose.
5. Abra um pull request com descrição clara do que foi alterado.

## Licença

Este projeto não informa uma licença explícita no repositório. Verifique as políticas do projeto antes de reutilizar o código em produção ou em contextos comerciais.
