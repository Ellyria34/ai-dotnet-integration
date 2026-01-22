# KnowledgeAssistant.Console

## Purpose

KnowledgeAssistant.Console is a console-based .NET project demonstrating a clean and controlled implementation of a Retrieval-Augmented Generation (RAG) pipeline.

This project focuses on architectural clarity, testability, and separation of concerns when integrating Large Language Models into an application.


## Scope

This project intentionally limits its scope to:

- Local knowledge sources (text / markdown files)
- Explicit document ingestion and chunking
- Deterministic retrieval logic
- Grounded answer generation

The goal is to understand and control each step of the RAG pipeline, not to build a production-ready assistant.


## Non-Goals

The following features are intentionally excluded from this iteration:

- Autonomous agents
- Function calling
- External vector databases
- Multi-step reasoning orchestration
- Web or graphical user interfaces


## Repository Context

This project is part of the **IA-DOTNET-INTEGRATION** monorepo.

Each project in this repository is autonomous and documents a specific integration pattern or architectural approach related to AI in .NET applications.


## Documentation

- `docs/project-vision.md` — project intent, scope, and constraints
- `docs/architecture.md` — internal architecture and conventions
- `docs/evolutions.md` — potential future evolutions

## Status

This project is under active development and evolves commit by commit for pedagogical purposes.
