## Recherche sur les RAG - Retrieval Augmented Generation

**Contexte et problématique**

Les LLM sont des modèles génératifs puissants, mais ils ne sont pas exploitables seuls en contexte applicatif ou entreprise.

Principales limites :
- Absence d’accès aux données internes
- Connaissances figées à la date d’entraînement
- Hallucinations possibles
- Manque de traçabilité et de contrôle

En production, on ne peut pas se contenter d’un LLM « brut ». Le RAG (Retrieval-Augmented Generation) est une architecture conçue pour répondre à ces limites.


**Définition du RAG**

Le RAG consiste à :
- Récupérer dynamiquement des documents* pertinents depuis une base de connaissances contrôlée
- Injecter ces documents dans le prompt du LLM au moment de l’inférence

Le modèle ne s’appuie plus uniquement sur ses connaissances internes, mais sur un contexte externe fourni à la demande. Le RAG transforme un LLM génératif en un système de réponse contextualisée et maîtrisée.


**Architecture générale d’un RAG**

Un système RAG repose sur trois briques principales :
- Une base documentaire (source de vérité)
- Des embeddings (représentation sémantique)
- Une base vectorielle (recherche par similarité)

Le LLM intervient uniquement en phase finale, pour générer la réponse.


**Les documents (source de vérité)**

Les documents correspondent aux données métier :
- PDF internes
- Procédures
- Documentation technique
- FAQ
- Wiki d’entreprise

Caractéristiques importantes :
- Les documents ne sont pas appris par le LLM
- Ils restent stockés et gouvernés séparément
- Ils peuvent être mis à jour sans réentraîner le modèle


**Embeddings et recherche sémantique**

Un embedding est une représentation vectorielle d’un texte.

Processus :
- Les documents sont découpés en chunks
- Chaque chunk est transformé en vecteur numérique
- Les vecteurs proches représentent des textes au sens similaire

Contrairement à la recherche par mots-clés, la recherche est sémantique.

Les embeddings sont stockés dans une base vectorielle permettant :
- Une recherche par similarité
- Un classement des documents les plus pertinents

Exemples de bases vectorielles :
- Pinecone
- Weaviate
- FAISS


**Déroulement d’une requête RAG**

1 - L’utilisateur pose une question
2 - La question est transformée en embedding
3 - Le système recherche les documents les plus proches sémantiquement
4 - Les documents récupérés sont injectés dans le prompt
5 - Le LLM génère une réponse basée sur ce contexte

Le LLM devient un moteur de synthèse et de reformulation, pas une source de vérité.


**Apports du RAG en production**

Le RAG permet :
- Des réponses alignées avec les données internes
- Une réduction significative des hallucinations
- Une mise à jour des connaissances sans réentraînement
- Une meilleure traçabilité (documents sources identifiables)
- Une intégration conforme aux contraintes métier et réglementaires

C’est aujourd’hui l’approche privilégiée en entreprise pour exploiter des LLM.

**Limites du RAG**

Le RAG :
- n’entraîne pas le modèle
- ne modifie pas les poids du LLM
- ne garantit pas une réponse correcte à 100 %
- ne remplace pas la gouvernance des données

Il doit être complété par :
- Du prompt engineering
- Des garde-fous (guardrails)
- Du monitoring


**RAG vs Fine-tuning**

| RAG                        | Fine-tuning                 |
| -------------------------- | --------------------------- |
| Données externes           | Données intégrées au modèle |
| Mise à jour simple         | Mise à jour coûteuse        |
| Très utilisé en entreprise | Plus rare                   |
| Faible risque              | Risque d’overfitting        |

En pratique, le RAG est privilégié pour intégrer des données métier.

conclusion : Le RAG est une architecture qui combine un LLM avec un moteur de recherche sémantique basé sur des embeddings. Lorsqu’une question est posée, le système récupère des documents pertinents depuis une base vectorielle et les fournit au LLM au moment de l’inférence, afin de produire une réponse contextualisée, traçable et alignée avec les données internes.