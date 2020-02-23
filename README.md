# Teste Dev Full Stack Gol Labs
## Marcio Sarabando

Sobre a GolLabs-APP - Minhas Reservas

<b>Objetivo:</b> APP de Avaliação de Candidato

Esta aplicação web possui uma página única que exibe a listagem de um cadastro de Reservas, exibe os campos: Nome, Data da Partida, Hora da Partida, Origem e Destino. Nela é possível Listar, Filtrar, Incluir, Editar e Remover Reservas.

Tecnologias utilizadas:
.Net Core + Angular + DBSqlite

Instalação e Execução:

API: GolLabs.API/dotnet run
url: http://localhost:5000

APP: Golbas-App/ng serve -o 
url: http://localhost:4200

Nota: O requisito de possuir um fluxo de login/logout não foi possível criar, pois encontrei problemas no uso do Ientity Framework entre a versão do .NET Core do curso e a versão 3 utilizada neste projeto, e não consegui fazer funcionar em tempo hábil, considerando um pouco de inesperiência nesta funcionalidade. Por este motivo, para ser mais breve na entrega e mais acertivo no funcionamento da aplicação, achei por bem deixar esta implementação para outra ocasião, se for o caso.