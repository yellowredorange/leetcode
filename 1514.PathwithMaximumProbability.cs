// namespace PathwithMaximumProbability;
// public class Solution {
//     public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) {
//         List<int>? route = [];
//         route = Search(edges, start_node, end_node, route);
//         if (route == null) {
//             return 0;
//         }
//         route
//     }
//     public List<int>? Search(int[][] edges, int start_node, int end_node, List<int> route) {
//         for (int i = 0; i < edges.Length; i++) {
//             for (int y = 0; y < 2; y++) {
//                 if (route.Contains(edges[i][y])) {
//                     continue;
//                 }
//                 if (start_node == edges[i][y]) {
//                     route.Add(edges[i][y]);
//                     int next = 0;
//                     if (y == 0) {
//                         next = 1;
//                     } else {
//                         next = 0;
//                     }
//                     if (edges[i][next] == end_node) {
//                         return route;
//                     } else {
//                         return Search(edges, edges[i][next], end_node, route);
//                     }

//                 }
//             }
//         }
//         return null;
//     }
// }