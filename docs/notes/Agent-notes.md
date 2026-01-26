## Recherche sur les Agents IA

**Contexte et problématique**

Les LLM sont capables de produire du texte de qualité, mais ils ne peuvent pas être utilisés seuls dans un système applicatif.

Limites d’un usage direct du LLM :
- Le LLM ne contrôle pas un flux d’exécution
- Le LLM ne choisit pas quelles actions exécuter
- Le LLM n’applique pas de règles métier
- Le LLM n’exécute aucune action technique

Un pipeline simple (par exemple un RAG basique) exécute toujours les mêmes étapes, dans le même ordre.
Pour gérer des scénarios plus complexes, une couche de contrôle est nécessaire.

C’est le rôle des agents IA.


**Définition d’un agent IA**

Un agent IA est une architecture logicielle qui :
- entoure un LLM avec une couche de contrôle applicative
- utilise le LLM comme composant de raisonnement
- conserve toutes les décisions finales côté système

Un agent permet au système de :
- analyser une demande
- déterminer quelles actions sont nécessaires
- exécuter ces actions via des composants contrôlés
- produire une réponse finale

Le LLM ne décide pas et n’agit pas.
Il fournit des propositions exploitées par le système.


**Principe fondamental : la boucle de contrôle**

Un agent fonctionne à l’aide d’une boucle contrôlée par l’application :

1. Le système reçoit une demande
2. Le contexte est préparé
3. Le LLM est interrogé pour produire une proposition
4. Le système valide cette proposition
5. L’action correspondante est exécutée
6. Le résultat est analysé
7. Le système décide de continuer ou de s’arrêter

Le raisonnement est délégué au LLM.
Le contrôle reste entièrement applicatif.


**Architecture générale d’un agent**

Un agent est composé de responsabilités clairement séparées :

- Couche d’orchestration (flux, règles, limites)
- LLM (raisonnement à partir du contexte fourni)
- Outils explicitement définis
- Règles métier et mécanismes de sécurité

La couche d’orchestration :
- définit les actions possibles
- limite le nombre d’itérations
- applique les règles métier
- garantit la traçabilité


**Les outils d’un agent**

Les outils sont des composants techniques appelables par le système :
- moteur RAG
- accès base de données
- services de calcul
- API externes
- gestion d’état ou mémoire courte

Le LLM peut proposer l’utilisation d’un outil.
Le système reste seul responsable de son exécution.

Le RAG est donc un outil parmi d’autres,
et non le moteur décisionnel.


**Rôle exact du LLM dans un agent**

Dans une architecture agent :
- le LLM reçoit un contexte structuré
- il produit un raisonnement ou une proposition
- il ne valide aucune règle
- il n’exécute aucune action
- il ne contrôle pas la boucle

Le LLM est utilisé comme composant de raisonnement,
au même titre qu’un moteur de règles probabiliste.


**Déroulement d’une requête avec un agent**

1. L’utilisateur soumet une requête
2. Le système analyse l’état courant
3. Le LLM est sollicité pour produire une proposition
4. Le système valide cette proposition
5. L’action correspondante est exécutée
6. Le résultat est intégré à l’état
7. Le système décide d’une nouvelle itération ou d’une réponse finale

Une requête peut nécessiter plusieurs itérations,
mais chaque étape reste contrôlée.


**Apports des agents en production**

Les agents permettent :
- un enchaînement d’actions non figé
- un raisonnement multi-étapes encadré
- une meilleure utilisation des outils existants
- une logique applicative plus expressive
- une meilleure séparation des responsabilités

Ils sont adaptés aux systèmes complexes nécessitant
une orchestration dynamique.


**Contraintes et limites des agents**

Les agents :
- augmentent la complexité du système
- nécessitent une observabilité fine
- doivent être strictement encadrés
- exigent des tests approfondis

Sans contrôle, un agent peut devenir imprévisible.
La couche d’orchestration est donc critique.


**Agent vs RAG**

```
| RAG                           | Agent                           |
| ----------------------------- | ------------------------------- |
| Pipeline fixe                 | Orchestration contrôlée         |
| Une seule étape principale    | Plusieurs actions possibles     |
| LLM utilisé pour générer      | LLM utilisé pour raisonner      |
| Logique déterministe          | Logique conditionnelle          |
```

Le RAG est un composant fonctionnel.
L’agent est une architecture de contrôle.


**Conclusion**

Un agent IA est une architecture qui intègre un LLM comme composant de raisonnement au sein d’un système applicatif contrôlé.

Le LLM ne décide pas et n’agit pas.
Le système applicatif conserve la maîtrise des règles, des actions et du flux d’exécution.

Le RAG reste un composant clé,
mais devient un outil utilisé par une orchestration plus large.
