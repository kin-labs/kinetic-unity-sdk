# Autogenerate Kinetic API Clients from Swagger

## Build & Run docker container to Generate the API client code
```
docker build -t kin-swagger-code-generation . && docker run --rm -v ${PWD}:/local kin-swagger-code-generation https://raw.githubusercontent.com/kin-labs/kinetic/main/api-swagger.json
```