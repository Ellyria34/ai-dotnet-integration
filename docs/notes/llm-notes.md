# Recherches sur Les LLM (Socle IA applicatif suite)

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