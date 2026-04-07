
FitManager - Gestão de Ginásio 🏋️‍♂️
O FitManager é uma aplicação desktop desenvolvida em C# (Windows Forms) para a gestão eficiente de ginásios, permitindo o controlo de sócios, planos de subscrição, registo de entradas (Check-in) e autenticação de funcionários.

🚀 Como Executar a Aplicação



1. Pré-requisitos
Visual Studio 2022 (com a carga de trabalho ".NET Desktop Development").

.NET SDK (versão 6.0 ou superior).

SQL Server (LocalDB ou Express).

SQL Server Management Studio (SSMS) ou Azure Data Studio.




2. Configuração da Base de Dados 🗄️
A aplicação utiliza o SQL Server. Segue os passos abaixo para preparar o ambiente:

Abre o teu gestor de base de dados (ex: SSMS).

Cria uma nova query e executa o script abaixo para criar as tabelas e os utilizadores iniciais: ARQUIVO ENVIADO A PARTE




3. Configuração do Projeto no Visual Studio
Clona o repositório ou abre a pasta do projeto.

Abre o ficheiro de solução (.sln).

No ficheiro App.config, verifica se a tua ConnectionString aponta corretamente para o teu servidor local:

<add name="ConnectionString" 
     connectionString="Server=localhost\SQLEXPRESS;Database=FitManager;Trusted_Connection=True;TrustServerCertificate=True;" />

Compila a solução (Ctrl + Shift + B).

Prime F5 para iniciar.


Credenciais de Acesso
Podes utilizar qualquer um dos seguintes utilizadores para entrar no sistema:

Utilizador
Palavra-passe

guilherme
123456

joao
123456

bruno
123456

carlos
123456


Tecnologias Utilizadas
Linguagem: C#

Framework: .NET Framework / .NET 6 (WinForms)

Base de Dados: Microsoft SQL Server

Segurança: Hash SHA-256 para armazenamento de passwords.

Arquitetura: Separação por Forms, Modelos e Serviços (Services).