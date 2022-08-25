#!/usr/bin/env bash

set -euo pipefail

API_SWAGGER_URL="$1"

API_CLIENT_FILE="src/main/CsharpDotNet2/IO/Swagger/Client/ApiClient.cs"

java -jar ${CODGEN_CLI} generate -i ${API_SWAGGER_URL} -l "csharp-dotnet2" -o /tmp/generated \
    && cd /tmp/generated/ \
    && mkdir -p ${GEN_DIR}/$OUTPUT_DIR \
    && cp -r /tmp/generated/src ${GEN_DIR}/$OUTPUT_DIR/ \
    && cp -r /tmp/generated/docs ${GEN_DIR}/$OUTPUT_DIR/ \
    && cp -r /tmp/generated/README.md ${GEN_DIR}/$OUTPUT_DIR/ \
    && sed -i '1s/^/using UnityEngine.Networking; \n/' ${GEN_DIR}/$OUTPUT_DIR/$API_CLIENT_FILE \
    && sed -i -e 's/RestSharp.Contrib.HttpUtility.UrlEncode(str)/UnityWebRequest.EscapeURL(str)/g' ${GEN_DIR}/$OUTPUT_DIR/$API_CLIENT_FILE \
    && sed -i -e 's/param.Value.FileName, param.Value.ContentType/param.Value.FileName, param.Value.ContentLength, param.Value.ContentType/g' ${GEN_DIR}/$OUTPUT_DIR/$API_CLIENT_FILE