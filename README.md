# AI .NET Integration

This repository documents outlines a practical learning path focused on integrating artificial intelligence into .NET applications using C#.

The objective is to build a strong, practical understanding of how AI can be integrated into real-world software systems, with an emphasis on clean architecture, maintainability, and professional development practices.

---

## Why this repository exists

Modern applications increasingly rely on AI-powered features such as text analysis, automation, and intelligent decision support.  
This repository serves as a structured, practical workspace to:

- Understand where AI fits in a .NET application architecture
- Learn how to integrate AI services responsibly and effectively
- Develop production-oriented coding habits
- Track technical progress over time in a clear and transparent way

---

## Learning approach

The learning process is based on:
- Short daily work sessions (around 1 hour)
- Incremental improvements to a real codebase
- Clear separation between application logic and AI concerns
- Regular documentation of design decisions and lessons learned

The repository evolves progressively, reflecting each step of the learning process rather than presenting a finished product upfront.

---

## Scope and learning boundaries

### The **AssistantIT.Console** project has a deliberately limited scope.

Its purpose is **not** to evolve into a full-featured AI assistant, but to serve as a focused learning exercise on:

- OpenAI function calling
- Clean AI integration in a .NET application
- Architectural boundaries between AI and business logic
- Testing strategies for AI-assisted systems

Once these objectives are met, the project is intentionally considered **complete**.

### Further experimentation (RAG, agents, memory, advanced orchestration) is explored through **separate projects**, each designed to address a specific level of complexity.

This approach ensures that:
- each project remains conceptually clear,
- learning goals are explicit,
- and architectural decisions remain easy to explain and defend.


### AssistantIT.Console

The main implemented application is a **console-based internal IT assistant**, intentionally built without AI in its first version.

Its purpose is to establish a clean, testable, and explainable application flow **before introducing any AI component**.

Key characteristics:

- Clear separation of responsibilities:
  - Console I/O
  - Application orchestration
  - Intent analysis
  - Business logic (IT support)
- An explicit orchestrator responsible for routing decisions
- An intent analyzer abstraction designed to evolve toward AI-based implementations
- A fully deterministic V1 (no LLM, no RAG, no agent)
- Comprehensive unit tests covering:
  - Intent analysis
  - Business logic
  - Orchestration and routing decisions
- No mock frameworks: fakes are implemented explicitly to keep behavior understandable

This approach ensures that AI will later be introduced as an **evolution**, not as a foundational dependency.

---

## Repository structure (initial)

```text
ai-dotnet-integration/
├─ docs/          # Learning notes, architectural reasoning, and summaries
│  └─ pdfs/
├─ src/           # Application source code (.NET)
│  └─ AssistantIT.Console/
├─ tests/         # Unit tests (xUnit, fakes, orchestration tests)
├─ experiments/   # Isolated experiments and proofs of concept
└─ README.md
```

## License

This project is licensed under the Apache License 2.0.

You are free to use, modify, and distribute this project,
provided that proper attribution is given to the original author.

Author: Sarah LEON


## Documentation language

The main `README.md` is written in English, as it serves as the public entry point of the repository.

Most internal documentation files located in the `docs/` directory are written in French.
This choice is intentional and aims to preserve clarity and precision when explaining
architectural reasoning and learning-oriented content.
