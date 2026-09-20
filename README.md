# 📦 Minha Primeira API

Uma API REST simples para cadastro de **Produtos**, feita em **.NET 10** com **Entity Framework Core** e banco de dados **SQLite**.

Este projeto foi criado como estudo de desenvolvimento de APIs com .NET, aplicando uma arquitetura em camadas (Controller → Service → Repository).

---

## 🚀 Tecnologias utilizadas

- [.NET 10](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger (documentação interativa da API)

---

## 📁 Estrutura do projeto

```
MinhaPrimeiraApi/
├── Controllers/          # Recebe as requisições HTTP
│   └── Repositories/      # Acesso ao banco de dados
│       └── Services/       # Regras de negócio
├── Models/                # Classes que representam os dados (ex: Produto)
├── Data/                  # Configuração do banco de dados (DbContext)
├── Migrations/            # Histórico de alterações do banco de dados
└── Program.cs              # Ponto de entrada da aplicação
```

A ideia dessa organização é separar responsabilidades:

- **Controller** → recebe a requisição e devolve a resposta.
- **Service** → aplica as regras de negócio (ex: não permitir nomes duplicados).
- **Repository** → conversa com o banco de dados.

---

## ✅ Pré-requisitos

Antes de começar, você precisa ter instalado:

- [.NET SDK 10](https://dotnet.microsoft.com/download)

Para verificar se já está instalado, rode no terminal:

```bash
dotnet --version
```

---

## ▶️ Como executar o projeto

1. Clone o repositório:

   ```bash
   git clone <url-do-repositorio>
   cd MinhaPrimeiraApi
   ```

2. Restaure as dependências:

   ```bash
   dotnet restore
   ```

3. Aplique as migrations (isso cria o banco de dados SQLite `minhaapi.db`):

   ```bash
   dotnet ef database update
   ```

4. Execute a aplicação:

   ```bash
   dotnet run
   ```

5. Abra o navegador no endereço mostrado no terminal e acrescente `/swagger` para testar a API pela interface visual, exemplo:

   ```
   https://localhost:5001/swagger
   ```

> 💡 O Swagger só fica disponível quando o projeto roda em modo de desenvolvimento.

---

## 📚 Endpoints disponíveis

Todos os endpoints começam com `/api/produtos`.

| Método   | Rota                | O que faz                          |
|----------|---------------------|-------------------------------------|
| `GET`    | `/api/produtos`     | Lista todos os produtos             |
| `GET`    | `/api/produtos/{id}`| Busca um produto pelo ID            |
| `POST`   | `/api/produtos`     | Cria um novo produto                |
| `PUT`    | `/api/produtos/{id}`| Atualiza um produto existente       |
| `DELETE` | `/api/produtos/{id}`| Remove um produto                   |

### Exemplo de corpo para criar/atualizar um produto (`POST` / `PUT`)

```json
{
  "nome": "Caneta Azul",
  "preco": 2.50
}
```

### Regras de validação

- `nome` é obrigatório e não pode ter mais de 100 caracteres.
- `nome` não pode se repetir entre produtos já cadastrados.
- `preco` deve estar entre `0.01` e `1000`.

---

## 🌐 CORS

A API já está configurada para aceitar requisições vindas de um front-end Angular rodando em `http://localhost:4200`.

---

## 🧪 Testando a API

Você pode testar as requisições de duas formas:

- Pelo **Swagger** (`/swagger`), direto no navegador.
- Pelo arquivo [MinhaPrimeiraApi.http](MinhaPrimeiraApi.http), usando a extensão **REST Client** do VS Code (ou similar).

---

## 📄 Licença

Projeto de estudo, livre para uso educacional.
