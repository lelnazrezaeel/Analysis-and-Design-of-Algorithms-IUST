#include <bits/stdc++.h>
using namespace std;
struct Tuple 
{
    long long v;
    long long u;
    long long po;
};
class MinHeap 
{
private:
    vector<Tuple> heap;
public:
    MinHeap();
    void push(Tuple value);
    Tuple pop();
    Tuple peek();
    bool isEmpty();
    void clear();
};
MinHeap::MinHeap() 
{
    heap.clear();
}
void MinHeap::clear() 
{
    heap.clear();
}
void MinHeap::push(Tuple value) 
{
    heap.push_back(value);
    int i = heap.size() - 1;
    while (i > 0 && heap[(i - 1) / 2].po > heap[i].po) 
    {
        Tuple temp = heap[(i - 1) / 2];
        heap[(i - 1) / 2] = heap[i];
        heap[i] = temp;
        i = (i - 1) / 2;
    }
}
Tuple MinHeap::pop() 
{
    if (heap.size() == 0) 
    {
        Tuple r;
        r.u = -1, r.v = -1, r.po = -1;
        return r;
    }
    Tuple value = heap[0];
    heap[0] = heap.back();
    heap.pop_back();
    int i = 0;
    while (i < heap.size()) 
    {
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        int min = i;
        if (left < heap.size() && heap[left].po < heap[min].po) 
        {
            min = left;
        }
        if (right < heap.size() && heap[right].po < heap[min].po) 
        {
            min = right;
        }
        if (min != i) 
        {
            Tuple temp = heap[i];
            heap[i] = heap[min];
            heap[min] = temp;
            i = min;
        } 
        else 
        {
            break;
        }
    }
    return value;
}
Tuple MinHeap::peek() 
{
    if (heap.size() == 0) 
    {
        Tuple r;
        r.u = -1, r.v = -1, r.po = -1;
        return r;
    }
    return heap[0];
}
bool MinHeap::isEmpty() 
{
    return heap.size() == 0;
}
const int SIZE = 2e3;
long long powers[SIZE];
vector<long long> graph[SIZE];
long long ans = 0;
long long p = 0;
MinHeap heap;
bool visited[SIZE];
void calculatePowerSum() 
{
    if (heap.isEmpty()) 
        return;
    while (!heap.isEmpty()) 
    {
        auto top = heap.pop();
        auto parent = top.u;
        if (visited[parent]) 
            continue;
        visited[parent] = true;
        if (powers[parent] >= p && top.v != -1) 
        {
            ans += (powers[parent] - p + 1);
            p = powers[parent] + 1;
        }
        p += powers[parent];
        for (auto child : graph[parent]) 
        {
            if (!visited[child]) 
            {
                Tuple r;
                r.v = parent;
                r.u = child;
                r.po = powers[r.u];
                heap.push(r);
            }
        }
    }
}
int main() 
{
    long long n, m;
    cin >> n >> m;
    for (int i = 0; i < n; i++) 
        cin >> powers[i];
    for (int i = 0; i < m; i++) 
    {
        long long u, v;
        cin >> v >> u;
        u--, v--;
        graph[u].push_back(v);
        graph[v].push_back(u);
    }
    for (int v = 0; v < n; v++) 
    {
        ans = 0;
        p = 0;
        Tuple r;
        r.v = -1;
        r.u = v;
        r.po = -1;
        heap.push(r);
        calculatePowerSum();
        heap.clear();
        fill(visited, visited + n, false);
        cout << ans << " ";
    }
    cout << "\n";
    return 0;
}
