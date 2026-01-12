<div align="center">
     <img src="./readmeIcon.png" width="230px" />
</div>

</br>
</br>

<p align="center">
  <a href="#visão-geral">Visão Geral</a> •
  <a href="#funcionalidades">Funcionalidades</a> •
  <a href="#instalação">Instalação</a> •   
  <a href="#arquitetura">Recursos</a> • 
  <a href="#contato">Contato</a> •   
  <a href="#licença">Licença</a>

</p>

## Visão Geral

O MiniBlog é um projeto que permite criar, listar e gerenciar posts e comentários em uma plataforma própria. Seu objetivo principal é fornecer uma API e uma estrutura organizada para o gerenciamento de publicações e interações, utilizando boas práticas de arquitetura e padrões modernos do .NET.

## Funcionalidades

- Conexão com banco de dados SQL Server
- CRUD de Posts (criação, listagem, consulta por ID)
- CRUD de Comentários associados a Posts
- Persistência de dados com Entity Framework Core
- DTOs para controle de entrada e saída de dados
- Validações de dados nos endpoints (ModelState)
- Tratamento centralizado de erros com ApiResponse<T> garantindo consistência nas respostas da API.
- Uso de Repository Pattern + Manager para separar lógica de negócio da persistência.

## 🛠 Tecnologias nececssárias

- .NET 8 ([Documentação](https://learn.microsoft.com/dotnet/core/dotnet-eight))
- Entity Framework Core ([Documentação](https://learn.microsoft.com/ef/core/))
- SQL Server 2019+
- C#
- Docker ([Documentação](https://www.docker.com/))

## Instalação

Antes de rodar o projeto, é necessário ter instalado em sua máquina:

- [Git](https://git-scm.com/)
- Visualizador de Banco de Dados (Utilizei o Microsoft SQL Server Management Studio)
- Um IDE de sua preferência (Windows: Recomendo o Visual Studio 2022; Linux: Recomendo o JetBrains Rider)

### 📦 Clonando repositório

```bash
$ git clone git@github.com:yagopeixinho/MiniBlog.git

cd MiniBlog
```

### Banco de Dados

O MiniBlog utiliza SQL Server como banco de dados principal. Para configurar corretamente:

#### Configuração no arquivo appsettings.json:

Insira as informações corretas de conexão no arquivo _appsettings.json_ do seu projeto:

```C#
{
  "ConnectionStrings": {
    "MBConnection": "Server=localhost,1433;Database=MiniBlogDb;User Id=sa;Password=SenhaForte@123;TrustServerCertificate=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

- Substitua `localhost, MiniBlogDb, sa` e `SenhaForte@123` pelos valores adequados do seu ambiente.

### Criação do Banco de Dados

Certifique-se de que o banco de dados já existe no SQL Server antes de prosseguir.

#### Aplicação das Migrações

Para aplicar as migrações necessárias ao banco de dados, siga os passos abaixo:

Estando na raiz do projeto, rode:
```bash
cd MiniBlog

dotnet ef database update --project MB.Data --startup-project MB.Api
```

Caso ocorram problemas, uma solução comum é recriar as migrações com:

```bash
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
```

> Se ocorrerem problemas durante o processo de migração, uma solução comum é excluir a pasta _Migrations_ e recriar as migrações novamente.

Após seguir esses passos, seu ambiente estará configurado e pronto.

## Como rodar o projeto?

O projeto inclui um arquivo `docker-compose.yml`. Ao executá-lo, **serão iniciados tanto a API quanto a base de dados SQL Server**, garantindo que o ambiente esteja pronto para uso imediatamente.

Para rodar, utilize o comando:

```bash
docker-compose up
```
Ou, se estiver usando o Visual Studio, você pode selecionar o arquivo docker-compose e executá-lo diretamente pela IDE.

## Arquitetura

Durante a tomada de decisões importantes para o desenvolvimento deste projeto, optei por adotar a conhecida e robusta arquitetura em camadas, amplamente reconhecida por sua capacidade de separar claramente as responsabilidades dentro de uma aplicação.
Essa escolha estratégica não apenas facilita a manutenção do código, mas também promove uma melhor organização das funcionalidades e
uma escalabilidade mais eficiente.

### Divisão em Camadas

> O MiniBlog foi desenvolvido seguindo arquitetura em camadas para manter código organizado e modular.

**MB.Core**: Contém as entidades e a lógica de negócio. Define modelos como BlogPost e Comment e interfaces dos serviços.

**MB.Infrastructure**: Responsável pela persistência de dados. Contém os repositórios que interagem com o banco e implementações de acesso a dados.

**MB.Manager**: Implementa a lógica de negócios, validando regras, transformando dados e chamando os repositórios.

**MB.Api**: Camada de apresentação. Inclui controllers que expõem os endpoints da API e conectam os managers aos DTOs e à resposta da API.

### Benefícios da Abordagem:

**Separação de Responsabilidades:** Cada camada tem um propósito bem definido, facilitando o entendimento e a manutenção do código ao longo do ciclo de vida do projeto.

**Escalabilidade:** A estrutura modular permite que novas funcionalidades sejam adicionadas ou modificadas com relativa facilidade, sem impactar outras partes do sistema.

**Testabilidade:** A separação clara entre as camadas facilita a escrita de testes automatizados, garantindo a qualidade e confiabilidade do software desenvolvido.

**Padrões de Design:** O uso de padrões como injeção de dependência, interfaces e camadas bem definidas promove boas práticas de desenvolvimento, resultando em um código mais limpo e organizado.

### Exemplos de endpoints:

- `GET /api/blogpost` → Lista todos os posts
- `GET /api/blogpost/{id}` → Consulta post por ID
- `POST /api/blogpost` → Cria um novo post
- `POST /api/blogpost/{id}/comments` → Cria comentário para um post

## Próximos Passos

Caso eu tivesse mais tempo, estas seriam algumas melhorias e evoluções planejadas para o MiniBlog:

- Implementar **autenticação e autorização** (JWT ou IdentityServer) para controlar acesso aos endpoints
- Criar **testes unitários e de integração** para controllers, managers e repositórios
- Implementar **DTOs de atualização (PUT/PATCH)** para posts e comentários
- Adicionar **paginação e filtros** nos endpoints de listagem de posts e comentários
- Melhorar **tratamento de erros** com `ProblemDetails` e logs centralizados
- Criar **Front-end simples** em Razor ou React para consumir a API
- Criar **CI/CD** para build, testes e deploy automáticos

Esses passos demonstram capacidade de planejar, escalar e manter o projeto de forma profissional.

## Contato

- 📬 Me envie um e-mail: peixinhoyago@gmail.com
- Se você tem alguma dúvida ou quer entrar em contato comigo por qualquer outro motivo, você pode encontrar minhas redes sociais e mais informação sobre mim [clicando aqui](https://github.com/yagopeixinho/yagopeixinho/blob/master/README.md)

## Licença

Esse projeto não possui nenhuma licença.

