FROM microsoft/dotnet:2.0-runtime
LABEL name "docker-vega"

WORKDIR /app
COPY out .

ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000

ENTRYPOINT ["dotnet",  "docker-vega.dll"]