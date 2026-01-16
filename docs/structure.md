# Structure et rôles

## Rôle de `docs/`

Ce dossier contient toute la documentation du projet et les supports de transmission (PDF visuels pour chacune des notions importantes).

Ce dossier ne contient aucun code exécutable.

Il sert à :
- Centraliser les notes de réflexion et d’apprentissage
- Expliquer les concepts abordés au fur et à mesure
- Documenter les choix techniques **avant** leur implémentation
- Conserver une trace écrite compréhensible dans le temps

**`docs/notes/`** sert à centraliser les notes prises lors des recherches biblio/meetup/tuto...

**`docs/pdfs/`** sert à centraliser les PDFs finaux destinés à la transmission et à la synthèse des connaissances.


## Rôle de `src/`

Ce dossier contient le code source principal de l’application.

Il est destiné à :
- Héberger l’implémentation réelle des fonctionnalités
- Accueillir progressivement l’intégration de composants liés à l’IA
- Représenter l’application “finale” ou structurée, par opposition aux essais

Le code présent dans ce dossier doit être :
- Lisible
- Organisé
- Plus stable que celui des expérimentations


## Rôle de `experiments/`

Ce dossier est dédié aux tests, essais et prototypes.

Il permet de :
- Tester des idées sans contrainte de propreté ou de structure définitive
- Explorer des concepts avant de les intégrer dans `src/`
- Réaliser des essais rapides, jetables ou incomplets

Le code présent dans ce dossier peut être :
- Non final
- Incomplet
- Temporaire

C’est un espace de liberté contrôlée.


## Rôle du `README.md`

Le fichier `README.md` est la porte d’entrée du projet.

Il a pour objectif de :
- Expliquer rapidement ce qu’est le projet
- Présenter la démarche et l’intention
- Donner le contexte sans entrer dans les détails techniques

Il doit permettre à quelqu’un (y compris moi-même ultérieurement) de comprendre :
- Pourquoi ce projet existe
- Comment il est structuré
- Dans quel esprit il évolue