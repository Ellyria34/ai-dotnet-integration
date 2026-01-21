# Vision du projet

## 1. Contexte

Les applications intégrant des LLM souffrent fréquemment de défauts structurels.On peut vite se retrouver avec :
- une logique métier mêlée à l’IA,
- des dépendances fortes à un fournisseur de modèle,
- une faible testabilité,
- une absence de traçabilité dans les réponses générées.

Le projet KnowledgeAssistant vise à répondre à ces problèmes en proposant une implémentation claire, progressive et architecturée d’un assistant de connaissance basé sur un pipeline RAG (Retrieval-Augmented Generation).

Ce projet a une vocation pédagogique : il s'inscrit dans dans une démarche globale pour comprendre, démontrer et expliquer comment intégrer proprement de l’IA générative dans une application .NET.


## 2. Objectif principal

L'objectif de ce projet est de concevoir une application .NET Console implémentant un RAG maîtrisé, dans laquelle :
- la récupération d’information est séparée de la génération,
- le modèle de langage n’est qu’un composant remplaçable,
- chaque étape du pipeline est observable, testable et compréhensible.


## 3. Périmètre fonctionnel

Ce que l’application fait :

- Charger une base de connaissances locale (fichiers texte / Markdown)
- Découper ces connaissances en unités exploitables (chunks)
- Retrouver les éléments les plus pertinents pour une question donnée
- Générer une réponse explicitement ancrée dans les informations récupérées

Ce que l’application ne fait pas (volontairement)
- Pas d’agents autonomes
- Pas de function calling
- Pas de base vectorielle externe
- Pas de raisonnement multi-étapes automatique
- Pas d’interface utilisateur graphique ou web

Ces choix sont intentionnels afin de préserver la lisibilité et la maîtrise du socle technique.


## 4. Contraintes non fonctionnelles

Le projet doit respecter les principes suivants :
- Séparation stricte des responsabilités
- Testabilité de chaque composant hors LLM
- Aucune dépendance directe entre le domaine métier et l’IA
- Traçabilité du contexte utilisé pour chaque réponse
- Architecture évolutive sans refonte majeure


## 5. Hypothèses techniques initiales

Application Console .NET avec une a rchitecture inspirée de la Clean Architecture.

Pipeline RAG linéaire :
- Ingestion
- Chunking
- Retrieval
- Génération

Stockage en mémoire (première itération)

Modèle LLM interchangeable via une abstraction


## 6. Glossaire minimal

**Document** : source brute de connaissance (fichier)

**Chunk** : portion découpée d’un document

**Retriever** : composant chargé de sélectionner les chunks pertinents

**Context** : ensemble de chunks transmis au modèle

**Grounded Answer** : réponse générée exclusivement à partir du contexte fourni
