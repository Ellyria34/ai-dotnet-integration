# Structure et rôles du repository

Ce document décrit l’organisation du repository **AI-DOTNET-INTEGRATION** et le rôle de
chaque dossier.

L’objectif est de fournir une **cartographie claire du dépôt**, ainsi que les règles
de répartition entre code, documentation et expérimentations.

Le principe général est le suivant :

> Un projet = un objectif pédagogique clair.


## Rôle de `docs/`

Ce dossier contient **toute la documentation du repository** ainsi que les supports de
transmission (PDF visuels pour les notions importantes).

Ce dossier ne contient **aucun code exécutable**.

Il sert à :
- centraliser les notes de réflexion et d’apprentissage,
- expliquer les concepts abordés au fur et à mesure,
- documenter les choix techniques et architecturaux,
- conserver une trace écrite compréhensible dans le temps.

### `docs/notes/`

Ce sous-dossier sert à centraliser les notes prises lors de recherches
(bibliographie, meetups, tutoriels, expérimentations).

Ces documents peuvent être exploratoires et moins formalisés.

### `docs/pdfs/`

Ce sous-dossier contient les documents PDF finalisés, destinés à la transmission
et à la synthèse des connaissances.

### Documentation de référence

Les documents structurants (architecture, stratégie de test, etc.) ont vocation
à être maintenus à jour et à refléter l’état réel des projets.


## Rôle de `src/`

Ce dossier contient le **code source principal des projets applicatifs**.

Il est destiné à :
- héberger des implémentations structurées et assumées,
- servir de base stable pour l’apprentissage,
- illustrer des choix architecturaux réfléchis.

Le code présent dans ce dossier doit être :
- lisible,
- organisé,
- testable,
- plus stable que celui des expérimentations.


## Rôle de `tests/`

Ce dossier contient les **projets de tests unitaires** associés aux projets présents
dans `src/`.

Il sert à :
- valider le comportement applicatif,
- garantir la stabilité des décisions métier,
- expérimenter des stratégies de test adaptées aux systèmes intégrant une IA.

Les tests ne cherchent pas à valider l’IA elle-même, mais le comportement du système
autour de celle-ci.


## Rôle de `experiments/`

Ce dossier est dédié aux **tests, essais et prototypes**.

Il permet de :
- tester des idées sans contrainte de propreté ou de structure définitive,
- explorer des concepts avant une éventuelle intégration dans `src/`,
- réaliser des essais rapides, jetables ou incomplets.

Le code présent dans ce dossier peut être :
- non final,
- incomplet,
- temporaire.

Il s’agit d’un espace de liberté contrôlée, volontairement séparé du code stable.


## Rôle des fichiers `README.md`

Le `README.md` à la racine du repository constitue la **porte d’entrée globale**.

Il a pour objectif de :
- expliquer pourquoi le repository existe,
- présenter la démarche générale,
- donner le contexte sans entrer dans les détails techniques.

Des fichiers `README.md` peuvent également exister au niveau des projets
individuels afin de :
- préciser leur objectif pédagogique,
- expliciter leur périmètre,
- éviter toute ambiguïté sur leur statut ou leur évolution.

