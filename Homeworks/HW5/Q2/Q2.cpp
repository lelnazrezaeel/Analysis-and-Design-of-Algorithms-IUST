#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;
const int Size = 2e5;
bool visited[Size];
vector<int> edges[Size];
int path[Size];
void DFS(int vertex, int d) 
{
    visited[vertex] = true;
    path[vertex] = d;
    for (int v : edges[vertex]) 
    {
        if (!visited[v]) 
        {
            DFS(v, d + 1);
        }
    }
}
int main() 
{
    int n, vi, vj, k = 1, d = 0;
    cin >> n;
    for (int i = 1; i < n; i++) 
    {
        cin >> vi >> vj;
        edges[vi].push_back(vj);
        edges[vj].push_back(vi);
    }
    DFS(1, 0);
    for (int i = 2; i <= n; i++) 
    {
        if (path[i] > path[k]) 
        {
            k = i;
        }
    }
    fill(visited, visited + Size, false);
    DFS(k, 0);
    for (int i = 1; i <= n; i++) 
    {
        d = max(d, path[i]);
    }
    cout << d << endl;
    return 0;
}