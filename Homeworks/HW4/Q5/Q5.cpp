#include <bits/stdc++.h>
using namespace std;
const int Size = 1e5;
vector<int> edges[Size];
int visited[Size];
void Topology(int v) 
{
    int vertex;
    queue<int> queue;
    for (int i = 1; i <= v; i++) 
    {
        if (visited[i] == 0)
        {
            queue.push(i);
        }
    }
    while (!queue.empty()) 
    {
        vertex = queue.front();
        queue.pop();
        printf("%d ", vertex);  // Use printf instead of cout
        for (int i : edges[vertex]) 
        {
            visited[i]--;
            if (visited[i] == 0)
            {
                queue.push(i);
            }
        }
    }
}
int main() 
{
    int v, e, vi, vj;
    scanf("%d %d", &e, &v);  
    for (int i = 0; i < e; i++) 
    {
        scanf("%d %d", &vi, &vj); 
        edges[vi].push_back(vj);
        visited[vj]++;
    }
    Topology(v);
    return 0;
}
