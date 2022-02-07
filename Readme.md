# Problem Solving Platform

Platform for competitive coding where programmers can practice solving problems from **very beginner level** to **very advanced level**.
This Platform is written using .NET Core.

The platform supports 4 programming languages : **Java**, **C++**, **C**, and **Python**

## Dependencies

* The platform communicate using Rest calls with an online code compiler that i developed using Java (Spring) check out [https://github.com/zakariamaaraki/RemoteCodeCompiler](https://github.com/zakariamaaraki/RemoteCodeCompiler).
* The platform uses MongoDB as a Database.

## Getting Started

First you'll need to build the docker image of the project [https://github.com/zakariamaaraki/RemoteCodeCompiler](https://github.com/zakariamaaraki/RemoteCodeCompiler). 

```shell
cd RemoteCodeCompiler
docker build . -t compiler
```

Then 

```shell
docker-compose up --build
```

## Architecture 

![Architecture](images/ProblemSolvingPlatform.png?raw=true "ProblemSolvingPlatform")


## For dev env

For dev env you can use the swagger page accessible using this url : [https://localhost:7074/swagger](https://localhost:7074/swagger)

![Swagger](images/Swagger-page.png?raw=true "ProblemSolvingPlatformSwagger")


## UI

The UI is written using **Razor** template engine

### Problem Interface

![Problem Interface](images/problem_interface.png?raw=true "ProblemInterface")

### Submissions

![Submissions Interface](images/Submission_page.png?raw=true "SubmissionsInterface")

## Author

- **Zakaria Maaraki** - _Initial work_ - [zakariamaaraki](https://github.com/zakariamaaraki)
