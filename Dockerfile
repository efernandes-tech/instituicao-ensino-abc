#Use your choice of image as base. Mine is alpine!
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0.401 AS build
WORKDIR /src
COPY . .

RUN curl -sL https://deb.nodesource.com/setup_14.x |  bash -
RUN apt-get install -y nodejs

RUN apt-get update -y
RUN apt-get install vim -y

RUN dotnet restore "InstituicaoEnsinoABC/InstituicaoEnsinoABC.csproj"
WORKDIR "/src/."
COPY . .
RUN dotnet build "InstituicaoEnsinoABC/InstituicaoEnsinoABC.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "InstituicaoEnsinoABC/InstituicaoEnsinoABC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:PORT_NUMBER
# ENTRYPOINT ["dotnet", "InstituicaoEnsinoABC.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet InstituicaoEnsinoABC.dll