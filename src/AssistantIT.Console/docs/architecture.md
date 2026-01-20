# Architecture – Assistant IT Support (V1 - POC pédagogique)

## 1. Contexte et objectifs du projet

Ce projet implémente un **Assistant IT interne fictif**, sous forme d’application console .NET, intégrant une IA (OpenAI) pour l’analyse d’intentions utilisateur.

Il s’agit volontairement d’un **POC d’apprentissage** dont l’objectif principal est de comprendre et démontrer :
- comment intégrer une IA dans une application existante,
- comment structurer cette intégration de manière robuste et maintenable,
- comment éviter que l’IA devienne un point de fragilité ou de couplage fort.

Ce projet n’a pas vocation à être déployé en production.

Les choix techniques privilégient :
- la lisibilité,
- la clarté conceptuelle,
- et la pédagogie,
au détriment d’optimisations prématurées.


## 2. Vision d’architecture globale

L’architecture repose sur un principe fondamental : **L’IA n’est pas le cœur du système, elle est un composant d’aide à la décision.**

L’application suit un flux classique :
- Réception d’un message utilisateur
- Analyse de l’intention via l’IA
- Interprétation applicative de cette intention
- Exécution d’une logique métier déterministe

L’IA intervient **en amont du métier**, uniquement pour produire une information structurée exploitable par le code.

Ce positionnement permet de conserver :
- un contrôle total sur les actions exécutées,
- une architecture testable,
- une séparation claire des responsabilités.

## 3. Rôle de l’IA dans le système

Dans cette V1, l’IA est utilisée exclusivement pour :
- analyser un texte libre fourni par l’utilisateur,
- classifier ce texte en **une intention normalisée.**

L’IA ne :
- déclenche aucune action directement,
- modifie aucun état applicatif,
- contient aucune logique métier.

Cette restriction est volontaire.

Elle permet :
- de limiter l’impact des erreurs ou hallucinations,
- de garantir que toute action reste sous contrôle du code,
- de rendre le comportement global du système explicable et prévisible.


## 4. Choix du Function Calling

Le projet utilise le function calling d’OpenAI pour encadrer strictement les réponses de l’IA.

**Problème initial**

Une réponse textuelle libre :
- est ambiguë,
- difficile à parser,
- peu fiable pour piloter une logique applicative.

**Solution retenue**

Le function calling permet de :
- définir un schéma contractuel attendu,
- forcer l’IA à produire une sortie structurée,
- transformer une réponse probabiliste en un signal applicatif exploitable.

**Bénéfices**

- Robustesse accrue
- Validation explicite des sorties
- Découplage entre langage naturel et logique métier

Le function calling agit comme un **contrat entre l’IA et l’application.**


## 5. Séparation du schéma d’intention

Le schéma décrivant les intentions possibles est défini dans un composant dédié, séparé de l’implémentation de l’analyseur.

Ce choix répond à plusieurs objectifs :
- éviter les constantes “magiques” enfouies dans le code,
- rendre le contrat IA explicite et visible,
- faciliter l’évolution future (ajout d’intentions, versioning).

Le schéma est considéré comme :
- un élément d’architecture,
- et non comme un simple détail d’implémentation.

Cette séparation améliore :
- la lisibilité globale,
- la responsabilité unique des classes,
- la capacité à faire évoluer l’architecture vers des scénarios plus complexes (multi-agents, orchestration avancée).

## 6. Modélisation de l’intention

L’intention produite par l’IA est modélisée comme un objet métier simple.

Deux notions sont distinguées :
- Intent : information décisionnelle utilisée par l’application
- Reason (ou équivalent) : contexte explicatif fourni par l’IA

Seule l’intention fait partie de l’identité logique du résultat.

Le contexte explicatif :
- n’influence pas la décision métier,
- n’est pas utilisé pour les comparaisons,
- sert uniquement à des fins de compréhension ou de debug.

Ce choix reflète une distinction importante : Toutes les données produites par l’IA ne font pas partie de l’identité métier.


## 7. Orchestration applicative

Le composant d’orchestration joue un rôle central.

Il est responsable de :
- coordonner l’analyse d’intention,
- interpréter le résultat IA,
- déclencher la logique applicative appropriée.

L’orchestrateur :
- ne contient aucune logique IA,
- ne contient aucune logique métier spécifique,
- agit comme un chef d’orchestre entre composants spécialisés.

Cette couche permet :
- une lecture claire du flux applicatif,
- une meilleure testabilité,
- une évolutivité contrôlée.

## 8. Responsabilités des composants

Cette section décrit les responsabilités architecturales des principaux composants de l’application.
Elle sert de contrat de conception et définit les règles de séparation des responsabilités.

