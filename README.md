# diadez

Plataforma web para proprietários que administram de 1 a 10 imóveis
próprios controlarem contratos de locação, cobranças mensais e
inadimplência — sem depender de imobiliária.

## O problema

Quem aluga poucos imóveis por conta própria hoje usa planilha e
WhatsApp. Sistemas de imobiliária são caros e complexos demais para
esse volume; apps voltados a inquilino final não resolvem o controle
financeiro do proprietário.

## Escopo da v1

- Cadastro de imóveis, inquilinos e contratos
- Geração automática das cobranças do mês
- Baixa de pagamento, multa e juros por atraso
- Dashboard de inadimplência
- Lembretes de vencimento por e-mail e push
- Portal de consulta para o inquilino

Fora do escopo por ora: veículos, assinatura eletrônica de contrato,
split de pagamento, integração com órgãos de crédito.

## Stack

.NET 10 (API) · PostgreSQL · React + TypeScript (front) · ver
[ADR-001](docs/adr-001-stack.md) para as decisões e justificativas.

## Status

🚧 Em desenvolvimento ativo.

## Licença

MIT
