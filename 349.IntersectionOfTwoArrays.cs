using System;
using System.Collections.Generic;

namespace IntersectionOfTwoArrays;
public class Solution {
  public int[] Intersection(int[] nums1, int[] nums2) {
    HashSet > set1 = new HashSet<int>(nums1);
    HashSet<int> set2 = new HashSet<int>(nums2);
    set1.IntersectWith(set2);
    return set1.ToArray();
  }
}