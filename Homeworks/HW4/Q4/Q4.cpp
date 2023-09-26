#include <iostream>
#include <vector>
#include <queue>
using namespace std;
const int Size = 1e7;
vector<int> edges[Size];
bool visited[Size];
void CheckPath(int A, int B)
{
    queue<int> queue;
    int x;
    visited[A] = true;
    queue.push(A);
    while (!queue.empty()) 
    {
        x = queue.front();
        queue.pop();
        for (int i : edges[x]) 
        {
            if (!visited[i]) 
            {
                visited[i] = true;
                queue.push(i);
            }
        }
    }
    if (visited[B]) 
    {
        cout << "YES\n";
    } 
    else 
    {
        cout << "NO\n";
    }
}
int main() 
{
    int v, e, A, B, k, neighbour;
    cin >> v >> e >> A >> B;
    for (int i = 0; i < v; i++) 
    {
        cin >> k;
        for (int j = 0; j < k; j++) 
        {
            cin >> neighbour;
            edges[i + 1].push_back(neighbour);
        }
    }
    CheckPath(A, B);
    return 0;
}
