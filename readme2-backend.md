# Criar Backend 
<br>

Aqui a inteção é criar uma API que será consumida pelo MVC no frontend, e fazer o deploy pelo Kubernetes. 

Serão feitas algumas alterações no projeto inicial frontend. Os requisitos são os mesmos do projeto frontend;

----

# Passo-a-passo
<br>

## Projeto backend
<br>
1. Criar o projeto backend:

        dotnet new webapi -o backend -f net5.0

2. Criar a Solution e acrescentar os projetos frontend e backend:

        dotnet new sln --name Kubernetes
        dotnet sln add .\frontend\
        dotnet sln add .\backend\

3. Deletar os arquivos do Weatherforecast;
4. Criar a entidade PizzaInfo em backend/Models;
5. Criar a controller PizzaInfoController em backend/controllers;
6. Crie o Dockerfile;

----

## Alterações no projeto frontend
<br>

1. Alterar a interface IPizzaService para Async;
2. Alterar a classe concreta PizzaService para consumir a API;
3. Inserir a `backendUrl` no appsettings.json;
4. Configurar o serviço HttpClient no Startup.cs;
5. Atualizar HomeController para `GetPizzasAsync()`;
6. Alterar no launchSettings as Urls para 8000 e 8001;
   
## Docker: Criando as imagens frontend e backend, e enviando ao dockerhub
<br>

    docker build -f .\backend\Dockerfile -t backend .
    docker build -f .\frontend\Dockerfile -t frontend .
    docker login

    docker tag backend <UserName>/pizzabackend
    docker tag frontend <UserName>/pizzafrontend

    docker push <UserName>/pizzabackend
    docker push <UserName>/pizzafrontend
   
**Opcional**

Esta etapa é só para testar os contêiners:

1. Na sequência crie o docker-compose.yml;
2. Execute o comando:

    docker-compose up -d

3. Acesse o projeto frontend consumindo os dados do backend no link:
   http://localhost:5902/Home/GetPizzas

---

## Criar o arquivo de Deployment

Nesta etapa será criado o arquivo de deployment junto ao arquivo de Service;
Verifique o arquivo no projeto.

1. Criar o arquivo backend-deploy.yaml;
2. Aplicar o deploy do backend:

        kubectl apply -f .\backend-deploy.yaml

3. Deletar os arquivos anteriores de frontend-deploy.yaml e frontend-service.yaml;
4. Criar o arquivo frontend.yaml;
5. Aplicar o deploy do frontend:

        kubectl apply -f .\frontend-deploy.yaml

6. Abrir o serviço criado:  

        minikube service pizzafrontend

>Não funcionou... vá para o passo seguinte..
>
>Aparentemente é um problema na última versão do minikube com algum driver do docker;

7. Usar o kubectl port-forward (faz um solicitação específica para a API do Kubernetes e via API Server encapsula uma conexão HTTP com cluster kubernetes. A API Server se torna um gateway temporário entre sua porta local e o cluster Kubernetes.)

        kubectl port-forward service/pizzafrontend 7123:80

Acessar pelo link: http://localhost:7123/