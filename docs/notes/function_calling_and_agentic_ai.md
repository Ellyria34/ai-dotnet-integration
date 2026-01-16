# Function Calling et Agentic AI

## 1. Contexte et objectif

Les **LLM** sont capables de comprendre des requêtes complexes et de produire des réponses pertinentes, mais **ils ne peuvent pas agir directement sur un système d’information**.

Pour passer :
- d’une **IA conversationnelle**
- à une **IA capable d’interagir avec des services, APIs et données métiers**

on s’appuie sur deux concepts clés :
- le **Function Calling**
- l’**Agentic AI**

Ces mécanismes constituent le **socle technique de l’IA applicative**.


## 2. Function Calling — mécanisme fondamental

### Définition

Le **Function Calling** est la capacité d’un LLM à **identifier qu’une action externe est nécessaire** pour répondre à une demande, et à **formuler une requête structurée décrivant cette action**.

Le LLM :
- ne réalise pas l’action
- n’exécute aucun code
- se contente de demander l’appel d’une fonction


### Principe général

Le développeur fournit au LLM :
- la demande de l’utilisateur
- une liste de fonctions disponibles, décrites par :
  - un nom
  - une description en langage naturel
  - les paramètres attendus

À partir de ces éléments, le LLM choisit :
- soit de répondre directement
- soit de demander l’appel d’une fonction précise avec des arguments structurés


## 3. Rôle du développeur dans le Function Calling

Le **rôle du développeur est central**.

Contrairement à une idée reçue, le LLM **ne fait jamais l’action lui-même**.

Le développeur est responsable de :

1. **L’exposition des capacités**
   - Définir quelles fonctions sont accessibles à l’IA
   - Décrire clairement leur intention et leurs paramètres

2. **L’exécution réelle**
   - Appeler les services métiers
   - Interroger des bases de données
   - Déclencher des APIs internes ou externes

3. **La réinjection du résultat**
   - Fournir le résultat de l’exécution au LLM
   - Permettre au modèle d’interpréter ce résultat
   - Générer une réponse finale compréhensible pour l’utilisateur

Le développeur agit comme **pont entre le raisonnement du LLM et le monde réel**.


## 4. La boucle Analyse / Action / Observation

Le Function Calling s’inscrit dans une boucle de raisonnement :

1. **Analyse**  
   Le LLM analyse la demande et détermine s’il a besoin d’un outil.

2. **Action**  
   Il demande l’exécution d’une fonction avec des paramètres précis.

3. **Observation**  
   Il reçoit le résultat et l’intègre dans son raisonnement.

Cette boucle peut se répéter plusieurs fois jusqu’à obtenir une réponse satisfaisante.


## 5. Limites du Function Calling seul

Utilisé seul, le Function Calling implique :
- une gestion manuelle de la boucle
- beaucoup de code d’orchestration
- des risques d’erreurs dans les enchaînements
- une logique parfois difficile à maintenir

C’est pour répondre à ces limites qu’intervient l’**Agentic AI**.


## 6. Agentic AI — automatisation et orchestration

### Définition

L’**Agentic AI** est une approche qui **encapsule et automatise le Function Calling**.

Au lieu de piloter manuellement chaque étape, le développeur définit :
- un **agent**
- un **LLM**
- un ensemble de **fonctions / actions**

L’agent se charge alors automatiquement :
- des appels au LLM
- de l’identification des fonctions à exécuter
- de la gestion des retours
- de la répétition de la boucle si nécessaire


### Apport principal

L’Agentic AI permet :
- une logique plus déclarative
- moins de code de contrôle
- une meilleure lisibilité
- une orchestration plus robuste

Le développeur se concentre sur le **métier**, pas sur la mécanique.


## 7. Mise en œuvre côté .NET / C#

Dans un environnement .NET, l’approche consiste à :

1. Définir des **fonctions métiers en C#**
2. Les exposer à l’IA via une **description sémantique**
3. Laisser le LLM décider quand les utiliser
4. Exécuter les fonctions dans l’infrastructure applicative
5. Réinjecter les résultats dans le contexte du LLM

Des frameworks comme **Semantic Kernel** facilitent cette orchestration côté .NET, mais le principe reste identique, même sans framework.


## 8. Ce que Function Calling et Agentic AI ne font pas

Ces mécanismes :
- n’autorisent pas l’IA à exécuter du code arbitraire
- ne remplacent pas les règles de sécurité
- ne suppriment pas le contrôle du développeur
- ne garantissent pas une décision métier correcte

Ils fournissent une **capacité d’action encadrée**, pas une autonomie totale.


Conclusion : Le Function Calling permet à un LLM de demander l’exécution d’outils externes sans jamais exécuter de code lui-même. Le développeur reste responsable de l’exécution et du contrôle. L’Agentic AI automatise cette boucle d’analyse, d’action et d’observation afin de construire des agents capables d’interagir de manière structurée avec un système d’information.