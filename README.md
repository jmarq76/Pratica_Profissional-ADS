# Emprega MAIS

### Requisitos

[.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

[.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework)

[NodeJS 18.12.1](https://nodejs.org/en/)

[PostgreSQL 15](https://www.postgresql.org/download/)

### Build and Run

Clonar o projeto [EmpregaMais](https://github.com/jmarq76/Pratica_Profissional-ADS) do GitHub

Iniciar o PostgreSQL.

Criar o usário do PostgreSQL através do seguinte SQL:

```
-- Role: "EmpregaMaisDb"
-- DROP ROLE IF EXISTS "EmpregaMaisDb";

CREATE ROLE "EmpregaMaisDb" WITH
  LOGIN
  NOSUPERUSER
  INHERIT
  NOCREATEDB
  NOCREATEROLE
  NOREPLICATION
  ENCRYPTED PASSWORD 'SCRAM-SHA-256$4096:Ztpejb5TT9dDtlqUkgtmag==$AcOp311FsEPtOfggMb4nPVxeDgy8xoiw0ZrpRY+e4vw=:QlUpwd/PtETe2emAbVSObdYG5rOaWLNbTsX+t0ewPKY='; 
```

Criar o banco de dados:

```
-- Database: EmpregaMaisDb

-- DROP DATABASE IF EXISTS "EmpregaMaisDb";

CREATE DATABASE "EmpregaMaisDb"
    WITH
    OWNER = "EmpregaMaisDb"
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
```

Rodar o SQL que se encontra dentro da pasta Pratica_Profissional-ADS\EmpregaMais-API: [CriarBaseDados.sql](https://github.com/jmarq76/Pratica_Profissional-ADS/blob/master/EmpregaMais-API/CriarBaseDados.sql)

Dentro da pasta 
Pratica_Profissional-ADS\EmpregaMais-API\EmpregaMais-API executar na linha de comandos o seguinte comando  `dotnet run` para incializar o servidor.

Na pasta Pratica_Profissional-ADS/Web/empregamais-website executar na linha de comandos o seguinte comando `npm start` para incializar o cliente.
