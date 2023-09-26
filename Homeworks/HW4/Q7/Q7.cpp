#include <iostream>
#include <vector>
using namespace std;
const int Size = 1e7;
vector<int> edges[Size];
int visited[Size];
void DFS(int v, bool &flag) 
{
    visited[v] = 1;
    for (int i : edges[v]) 
    {
        if (visited[i] == 2) 
        {
            flag = false;
            return;
        }
        else if(visited[i] == 0)
        {
            DFS(i, flag);
        }
    }
    visited[v] = 2;
}
int main() 
{
    int v, e, vi, vj;
    cin >> v >> e;
    for (int i = 1; i <= e; i++) 
    {
        cin >> vi >> vj;
        edges[vi].push_back(vj);
    }
    bool flag = true;
    for(int i = 1; i <= v; i++) 
    {
        for(int j = 1; j <= v; j++)
        {
            visited[j] = 0;
        }
        DFS(i, flag);
        if(!flag)
        {
            break;
        }  
    }
    if(flag)
    {
        cout << "Yes\n";
    }
    else
    {
        cout << "No\n";
    }
    return 0;
}