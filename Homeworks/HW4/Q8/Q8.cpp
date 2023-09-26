#include <bits/stdc++.h>
using namespace std;
const int Size = 1e5;
vector<int> edges[Size];
vector<int> rev_edges[Size];
bool visited[Size];
stack<int> stck;
void DFS_1(int v) 
{
    visited[v] = true;
    for(int i : edges[v]) 
    {
        if(!visited[i]) 
        {
            DFS_1(i);
        }
    }
    stck.push(v);
}
void DFS_2(int v) 
{
    visited[v] = true;
    for(int i : rev_edges[v]) {
        if(!visited[i]) {
            DFS_2(i);
        }
    }
}
int main() 
{
    int v, e, vi, vj, vertex, cnt = 0;
    cin >> v >> e;
    for(int i = 0; i < e; i++) 
    {
        cin >> vi >> vj;
        edges[vi].push_back(vj);
        rev_edges[vj].push_back(vi);
    }
    for(int i = 1; i <= v; i++) 
    {
        if(!visited[i]) 
        {
            DFS_1(i);
        }
    }
    memset(visited, false, sizeof(visited));
    while(!stck.empty()) 
    {
        vertex = stck.top();
        stck.pop();
        if(!visited[vertex]) 
        {
            cnt++;
            DFS_2(vertex);
        }
    }
    cout << cnt << endl;
    return 0;
}