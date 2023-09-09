public class Actions
{
    int[] visited = new int[0];
    bool[,] adjacencyMatrix = new bool[8, 8];
    int[] actions = new int[0];

    /* INSERE ARESTAS NA MATRIZ DE ADJACÊNCIA */
    public void setUpMatrix(params Tuple<int, int>[] points)
    {
        foreach (Tuple<int, int> point in points)
        {
            adjacencyMatrix[point.Item1 - 1, point.Item2 - 1] = true;
        }
        /* for(int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                Console.Write(matrix[i,j] + "\t");
            }
            Console.WriteLine();
        } */
    }

    /* RECUPERA OS VERTICES ADJASCENTES */
    int[] getAdjacents(int vertice)
    {
        int[] adjacents = new int[0];
        for (int i = 0; i < adjacencyMatrix.GetLength(1); i++)
        {
            if (adjacencyMatrix[vertice - 1, i] == true)
            {
                int[] aux_adjacents = new int[adjacents.Length + 1];
                Array.Copy(adjacents, 0, aux_adjacents, 1, adjacents.Length);
                aux_adjacents[0] = i + 1;
                adjacents = aux_adjacents;
            }
        }
        return adjacents;
    }

    /* REALIZA ORDENAÇÃO TOPOLÓGICA */
    public int[] topologic_sort()
    {
        visit(1);
        foreach (int action in actions)
        {
            switch (action)
            {
                case 1:
                    Console.WriteLine(action + " - Minerar Recursos");
                    break;
                case 2:
                    Console.WriteLine(action + " - Abastecer Nave");
                    break;
                case 3:
                    Console.WriteLine(action + " - Refinar Recursos");
                    break;
                case 4:
                    Console.WriteLine(action + " - Vender Recursos");
                    break;
                case 5:
                    Console.WriteLine(action + " - Ir Até Estação Espacial");
                    break;
                case 6:
                    Console.WriteLine(action + " - Juntar Dinheiro");
                    break;
                case 7:
                    Console.WriteLine(action + " - Procurar Nave");
                    break;
                case 8:
                    Console.WriteLine(action + " - Comprar Nave");
                    break;
                
            }
        }
        return actions;
    }

    /* VISITA CADA VÉRTICE */
    void visit(int vertice)
    {
        if (!Array.Exists(visited, element => element == vertice))
        {
            int[] adjacents = getAdjacents(vertice);
            foreach (int adjacent in adjacents)
            {
                visit(adjacent);
                int[] aux_visited = new int[visited.Length + 2];
                Array.Copy(visited, 0, aux_visited, 2, visited.Length);
                aux_visited[0] = adjacent;
                visited = aux_visited;
            }
            int[] aux_actions = new int[actions.Length + 1];
            Array.Copy(actions, 0, aux_actions, 1, actions.Length);
            aux_actions[0] = vertice;
            actions = aux_actions;
        }
    }
}