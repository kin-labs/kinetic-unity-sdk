setup:
	npm install @openapitools/openapi-generator-cli -g

generate_api:
	npx @openapitools/openapi-generator-cli generate \
		-i https://raw.githubusercontent.com/kin-labs/kinetic/main/api-swagger.json \
		-o Temp/Generated  \
		-g csharp-netcore \
		-t .openapi-generator/templates/csharp-dotnet2 \
		--additional-properties=packageName=Generated \
		--additional-properties=clientPackage=Client

generate_pre:
	rm -rfv Temp/Generated Runtime/Kinetic

generate_post:
	cp -r Temp/Generated/src/Generated Runtime/Kinetic && \
	rm -rfv Temp/Generated Runtime/Kinetic/Client/GlobalConfiguration.cs Runtime/Kinetic/Client/RetryConfiguration.cs

generate_patch: generate_patch_enums generate_patch_client_cs

# The version of our generated code doesn't know how to generate enums
# so we have to do it ourselves as aliases of Strings (internally).
# See .openapi-generator/templates/csharp-dotnet2/model.mustache
generate_patch_enums:
	rm -v Runtime/Kinetic/Model/ClusterType.cs* && \
	rm -v Runtime/Kinetic/Model/Commitment.cs*  && \
	rm -v Runtime/Kinetic/Model/ConfirmationStatus.cs*  && \
	rm -v Runtime/Kinetic/Model/TransactionErrorType.cs*  && \
	rm -v Runtime/Kinetic/Model/TransactionStatus.cs*  

generate_patch_client_cs:
	sed -i '' 's/ ?? GlobalConfiguration.Instance/ /g' Runtime/Kinetic/Client/ClientUtils.cs

generate:  generate_pre generate_api generate_post generate_patch

all: generate


  
 
 
