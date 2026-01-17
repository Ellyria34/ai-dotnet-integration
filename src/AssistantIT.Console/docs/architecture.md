## Architecture (V1)

Ce document décrit l’architecture de la version 1 de l’assistant IT support, ainsi que le raisonnement ayant conduit aux choix de découpage applicatif.

## Flux logique global
```
User input (console)
        ↓
AssistantOrchestrator
        ↓
Intent analysis (IA)
        ↓
Support logic
        ↓
Structured response
        ↓
Console output
```


## Découpage des responsabilités (v1)

### 1 - Program.cs

Responsabilités:
- Point d’entrée de l’application.
- Gestion des entrées/sorties console.
- Délégation complète du traitement à l’orchestrateur.

Règle importante : Program.cs ne contient aucune logique métier ni décisionnelle.

Il ne fait que :
- lire l’entrée utilisateur,
- appeler l’orchestrateur,
- afficher la réponse.

Il ne contient aucune responsablilté : pas d'analyse, pas de logique support et pas de décision.


### 2 - AssistantOrchestrator

C’est le cerveau applicatif, pas l'exécutant. 

Responsabilité :
- Orchestration du flux applicatif.
- Coordination entre :
    - analyse d’intention,
    - logique métier IT support,
    - génération de la réponse finale.

Ce qu’il fait :
- Appelle l’IIntentAnalyzer.
- Route la demande vers le bon service métier.
- Assemble une réponse structurée.

Ce qu’il ne fait pas :
- Pas d’analyse métier détaillée.
- Pas de parsing de logs.
- Pas de logique IA interne.
- Pas d’accès aux entrées/sorties.


### IIntentAnalyzer

Rôle architectural :
- Découpler la compréhension du langage naturel du reste de l’application.
- Permettre l’évolution future (LLM, Agent, RAG) sans impacter le cœur métier.

Responsabilités:
- Analyser une demande utilisateur brute.
- Retourner une intention structurée et explicite.


### SupportService

Responsabilités :
- Implémenter la logique métier IT support.
- Travailler uniquement à partir de données déjà structurées.

Exemples : Analyse de ticket, analyse d’erreurs dans des logs, proposition de causes probables, recommandation d’actions ou d’escalade.

Règle clé : Le SupportService ne connaît pas l’IA.

Il reçoit :
- des intentions,
- des modèles métier.

Il retourne des résultats métier structurés.


### Modèles métier

Il représente les données manipulées par le domaine IT support (ex : SupportTicket, LogAnalysisResult, SupportRecommendation...)
Règles : 
- Modèles simples
- Pas de dépendance à l’IA
- Pas d’accès à l’infrastructure
- Comportement minimal en v1



## Structure de dossiers

```
AssistantIT.Console/
 ├── Program.cs
 ├── Orchestration/
 │    └── AssistantOrchestrator.cs
 ├── Intent/
 │    ├── IIntentAnalyzer.cs
 │    └── SimpleIntentAnalyzer.cs
 ├── Support/
 │    └── SupportService.cs
 └── Models/
      ├── SupportTicket.cs
      ├── LogAnalysisResult.cs
      └── SupportRecommendation.cs
```

