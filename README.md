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
