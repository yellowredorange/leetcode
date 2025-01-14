from typing import List


class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        nums.sort()
        answer = []  ##拋下set，直接精準去除重複
        for i in range(len(nums)):
            if i > 0 and nums[i - 1] == nums[i]:  # (0,0,0) exception
                continue
            if nums[i] > 0:
                break  ##不可能了，直接斷
            left = i + 1
            right = len(nums) - 1
            while left < right:
                total = nums[i] + nums[left] + nums[right]
                if total > 0:
                    right -= 1
                elif total < 0:
                    left += 1
                else:
                    answer.append([nums[i], nums[left], nums[right]])
                    ## 因為這組是正解，所以下方left+1後，right跟i沒變，肯定也不是正解
                    while left < right and nums[left] == nums[left + 1]:
                        left += 1
                    while left < right and nums[right] == nums[right - 1]:
                        right -= 1
                    ## 當nums[left] != nums[left + 1]跳出迴圈,left仍是上一個數
                    left += 1
                    right -= 1
        return answer

    def threeSumVisual(self, nums: List[int]) -> List[List[int]]:
        nums.sort()  # 排序
        print(f"排序後的 nums: {nums}")
        answer = []  # 存放結果
        for i in range(len(nums)):
            if i > 0 and nums[i] == nums[i - 1]:
                print(f"跳過重複的 nums[i]: {nums[i]} at index {i}")
                continue
            if nums[i] > 0:
                print(f"nums[i] 大於 0，後續無法再找到答案，結束迴圈")
                break
            left = i + 1
            right = len(nums) - 1
            print(f"\n固定 a = nums[i]: {nums[i]} at index {i}")
            while left < right:
                total = nums[i] + nums[left] + nums[right]
                print(
                    f"檢查組合: a={nums[i]}, b={nums[left]}, c={nums[right]} (total={total})"
                )
                if total > 0:
                    print(f"總和大於 0，右指針左移")
                    right -= 1
                elif total < 0:
                    print(f"總和小於 0，左指針右移")
                    left += 1
                else:
                    print(f"找到答案: [{nums[i]}, {nums[left]}, {nums[right]}]")
                    answer.append([nums[i], nums[left], nums[right]])
                    while left < right and nums[left] == nums[left + 1]:
                        left += 1
                        print(f"跳過重複的 b: {nums[left]} at index {left}")
                    while left < right and nums[right] == nums[right - 1]:
                        right -= 1
                        print(f"跳過重複的 c: {nums[right]} at index {right}")
                    left += 1
                    right -= 1
        print(f"\n結果: {answer}")
        return answer


# 測試用例
solution = Solution()
solution.threeSumVisual([-1, 0, 1, 2, -1, -4])
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
