# History

- 2026-11-06: updated packages (Cadmus 17.1.0), and aligned the mappings runner (`api/mappings/run`) with the Cadmus graph updater:
  - 🐛 `flags` was bound as a string, while the frontend sends a number, so that any run with flags failed with a 400 error. Now it is a number (a numeric string is still accepted).
  - the metadata now include the components of a composite group ID (`item-group@1`, `item-group@2`...), as set by Cadmus.
  - mappings and their children are applied in the order of their `ordinal`, and then of their definition, as in the Cadmus graph database.
  - the result has a new `warnings` list, telling when the filters of a root mapping would prevent it from being applied in Cadmus to a source with the specified metadata (with the filter semantics of Cadmus 17.1: facet, part type and part role equal case-insensitively; group and title matching a regular expression; all the mapping's flags set in the item; a filter on a missing value never matching). The mapping is run anyway. The result is otherwise unchanged (`value`, `error`), so this is backwards compatible.

## 1.0.1

- 2026-10-17: updated packages.
- 2026-06-13: updated packages.

## 1.0.0

- 2026-05-05: updated packages.
- 2026-04-09: updated packages.
- 2025-02-01: updated packages.
- 2025-11-24: ⚠️ upgraded to NET 10.
- 2025-11-07: updated packages.
- 2025-09-18: updated packages.

## 0.0.10

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

## 0.0.9

- 2023-09-11: updated packages.
- 2023-08-07: updated packages and added `cod-loc` macro.
- 2023-07-01: updated packages.
- 2023-06-30: updated packages.
- 2023-06-17: updated packages.
- 2023-06-14: updated packages.

## 0.0.7

- 2023-05-31: updated packages and added metadata pid to received metadata.
- 2023-05-27: updated packages.

## 0.0.6

- 2023-05-23: updated `Cadmus.Graph` packages.

## 0.0.5

- 2023-05-15: updated `Cadmus.Graph` packages.

## 0.0.4

- 2023-05-14: error handling.

## 0.0.3

- 2023-05-13: updated `Cadmus.Graph` packages.

## 0.0.2

- 2023-05-09: updated `Cadmus.Graph` packages.

## 0.0.1

- 2023-05-08: initial release.
