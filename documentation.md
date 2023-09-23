### git
go to the AGENDA folder and init remote repository: git init 
create new branch: git branch name of branch
go to the new branch: git checkout name of branch
see your changes: git status
add your changes: git add .
commit your changes: git commit -m "commit message"
send your changes to the repository: git push -u origin branch name

## Rodar as migrations
1. instalar o entity framework com o comando " dotnet ef migrations add <nomeDaMigration>"
2. Comando para criar uma nova migration = "dotnet ef migrations add <nomeDaMigration>" 
3. Comando para aplicar a migration ao seu banco de dados "dotnet ef database update"

## O que eu preciso para executar as migrations sem erros?
 1. No arquivo appsettings.json deve-se atribuir a string de conexão
2. Informar o provedor de banco de dados no método AddInfraestructure(). (UseSQLServer, por exemplo.)
3. Para criar as tabelas é preciso do arquivo de contexto, que é o nosso arquivo "ApplicationContext" que está na camada Data, porque é nesse arquivo que temos o mapeamento ORM (DbSet).

## ferramentas para gerenciar os dados 
1. SQL Server Management Studio
2. DBeaver
3. Azure 
4. Server Explorer no Visual Studio 2022

## Possível erro :
verificar o método AddInfraestructure no arquivo program.cs
