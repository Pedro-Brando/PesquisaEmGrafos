class GFG {
    //Função para encontrar o vértice com menor valor de distância dos vértice
    static int V = 9;
    int minDistance(int[] dist,
                    bool[] sptSet)
    {
        // Valor mínimo
        int min = int.MaxValue, min_index = -1;
  
        for (int v = 0; v < V; v++)
            if (sptSet[v] == false && dist[v] <= min) {
                min = dist[v];
                min_index = v;
            }
  
        return min_index;
    }
  
    //Printar o array de distância
    void printSolution(int[] dist, int n)
    {
        Console.Write("Vertex     Distance "
                      + "from Source\n");
        for (int i = 0; i < V; i++)
            Console.Write(i + " \t\t " + dist[i] + "\n");
    }
  
    //Função para implementar o algoritmo de Dijkstra para um grafo utilizando representação por matriz de adjacência
    void dijkstra(int[, ] graph, int src)
    {
        int[] dist = new int[V];
        
        //Array. dist[i] irá segurar a variável de menor distancia de src até i
        //sptSet[i] será verdadeiro se i é incluido no menor caminho ou se há a menor distância entre src e i é final
        bool[] sptSet = new bool[V];
  
        //Inicializa todas as distâncias como infinita e stpSet[] como falso
        for (int i = 0; i < V; i++) {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }
  
        //Distância do vértice fonte até ele mesmo é sempre 0 né bobão
        dist[src] = 0;
  
        //Encontrar menor caminho para todos os vértices
        for (int count = 0; count < V - 1; count++) {
            //Escolher o vértice de menor distância dos vértices ainda não processados. u é sempre igual a src em sua primeira iteração.
            int u = minDistance(dist, sptSet);
  
            //Marcar o vértice como processado :thumbs_up:
            sptSet[u] = true;
  
            //Atualizar o valor dos vértices adjacentes ao escolhido
            for (int v = 0; v < V; v++)
  
                //Atualizara dist[v] apenas caso não esteja em sptSet, tenha uma ponta entre de u até v. e o peso da fonte até v é menor que o valor atual de dist[v]
                if (!sptSet[v] && graph[u, v] != 0 && 
                     dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];
        }
  
        // printar o array
        printSolution(dist, V);
    }
  
    // Código
    public static void Main()
    {
        /* Criar um gráfico de exemplo */
        int[, ] graph = new int[, ] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
        GFG t = new GFG();
        t.dijkstra(graph, 0);
    }
}
  