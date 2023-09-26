#include <iostream>
#include <vector>
using namespace std;
const int Size = 1e5;
vector<int> edges[Size];
int parent[Size];
int lowest[Size];
void DFS(int u, int p, int l) 
{
    parent[u] = p;
    lowest[u] = l;
    for (int v : edges[u]) 
    {
        if (v != p) 
        {
            DFS(v, u, l + 1);
        }
    }
}
int LCA(int u, int v) 
{
    while (lowest[u] > lowest[v]) 
    {
        u = parent[u];
    }
    while (lowest[v] > lowest[u]) 
    {
        v = parent[v];
    }
    while (u != v) 
    {
        u = parent[u];
        v = parent[v];
    }
    return u;
}

int main() 
{
    int n, q, p, k = 0;
    cin >> n >> q;
    int output[q];
    for (int i = 2; i <= n; i++) 
    {
        cin >> p;
        edges[p].push_back(i);
        edges[i].push_back(p);
    }
    DFS(1, 0, 0);
    while (q--) 
    {
        int u, v;
        cin >> u >> v;
        output[k] = LCA(u, v);
        k++;
    }
    for (int i = 0; i < k; i++)
    {
        cout << output[i] << endl;
    }
    return 0;
}