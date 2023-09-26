#include <iostream>
#include <vector>
#include <algorithm>
#include <cstring>
#include <climits>
using namespace std;
const int SIZE = 1000;
void FindShortestPath(int n, vector<int> adj[], int time[][SIZE]) 
{
    int parent[SIZE];
    int distances[SIZE];
    for (int j = 0; j < n; j++) 
    {
        parent[j] = -1;
        distances[j] = INT_MAX;
    }
    distances[0] = 0;
    for (int j = 0; j < n - 1; j++) 
    {
        for (int k = 0; k < n; k++) 
        {
            for (int l = 0; l < adj[k].size(); l++) 
            {
                int edge = adj[k][l];
                if (distances[edge] - time[k][edge] > distances[k]) 
                {
                    distances[edge] = distances[k] + time[k][edge];
                    parent[edge] = k;
                }
            }
        }
    }
    bool flag = false;
    int i = 0;
    for (; i < n; i++) {
        for (int l = 0; l < adj[i].size(); l++) 
        {
            int edge = adj[i][l];
            if (distances[edge] - time[i][edge] > distances[i]) 
            {
                flag= true;
                break;
            }
        }
        if (flag) 
        {
            break;
        }
    }
    if (!flag) 
    {
        cout << -1 << endl;
    }
    else 
    {
        string cycle = "";
        int t = i;
        do 
        {
            cycle += to_string(t) + " ";
            t = parent[t];
        } while (t != i);
        cycle += to_string(i);
        vector<int> output;
        char* p = strtok((char*)cycle.c_str(), " ");
        while (p != NULL) 
        {
            output.push_back(stoi(p));
            p = strtok(NULL, " ");
        }
        for (int j = output.size() - 1; j >= 0; j--) 
        {
            cout << output[j] << " ";
        }
        cout << endl;
    }
}

int main() 
{
    int n, e;
    cin >> n >> e;
    vector<int> adj[SIZE];
    int time[SIZE][SIZE];
    memset(time, 0, sizeof(time));
    for (int i = 0; i < e; i++) 
    {
        int u, v, w;
        cin >> u >> v >> w;
        adj[u].push_back(v);
        time[u][v] = w;
    }
    FindShortestPath(n, adj, time);
    return 0;
}