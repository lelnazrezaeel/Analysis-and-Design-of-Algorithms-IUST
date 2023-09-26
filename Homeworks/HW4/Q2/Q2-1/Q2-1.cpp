#include <bits/stdc++.h>
using namespace std;
const int Size = 1e7;
vector<int> edges[Size];
bool visited[Size];
void DFS(int v) 
{
    visited[v] = true;
    cout << v << "\n";
    for(int i = 0; i < edges[v].size(); i++) 
    {
        int vertex = edges[v][i];
        if(!visited[vertex]) 
        {
            DFS(vertex);
        }
    }
}
int main() {
    int v, e, s;
    cin >> v >> e >> s;
    for(int i = 0; i < e; i++) 
    {
        int vi, vj;
        cin >> vi >> vj;
        edges[vi].push_back(vj);
        edges[vj].push_back(vi);
    }
    DFS(s);
    return 0;
}
