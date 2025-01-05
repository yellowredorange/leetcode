namespace LandPurchase;

/*
In a city area, the land is divided into n * m contiguous blocks, and each block has a different value representing its land value. Currently, two development companies, Company A and Company B, are interested in purchasing this city's land.

You are required to allocate all blocks in this city area to either Company A or Company B.

However, due to urban planning restrictions, the area can only be divided into two subareas either horizontally or vertically, and each subarea must contain one or more blocks.

To ensure fair competition, you need to find a way to allocate the blocks so that the difference in the total land value between the subareas assigned to Company A and Company B is minimized.

Note: The blocks cannot be further subdivided.

[Input Description]

The first line contains two positive integers representing n and m.

The next n lines each contain m positive integers representing the land values of the blocks.

[Output Description]

Output a single integer representing the minimum difference between the total land values of the two subareas.

[Input Example]

3 3
1 2 3
2 1 3
1 2 3
[Output Example]

0
[Hint]

If you divide the area as follows:

1 2 | 3
2 1 | 3
1 2 | 3
The difference in total land values between the two subareas can be minimized to 0.

[Constraints]

1 <= n, m <= 100;
n and m are not simultaneously equal to 1.
*/
class Solution {
  public void LandPurchase() {
    string[] dimensions = Console.ReadLine().Split();
    int n = int.Parse(dimensions[0]); //共有幾列(lines)
    int m = int.Parse(dimensions[1]);
    int[,] grid = new int[n, m];
    int[] prefixSumHorizontal = new int[n + 1];
    int[] prefixSumVertical = new int[m + 1];
    //*先把輸入的資料建成矩陣
    for (int i = 0; i < n; i++) {
      string[] values = Console.ReadLine().Split();
      for (int j = 0; j < m; j++) {
        grid[i, j] = int.Parse(values[j]);
      }
    }
    // 計算每一行的 prefix，因為每次固定一個 x 軸，累加起來，所以是 horizontal，因為目前有 n 個 x 軸可選所以是 n 的長度。
    for (int x = 0; x < n; x++) {
      int horSum = 0;
      for (int y = 0; y < m; y++) {
        horSum += grid[x, y];
      }
      prefixSumHorizontal[x + 1] = prefixSumHorizontal[x] + horSum;
    }
    // 計算每一行的 prefix，因為每次固定一個 y 軸，累加起來，所以是 vertical，因為目前有 m 個 y 軸可選所以是 m 的長度。
    for (int y = 0; y < m; y++) {
      int verSum = 0;
      for (int x = 0; x < n; x++) {
        verSum += grid[x, y];
      }
      prefixSumVertical[y + 1] = prefixSumVertical[y] + verSum;
    }
    int totalSum = prefixSumVertical[m];
    int result = int.MaxValue;
    //縱向劃分
    for (int i = 1; i < m; i++)//以劃分的概念來說，01234，5個元素其實能劃分的只有4條，再放上累加的概念，0(第一個恆為0) 0 1 3 6 10，第一個0捨棄因不是劃分的點，最後一個10也捨棄他也不是劃分點。
    {
      int upperPart = prefixSumVertical[i];
      int lowerPart = totalSum - upperPart;
      result = Math.Min(result, Math.Abs(upperPart - lowerPart));
    }
    //橫向劃分
    for (int i = 0; i < n; i++) {
      int upperPart = prefixSumHorizontal[i];
      int lowerPart = totalSum - upperPart;
      result = Math.Min(result, Math.Abs(upperPart - lowerPart));
    }
    Console.WriteLine(result);
  }
}