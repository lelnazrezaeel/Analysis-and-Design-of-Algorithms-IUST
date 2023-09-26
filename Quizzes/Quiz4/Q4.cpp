#include <iostream>
#include <vector>
#include <queue>
using namespace std;

int findSmallestDistanceNode(vector<int>& edges, int node1, int node2) {
    int n = edges.size();
    vector<int> indegrees(n, 0);
    vector<int> distances(n, -1); // initialize all distances to -1
    queue<int> q;

    // calculate indegrees for each node
    for (int i = 0; i < n; i++) {
        if (edges[i] != -1) {
            indegrees[edges[i]]++;
        }
    }

    // add all nodes with zero indegree to the queue
    for (int i = 0; i < n; i++) {
        if (indegrees[i] == 0) {
            q.push(i);
            distances[i] = 0; // distance of each node to itself is 0
        }
    }

    // perform a BFS starting from nodes with zero indegree
    while (!q.empty()) {
        int node = q.front();
        q.pop();

        if (node == node1 && distances[node2] != -1) {
            return node; // found an answer, return it
        }
        if (node == node2 && distances[node1] != -1) {
            return node; // found an answer, return it
        }

        int next = edges[node];
        if (next != -1) {
            distances[next] = max(distances[next], distances[node] + 1);
            indegrees[next]--;
            if (indegrees[next] == 0) {
                q.push(next);
            }
        }
    }

    return -1; // no answer found
}

int main() {
    // example usage
    vector<int> edges = {2, 2, 3, -1};
    int node1 = 0;
    int node2 = 1;
    cout << findSmallestDistanceNode(edges, node1, node2) << endl; // expected output: 2

    edges = {1, 2, -1};
    node1 = 0;
    node2 = 2;
    cout << findSmallestDistanceNode(edges, node1, node2) << endl; // expected output: 2

    return 0;
}
