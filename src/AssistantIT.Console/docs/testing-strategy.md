# Testing Strategy – Assistant IT Support (POC pédagogique)

## 1. Objectif de la stratégie de test

L’objectif de cette stratégie de test est de garantir le comportement applicatif de l’Assistant IT Support, et non de valider les réponses de l’IA elle-même.

Dans ce projet, l’IA est considérée comme :
- une dépendance externe,
- non déterministe,
- non testable de manière fiable par des tests unitaires classiques.

La stratégie adoptée vise donc à :
- tester le système autour de l’IA,
- sécuriser les décisions applicatives basées sur des intentions,
- garantir la stabilité du cœur métier face à l’évolution des composants IA.


## 2. Principe fondamental : on ne teste pas l’IA

Les modèles de langage :
- produisent des réponses probabilistes,
- évoluent dans le temps,
- ne garantissent pas une sortie identique à entrée identique.

Pour ces raisons :
- aucun test ne fait appel à l’API OpenAI,
- aucun test ne valide un prompt ou une réponse textuelle brute,
- aucun test ne dépend d’un comportement spécifique du modèle.

L’IA est simulée, jamais exécutée, dans le cadre des tests unitaires.


## 3. Ce qui est testé

Les tests portent sur les éléments déterministes du système.

Comportements testés
- Réaction de l’application à une intention donnée
- Décisions prises par l’orchestrateur
- Appels aux bons services métier
- Construction correcte des réponses applicatives

Exemples
- Une intention AnalyzeTicket déclenche le flux de traitement des tickets
- Une intention AnalyzeLogs déclenche l’analyse de logs
- Une intention inconnue est correctement gérée

Les tests vérifient le “quoi”, pas le “comment” interne de l’IA.


## 4. Ce qui n’est volontairement pas testé

Par conception, les éléments suivants ne sont pas couverts par les tests unitaires :
- Qualité linguistique des réponses IA
- Pertinence sémantique du raisonnement IA
- Performance ou latence des appels OpenAI

Variations de réponse liées au prompt

Ces aspects relèvent :
- de tests exploratoires,
- de tests manuels,
- ou de validations en environnement réel.


## 5. Usage de Fakes

Afin d’isoler le comportement applicatif, le projet utilise des fakes pour simuler l’analyse d’intention.

Rôle des fakes
- Remplacer l’implémentation réelle de IIntentAnalyzer
- Fournir des intentions déterministes et contrôlées
- Tester chaque branche logique de l’orchestrateur

Les fakes permettent de :
- supprimer toute dépendance externe,
- rendre les tests rapides et fiables,
- tester des scénarios difficiles à reproduire avec une IA réelle.


## 6. Tests par couche

La stratégie de test suit la séparation architecturale du projet.

**Tests d’analyse d’intention (simulée)**
- Vérification que les intentions retournées sont correctement interprétées
- Validation du contrat attendu par l’orchestrateur

**Tests d’orchestration**
- Vérification du routage vers le bon service métier
- Validation des décisions prises à partir d’une intention donnée
- Couverture des cas nominaux et des cas d’erreur

**Tests des services métier**
- Tests purement déterministes
- Aucun lien avec l’IA
- Validation de la logique métier IT support

Chaque couche est testée indépendamment, sans effet de bord.


## 7. Positionnement du AssistantIT.Console.Tests

Les tests sont regroupés dans un projet dédié :
- AssistantIT.Console.Tests

Ce projet :
- référence le projet principal,
- ne contient aucune logique IA réelle,
- utilise exclusivement des doubles de test pour les dépendances externes.

Cette séparation :
- clarifie les responsabilités,
- évite les dépendances croisées,
- facilite l’évolution du système.


## 8. Bénéfices de cette stratégie

Cette approche permet :
- des tests rapides et stables,
- une forte confiance dans les décisions applicatives,
- une évolution maîtrisée des composants IA,
- une meilleure lisibilité des intentions métier testées.

Elle favorise également une bonne compréhension du rôle réel de l’IA dans le système.


## 9. Limites de la stratégie de test (V1)

Cette stratégie ne couvre pas :
- les tests d’intégration avec OpenAI,
- les tests de charge ou de performance,
- la validation automatique des prompts,
- l’observabilité IA.

Ces limites sont assumées et cohérentes avec le périmètre pédagogique de la V1.


## 10. Conclusion

Cette stratégie de test montre qu’un projet intégrant une IA peut rester :
- testable,
- fiable,
- et maintenable,
à condition de considérer l’IA comme une dépendance externe et non comme une source de vérité métier.

Les tests garantissent le comportement applicatif, indépendamment des variations et évolutions du modèle de langage.