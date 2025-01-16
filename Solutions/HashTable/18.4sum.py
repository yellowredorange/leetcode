from typing import List


class Solution:
    def fourSum(self, nums: List[int], target: int) -> List[List[int]]:
        nums.sort()
        answer = []
        for i in range(len(nums) - 3):
            if i > 0 and nums[i - 1] == nums[i]:
                continue
            # if target <= 0 and nums[i] > 0: 這條件是錯的，因為有可能，target<0，前面負的，後面正的加完後變target
            #     continue
            for j in range(i + 1, len(nums) - 2):
                if (
                    j > i + 1 and nums[j - 1] == nums[j]
                ):  # j>i+1的理由和i>0一樣，一樣的數字第一次應該要給個機會
                    continue
                # if nums[i] + nums[j] > target:這條件是錯的，因為有可能，targe是-10，-3,-2,-2...一路加完後變target
                #     continue
                left = j + 1
                right = len(nums) - 1
                while left < right:
                    if nums[i] + nums[j] + nums[left] + nums[right] > target:
                        right -= 1
                    elif nums[i] + nums[j] + nums[left] + nums[right] < target:
                        left += 1
                    else:
                        answer.append([nums[i], nums[j], nums[left], nums[right]])
                        while left < right and nums[left] == nums[left + 1]:
                            left += 1
                        while left < right and nums[right] == nums[right - 1]:
                            right -= 1
                        left += 1
                        right -= 1
        return answer
