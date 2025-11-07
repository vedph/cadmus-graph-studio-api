# Graph Studio API

This is a minimal API used to provide some basic tooling to the [Graph Studio web application](https://github.com/vedph/cadmus-graph-studio-app).

Quick **Docker** image build:

```bash
docker buildx create --use

docker buildx build . --platform linux/amd64,linux/arm64,windows/amd64,windows/arm64 -t vedph2020/cadmus-graph-studio-api:0.0.10 -t vedph2020/cadmus-graph-studio-api:latest --push
```

(replace with the current version).

## History

- 2025-11-07: updated packages.
- 2025-09-18: updated packages.

### 0.0.10

- 2025-07-12:
  - updated packages.
  - fixes to Dockerfile.
- 2025-07-10:
  - added HTTP file.
  - updated packages. 
- 2025-07-09:
  - updated packages.
  - fixes to run model.
- 2025-06-09: updated packages.
- 2025-06-05: updated packages.
- 2025-03-10: updated packages.
- 2024-12-12: updated packages.
- 2024-11-22: updated packages.
- 2024-11-20: updated packages.
- 2024-11-19: ⚠️ upgraded to .NET 9 and replaced Swagger with Scalar.
- 2023-11-21: updated packages.
- 2023-11-18: ⚠️ Upgraded to .NET 8.
- 2023-11-09: updated packages.
- 2023-10-05: updated packages.

### 0.0.9

- 2023-09-11: updated packages.
- 2023-08-07: updated packages and added `cod-loc` macro.
- 2023-07-01: updated packages.
- 2023-06-30: updated packages.
- 2023-06-17: updated packages.
- 2023-06-14: updated packages.

### 0.0.7

- 2023-05-31: updated packages and added metadata pid to received metadata.
- 2023-05-27: updated packages.

### 0.0.6

- 2023-05-23: updated `Cadmus.Graph` packages.

### 0.0.5

- 2023-05-15: updated `Cadmus.Graph` packages.

### 0.0.4

- 2023-05-14: error handling.

### 0.0.3

- 2023-05-13: updated `Cadmus.Graph` packages.

### 0.0.2

- 2023-05-09: updated `Cadmus.Graph` packages.

### 0.0.1

- 2023-05-08: initial release.