### Program.cs

Program.cs est le point d’entrée de l’application.

Responsabilités :
- gestion des entrées/sorties console,
- démarrage de l’application,
- délégation complète du traitement à l’orchestrateur.

Règle fondamentale : Program.cs ne contient aucune logique métier ni décisionnelle.

Il se limite strictement à :
- lire l’entrée utilisateur,
- appeler l’orchestrateur,
- afficher la réponse finale.

Il ne réalise :
- aucune analyse,
- aucune prise de décision,
- aucune logique de support,
- aucune interaction directe avec l’IA.

### AssistantOrchestrator

L’AssistantOrchestrator représente le cerveau applicatif, mais pas l’exécutant métier.

Responsabilités : orchestration du flux applicatif,

coordination entre :
- l’analyse d’intention,
- les services métier IT support,
- l’assemblage de la réponse finale.

Il :
- appelle l’IIntentAnalyzer,
- route la demande vers le service métier approprié,
- agrège les résultats pour produire une réponse cohérente.

Il ne :
- contient aucune logique métier détaillée,
- analyse aucun log ou ticket lui-même,
- implémente aucune logique IA interne,
- gère aucune entrée/sortie utilisateur.

Ce découplage garantit une orchestration lisible, testable et évolutive.

### IIntentAnalyzer

IIntentAnalyzer définit la frontière entre le langage naturel et le monde applicatif structuré.

Rôle architectural :
- isoler la compréhension du langage naturel,
- protéger le cœur applicatif des évolutions IA,
- permettre l’introduction future de LLMs, d’agents ou de RAG sans refonte du métier.

Responsabilités :
- analyser une demande utilisateur brute,
- produire une intention explicite et structurée,
- garantir un contrat clair entre l’IA et l’application.

L’implémentation concrète peut évoluer, mais l’interface reste stable.

### SupportService

Le SupportService implémente la logique métier IT support.

Responsabilités :
- traiter des demandes métier à partir de données structurées,
- analyser des tickets,
- interpréter des résultats de logs,
- proposer des causes probables,
- recommander des actions ou des escalades.

Règle clé : Le SupportService ne connaît pas l’IA.

Il reçoit :
- des intentions,
- des modèles métier explicites.

Il retourne :
- des résultats métier structurés.
- Cette isolation garantit que la logique métier reste indépendante des choix technologiques liés à l’IA.

### Modèles métier

Les modèles métier représentent les données manipulées par le domaine IT support
(ex. : SupportTicket, LogAnalysisResult, SupportRecommendation).

Règles de conception :
- modèles simples et explicites,
- aucune dépendance à l’IA,
- aucun accès à l’infrastructure,
- comportement minimal en V1.

Ils constituent le langage commun entre les composants métier.

### Structure de dossiers

L’organisation des dossiers reflète directement les responsabilités architecturales :

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
      ├── SupportRecommendation.cs
      └── UserIntent.cs
```

Cette structure favorise :
- la lisibilité,
- la séparation des responsabilités,
- et l’évolutivité de l’architecture.


## 9. Flux détaillé d’un appel utilisateur

Le déroulement complet d’un appel est le suivant :
- L’utilisateur saisit une requête en langage naturel
- La requête est transmise à l’analyseur d’intention
- L’IA retourne une intention structurée via function calling
- Le résultat est validé et interprété
- L’orchestrateur décide de l’action à effectuer
- La logique IT correspondante est exécutée

Chaque étape est volontairement simple et clairement délimitée.


## 10. Tests et validation

Le projet inclut un projet de tests unitaires dédié.
Les tests ne cherchent pas à valider le comportement de l’IA elle-même, mais à garantir que :
- l’application réagit correctement à une intention donnée,
- l’orchestration applique la bonne logique,
- les composants sont isolés et remplaçables.

La stratégie de test est documentée séparément dans docs/testing-strategy.md.


## 11. Limites volontaires du projet

Cette version n’inclut volontairement pas :
- de RAG (Retrieval Augmented Generation),
- de mémoire conversationnelle,
- de multi-agents,
- de raisonnement complexe côté IA,
- d’observabilité avancée.

Ces limitations permettent de :
- conserver un périmètre maîtrisé,
- solidifier les fondations,
- éviter une complexité prématurée.

## 12. Conclusion

Ce projet démontre qu’une IA peut être intégrée :
- comme un composant logiciel maîtrisé,
- avec des responsabilités claires,
- sans compromettre la testabilité ni la lisibilité du système.

Cette V1 pose volontairement des bases simples et solides, afin de privilégier
la compréhension architecturale avant toute montée en complexité.