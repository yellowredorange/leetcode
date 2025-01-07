from typing import List


class Solution:
    def intersection(self, nums1: List[int], nums2: List[int]) -> List[int]:
        set1 = set(nums1)
        set2 = set(nums2)
        # set is O1 average time complexity for lookups
        result = []
        for num in set1:
            if num in set2:
                result.append(num)
        return result
