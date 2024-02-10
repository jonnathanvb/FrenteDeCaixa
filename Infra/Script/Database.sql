CREATE TABLE [Produto]
(
    [Id]         INT            NOT NULL IDENTITY,
    [Nome]       NVARCHAR(MAX)  NOT NULL,
    [Descricao]  NVARCHAR(MAX)  NULL,
    [SaldoAtual] DECIMAL(18, 4) NULL,
    [Preco]      DECIMAL(18, 2) NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Id])
);

CREATE TABLE [Pedido]
(
    Id    INT  NOT NULL IDENTITY,
    Nome  NVARCHAR(MAX)  NULL,
);

CREATE TABLE [Item]
(
    [Id]            INT            NOT NULL IDENTITY,
    [PedidoId]      INT            NOT NULL,
    [ProdutoId]     INT            NOT NULL,
    [Quantidade]    DECIMAL(18, 4) NULL,
    [PrecoUnitario] DECIMAL(18, 2) NULL,
);