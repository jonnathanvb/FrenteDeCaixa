# Frente De Caixa

> Este projeto é uma API para fins educacional.

# Requesito
- Dotnet Core 8 >
- SqlSever
    - O aquivos de script está localizado no diretorio ./infra/script
        - Database.sql (arquivo das tabela do banco)
        - StartProduto.sql (insert inicial na tabela de produtos)


OBS: Na pasta raiz tem um arquivo microsoft-sqlserver.yml caso queira subir um container de sqlserver local.
Se caso tiver em uma maquina Windows atualize o local do diretorio fisico dos arquivos do banco.

Exemplo
```
 volumes:
      - CaminhoDaPastaDaSuaMaquina:/var/opt/mssql
```

Se caso tiver seu proprio banco não esqueça de trocar a ConnectionString no appsetting.json