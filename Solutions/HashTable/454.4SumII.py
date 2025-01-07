from typing import List


class Solution:
    def fourSumCount(
        self, nums1: List[int], nums2: List[int], nums3: List[int], nums4: List[int]
    ) -> int:
        two_sum1 = (
            {}
        )  # key: sum of num1 and num 2, value: same pair counts, like 2+1 = 1+2
        two_sum2 = {}
        allCombination = 0
        for num1 in nums1:
            for num2 in nums2:
                if num1 + num2 in two_sum1:
                    two_sum1[num1 + num2] += 1
                else:
                    two_sum1[num1 + num2] = 1
        for num3 in nums3:
            for num4 in nums4:
                if num3 + num4 in two_sum2:
                    two_sum2[num3 + num4] += 1
                else:
                    two_sum2[num3 + num4] = 1
        for sum1 in two_sum1:
            for sum2 in two_sum2:
                if sum1 + sum2 == 0:
                    allCombination += two_sum1[sum1] * two_sum2[sum2]
        return allCombination
