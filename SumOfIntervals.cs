namespace SumOfIntervals;

/*
題目描述
給定一個整數陣列 Array，請計算該陣列在每個指定區間內的元素總和。

輸入描述
第一行輸入為整數陣列 Array 的長度 n，接下來的 n 行，每行輸入一個整數，表示陣列的元素。之後的輸入為需要計算總和的區間，直到文件結束。

範例
輸入：
5
1
2
3
4
5
0 1
1 3
輸出：
3
9
*/
class Solution {
  public static void SumOfIntervals() {
    int n = int.Parse(Console.ReadLine() ?? "0");
    int[] array = [n];
    int[] prefixSum = [n + 1];
    for (int i = 0; i < n; i++) {
      array[i] = int.Parse(Console.ReadLine() ?? "0");
      prefixSum[i + 1] = prefixSum[i] + array[i];
    }
    string line;
    while ((line = Console.ReadLine() ?? string.Empty) != string.Empty) {
      string[] parts = line.Split();
      int a = int.Parse(parts[0]);
      int b = int.Parse(parts[1]);
      int sum = prefixSum[b + 1] - prefixSum[a];
      Console.WriteLine(sum);
    }
  }
}