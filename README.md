# InstituicaoEnsinoABC

## Notes:

- Conforme mudamos algo no banco, é só executar esse comando no Console do Gerenciador de Pacotes:
Scaffold-DbContext "server=localhost;port=3308;database=InstituicaoEnsinoABC;user=root;password=root;" Pomelo.EntityFrameworkCore.MySql -f -o Models -Context InstituicaoEnsinoABCDbContext -ContextDir Context

- Add no arquivo "InstituicaoEnsinoABCDbContext.cs"

``
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
modelBuilder.ApplyConfiguration(new UsuarioMap());
modelBuilder.ApplyGlobalConfigurations();
``

## Run application:

- Back-end (https://localhost:5001):

```
cd ./InstituicaoEnsinoABC
dotnet run
// or
dotnet watch
```

- Front-end (http://localhost:4200):

```
cd ./InstituicaoEnsinoABC/ClientApp
ng serve
```

## Docker Local:

- Gerar container local:

```
cd ./
docker build -t instituicao-ensino-abc-img .
```

- Rodar container:

```
cd ./
docker run -d -p 5000:80 --name instituicao-ensino-abc instituicao-ensino-abc-img
```

## Deploy:

- Heroku: https://instituicao-ensino-abc.herokuapp.com/login

```
cd ./
heroku login
heroku container:login
heroku container:push web -a instituicao-ensino-abc
heroku container:release web -a instituicao-ensino-abc
```
