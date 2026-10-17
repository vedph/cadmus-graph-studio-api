# Graph Studio API

This is a minimal API used to provide some basic tooling to the [Graph Studio web application](https://github.com/vedph/cadmus-graph-studio-app).

🐋 Quick Docker image build:

```sh
docker buildx create --use

docker buildx build . --platform linux/amd64,linux/arm64,windows/amd64 -t vedph2020/cadmus-graph-studio-api:1.0.1 -t vedph2020/cadmus-graph-studio-api:latest --push
```

(replace with the current version).
