# Architecture – Assistant IT Support (V1 – POC pédagogique)

## 1. Contexte et objectifs du projet

Ce projet implémente un **Assistant IT interne fictif**, sous forme d’application console .NET, intégrant un **LLM (OpenAI)** pour l’analyse d’intentions utilisateur.

Il s’agit volontairement d’un **POC d’apprentissage**, dont l’objectif principal est de :
- comprendre concrètement comment intégrer une IA dans une application existante,
- démystifier le rôle réel d’un LLM dans une architecture applicative,
- structurer cette intégration de manière claire, contrôlée et maintenable,
- éviter que l’IA devienne un point de fragilité ou un couplage fort.

Ce projet n’a **pas vocation à être déployé en production**.

Les choix techniques privilégient :
- la lisibilité,
- la clarté conceptuelle,
- la pédagogie,
au détriment d’optimisations prématurées.


## 2. Vision d’architecture globale

L’architecture repose sur un principe fondamental :

**Le LLM n’est pas le cœur du système.  
Il agit comme un composant d’analyse, au service d’un flux applicatif piloté par le code.**

Le flux global est le suivant :
- réception d’un message utilisateur,
- analyse de l’intention à l’aide du LLM,
- interprétation applicative de cette intention,
- exécution d’une logique métier déterministe.

Le LLM intervient **en amont du métier**, uniquement pour produire une information
structurée exploitable par l’application.

Ce positionnement permet de conserver :
- un contrôle total sur les actions exécutées,
- une architecture testable et explicable,
- une séparation claire des responsabilités.


## 3. Rôle du LLM dans le système

Dans cette V1, le LLM est utilisé exclusivement pour :
- analyser un texte libre fourni par l’utilisateur,
- interpréter ce texte,
- produire une **intention normalisée et structurée**.

Le LLM :
- ne déclenche aucune action,
- ne modifie aucun état applicatif,
- ne contient aucune logique métier,
- ne pilote aucun workflow.

Cette restriction est volontaire.

Elle permet :
- de limiter l’impact des erreurs ou hallucinations,
- de garantir que toute action reste sous contrôle applicatif,
- de rendre le comportement global du système prévisible et compréhensible.


## 4. Choix du Function Calling

Le projet utilise le **Function Calling d’OpenAI** afin d’encadrer strictement les sorties du LLM.

### Problème initial

Une réponse textuelle libre :
- est ambiguë,
- difficile à parser,
- peu fiable pour piloter une logique applicative.

### Solution retenue

Le Function Calling permet de :
- définir un schéma contractuel explicite,
- forcer le LLM à produire une sortie structurée,
- transformer une réponse probabiliste en signal applicatif exploitable.

### Bénéfices

- Robustesse accrue
- Validation explicite des sorties
- Découplage entre langage naturel et logique métier

Le Function Calling agit comme un **contrat formel entre le LLM et l’application**.


## 5. Séparation du schéma d’intention

Le schéma décrivant les intentions possibles est défini dans un composant dédié,
séparé de l’implémentation de l’analyse d’intention.

Ce choix permet :
- d’éviter des constantes implicites ou “magiques”,
- de rendre le contrat IA visible et explicite,
- de faciliter l’évolution future (nouvelles intentions, versioning).

Le schéma est considéré comme :
- un élément d’architecture,
- et non comme un simple détail d’implémentation.

Cette séparation améliore :
- la lisibilité,
- la responsabilité unique des composants,
- la capacité d’évolution contrôlée du système.


## 6. Modélisation de l’intention

L’intention produite par le LLM est modélisée comme un objet métier simple.

Deux notions sont distinguées :
- **Intent** : information décisionnelle utilisée par l’application,
- **Context / Reason** : information explicative fournie par le LLM.

Seule l’intention fait partie de l’identité logique du résultat.

Les données explicatives :
- n’influencent aucune décision métier,
- ne sont pas utilisées pour les comparaisons,
- servent uniquement à des fins de compréhension ou de diagnostic.

Ce choix reflète un principe clé :
**toutes les données produites par un LLM ne font pas partie du modèle métier.**


## 7. Orchestration applicative

Le composant d’orchestration est **entièrement applicatif**.

Il est responsable de :
- coordonner l’analyse d’intention,
- interpréter le résultat produit par le LLM,
- déclencher la logique métier appropriée.

L’orchestrateur :
- ne contient aucune logique IA,
- ne contient aucune logique métier,
- ne prend aucune décision autonome.

Il agit comme une couche de coordination explicite entre composants spécialisés.

Cette séparation garantit :
- une lecture claire du flux applicatif,
- une meilleure testabilité,
- une évolutivité maîtrisée.


## 8. Responsabilités des composants

### Program.cs

Point d’entrée de l’application.

Responsabilités :
- gestion des entrées/sorties console,
- démarrage de l’application,
- délégation complète du traitement à l’orchestrateur.

Aucune logique métier, décisionnelle ou IA n’est présente dans ce composant.


### AssistantOrchestrator

Responsable de la coordination du flux applicatif.

Il :
- appelle l’IIntentAnalyzer,
- interprète l’intention retournée,
- route la demande vers le service métier approprié,
- assemble la réponse finale.

Il ne contient ni logique métier détaillée, ni logique IA.


### IIntentAnalyzer

Frontière entre langage naturel et monde applicatif structuré.

Responsabilités :
- analyser une demande utilisateur brute,
- produire une intention structurée,
- garantir un contrat stable entre l’IA et l’application.

L’implémentation peut évoluer sans impacter le cœur applicatif.


### SupportService

Implémente la logique métier IT support.

Règle clé :
**le SupportService ne connaît pas l’IA.**

Il manipule uniquement des intentions et des modèles métier explicites,
garantissant l’indépendance du domaine métier.


### Modèles métier

Les modèles métier représentent les données du domaine IT support.

Règles :
- modèles simples,
- aucune dépendance à l’IA,
- aucune dépendance à l’infrastructure.


## 9. Flux détaillé d’un appel utilisateur

- saisie d’une requête en langage naturel,
- analyse de l’intention via le LLM,
- production d’une intention structurée (Function Calling),
- validation et interprétation applicative,
- exécution de la logique métier correspondante.

Chaque étape est volontairement simple et isolée.


## 10. Tests et validation

Les tests unitaires valident :
- le comportement applicatif face à une intention donnée,
- l’orchestration,
- l’isolation des composants.

Le comportement du LLM lui-même n’est pas testé.

La stratégie est détaillée dans `docs/testing-strategy.md`.


## 11. Limites volontaires

Cette V1 n’inclut volontairement pas :
- RAG,
- mémoire conversationnelle,
- comportements agentiques,
- raisonnement autonome,
- observabilité avancée.

Ces limites permettent de consolider les fondations
avant toute montée en complexité.


## 12. Conclusion

Cette architecture démontre qu’un LLM peut être intégré :
- comme un composant maîtrisé,
- avec des responsabilités clairement définies,
- sans compromettre la lisibilité ni la testabilité du système.

Cette V1 privilégie la compréhension architecturale
avant l’exploration de modèles plus complexes.
