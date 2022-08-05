//1) Crie um conjunto sptSet (conjunto de árvore do caminho mais curto) que mantém o controle 
//   dos vértices incluídos na árvore do caminho mais curto, ou seja, cuja distância mínima da fonte 
//   é calculada e finalizada. Inicialmente, este conjunto está vazio.
//2) Atribua um valor de distância a todos os vértices no gráfico de entrada. Inicialize todos 
//   os valores de distância como INFINITO. Atribua o valor da distância como 0 para o vértice de origem para que ele seja selecionado primeiro.
//3) Enquanto sptSet não inclui todos os vértices
//  a) Escolha um vértice u que não existe em sptSete tem valor mínimo de distância.
//  b) Inclua u no sptSet .
//  c) Atualize o valor da distância de todos os vértices adjacentes de u. Para atualizar os valores de distância, 
//     itere por todos os vértices adjacentes. Para cada vértice adjacente v, se a soma do valor da distância de u (da fonte) 
//     e o peso da aresta uv, for menor que o valor da distância de v, então atualize o valor da distância de v.

using System;

class GFG {
    //Função para encontrar o vértice com menor valor de distância dos vértice
    static int V = 9;
    int minDistancia(int[] dist,
                    bool[] sptSet)
    {
        // Valor mínimo
        int min = int.MaxValue, index_min = -1;
  
        for (int v = 0; v < V; v++)
            if (sptSet[v] == false && dist[v] <= min) {
                min = dist[v];
                index_min = v;
            }
  
        return index_min;
    }
  
    //Printar o array de distância
    void printarSolucao(int[] dist, int n)
    {
        Console.Write("Vertice     Distancia "
                      + "da fonte\n");
        for (int i = 0; i < V; i++)
            Console.Write(i + " \t\t " + dist[i] + "\n");
    }
  
    //Função para implementar o algoritmo de Dijkstra para um grafo 
    //utilizando representação por matriz de adjacência
    void dijkstra(int[, ] grafo, int src)
    {
        int[] dist = new int[V];
        
        //Array. dist[i] irá segurar a variável de menor distancia de src até i
        //sptSet[i] será verdadeiro se i é incluido no menor caminho
        //ou se há a menor distância entre src e i é final
        bool[] sptSet = new bool[V];
  
        //Inicializa todas as distâncias como infinita e stpSet[] como falso
        for (int i = 0; i < V; i++) {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }
  
        //Distância do vértice fonte até ele mesmo é sempre 0
        dist[src] = 0;
  
        //Encontrar menor caminho para todos os vértices
        for (int contagem = 0; contagem < V - 1; contagem++) {
            //Escolher o vértice de menor distância dos vértices ainda não processados. 
            //u é sempre igual a src em sua primeira iteração.
            int u = minDistancia(dist, sptSet);
  
            //Marcar o vértice como processado :thumbs_up:
            sptSet[u] = true;
  
            //Atualizar o valor dos vértices adjacentes ao escolhido
            for (int v = 0; v < V; v++)
  
                //Atualizara dist[v] apenas caso não esteja em sptSet, tenha uma ponta entre de u até v. 
                //e o peso da fonte até v é menor que o valor atual de dist[v]
                if (!sptSet[v] && grafo[u, v] != 0 && 
                     dist[u] != int.MaxValue && dist[u] + grafo[u, v] < dist[v])
                    dist[v] = dist[u] + grafo[u, v];
        }
  
        // printar o array
        printarSolucao(dist, V);
    }
  
    // Código
    public static void Main()
    {
        /* Criar um gráfico de exemplo */
        int[, ] grafo = new int[, ] { { 0, 5, 0, 0, 0, 0, 0, 7, 0 },
                                      { 5, 0, 7, 0, 0, 0, 0, 13, 0 },
                                      { 0, 7, 0, 7, 0, 5, 0, 0, 3 },
                                      { 0, 0, 7, 0, 11, 16, 0, 0, 0 },
                                      { 0, 0, 0, 11, 0, 10, 0, 0, 0 },
                                      { 0, 0, 5, 16, 10, 0, 3, 0, 0 },
                                      { 0, 0, 0, 0, 0, 3, 0, 1, 5 },
                                      { 7, 13, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 3, 0, 0, 0, 5, 7, 0 } };
        GFG t = new GFG();
        t.dijkstra(grafo, 0);
    }
}
  
