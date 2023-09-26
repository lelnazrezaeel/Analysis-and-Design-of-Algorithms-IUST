#include <iostream>
#include <vector>
#include <stack>
using namespace std;
const int Size = 1e7;
bool visited[Size];
vector<int> edges[Size];
void DFS(int s) 
{
    stack<int> stack;
    stack.push(s);
    while (!stack.empty()) 
    {
        int v = stack.top();
        stack.pop();
        if (visited[v]) continue;
        visited[v] = true;
        cout << v << endl;
        for (int i = edges[v].size() - 1; i >= 0; i--) 
        {
            int vertex = edges[v][i];
            if (!visited[vertex]) 
            {
                stack.push(vertex);
            }
        }
    }
}
int main() {
    int v, e, s;
    cin >> v >> e >> s;
    for (int i = 0; i < e; i++) 
    {
        int vi, vj;
        cin >> vi >> vj;
        edges[vi].push_back(vj);
        edges[vj].push_back(vi);
    }
    DFS(s);
    return 0;
}