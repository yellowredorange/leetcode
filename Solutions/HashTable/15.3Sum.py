from typing import List


class Solution:
    # def threeSum(self, nums: List[int]) -> List[List[int]]:
    #     two_nums = {}
    #     answer = set()
    #     for i in range(len(nums)):
    #         for y in range(len(nums)):
    #             plus = nums[i] + nums[y]
    #             if two_nums.get(plus, 0) == 0:
    #                 two_nums[plus] = set()
    #             if (i, y) not in two_nums[plus]:
    #                 two_nums[plus].add((i, y))
    #     for i in range(len(nums)):
    #         need = -nums[i]
    #         if need in two_nums:
    #             for tuple in two_nums[need]:
    #                 answer.add(tuple)
