
# Projeto Sinistro .NET

 <img src="https://img.shields.io/badge/status-desenvolvimento-green?style=for-the-badge">

 ## Tecnologias
<div>
  <img src="https://img.shields.io/badge/.Net-orange?style=flat&logo=.net&logoColor-black">
  
  
</div>

## 1. Nome da Aplicação

Projeto Sinistro

## 2. Nome completo dos integrantes

* Jhemysson Moura Vieira (RM552570) - reponsavel por .Net, IOT e Cloud;
* Robson Apparecido dos Santos (RM 552858) - responsavel por  Database e Mobile; 
* Talyta Botelho Perrotti (RM553739)- responsável por Java Advanced, QA e .Net;

## 3. Instruções

Em "app.settings.json" é necessário inserir o usuário (User id) e senha (Password) oracle em "OracleConnection"  para o funcionamento completo. 
Exemplo: 
"ConnectionStrings": {
  "OracleConnection": "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=rm123456;Password=123456;"
}

![Image](https://github.com/user-attachments/assets/41f7068d-a770-4b79-abf4-5ac7fad2423e)

Cadastro de Pacientes

- Get: 
/Paciente/List:

![Image](https://github.com/user-attachments/assets/cb4b1902-eb01-4808-8fb2-48b184c21a8b)
 
![Image](https://github.com/user-attachments/assets/1b11ea77-bdd3-4b54-8516-91feb65c734c)

- Post: 
/Paciente/Add:
{
 "pacienteId": 1,
 "nome": "Thiago Keller",
 "email": "thiagokeller@hotmail.com",
 "dataNascimento": "2025-03-20"
}

![Image](https://github.com/user-attachments/assets/e7fbf811-9238-49a2-a4b8-6cc18f9709e2)

![Image](https://github.com/user-attachments/assets/92b101b7-9097-4d57-8ef7-38041e09d5bd)

![Image](https://github.com/user-attachments/assets/bca727f4-4462-4b9b-979b-3cbb4c7b8553)
 
- Put: 
/Paciente/Update: 

{
 "pacienteId": 1,
 "nome": "Thiago Keller",
 "email": "thiago@hotmail.com",
 "dataNascimento": "2025-03-20"
}

![Image](https://github.com/user-attachments/assets/f9d13126-6be5-4f44-8276-925b8d25af16)

![Image](https://github.com/user-attachments/assets/5c31b7f1-f98e-4ae4-9643-5a4cf78f6d6e)

![Image](https://github.com/user-attachments/assets/61359eb8-1ee2-479e-a5e3-6841c71af11f)

- Delete:
/Paciente/Delete: 

id: 1

![Image](https://github.com/user-attachments/assets/0e9577bd-b171-4d9f-8777-ea034ae2673a)

![Image](https://github.com/user-attachments/assets/d996fd2f-8f5c-4323-a9cb-e470a259c0df)

![Image](https://github.com/user-attachments/assets/8f87283a-483f-458d-8a06-eb04a0110255)
 
Identificador de Doenças:
{
 "sintomas": [
   "dor de dente"
  ]
}

![Image](https://github.com/user-attachments/assets/76ea193f-787b-4879-bb40-5ea46d224f03)

![Image](https://github.com/user-attachments/assets/006e7a5c-38a0-4feb-98ad-eee7b930b4d4)

![Image](https://github.com/user-attachments/assets/73ba81a7-7045-4caf-a9fc-c12e93027298)

## 4. Arquitetura Monolítica

A estrutura foi implementada devido aos pontos:

- Desenvolvimento eficiente:
  - Implementação inicial rápida e direta
  - Base de código única que facilita o entendimento geral
  - Integração simplificada dos componentes


- Manutenção simplificada:
  - Testes mais simples de executar
  - Padronização natural dos padrões de código


- Performance otimizada:
  - Comunicação mais rápida entre componentes
  - Menor latência nas operações

## 5. Detalhes de Implementação

### 5.1. Testes Implementados
O projeto inclui uma suíte de testes unitários e de integração para garantir a robustez e a confiabilidade da API. Os testes foram implementados utilizando o framework xUnit em conjunto com Moq para simulação de dependências. A cobertura de testes abrange as principais funcionalidades do sistema, com foco nos endpoints de cadastro de pacientes e identificação de doenças.

- Testes Unitários:
  - Validação dos métodos do controlador PacienteController para os endpoints GET, POST, PUT e DELETE;
  - Testes de regras de negócio, como validação de e-mails únicos e formato correto de datas de nascimento;
  - Simulação de repositórios utilizando Moq para isolar a camada de acesso a dados;
  - Exemplo: Teste do método AddPaciente verifica se um paciente é adicionado corretamente e retorna o status HTTP 201;

- Testes de Integração:
  - Testes dos fluxos completos dos endpoints da API utilizando um banco de dados Oracle em memória (via TestContainers);
  - Verificação de cenários reais, como a persistência de dados no banco e a recuperação de listas de pacientes;
  - Testes de falha, como tentativas de atualização de pacientes inexistentes, garantindo respostas HTTP apropriadas (ex.: 404 Not Found);

- Cobertura de Testes:
  - A cobertura atual é de aproximadamente 85%, com planos de expansão para os módulos de identificação de doenças;
  - Relatórios de cobertura são gerados utilizando Coverlet e integrados ao pipeline de CI/CD;

### 5.2. Práticas de Clean Code Aplicadas
O desenvolvimento do projeto seguiu princípios de Clean Code para garantir um código legível, manutenível e escalável. As principais práticas aplicadas incluem:

- Nomenclatura Clara:
  - Uso de nomes descritivos para variáveis, métodos e classes (ex.: PacienteRepository em vez de Repo);
  - Convenções consistentes, como PascalCase para métodos e propriedades públicas;
  
- Responsabilidade Única (SRP):
  - Cada classe e método possui uma única responsabilidade. Por exemplo, a classe PacienteService gerencia a lógica de negócio, enquanto PacienteRepository lida apenas com acesso a dados;
   
- Refatoração Contínua:
  - Métodos longos foram divididos em funções menores e mais específicas (ex.: validação de dados separada em métodos auxiliares);
  - Eliminação de código duplicado por meio de abstrações reutilizáveis, como métodos genéricos para validação;

- Tratamento de Exceções:
  - Uso de exceções personalizadas (ex.: PacienteNotFoundException) para erros específicos;
  - Respostas HTTP consistentes para erros, com mensagens claras para o consumidor da API;

- Documentação:
  - Uso de XML Comments para documentar métodos e classes públicas;
  - Swagger configurado para gerar documentação interativa da API, facilitando o uso por outros desenvolvedores;

- Injeção de Dependência:
  - Configuração de DI nativa do .NET para promover baixo acoplamento entre camadas (ex.: injeção de IPacienteRepository no PacienteController);

### 5.3. Funcionalidade de IA Generativa Adicionadas
O projeto incorpora funcionalidades de IA generativa para aprimorar a identificação de doenças com base em sintomas fornecidos pelos usuários. As principais funcionalidades incluem:

- Identificador de Doenças Baseado em IA:
  - Integração com um modelo de IA generativa treinado para correlacionar sintomas com possíveis diagnósticos;
  - O endpoint /Doenca/Identificar recebe uma lista de sintomas (ex.: ["dor de dente"]) e retorna uma lista de possíveis condições médicas com probabilidades associadas;
  - Exemplo de resposta:
 ```
    {
  "doencas": [
    { "nome": "Cárie Dentária", "probabilidade": 0.85 },
    { "nome": "Gengivite", "probabilidade": 0.10 }
  ]
}
```

- Processamento de Linguagem Natural (NLP):
  - O modelo de IA utiliza NLP para interpretar sintomas descritos em linguagem natural, permitindo maior flexibilidade na entrada de dados (ex.: "dor forte no dente" é normalizado para "dor de dente");
  - Pré-processamento dos sintomas para remover ruídos e padronizar termos médicos;

- Integração com Banco de Dados:
  - Os resultados gerados pela IA são armazenados no banco Oracle para auditoria e análise posterior, incluindo os sintomas fornecidos e os diagnósticos sugeridos;
  - A tabela DiagnosticoIA registra o histórico de identificações, com campos como Sintomas, DoencaSugerida e Probabilidade;

- Validação e Segurança:
  - Validação rigorosa dos dados de entrada para evitar injeções maliciosas ou entradas inválidas;
  - Limitação de taxa (rate limiting) no endpoint de IA para prevenir abuso;




