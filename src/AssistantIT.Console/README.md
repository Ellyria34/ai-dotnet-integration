# AssistantIT.Console

This project is a **pedagogical proof of concept** designed to explore and understand
**how to integrate AI (LLMs) into a .NET application in a clean and controlled way**.

It is intentionally **not** a production-ready application.


## Purpose of this project

The goal of this project is to demonstrate:

- How to integrate an AI component without making it the core of the system
- How to use OpenAI function calling to produce structured, contract-based outputs
- How to keep business logic deterministic and independent from AI
- How to preserve testability in an AI-assisted application

The project focuses specifically on **intent analysis via AI**, and nothing more.


## What this project does

- Provides a console-based internal IT assistant
- Uses AI exclusively to classify user input into structured intents
- Routes intents through an explicit application orchestrator
- Executes IT support business logic independently of AI
- Includes a dedicated test project with explicit fakes (no AI calls in tests)


## What this project deliberately does NOT do

- No Retrieval-Augmented Generation (RAG)
- No conversational memory
- No multi-agent architecture
- No AI-driven business decisions
- No production hardening

These limitations are **intentional** and aligned with the learning objectives.


## Documentation

The architectural decisions and testing strategy are documented in detail:

- `docs/architecture.md`
- `docs/testing-strategy.md`

These documents explain the *why* behind the design, not just the implementation.


## Project status

This project is considered **complete** from a learning perspective.

Further AI experimentation is intentionally performed in **separate projects** to keep
each learning objective clearly scoped.