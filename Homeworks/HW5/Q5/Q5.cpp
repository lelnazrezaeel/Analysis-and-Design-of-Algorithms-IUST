#include <bits/stdc++.h>
using namespace std;
const int Size = 1e5;
vector<int> edges[Size];
int n;
void DFS(int vertex, int parent, int height, vector<int> &depth) 
{
    depth[vertex] = height;
    for (int i : edges[vertex]) 
    {
        if (i != parent) 
        {
            DFS(i, vertex, height + 1, depth);
        }
    }
}
void DisplayAnswer()
{
    int answer = 0;
    vector<int> depht1(n), depht2(n);
    DFS(0, -1, 0, depht1);
    int u = max_element(depht1.begin(), depht1.end()) - depht1.begin();
    DFS(u, -1, 0, depht1);
    int v = max_element(depht1.begin(), depht1.end()) - depht1.begin();
    DFS(v, -1, 0, depht2);
    for (int i = 0; i < n; i++) 
    {
        depht2[i] = max(depht1[i], depht2[i]);
    }
    sort(depht2.begin(), depht2.end());
    for (int i = 1; i <= n; i++) 
    {
        while (depht2[answer] < i && answer < n) 
        {
            answer++;
        }
        cout << min(n, answer + 1) << ' ';
    }
    cout << '\n';
}
int main() 
{
    int u, v;
    cin >> n;
    for (int i = 0; i < n - 1; i++) 
    {
        cin >> u >> v;
        edges[u - 1].push_back(v - 1);
        edges[v - 1].push_back(u - 1);
    }
    DisplayAnswer();
    return 0;
}
