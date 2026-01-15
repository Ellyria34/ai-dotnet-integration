# Notes

## Recherche sur l'IA utilisée en entreprise, à quoi ça correspond réellement (Socle IA applicatif)

**Qu’appelle-t-on “IA” dans une application ?**

Dans une application, l’IA est un composant fonctionnel chargé de produire des résultats ou des recommandations à partir de données, sans porter la logique globale de l’application.


**Où se situe l’IA dans une architecture applicative ?**

Dans une architecture applicative, l’IA se situe généralement comme un service externe, appelé par l’application via une interface, de la même manière qu’une API.


**-Différence entre “application avec IA” et “application pilotée par l’IA”**

**- Application avec IA :**

Une application avec IA utilise l’intelligence artificielle comme un outil complémentaire, appelé selon le contexte, pour enrichir certaines fonctionnalités sans remettre en cause le contrôle global de l’application.

**- Application pilotée / contrôlée par l’IA :**

Une application pilotée par l’IA délègue une partie significative de la prise de décision à des systèmes probabilistes.
L’IA influence directement le comportement de l’application, ce qui augmente les risques et nécessite un encadrement strict.


**Quelles responsabilités ne doivent pas être confiées à l’IA ?**

L’IA ne doit pas être responsable de la logique centrale de l’application ni de décisions critiques.
Étant basée sur des probabilités et des données d’entraînement, elle doit rester un outil d’aide à la décision, sous contrôle de règles explicites définies par l’application.

## Recherches sur Les LLM (Socle IA applicatif suite)

LLM = Large Language Model
Il s'agit d'un modèle statistique entraîné sur un volume énorme de données (texte) dont l’objectif fondamental est uniquement de prédire le prochain token à partir d’un contexte.

Un LLM ne sait pas si l'information est vraie ou fausse il va uniquement savoir si une suite de mots est probable par rapport à ce qu'il a vu pendnat son entraînement.
**Un LLM ne retrouve pas l'information comme un moteur de recherche il la construit statistiquement sans obligation de vérité!.**

**Token**
Un token peut être :
- un mot entier
- une partie de mot
- un préfixe ou suffixe
- un signe de ponctuation
- un espace


**Les mécanisme clé : un LLM prédit le prochain token**

Quand on donne un prompte :
- Le texte fournit est découper en tokens en fonction de la langue, du vocabulaire appris par le modèle et la fréquence des mots
- Chaque token est transformé en nombres
- Le modèle fait une analyse du contexte complet en regardant tous les tokens précédents.
- Il calcule une probabilité pour chacun des tokens possible
- Il sélectionne un token en fonction d’une stratégie de génération basée sur les probabilités.
- il répète ce processus token par token jusqu’à atteindre une condition d’arrêt.


Même si il maitrise parfaitement le langage, qu'il c'est nourit d'exemple de raisonnements humains, le modèle imite la forme d’un raisonnement humain, mais il n’y a ni compréhension réelle ni raisonnement logique au sens humain. Il s’agit uniquement de statistiques appliquées au langage.

**L'hallucination : conséquence directe (ce n'est pas un bug)**

Ce n'est pas une erreur technique. Le Modèle doit fournir une réponse même si il n'a pas l'information. il va donc fournir la plus probable même si ce n'est pas vrai! Il ne va pas répondre "je ne sais pas".

C'est pour ça que le prompte est important. Il fait partie des contraintes externes sur lequelles ont peut jouer mais ce n'est pas une garantie.
**Les LLM doivent être cadrer en entreprise et les sources doivent être maîtrisées**


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

