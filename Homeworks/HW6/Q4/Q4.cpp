#include <bits/stdc++.h>
using namespace std;
const int SIZE = 100000;
int parent[SIZE];
int edge;
vector<int> current;
struct Edge 
{
    int source; 
    int destination;
    int weight;
} edges[SIZE];
int FindSet(int v) 
{
    if (parent[v] == v) 
    {
        return v;
    }
    return parent[v] = FindSet(parent[v]);
}
int MergeSets1(int v, int s) 
{
    int v1 = FindSet(edges[v].source);
    int v2 = FindSet(edges[v].destination);
    if (v1 != v2) 
    {
        parent[v1] = v2;
        s += edges[v].weight;
        current.push_back(v);
    }
    return s;
}
int MergeSets2(int v, int s) 
{
    int v1 = FindSet(edges[v].source);
    int v2 = FindSet(edges[v].destination);
    if (v1 != v2) 
    {
        parent[v1] = v2;
        s += edges[v].weight;
        edge++;
    }
    return s;
}
int SecondMST(int e, int v)
{
    sort(edges, edges + e, [](const Edge& edge1, const Edge& edge2) {return edge1.weight < edge2.weight;});
    int s = 0;
    int max = INT_MAX;
    for (int i = 0; i < e; i++) 
    {
        s = MergeSets1(i, s);
    }
    s = 0;
    for (int j = 0; j < current.size(); j++) 
    {
        edge = 0;
        for (int i = 1; i <= v; i++) 
        {
            parent[i] = i;
        }
        for (int i = 0; i < e; i++) 
        {
            if (i == current[j]) 
            {
                continue;
            } 
            s = MergeSets2(i, s);
        }
        if (edge == v - 1 && s < max) 
        {
            max = s;
        }
        s = 0;
    }
    if (max != INT_MAX) 
    {
       return max;
    } 
    else 
    {
        return -1;
    }

}
int main() 
{
    int numv, e, u, v, w;
    cin >> numv >> e;
    for (int i = 1; i <= numv; i++) 
    {
        parent[i] = i;
    }
    for (int i = 0; i < e; i++) 
    {
        cin >> v >> u >> w;
        edges[i].source = v;
        edges[i].destination = u;
        edges[i].weight = w;
    }
    cout << SecondMST(e, numv) << endl;
    return 0;
}