# ProductClient

ProductClient é uma API simples para gerenciar clientes e produtos. Ela permite cadastrar, listar, atualizar e deletar clientes e produtos, além de vincular produtos a clientes.

## Funcionalidades

- **Clientes**:
  - Cadastrar cliente
  - Listar clientes
  - Atualizar cliente
  - Deletar cliente
  - Buscar cliente por ID

- **Produtos**:
  - Cadastrar produto
  - Listar produtos
  - Atualizar produto
  - Deletar produto
  - Buscar produto por ID

- **ClientProducts**:
  - Listar produtos por cliente
  - Inserir produtos para um cliente
  - Devolver produtos de um cliente

## Executando a API

### Pré-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server)

### Configuração

1. Clone o repositório:

    ```sh
    git clone https://github.com/seu-usuario/ProductClient.git
    cd ProductClient
    ```

2. Configure a string de conexão com o banco de dados no arquivo `appsettings.Development.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=seu-servidor;Database=ProductClientDB;User Id=seu-usuario;Password=sua-senha;"
      }
    }
    ```

### Buildando e executando a API

1. Restaure as dependências:

    ```sh
    dotnet restore
    ```

2. Execute as migrações do banco de dados:

    ```sh
    dotnet ef migrations ADD "nome" - CRIANDO MIGRATION 
    dotnet ef database update --project ProductClient.API
    ```

3. Inicie a aplicação:

    ```sh
    dotnet run --project ProductClient.API
    ```

A API estará disponível em alguma porta livre de sua maquina, ex: `https://localhost:5001`.

## Endpoints

- **Clientes**:
  - `GET /api/clients/ListarClientes`
  - `GET /api/clients/ListarClientePorId/{Id}`
  - `POST /api/clients/CadastrarCliente`
  - `PATCH /api/clients/AtualizarCliente/{Id}`
  - `DELETE /api/clients/DeletarCliente/{Id}`

- **Produtos**:
  - `GET /api/products/ListarProdutos`
  - `GET /api/products/ListarProdutoPorId/{Id}`
  - `POST /api/products/CadastrarProduto`
  - `DELETE /api/products/DeletarProduto/{Id}`

- **ClientProducts**:
  - `GET /api/clientproducts/ListarProdutosPorCliente/{ClienteId}`
  - `POST /api/clientproducts/InserirClienteProdutos`
  - `PATCH /api/clientproducts/DevolverProdutos/{Id}`

## Licença

Este projeto está licenciado sob a MIT License.
