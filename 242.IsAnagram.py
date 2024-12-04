class Solution:
    def isAnagram(self, s, t):  # *適用 unicode
        hashtable = {}
        for char in s:
            hashtable[char] = hashtable.get(char, 0) + 1
        for char in t:
            hashtable[char] = hashtable.get(char, 0) - 1
        for value in hashtable.values():
            if value != 0:
                return False
        return True

    def isAnagram2(self, s: str, t: str) -> bool:
        if len(s) != len(t):
            return False
        record = [0] * 26  # * 固定 list 空間利用更好
        for char in s:
            record[
                ord(char) - ord("a")
            ] += 1  # *使用 ord(char) 來將字元轉換為其 ASCII 值, 這與 C# 不同， C# 可以直接 char c = 'c' int index = c - 'a'
        for char in t:
            record[ord(char) - ord("a")] -= 1
        for value in record:
            if value != 0:
                return False
        return True
