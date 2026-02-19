# 🚀 Gerenciador de Tarefas - PS-Fatto

Este projeto é uma aplicação web completa para gerenciamento de tarefas (To-Do List), desenvolvida como parte do processo seletivo para a **Fatto Consultoria e Sistemas**. A solução foca em usabilidade, segurança de dados e portabilidade.

## 🛠️ Tecnologias Utilizadas

* **Framework:** ASP.NET Core MVC 8 ( .NET 8 )
* **ORM:** Entity Framework Core
* **Banco de Dados:** SQLite (Portabilidade total, sem necessidade de configuração externa)
* **Frontend:** Razor Pages, Bootstrap 5 e CSS3 Customizado
* **Ícones:** Bootstrap Icons

## ✨ Funcionalidades e Regras de Negócio

A aplicação atende a todos os requisitos propostos, com diferenciais de UX:

1.  **CRUD de Tarefas:** Inclusão, edição, visualização e exclusão de registros.
2.  **Segurança e Validação:**
    * **Nomes Únicos:** O sistema impede o cadastro de tarefas com nomes duplicados.
    * **Validação de Custo:** O campo custo aceita apenas valores numéricos fracionários maiores ou iguais a zero.
    * **Datas:** Validação de datas reais e exibição padronizada no formato `DD/MM/AAAA`.
3.  **Interface Inteligente:**
    * **Destaque Visual:** Tarefas com custo superior ou igual a R$ 1.000,00 recebem destaque visual na listagem.
    * **Somatório Dinâmico:** Exibição do custo total acumulado no rodapé da tabela.
4.  **Sistema de Reordenação:** Botões interativos que permitem subir ou descer a ordem das tarefas, persistindo a nova sequência no banco de dados.

## ⚙️ Como Executar o Projeto

Graças ao uso do **SQLite**, você não precisa configurar um servidor SQL Server ou MySQL. O banco de dados já acompanha a solução.

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/seu-usuario/ps-fatto.git](https://github.com/seu-usuario/ps-fatto.git)
    ```
2.  **Navegue até a pasta do projeto:**
    ```bash
    cd PS-Fatto
    ```
3.  **Restaure as dependências:**
    ```bash
    dotnet restore
    ```
4.  **Execute a aplicação:**
    ```bash
    dotnet run
    ```
5.  **Acesse no navegador:**
    Acesse o endereço `https://localhost:7000` (ou a porta indicada no terminal).

## 📂 Estrutura do Projeto

* `Controllers/`: Lógica de controle, incluindo a lógica de troca de ordem (swap) das tarefas.
* `Models/`: Entidade `Tarefa` com Data Annotations para validação de segurança.
* `Views/`: Interfaces Razor Pages estilizadas para uma experiência moderna.
* `Data/`: Contexto de acesso ao banco de dados via EF Core.

---
Desenvolvido por **[Seu Nome]** para o Processo Seletivo Fatto.
