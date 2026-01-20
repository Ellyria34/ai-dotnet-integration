# AssistantIT.Console

This project is a **pedagogical proof of concept** designed to explore and demystify  
**how to integrate a Large Language Model (LLM) into a .NET application in a clean, explicit, and controlled way**.

It is intentionally **not** a production-ready application.


## Purpose of this project

The primary goal of this project is to **understand concretely how AI integration works in practice**, beyond theory and abstractions.

More specifically, it aims to demonstrate:

- How to integrate an LLM **without delegating control of the application**
- How to use **OpenAI Function Calling** to produce structured, contract-based outputs
- How to keep orchestration and execution **fully application-driven**
- How to integrate AI while preserving determinism, testability, and clarity

This project focuses specifically on **intent analysis using a LLM**, as a first and contained AI use case.


## What this project does

- Provides a console-based internal IT assistant
- Uses a LLM to:
  - analyze free-form user input,
  - interpret user intent,
  - propose a suitable function call via Function Calling
- Keeps all execution logic under **explicit application control**
- Routes intents through a deterministic application orchestrator
- Executes IT support business logic independently of the AI
- Allows the application to run **with or without AI**, depending on configuration
- Includes a dedicated test project using explicit fakes (no AI calls in tests)


## Role of the LLM

The LLM is used strictly as an **analysis and routing mechanism**.

- It does **not** execute business logic
- It does **not** control the workflow
- It does **not** make autonomous decisions

The application defines:
- when the LLM is called,
- what functions are available,
- how results are validated and executed.

This design choice is intentional and central to the learning objectives.


## What this project deliberately does NOT do

- No Retrieval-Augmented Generation (RAG)
- No conversational memory
- No agentic or autonomous AI behavior
- No AI-driven business decisions
- No production hardening

These limitations are **intentional**, allowing the project to stay focused on
understanding Function Calling and controlled AI integration.


## Documentation

The architectural decisions and design rationale are documented in detail:

- `docs/architecture.md`
- `docs/testing-strategy.md`

These documents explain **why** certain choices were made, not just how the code works.


## Project status

This project is considered **complete for its learning scope**.

The next learning step — exploring **agentic approaches** — is intentionally planned
as a **separate experiment**, built on top of the foundations validated here.
