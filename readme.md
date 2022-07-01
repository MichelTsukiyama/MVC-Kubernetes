# Projeto MVC usando Kubernetes
<br>

Projeto MVC simples para fazer deploy de uma aplicação MVC no cluster Kubernetes com mikube.

Requisitos:

- .Net sdk 5.0;
- docker for windows;
- Kubectl;
- Minikube;

-----

# Passo-a-passo do projeto

1. Criar projeto:

        dotnet new mvc -o frontend -f net5.0

2. Criar Model PizzaInfo;
3. Criar Services IPizzaService, PizzaService;
4. Adicionar o serviço `addScoped<IPizzaService, PizzaService>();` no ConfigureServices(), na classe Startup.cs;
5. Injetar o IPizzaService na HomeController em Controllers;
6. Criar o método GetPizzas na HomeController;
7. Alterar o _Layout.cshtml nas Views, removendo o Privacy e colocando o GetPizzas no lugar;
8. Criar a view GetPizzas em Views/home, inserir a tabela com as pizzas;
9. Criar o Dockerfile, gerar a imagem, testar o container, "tagear" a imagem e dar push para o docker hub:

        docker build -f .\frontend\Dockerfile -t pizzafrontend .
        docker container run -d -p 8080:80 --name testemvc pizzafrontend
        docker login 
        docker tag pizzafrontend <UserName>/pizzafrontend
        docker push <UserName>/pizzafrontend

10. Criar o arquivo de deploy(Kubernetes), frontend-deploy.yaml
11. Executar arquivo de Deploy, verificar o Pod e sua descrição:
    
        kubectl apply -f frontend-deploy.yaml
        kubectl get all
        kubectl describe deploy pizzafrontend

12. Criar o frontend-service.yaml (Serviço do kubernetes);
13. Executar o arquivo frontend-service.yaml:

        kubectl apply -f frontend-service.yaml

14. Abrir o serviço criado:

        minikube service pizzafrontend

>Não funcionou... vá para o passo seguinte..

15. Usar o kubectl port-forward (faz um solicitação específica para a API do Kubernetes e via API Server encapsula uma conexão HTTP com cluster kubernetes. A API Server se torna um gateway temporário entre sua porta local e o cluster Kubernetes.)

        kubectl port-forward service/pizzafrontend 7080:8080

16. Link para acessar a aplicação: http://localhost:7080
<<<<<<< HEAD

----

# Branch backend

Na branch backend há alterações no projeto criando uma API, e esta será consumida pelo frontend (também foram feitas alterações no projeto frontend).

