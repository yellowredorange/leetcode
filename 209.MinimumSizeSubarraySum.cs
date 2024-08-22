namespace MinimumSizeSubarraySum;

//* 這題的要求是你必須維持原本 array 的樣態，並且給出大於等於 target 又是子序列是最小長度，所以才會有所謂的滑動窗口法，像是指針一樣滑動指著子序列的頭與尾，第一個寫法是我誤會意思的寫法，我以為可以排列後，要找到剛剛好等於 target 的最小長度, 因為我由大到小去找，所以一定第一個找到的便是最小長度。或許是貪心算法（Greedy Algorithm）的應用。貪心算法的基本思想是每一步都選擇當前看起來最好的選擇（以此例來說就是從最大的數字開始），以期望最終得到全局最優解。
public class Solution {
  public int MinSubArrayLen(int target, int[] nums) {
    Array.Sort(nums);  // 先進行排序

    for (int i = nums.Length - 1; i >= 0; i--) {
      int left = target;
      List<int> arr = [];
      left -= nums[i];
      if (left < 0) {
        continue;
      } else {
        arr.Add(nums[i]);
        for (int j = i - 1; j >= 0; j--) {
          if ((left - nums[j]) < 0) {
            continue;
          } else if ((left - nums[j]) == 0) {
            arr.Add(nums[j]);
            return arr.Count;  // 找到第一個符合條件的子陣列並返回其長度
          } else {
            arr.Add(nums[j]);
            left -= nums[j];
          }
        }
      }
    }
    return 0;  // 如果沒有找到符合條件的子陣列，返回0
  }
}

public class Solution2 {
  public int MinSubArrayLen(int target, int[] nums) {
    int result = int.MaxValue;
    int sum = 0;
    int left = 0;
    for (int right = 0; right < nums.Length; right++) {
      sum += nums[right];
      while (sum >= target) {
        int subLength = right - left + 1;
        result = result < subLength ? result : subLength;
        sum -= nums[left++]; //*滑動窗口，把left目前所指的數字剪掉，將left+1後成為新的範圍。同時不斷的減去左邊的範圍，看能不能在大於等於target的情況下獲取更短的子序列長度。
      }
    }
    return result == int.MaxValue ? 0 : result;
  }
}

