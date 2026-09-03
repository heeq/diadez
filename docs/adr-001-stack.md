# ADR-001: Escolha da stack tecnológica

## Status
Aceito

## Contexto
Preciso construir um MVP funcional sozinho, em ~3h por dia, 4 dias
por semana, priorizando velocidade de entrega e familiaridade com
tecnologia que uso profissionalmente (.NET/React), mantendo o
projeto demonstrável para processos seletivos.

## Decisão

**Back-end:** .NET 10, ASP.NET Core Web API (controllers), EF Core,
PostgreSQL. Arquitetura em camadas com princípios de Clean
Architecture: Domain no centro, sem dependências externas;
Application orquestra casos de uso sobre o Domain; Infrastructure
implementa as interfaces definidas pelo Domain/Application (acesso a
banco, e-mail, etc.); Api expõe tudo via HTTP. As dependências
sempre apontam para dentro (Api → Application → Domain,
Infrastructure → Domain e Application). Sem CQRS, MediatR ou Event
Sourcing.

**Front-end:** React + TypeScript + Vite + TanStack Query + Tailwind.
PWA desde o início, sem app nativo.

**Infra:** Railway (API + Postgres) · Cloudflare Pages (front) ·
Cloudflare R2 (anexos) · GitHub Actions (CI/CD).

## Alternativas consideradas

- **.NET 9** — rejeitado: é release STS (Standard Term Support), com
  suporte até novembro de 2026. O .NET 10, lançado em novembro de
  2025, é LTS (Long-Term Support) com suporte até novembro de 2028 —
  mais alinhado à duração do projeto.
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
- **Herança de Contrato por tipo de ativo (ContratoImovel,
  ContratoVeiculo)** — rejeitado em favor do padrão Strategy para
  regras variáveis (ex: reajuste por IPCA vs. quilometragem), evitando
  explosão de subclasses conforme novos eixos de variação aparecerem.

## Consequências

- Fica fácil justificar cada escolha em entrevista técnica.
- Abre mão de features prontas (auth gerenciado, realtime) em troca
  de controle total do domínio.
- Multi-tenancy, jobs recorrentes e autenticação precisam ser
  implementados manualmente (ver ADR-002 e seguintes).
- Domain modelado como "rico" (regras de negócio nas próprias
  entidades), não anêmico — decisão registrada aqui porque orienta
  todo o desenho das próximas fases.