# KnowledgeAssistant.Console

## Purpose

KnowledgeAssistant.Console is a console-based .NET project demonstrating a clean and controlled implementation of a Retrieval-Augmented Generation (RAG) pipeline.

This project focuses on architectural clarity, testability, and separation of concerns when integrating Large Language Models into an application.

The application explicitly controls when the LLM is invoked and prevents generation when no relevant context is available, ensuring grounded and non-hallucinated answers.

## Scope

This project intentionally limits its scope to:

- Local knowledge sources (text / markdown files)
- Explicit document ingestion and chunking
- Deterministic retrieval logic
- Grounded answer generation with optional LLM integration

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
KnowledgeAssistant.Console focuses specifically on Retrieval-Augmented Generation design and control.


## Key Design Decisions

- The domain layer is fully independent from AI concerns.
- The decision to invoke the LLM is made at the application level, before generation.
- Prompt construction and LLM integration are treated as infrastructure concerns.
- The system is designed to prevent hallucinations by refusing to answer when no relevant context is found.


## Documentation

- `docs/project-vision.md` — project intent, scope, and constraints
- `docs/architecture.md` — internal architecture, layering, and design decisions
- `docs/evolutions.md` — potential future evolutions

## Status

This project has reached a complete and functional state for its intended learning scope and may evolve further for experimentation purposes.