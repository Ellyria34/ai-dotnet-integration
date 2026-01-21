## Architecture

# 1. Positionnement dans le dépôt IA-DOTNET-INTEGRATION

Le dépôt IA-DOTNET-INTEGRATION est un monorepo pédagogique et expérimental, destiné à regrouper plusieurs projets illustrant différentes approches d’intégration de l’IA dans des applications .NET.
Dans ce contexte, KnowledgeAssistant.Console est un projet autonome et dispose de sa documentation locale.
C'est pour celà que les choix architecturaux décrits dans ce document sont strictement limités au périmètre du projet KnowledgeAssistant.Console.

## 2. Principes architecturaux

Le projet repose sur les principes suivants :
- Séparation logique des responsabilités
- Indépendance conceptuelle du domaine
- Testabilité maximale hors dépendances IA
- Lisibilité avant optimisation
- Évolutivité sans refonte

L’architecture est volontairement modulaire mais mono-projet afin de rester légère et cohérente avec un dépôt multi-projets.


## 3. Convention de nommage

Les conventions suivantes sont figées pour l’ensemble du projet :

### 3.1 Dossiers de code

PascalCase pour les couches logiques :
- Domain
- Application
- Infrastructure

Ces dossiers représentent des concepts d’architecture et sont alignés avec les namespaces .NET.

### 3.2 Dossiers transverses

lowercase pour les dossiers non exécutables ou transverses :
- docs
- experiments
- tests/KnowledgeAssistant.Console.Tests (se trouvant dans le dossier tests commun à l'ensemble des projets)


## 4. Organisation interne du projet

Structure cible du projet KnowledgeAssistant.Console :

```
KnowledgeAssistant.Console
│
├─ Application/
│   ├─ UseCases/
│   └─ Abstractions/
│
├─ Domain/
│   ├─ Models/
│   └─ ValueObjects/
│
├─ Infrastructure/
│   ├─ KnowledgeSources/
│   ├─ Retrieval/
│   └─ Generation/
│
├─ docs/
│   ├─ project-vision.md
│   └─ architecture.md
│
├─ Program.cs
└─ README.md
```

Cette organisation est logique, non physique au sens multi-projets, mais elle permet une future extraction sans renommage.

## 5.Testing

Tests for this project are located in: ../../tests/KnowledgeAssistant.Console.Tests
This separation is intentional and aligns with the monorepo structure of **IA-DOTNET-INTEGRATION**.

### Testing principles

- Core domain logic is fully testable without any AI dependency
- Retrieval, chunking, and scoring logic are covered by deterministic tests
- End-to-end behavior of the RAG pipeline (excluding LLM calls) can be validated through controlled scenarios
- LLM-based generation is abstracted and excluded from blocking tests
- No test requires network access or external services by default

The goal is to ensure that the RAG pipeline can be validated and reasoned about independently of the underlying language model.


## 6. Rôle des couches

### 6.1 Domain

Responsabilités :
- Modèles métier fondamentaux (Document, Chunk, etc.)
- Value Objects
- Règles invariantes

Contraintes :
- Aucune dépendance externe
- Aucune référence à l’IA
- Aucune logique d’orchestration


### 6.2 Application

Responsabilités :
- Orchestration du pipeline RAG
- Cas d’usage applicatifs
- Définition des contrats (interfaces)

Exemples de contrats :
- IKnowledgeSource
- IRetriever
- IAnswerGenerator

Contraintes :
- Dépend uniquement du Domain
- Ne contient aucune implémentation technique


### 6.3 Infrastructure

Responsabilités :
- Implémentations concrètes des abstractions
- Accès aux fichiers
- Algorithmes de retrieval
- Intégration LLM

Contraintes :
- Dépend de Application et Domain
- Aucune logique métier décisionnelle

## 7. Flux applicatif (pipeline RAG)

Flux conceptuel :

```
User Input
   ↓
Application Use Case
   ↓
Retriever
   ↓
Retrieved Context
   ↓
Answer Generator
   ↓
Console Output
```

Chaque étape est :
- isolée conceptuellement
- testable indépendamment (hors LLM)
- observable


## 8. Choix mono-projet : justification

Le choix de conserver une architecture interne mono-projet est intentionnel :
- Réduction de la complexité initiale
- Meilleure lisibilité pédagogique
- Intégration naturelle dans un monorepo
- Préparation à une extraction ultérieure

Ce choix n’empêche pas :
- l’ajout de tests
- l’évolution vers une solution multi-projets
- l’industrialisation future