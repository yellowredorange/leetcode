from typing import List


class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        history = {}
        for i in range(len(nums)):
            if (target - nums[i]) in history:
                return [history[target - nums[i]], i]
            history[nums[i]] = i
