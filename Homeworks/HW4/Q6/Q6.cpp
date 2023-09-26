#include <bits/stdc++.h>
using namespace std;
const int Size = 1e5;
vector<int> edges[Size];
bool visited[Size];
void DFS(int v) 
{
    visited[v] = true;
    for (int i : edges[v]) 
    {
        if (!visited[i])
        { 
            DFS(i);
        }
    }
}
int CountComponents(int v)
{
    int cnt = 0;
    for (int i = 1; i <= v; i++) 
    {
        if (!visited[i]) 
        {
            DFS(i);
            cnt++;
        }
    }
    return cnt;
}
int main() 
{
    int v, e, vi, vj;
    cin >> e >> v;
    for (int i = 0; i < e; i++) 
    {
        cin >> vi >> vj;
        edges[vi].push_back(vj);
        edges[vj].push_back(vi);
    }
    int answer = CountComponents(v);
    cout << answer << endl;
    return 0;
}