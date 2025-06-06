Checkpoint6NET
API desenvolvida em .NET 8, focada no gerenciamento de barcos. O projeto demonstra a arquitetura em camadas (API, Application), boas práticas com DTOs, services e controllers. Foi desenvolvido como exercício acadêmico.

Sobre o projeto
O Checkpoint6NET oferece endpoints para cadastrar, listar, editar e excluir barcos. Utiliza a separação entre camada de apresentação (API), aplicação (Application) e objetos de transferência de dados (DTOs), tornando o projeto organizado e didático.

Funcionalidades
Cadastro de barcos

Listagem de barcos

Atualização de informações de barcos

Exclusão de barcos

Estrutura pronta para expandir com outras entidades

Tecnologias Utilizadas
.NET 8

ASP.NET Core Web API

Camada de Application (Services e DTOs)

C#

REST

Estrutura do Projeto
Checkpoint6NET/
├── CP3.API.sln
├── CP3.API/
│ ├── Controllers/
│ │ └── BarcoController.cs
│ ├── Program.cs
│ └── appsettings.json
├── CP3.Application/
│ ├── Dtos/
│ │ └── BarcoDto.cs
│ └── Services/
│ └── BarcoApplicationService.cs

CP3.API/: camada da Web API e configuração

Controllers/: endpoints da aplicação

CP3.Application/: camada de lógica de negócio e DTOs

Como rodar o projeto localmente
Clone o repositório
git clone https://github.com/seuusuario/Checkpoint6NET.git
cd Checkpoint6NET

Abra a solução no Visual Studio ou rode pelo terminal:

Restaure os pacotes
dotnet restore

Execute a aplicação
dotnet run --project CP3.API

Acesse os endpoints via Postman ou navegador em http://localhost:5000 (ou a porta informada no console)

Obs.: Configure o appsettings.json conforme seu ambiente de banco de dados, se necessário.

Autor
Vinicius Becker
Projeto desenvolvido para fins acadêmicos.
