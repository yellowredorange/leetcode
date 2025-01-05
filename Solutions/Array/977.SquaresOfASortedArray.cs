namespace SquaresOfASortedArray;
public class Solution {
  public int[] SortedSquares(int[] nums) {
    int left = 0;
    int right = nums.Length - 1;
    int[] sortedSquares = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++) {
      if (nums[left] * nums[left] >= nums[right] * nums[right]) {
        sortedSquares[nums.Length - 1 - i] = nums[left] * nums[left];
        left += 1;
      } else {
        sortedSquares[nums.Length - 1 - i] = nums[right] * nums[right];
        right -= 1;
      }
    }
    return sortedSquares;
  }
}

//更簡便的寫法
public class Solution2 {
  public int[] SortedSquares(int[] nums) {
    int k = nums.Length - 1;
    int[] result = new int[nums.Length];
    for (int i = 0, j = nums.Length - 1; j >= i;)//* 不標準 for 迴圈寫法，for 可以塞超多東西都沒問題，只是得注意是逗號不是分號
    //* 第一個放變數;第二個中斷前條件;第三個放遞增，這是標準習慣而不是一定得這樣寫
     {
      if (nums[i] * nums[i] < nums[j] * nums[j]) {
        result[k--] = nums[j] * nums[j]; //在這一行被使用後 k 才會--
        j--;
      } else {
        result[k--] = nums[i] * nums[i];
        i++;
      }
    }
    return result;
  }
}