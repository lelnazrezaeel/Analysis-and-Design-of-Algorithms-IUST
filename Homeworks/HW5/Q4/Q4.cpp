#include <bits/stdc++.h>
using namespace std;
const int Size = 1e5;
int n, m, component[Size], component_count = 0;
bool visited[Size], in_current_component[Size], component_contains_cycle[Size];
vector<int> adj[Size], reverse_adj[Size];
void DFS1(int u) 
{
    component[u] = component_count;
    for (int v : reverse_adj[u]) 
    {
        if (component[v] == 0) 
        {
            DFS1(v);
        }
    }
}
void DFS2(int u) 
{
    visited[u] = in_current_component[u] = true;
    for (int v : adj[u]) 
    {
        if (!visited[v]) 
        {
            DFS2(v);
        } 
        else
        {
            component_contains_cycle[component[u]] |= in_current_component[v];
        }
    }
    in_current_component[u] = false;
}
void DisplayAnswer()
{
    for (int i = 1; i <= n; i++) 
    {
        if (component[i] == 0) 
        {
            component_count++;
            DFS1(i);
        }
    }
    for (int i = 1; i <= n; i++) 
    {
        if (!visited[i]) 
        {
            DFS2(i);
        }
    }
    for (int i = 1; i <= component_count; i++) 
    {
        n += component_contains_cycle[i];
    }
    cout << n - component_count << endl;
}
int main() 
{
    int u, v;
    cin >> n >> m;
    for (int i = 1, u, v; i <= m; i++) 
    {
        cin >> u >> v;
        adj[u].emplace_back(v);
        reverse_adj[u].emplace_back(v);
        reverse_adj[v].emplace_back(u);
    }
    DisplayAnswer();
    return 0;
}
