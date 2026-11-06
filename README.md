# BarberiaJR

Aplicação web para apresentar os serviços de uma barbearia e facilitar o contato e o agendamento. O repositório contém uma aplicação ASP.NET Core MVC e uma página HTML estática na raiz.

## Tecnologias

- C# e ASP.NET Core MVC (`net10.0`)
- Entity Framework Core com provedor MySQL (Pomelo)
- Autenticação por cookies do ASP.NET Core
- HTML, CSS e JavaScript para a página estática

## Requisitos

- .NET SDK 10.0
- Uma instância MySQL acessível pela aplicação

## Executar a aplicação ASP.NET Core

No terminal, a partir da raiz do repositório:

```bash
dotnet restore Barbearia.slnx
dotnet run --project Barbearia/Barbearia.csproj
```

A URL local será exibida no terminal. Para compilar sem iniciar o servidor:

```bash
dotnet build Barbearia.slnx
```

A aplicação MVC usa a rota padrão `Home/Index`. Antes de executá-la, configure a conexão MySQL com a chave `ConnectionStrings:DefaultConnection`, por exemplo por meio de User Secrets ou de variáveis de ambiente. Não armazene senhas ou outras credenciais no repositório.

Exemplo de variável de ambiente (substitua os valores pelos da sua instalação):

```bash
ConnectionStrings__DefaultConnection="Server=localhost;Database=barbearia;User=SEU_USUARIO;Password=SUA_SENHA;"
```

O projeto configura o Entity Framework Core para detectar a versão do servidor MySQL automaticamente. A inicialização também registra o `AppDbContext` do namespace `Barbearia.Data`; mantenha essa implementação disponível e alinhada com a configuração do banco.

## Página HTML estática

O arquivo `index.html` na raiz é uma página independente em português com apresentação, destaques, serviços e links de contato/agendamento. Ela referencia arquivos em `style/`, `script/` e `assets/`. Para visualizar essa versão, abra `index.html` no navegador ou publique a página junto com esses recursos.

Os links do WhatsApp e do Instagram, assim como preços e dados de contato, devem ser revisados e substituídos pelos dados reais antes da publicação.

## Estrutura principal

```text
.
├── index.html                 # Página estática de apresentação
├── Barbearia.slnx              # Solução .NET
└── Barbearia/
    ├── Barbearia.csproj        # Configuração do projeto e dependências
    ├── Program.cs              # Registro de serviços e pipeline HTTP
    ├── Models/                 # Modelos da aplicação
    ├── ViewModels/             # Modelos para as views
    ├── Views/                  # Views Razor, incluindo Home/Index
    └── wwwroot/                # Arquivos estáticos da aplicação MVC
```

## Configurações relevantes

- O ASP.NET Core MVC é registrado em `Barbearia/Program.cs`.
- A autenticação usa cookies, com caminho de login `/Account/Login` e validade de oito horas.
- O acesso ao banco depende da configuração `DefaultConnection` e do `AppDbContext`.
- Arquivos públicos da aplicação MVC devem ficar em `Barbearia/wwwroot/`.

## Observação

A página estática da raiz e a aplicação ASP.NET Core são componentes distintos no repositório. A rota inicial da aplicação MVC é `Home/Index`; o `index.html` não é, por si só, a view MVC.
