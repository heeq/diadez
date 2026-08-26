# ADR-001: Escolha da stack tecnológica

## Status
Aceito

## Contexto
Preciso construir um MVP funcional sozinho, em ~3h por dia, 4 dias
por semana, priorizando velocidade de entrega e familiaridade com
tecnologia que uso profissionalmente (.NET/React), mantendo o
projeto demonstrável para processos seletivos.

Arquitetura em camadas com princípios de Clean Architecture: o domínio não depende de infraestrutura, e as dependências fluem sempre em direção ao centro (Domain).

## Decisão

**Back-end:** .NET 10, ASP.NET Core Web API, EF Core, PostgreSQL.
Arquitetura em camadas (Api / Application / Domain / Infrastructure),
sem CQRS/MediatR/Event Sourcing. LTS com suporte até nov/2028, versus .NET 9 (STS, suporte até nov/2026)

**Front-end:** React + TypeScript + Vite + TanStack Query + Tailwind.
PWA desde o início, sem app nativo.

**Infra:** Railway (API + Postgres) · Cloudflare Pages (front) ·
Cloudflare R2 (anexos) · GitHub Actions (CI/CD).

## Alternativas consideradas

- **CQRS + MediatR** — rejeitado: complexidade desnecessária para o
  volume de regras de negócio da v1; risco real de nunca terminar o
  MVP.
- **Next.js (SSR)** — rejeitado: o produto é majoritariamente
  autenticado (dashboard), sem necessidade de SEO nas telas internas;
  SPA é mais simples de hospedar e depurar.
- **Render** — rejeitado para a API: free tier hiberna por
  inatividade, o que prejudica a demo em entrevista.
- **Supabase/Firebase (BaaS)** — rejeitado: o objetivo do projeto é
  demonstrar competência em .NET, não terceirizar a camada de
  domínio.

## Consequências

- Fica fácil justificar cada escolha em entrevista técnica.
- Abre mão de features prontas (auth gerenciado, realtime) em troca
  de controle total do domínio.
- Multi-tenancy, jobs recorrentes e autenticação precisam ser
  implementados manualmente (ver ADR-002 e seguintes).
