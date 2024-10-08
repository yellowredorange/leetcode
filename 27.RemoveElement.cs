namespace RemoveElement;
public class Solution {
  public int RemoveElement(int[] nums, int val) {
    int slow = 0;
    for (int fast = 0; fast < nums.Length; fast++) {
      if (nums[fast] != val) //* 當非 val 的值的時候我們會選擇保留，slow 才會增加
      {
        nums[slow] = nums[fast];
        slow++;
      }
      //* 當遇到 val 值的時候，slow 不會增加，並且要跳到 val 值的下一個，才會做 swap
      /* 舉例 如果為 2 的話
      初始狀態：
        nums = {4, 2, 3, 2, 5, 2, 6, 2, 7, 8, 2, 9}
        第一次有效替換（第 3 次迭代）：
        slow 還停在 2 的位子所以換成 3
        nums = {4, 3, 3, 2, 5, 2, 6, 2, 7, 8, 2, 9}
        第二次有效替換（第 5 次迭代）：
        slow 停在 第二個 3 的位子所以換成 5
        nums = {4, 3, 5, 2, 5, 2, 6, 2, 7, 8, 2, 9}
        第三次有效替換（第 7 次迭代後）：
        nums = {4, 3, 5, 6, 5, 2, 6, 2, 7, 8, 2, 9}
        第四次有效替換（第 9 次迭代後）：
        nums = {4, 3, 5, 6, 7, 2, 6, 2, 7, 8, 2, 9}
        第五次有效替換（第 10 次迭代後）：
        nums = {4, 3, 5, 6, 7, 8, 6, 2, 7, 8, 2, 9}
        第六次有效替換（第 12 次迭代後）：
        nums = {4, 3, 5, 6, 7, 8, 9, 2, 7, 8, 2, 9}
        當遇到 2 的時候，slow 會停止下來，等到遇到下一次不是 2 的數字就會複製到 slow 的位子上，不是 swap 的概念，slow 的總數就是不是 2 的數字有幾個，所以會保留正確的位子數給後面的數字，可以發現第六次替換是 9 替換到 6 的位子，這個 6 是之前複製後留下來的原本的 6，剩餘的 2 7 8 2 9 都是被複製的數字，所以後半段都不重要，2 會消失一些，但也跟 2 的消失無關，而是總數跟保留的數字有關。
      */
    }
    return slow;
  }
}