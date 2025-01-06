class Solution:
    def happyNumber(self, number: int) -> bool:
        allSum = {}
        while number != 1:
            current_sum = 0
            while number > 0:
                digit = number % 10
                current_sum += digit**2
                number //= 10
            number = current_sum
            if number in allSum:
                return False
            else:
                allSum[number] = 1
        return True
