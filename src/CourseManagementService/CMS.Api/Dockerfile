#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1803 AS build
WORKDIR /src
COPY ["CMS.Api/CMS.Api.csproj", "CMS.Api/"]
RUN dotnet restore "CMS.Api/CMS.Api.csproj"
COPY . .
WORKDIR "/src/CMS.Api"
RUN dotnet build "CMS.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CMS.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CMS.Api.dll"]