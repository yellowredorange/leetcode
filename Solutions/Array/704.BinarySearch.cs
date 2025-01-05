namespace BinarySearch;
public class Solution {
  public int Search(int[] nums, int target) {
    //*左閉右閉區間 [left, right]：

    //* left 和 right 都是包含在搜尋範圍內的，這意味著在迴圈內會檢查 left 和 right 兩個邊界所對應的元素。
    int left = 0;
    int right = nums.Length - 1; //*最後一個元素
    while (left <= right) //*這確保 left 和 right 相等時仍然會檢查最後一個元素。
    {
      int mid = left + (right - left) / 2; //*避免相加厚超過int最大值
      if (nums[mid] == target) {
        return mid;
      } else if (nums[mid] < target) {
        left = mid + 1;
      } else {
        right = mid - 1;
      }
    }
    return -1;
  }
}

public class Solution2 {
  public int Search(int[] nums, int target) {
    //*左閉右開區間 [left, right)：
    //* 搜尋範圍包含 left，但不包含 right，這意味著在每次迴圈中，right 不會是檢查範圍，因此當 left 和 right 相等時，迴圈結束。
    int left = 0;
    int right = nums.Length; //*表示範圍超出最後一個索引一個單位。
    while (left < right) //*當 left 和 right 相等時，迴圈結束，因為 right 本身不屬於搜尋範圍。
    {
      int mid = left + (right - left) / 2;
      if (nums[mid] == target) {
        return mid;
      } else if (nums[mid] < target) {
        left = mid + 1;
      } else {
        right = mid; //* 因為是開合區間，所以不必像 left 需要 +1 去排除掉，可以讓他為 mid。
      }
    }
    return -1;
  }
}