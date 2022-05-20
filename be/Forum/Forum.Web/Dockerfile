#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Forum.Web/Forum.Web.csproj", "Forum.Web/"]
COPY ["Forum.Transfer/Forum.Transfer.csproj", "Forum.Transfer/"]
COPY ["Forum.Core/Forum.Core.csproj", "Forum.Core/"]
COPY ["Forum.Handler/Forum.Handler.csproj", "Forum.Handler/"]
COPY ["Forum.Domain.Implementation/Forum.Domain.Implementation.csproj", "Forum.Domain.Implementation/"]
COPY ["Forum.Domain.Interface/Forum.Domain.Interface.csproj", "Forum.Domain.Interface/"]
COPY ["Forum.Data/Forum.Data.csproj", "Forum.Data/"]
RUN dotnet restore "Forum.Web/Forum.Web.csproj"
COPY . .
WORKDIR "/src/Forum.Web"
RUN dotnet build "Forum.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Forum.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Forum.Web.dll"]