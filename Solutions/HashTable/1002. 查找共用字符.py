class Solution:
    def commonChars(self, words: list[str]) -> list[str]:
        # only need word appears in first element
        hash_counts = {}
        for c in words[0]:
            hash_counts[c] = hash_counts.get(c, 0) + 1
        for word in words[1:]:
            hash_other = {}
            for c in word:
                hash_other[c] = hash_other.get(c, 0) + 1
            for key in list(hash_counts.keys()):  # 避免修改字典出錯
                if key in hash_other:
                    hash_counts[key] = min(
                        hash_counts[key], hash_other[key]
                    )  # 為了同一個字有兩個相同字母，確定最少幾次
                else:
                    del hash_counts[key]  ##其他字沒出現的，原始刪掉
        result = []
        for char, count in hash_counts.items():
            result.extend([char] * count)
        return result
