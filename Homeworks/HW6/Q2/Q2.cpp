#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;
const int SIZE = 2000;
int parent[SIZE], degree[SIZE];
struct Edge 
{
    int u, v, w;
};
bool Compare(Edge edge1, Edge edge2) 
{
    return edge1.w < edge2.w;
}
void InitializationSet(int vertex) 
{
    parent[vertex] = vertex;
    degree[vertex] = 0;
}
int GetRepresentative(int vertex) 
{
    if (vertex == parent[vertex])
        return vertex;
    return parent[vertex] = GetRepresentative(parent[vertex]);
}
void MergeSetes(int elements1, int elements2) 
{
    elements1 = GetRepresentative(elements1);
    elements2 = GetRepresentative(elements2);
    if (elements1 != elements2) 
    {
        if (degree[elements1] < degree[elements2])
        {
            swap(elements1, elements2);
        }
        parent[elements2] = elements1;
        if (degree[elements1] == degree[elements2])
        {
            degree[elements1]++;
        }
    }
}
int FindMST(vector<Edge> edges, int vertex)
{
    int total_weights = 0;
    sort(edges.begin(), edges.end(), Compare);
    for (int i = 1; i <= vertex; i++)
    {
        InitializationSet(i);
    }
    for (auto edge : edges) 
    {
        if (GetRepresentative(edge.u) != GetRepresentative(edge.v)) 
        {
            MergeSetes(edge.u, edge.v);
            total_weights += edge.w;
        }
    }
    return total_weights;
}
int main() 
{
    int v, e, vi, vj, w, answer;
    cin >> v >> e;
    vector<Edge> edges(e);
    for (int i = 0; i < e; i++) 
    {
        cin >> vi >> vj >> w;
        edges[i] = {vi, vj, w};
    }
    answer = FindMST(edges, v);
    cout << answer << endl;
    return 0;
}