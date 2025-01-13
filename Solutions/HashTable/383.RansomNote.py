class Solution:
    def canConstruct(self, ransomNote: str, magazine: str) -> bool:
        material = {}
        for m in magazine:
            material[m] = material.get(m, 0) + 1
        for r in ransomNote:
            material[r] = material.get(r, 0) - 1
            if material[r] < 0:
                return False
        return True
