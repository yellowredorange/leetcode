class Solution(object):
    def isAnagram(self, s, t):
        myDict = {}
        for c in s:
            if c in myDict:
                myDict[c] += 1
            else:
                myDict[c] = 1
        for c in t:
            if c in myDict:
                myDict[c] -= 1
            else:
                return False
        for c in myDict:
            if myDict[c] != 0:
                return False
        return True
