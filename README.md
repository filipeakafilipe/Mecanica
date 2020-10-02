# 
## → Aplicativo de Gerenciamento de Mecanica

<p align="center">
  <img src="https://cdns.iconmonstr.com/wp-content/assets/preview/2016/240/iconmonstr-car-3.png">
</p>

## Objetivo
```
Agilizar  processos rotineiros em uma oficina mecânica.
```
## Versão Atual
```
1.0
```
## Funcionalidades
```

→ Cadastrar perfil
→ Cadastrar veículo
→ Cadastrar tipo de serviço
→ Cadastrar pedido
→ Visualizar perfis
→ Visualizar veículos
→ Visualizar tipos de serviço
→ Visualizar pedidos
→ Alterar perfis
→ Alterar veículos
→ Alterar tipos de serviço
→ Alterar pedidos
```

## Como rodar

- Alterar connection string em Mecanica.Modelos.Contexto
- Selecionar como projeto padrão Mecanica.Modelos
- Abrir console do NuGet, selecionar projeto padrão Mecanica.Modelos
- Utilizar o comando update-database
- Alterar Base.Uri em App.Services.Base para sua API (caso esteja utilizando um celular Android utilizar o Conveyor - https://keyoti.com/products/conveyor/index.html)
- Selecionar como projetos de inicialização Mecanica.Api e Api.Android
