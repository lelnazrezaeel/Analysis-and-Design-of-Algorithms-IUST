#include<bits/stdc++.h>
using namespace std;
const int Size = 1e7;
vector<int> edges[Size];
bool visited[Size];
void BFS(int s) 
{
    queue<int> queue;
    queue.push(s);
    visited[s] = true;
    while(!queue.empty()) 
    {
        int v = queue.front();
        queue.pop();
        cout << v << "\n";
        for(int vertex : edges[v]) 
        {
            if(!visited[vertex]) 
            {
                visited[vertex] = true;
                queue.push(vertex);
            }
        }
    }
}
int main() {
    int v, e, s;
    cin >> v >> e >> s;
    for(int i = 0; i < e; i++) {
        int vi, vj;
        cin >> vi >> vj;
        edges[vi].push_back(vj);
        edges[vj].push_back(vi);
    }
    BFS(s);
    return 0;
}
