# Pesquisa em Grafos - Caminho Mínimo

## Informações 

+ **Grupo 8: Pesquisa em Grafos**, responsável pela Quality Assurance do grupo 1 (Árvores Binárias).
+ **Integrantes**:
  + Matheus de Carvalho Souza
  + Pedro Henrique Alcântara Ramos
  + Renan Souza do Nascimento 
  + Roberta Meyrelles França
 + **Turma**: CC6M

## Algoritmo de Dijkstra

<p text-align:"justify"> O algoritmo de Dijkstra é muito semelhante ao algoritmo de Prim para árvore de extensão de custo mínimo (minimum spanning tree ou MST). Como o MST de Prim, geramos uma árvore de caminho mais curto (shortest-paths tree ou SPT) com um determinado vértice como raiz, que chamamos de *fonte*. Mantemos dois conjuntos, um conjunto contendo vértices incluídos na árvore do caminho mais curto e o outro conjunto inclui vértices ainda não incluídos na árvore do caminho mais curto. A cada passo do algoritmo, encontramos um vértice que está no outro conjunto (conjunto dos vértices ainda não incluídos) e possui uma distância mínima da fonte. </p>

### Grafo utilizado

![Exemplo_Grafo - Cor](https://user-images.githubusercontent.com/63109114/182698772-aec7c0a0-ee56-46b9-b627-cff39a47623d.png)
