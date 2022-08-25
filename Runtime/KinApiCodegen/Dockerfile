FROM maven:3-jdk-8

ENV GEN_DIR /local
ENV OUTPUT_DIR KinApiClient

ENV CODGEN_CLI /opt/swagger-codegen-cli.jar

RUN apt-get update \
    && apt-get install -y wget mono-devel\
    && rm -rf /var/lib/apt/lists/*


# Download current stable 3.x.x branch (OpenAPI version 3)
RUN wget https://repo1.maven.org/maven2/io/swagger/codegen/v3/swagger-codegen-cli/3.0.34/swagger-codegen-cli-3.0.34.jar -O ${CODGEN_CLI}

COPY docker-entrypoint.sh /usr/local/bin/
RUN chmod +x /usr/local/bin/docker-entrypoint.sh

ENTRYPOINT ["docker-entrypoint.sh"]

CMD ["help"]