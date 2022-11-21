setup:
	npm install @openapitools/openapi-generator-cli -g

generate_api:
	npx @openapitools/openapi-generator-cli generate -i https://raw.githubusercontent.com/kin-labs/kinetic/main/api-swagger.json \
		-g csharp-netcore -t .openapi-generator/templates/csharp-dotnet2 -o Temp/Generated  \
		--additional-properties=packageName=Generated  --additional-properties=clientPackage=Client

generate_pre:
	rm -rfv Temp/Generated Runtime/Kinetic

generate_post:
	cp -r Temp/Generated/src/Generated Runtime/Kinetic && rm -rfv Temp/Generated Runtime/Kinetic/Client/GlobalConfiguration.cs Runtime/Kinetic/Client/RetryConfiguration.cs

generate:  generate_pre generate_api generate_post

all: generate


  
 
 
