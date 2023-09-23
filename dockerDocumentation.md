## Como subir um banco com docker? 
1. Instale o docker.

2. crie um dockerfile com as configurações do banco.
3. crie a imagem com o comando a seguir:
 docker build -t nomedaimagem -f Dockerfile . 
obs: Para efetuar o passo 3 você deve estar na pasta que o seu Dockerfile está.
4. crie o seu contêiner a partir da imagem com o comando a seguir : 
sudo docker run -p 1433:1433 nomedaimagem
obs: "1433:1433" são as portas externa e interna.  

## Para fazer login no DBeaver:
- Use o username, a password e o database name configurados no Dockerfile.
- Você não pode definir o username como "admin".
- caso você não defina o username ele, provavelmente, será "sa".

## para subir um contêiner de um banco SQLServer direto, sem precisar criar uma imagem com o Dockerfile:
use o comando a seguir: docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=<YourStrong!Passw0rd>' -p 1433:1433 -v sqlvolume:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest

