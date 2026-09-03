# Como rodar o ambiente local

## Pré-requisitos
- Docker Desktop instalado e rodando
- .NET 10 SDK

## Subir o banco de dados

    docker compose up -d

Isso sobe um container PostgreSQL 17 local, na porta 5432.

Dados de conexão:
- Host: localhost
- Porta: 5432
- Usuário: diadez
- Senha: diadez_dev_local
- Banco: diadez

## Parar o banco (mantendo os dados)

    docker compose down

## Parar e apagar os dados (reset completo)

    docker compose down -v