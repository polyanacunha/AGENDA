# Use a imagem base do SQL Server da Microsoft
FROM mcr.microsoft.com/mssql/server:2019-latest

# Configuração das variáveis de ambiente do SQL Server
ENV ACCEPT_EULA=Y
ENV SA_DB=agenda
ENV SA_USER=admin
ENV SA_PASSWORD=admin

# Criar um diretório para scripts SQL personalizados
WORKDIR /usr/src/app

# Copie os scripts SQL personalizados para o contêiner (se necessário)
#COPY ./seus_scripts_sql /usr/src/app/
    
# Expor a porta padrão do SQL Server
EXPOSE 1433

# Comando de inicialização do SQL Server
CMD ["/opt/mssql/bin/sqlservr"]
