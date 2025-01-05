namespace SpiralMatrixII;
public class Solution {
  public int[][] GenerateMatrix(int n) {
    int[][] matrix = new int[n][];
    for (int i = 0; i < n; i++) {
      matrix[i] = new int[n];
    }
    //*這樣子設計陣列是有一個一維陣列，每一個陣列裡面再放n個長度的陣列。這和 int[,]=new int[n,n]不一樣。前者是交錯陣列，子陣列可以有不同的大小。後者是直接設計一個矩形陣列，連續分佈的。
    int times = n;
    int x = 0;
    int y = -1;//*這裡比較弔詭一點，最根本的原因是因為我的算法是算前進的步數，但這樣迴圈裡面 0,0 會沒有設定到 1。我原本將 x,y 都設為 0，然後再加完數字以後再++，但是這會導致迴圈跑到極限以後，雖然中止迴圈圈了，但會++留到下一個方向，所以必須將y++放到加數字以前，因此這裡乾脆直接先設定 -1。另一個解法就是乾脆一開始 0,0 就設定賦值為 1，第一次移動的時候迴圈少加一次。
    int number = 0;
    //*第一次 往右 n 格並且只持續一次
    for (int i = 0; i < times; i++) {
      y++;
      number++;
      Console.WriteLine(y);
      matrix[x][y] = number;
    }
    times--;
    while (true) //*接下來每個按下左上右輪流 重複同個格數兩次後格數-1
    {
      if (times == 0) {
        break;
      }
      //*下
      for (int i = 0; i < times; i++) {
        x++;
        number++;
        matrix[x][y] = number;
      }
      //*左
      for (int i = 0; i < times; i++) {
        y--;
        number++;
        matrix[x][y] = number;
      }
      times--;
      if (times == 0) {
        break;
      }
      //*上
      for (int i = 0; i < times; i++) {
        number++;
        x--;
        matrix[x][y] = number;
      }
      //*右
      for (int i = 0; i < times; i++) {
        number++;
        y++;
        matrix[x][y] = number;
      }
      times--;
    }
    return matrix;
  }

  public void PrintMatrix(int[][] matrix) {
    for (int i = 0; i < matrix.Length; i++) {
      for (int j = 0; j < matrix[i].Length; j++) {
        Console.Write(matrix[i][j].ToString().PadLeft(3) + " ");
      }
      Console.WriteLine();
    }
  }
}


//* 以上這是我的看法，但有些人的眼中認為可以拆分為每一圈
// 1  2 3 4
// 12     5
// 11     6
// 10 9 8 7
//* 另用一圈一圈的方式去填充，例如123 456 789 101112 這樣每一個迴圈跑得層數都一樣 只需要控制 start 和 end
//* 只需要特別注意奇數時 中心要額外填入

public class Solution2 {
  public int[][] GenerateMatrix(int n) {
    int[][] answer = new int[n][];
    for (int i = 0; i < n; i++)
      answer[i] = new int[n];
    int start = 0;
    int end = n - 1;
    int tmp = 1;
    while (tmp < n * n) {
      for (int i = start; i < end; i++) answer[start][i] = tmp++;
      for (int i = start; i < end; i++) answer[i][end] = tmp++;
      for (int i = end; i > start; i--) answer[end][i] = tmp++;
      for (int i = end; i > start; i--) answer[i][start] = tmp++;
      start++;
      end--;
    }
    if (n % 2 == 1) answer[n / 2][n / 2] = tmp;
    return answer;
  }
}

